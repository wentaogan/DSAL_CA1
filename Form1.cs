using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experiment_DSAL_assignment_1.Classes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;

namespace Experiment_DSAL_assignment_1
{
    public partial class Form1 : Form
    {
        // Class scope SeatManager type object
        SeatManager seatManager;

        private enum BookState
        {
            Start,
            Booking,
            Load,
            Editor,
            End
        }
        private BookState bookState;

        private enum EditorState
        {
            None,
            Enable,
            Disable
        }
        private EditorState editorState = EditorState.None;

        private int _numRow, _seatPerRow; // track num of row and seat per row enter by user
        private int _maxSeats; // track num of max Seats user enter

        private Person _currentPerson = null;

        private List<Label> _seatLabels = new List<Label>(); // to hold all seat label
        private List<Label> _personLabels = new List<Label>(); // to hold all the person

        private UndoActionLog _undoActionLog = new UndoActionLog();
        private RedoActionLog _redoActionLog = new RedoActionLog();
        public Form1()
        {
            InitializeComponent();
            // input validation
            TextNumRow.KeyPress += TextNumRowCol_KeyPress;
            TextSeatPerRow.KeyPress += TextNumRowCol_KeyPress;
            TextColDiv.KeyPress += TextDivider_KeyPress;
            TextRowDiv.KeyPress += TextDivider_KeyPress;
            TextMaxSeats.KeyPress += TextNumRowCol_KeyPress;

            // add list item into maxSeat drop down list
            comboBoxPersonNo.Items.Add("1");
            comboBoxPersonNo.Items.Add("2");
            comboBoxPersonNo.Items.Add("3");
            comboBoxPersonNo.Items.Add("4");
            comboBoxPersonNo.Items.Add("5");
            comboBoxPersonNo.Items.Add("6");
            comboBoxPersonNo.Items.Add("7");
            comboBoxPersonNo.Items.Add("8");

            // Set an initial selected item (optional)
            comboBoxPersonNo.SelectedIndex = 0;

            // Attach an event handler for selection change (optional)
            comboBoxPersonNo.SelectedIndexChanged += ComboBoxPersonNo_SelectedIndexChanged;
            seatManager = new SeatManager();
        }// end of Form1



        private void UpdateLabel()
        {
            if (bookState == BookState.Load) // when user click on the load button
            {
                bookState = BookState.Start;
                foreach (Label seatLabel in _seatLabels)
                {
                    Seat seat = (Seat)seatLabel.Tag;
                    // set current person book seat to current person select color
                    if (seat.IAmBooked)
                    {
                        seatLabel.BackColor = _currentPerson.SelectColor;
                    }
                    // set booked seat color to the specify person color
                    else if (seat.IAmBookedBy != "")
                    {
                        foreach (Label personLabel in _personLabels)
                        {
                            Person person = (Person)personLabel.Tag;
                            if (person.Name == seat.IAmBookedBy)
                            {
                                seatLabel.BackColor = person.SelectColor;
                            }
                        }
                    }
                    // set disabled seat color to purple
                    else if (!seat.status)
                    {
                        seatLabel.BackColor = Color.Purple;
                    }
                    // set other non booked seat and not selected by current person seat color
                    else
                    {
                        seatLabel.BackColor = Color.LightCyan;
                    }
                }
            }
            else if (_currentPerson != null) // when user is booking for second person
            {
                bookState = BookState.Booking;
                // foreach loop to check the final selected seat select by user.
                // change the color, disable the label and set the IAmBookeBy attribute to the last person
                foreach (Label seatLabel in _seatLabels)
                {
                    Seat seat = (Seat)seatLabel.Tag;
                    // set current person book seat to current person select color
                    if (seat.IAmBooked)
                    {
                        seat.IAmBooked = false;
                        seat.IAmBookedBy = _currentPerson.Name.ToString();
                        seatLabel.BackColor = _currentPerson.SelectColor;
                        seatLabel.Enabled = false;
                    }
                    // target for disabled seats
                    else if (!seat.status)
                    {
                        seatLabel.BackColor = Color.Purple;
                    }
                    // target for unselected and enabled seats
                    else if (seat.IAmBookedBy == "" && seat.status)
                    {
                        seatLabel.BackColor = Color.LightCyan;
                        seatLabel.Enabled = true;
                    }
                }
                // reset the redo and undo action list
                _redoActionLog.Start = null;
                _redoActionLog.Current = null;
                _undoActionLog.Current = null;
                _undoActionLog.Start = null;
                ButtonUndo.Enabled = true;
            }
            // Start - when user click on the person label (first person)
            //       - when user click on enter editor mode go into editor bookstate
            //       - when user exit editor mode is go into Start bookState
            else if (bookState == BookState.Start || bookState == BookState.Editor)
            {
                foreach (Label seatLabel in _seatLabels)
                {
                    Seat seat = (Seat)seatLabel.Tag;
                    if (seat.status)
                    {
                        seatLabel.BackColor = Color.LightCyan;
                    }
                    else
                    {
                        seatLabel.BackColor = Color.Purple;
                    }
                    seatLabel.Enabled = true;
                }
            }
            else if (bookState == BookState.End) // when user click on the ResetSimulationButton
            {
                foreach (Label seatLabel in _seatLabels)
                {
                    Seat seat = (Seat)seatLabel.Tag;
                    seatLabel.BackColor = Color.Purple;
                    seat.status = true;
                    seatLabel.Enabled = true;
                    seat.IAmBooked = false;
                    seat.IAmBookedBy = "";
                }
                // reset the undo and redo action list
                _redoActionLog.Start = null;
                _redoActionLog.Current = null;
                _undoActionLog.Current = null;
                _undoActionLog.Start = null;
                //ButtonUndo.Enabled = true;
            }
        }// end of UpdateLabel()

        private void LabelSeat_Click(object sender, EventArgs e)
        {
            // check whether user already end the simulation 
            if (bookState == BookState.End)
            {
                MessageBox.Show("You already end the simulation mode");
                return;
            }
            // make sure user select a person first before click on the seat label
            if (_currentPerson == null && bookState != BookState.Editor)
            {
                MessageBox.Show("Please select a person first");
                return;
            }
            if (TextMaxSeats.Text != "")
            {
                _currentPerson.MaxSeat = int.Parse(TextMaxSeats.Text);
            }
            Label seatLabel = (Label)sender;
            Seat seat = (Seat)seatLabel.Tag;
            if (editorState == EditorState.Enable)
            {
                seat.status = true;
                seatLabel.BackColor = Color.LightCyan;
            }
            else if (editorState == EditorState.Disable)
            {
                seat.status = false;
                seatLabel.BackColor = Color.Purple;
            }
            else
            {
                if (int.TryParse(TextMaxSeats.Text, out int intMaxSeats))
                {
                    if (intMaxSeats == 0)
                    {
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    else
                    {
                        TextMaxSeats.Enabled = false;
                        _maxSeats = intMaxSeats;
                    }
                    if (seat.status) // check the status of seat (disable/enable)
                    {
                        if (seat.IAmBooked) // check booked seat
                        {
                            if (CheckAvailabilityToUnBook(seat))
                            {
                                // record the seat's row and col and IAmBooked selected by user 
                                _undoActionLog.RecordAction(seat.RowNumber, seat.ColumnNumber, seat.IAmBooked);
                                ButtonUndo.Enabled = true;
                                ButtonRedo.Enabled = false;
                                // when user perform new action on seat label, reset the redoActionLog
                                _redoActionLog.Start = null;
                                _redoActionLog.Current = null;
                                seat.IAmBooked = false;
                            }
                        }
                        else // check unbook seat
                        {
                            // Check whether is exceed the maxSeats
                            // Check is there a person at left and right by CheckPersonBeside
                            // Check is the seat selected is adjacent with the seat already select previouly
                            if (CheckAvailabilityToBook(seat))
                            {
                                // record the seat's row and col and IAmBooked selected by user 
                                _undoActionLog.RecordAction(seat.RowNumber, seat.ColumnNumber, seat.IAmBooked);
                                ButtonUndo.Enabled = true;
                                ButtonRedo.Enabled = false;
                                // when user perform new action on seat label, reset the redoActionLog
                                _redoActionLog.Start = null;
                                _redoActionLog.Current = null;
                                seat.MyLabel.BackColor = _currentPerson.SelectColor;
                                seat.IAmBooked = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seat is Disable.");
                    }
                }
                else
                {
                    MessageBox.Show("Please set a maximum number of seats first");
                }
            }
        }//end of labelSeat_Click


        // retrieve the seat at the left and right of the selected seat
        // check both IAmBookedBy
        // return true if there is no person beside
        private bool CheckPersonBeside(Seat selectedSeat)
        {
            Seat leftSeat = seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber - 1);
            Seat rightSeat = seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber + 1);
            // check if the seat is having right and left seat
            if (leftSeat != null && rightSeat != null)
            {
                if (leftSeat.IAmBookedBy == "" && rightSeat.IAmBookedBy == "")
                {
                    return true;
                }
            }
            // check if the seat is at the most left
            else if (rightSeat != null)
            {
                if (rightSeat.IAmBookedBy == "")
                {
                    return true;
                }
            }
            // check if the seat is at the most right
            else if (leftSeat != null)
            {
                if (leftSeat.IAmBookedBy == "")
                {
                    return true;
                }
            }
            MessageBox.Show("You may not select a seat beside others");
            return false;
        }// end of CheckPersonBeside()


        // retrieve the seat at the left and right of the selected seat
        // check both IAmBooked, if both true return true
        // return true if the selected seat is adjacent
        private bool CheckAdjacent(Seat selectedSeat, List<Seat> bookSeatsList)
        {
            foreach (Seat seat in bookSeatsList)
            {
                if (seatManager.Search(seat.RowNumber, seat.ColumnNumber + 1) == selectedSeat || seatManager.Search(seat.RowNumber, seat.ColumnNumber - 1) == selectedSeat)
                {
                    // return true if user's selected seat is at the right or left of the seat have been booked
                    return true;
                }
            }
            // return false and prompt out message box to notice user may only book adjacent seats
            MessageBox.Show("You may only book adjacent seats.");
            return false;
        }// end of CheckAdjacent


        // return true if is able to unbook
        private bool CheckAvailabilityToUnBook(Seat selectedSeat)
        {
            // return true when the seat selected is at the most right or most left
            if (seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber + 1) == null || seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber - 1) == null)
            {
                return true;
            }
            // return false if there is a seat at the right and left of the seat selected 
            if (seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber + 1).IAmBooked && seatManager.Search(selectedSeat.RowNumber, selectedSeat.ColumnNumber - 1).IAmBooked)
            {
                MessageBox.Show("You may only book adjacent seats.");
                return false;
            }
            return true;
        }// end of CheckAvailabilityToUnBook()


        // Check exceed maxSeats, CheckPersonBeside and Check adjacent
        // return true if is able to add a book seat
        private bool CheckAvailabilityToBook(Seat selectedSeat)
        {
            List<Seat> bookedSeats = new List<Seat>();
            // check the seat has been selected by user 
            foreach (Label seatLabel in _seatLabels)
            {
                Seat seat = (Seat)seatLabel.Tag;
                if (seat.IAmBooked)
                {
                    bookedSeats.Add(seat);
                }
            }
            // check user exceed the max seat 
            if (bookedSeats.Count + 1 > _maxSeats)
            {
                // prompt out message box to notice user if user exceed the number of max seat
                MessageBox.Show("You have booked the maximum number of seats!");
                return false;
            }
            // this is the first user selected seat edge case
            else if (bookedSeats.Count == 0)
            {
                // return true if no person beside
                return CheckPersonBeside(selectedSeat);
            }
            // check for second user selected seat until the end
            else
            {
                // return true if no person beside
                if (CheckPersonBeside(selectedSeat))
                {
                    // return true if selected seat is adjacent
                    return CheckAdjacent(selectedSeat, bookedSeats);
                }
                else
                {
                    return false;
                }
            }
        }// end of CheckAvailabilityToBook()

        private void TextNumRowCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or the backspace key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the keypress
            }
        }// end of TextNumRowCol_KeyPress()

        private void TextDivider_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit, a comma, or the backspace key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the keypress
            }
        }// end of TextDivider_KeyPress()

        private void ButtonGenerateSeat_Click(object sender, EventArgs e)
        {
            _seatLabels.Clear();
            // parse the number of row and col into integer
            // if parse success, assign the value to numRow and seatPerRow
            if (int.TryParse(TextNumRow.Text, out int row) && int.TryParse(TextSeatPerRow.Text, out int col))
            {
                if (row != 0 && col != 0)
                {
                    _numRow = row;
                    _seatPerRow = col;
                }
                else
                {
                    MessageBox.Show("Invalid input!!!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid input!!!");
                return;
            }
            string rowDiv = TextRowDiv.Text;
            // Split the string by commas and remove any leading/trailing whitespace for stringRowDiv
            string[] stringRowDiv = rowDiv.Split(',');

            string colDiv = TextColDiv.Text;
            // Split the string by commas and remove any leading/trailing whitespace for stringColDiv
            string[] stringColDiv = colDiv.Split(',');

            // Convert each string element to an integer for RowDiv
            int[] intRowDiv = Array.ConvertAll(stringRowDiv, s => int.Parse(s.Trim()));
            // Convert each string element to an integer for ColDiv
            int[] intColDiv = Array.ConvertAll(stringColDiv, s => int.Parse(s.Trim()));

            // clear all the controls on the panel
            panelLayout.Controls.Clear();

            int current_xcor = 60, current_ycor = 120; // track where the x and y coordinate
            // generate screen
            Label labelScreen = new Label();
            labelScreen.Text = "Screen";
            labelScreen.Location = new Point(60, 10); // Create a Point type object which has x, y coordinate info
            labelScreen.Size = new Size(130 * intColDiv.Length + 70 * (_seatPerRow - intColDiv.Length), 90); // Create a Size type object which has the width, height info
            labelScreen.TextAlign = ContentAlignment.MiddleCenter; // Align the Text to mid - center
            labelScreen.BorderStyle = BorderStyle.FixedSingle; // Make the border visible
            labelScreen.BackColor = Color.LightBlue; // Set the background color
            labelScreen.Font = new Font("Calibri", 20, FontStyle.Bold);
            labelScreen.ForeColor = Color.Black;
            this.panelLayout.Controls.Add(labelScreen);

            for (int i = 1; i <= _numRow; i++)
            {
                // set the y coordinate for every row
                // if the col number is exist in the intRowDiv array, add a divider
                if (Array.Exists(intRowDiv, item => item == i - 1))
                {
                    current_ycor += 130;
                }
                else
                {
                    current_ycor += 70;
                }
                // reset the x coordinate for every row
                current_xcor = 0;

                for (int j = 1; j <= _seatPerRow; j++)
                {
                    // set the x coordinate for every column
                    if (j - 1 == 0)
                    {
                        current_xcor += 60;
                    }
                    // if the row number is exist in the intColDiv array, add a divider
                    else if (Array.Exists(intColDiv, item => item == j - 1))
                    {
                        current_xcor += 130;
                    }
                    else
                    {
                        current_xcor += 70;
                    }
                    // generate seat label into panel control
                    seatManager.AddSeat(new Seat() { RowNumber = i, ColumnNumber = j, Xcor = current_xcor, Ycor = current_ycor }); // add a new seat
                    Seat oneSeat = new Seat();
                    oneSeat = seatManager.Search(i, j); // search the seat has been added just now
                    Label labelSeat = new Label(); // Instantiate a new label type object, labelSeat
                    labelSeat.Text = oneSeat.SeatLabel; // Set the Text property by using a string
                    labelSeat.Location = new Point(current_xcor, current_ycor); // Create a Point type object which has x, y coordinate info
                    labelSeat.Size = new Size(60, 60); // Create a Size type object which has the width, height info
                    labelSeat.TextAlign = ContentAlignment.MiddleCenter; // Align the Text to mid - center
                    labelSeat.BorderStyle = BorderStyle.FixedSingle; // Make the border visible
                    labelSeat.BackColor = Color.Purple; // Set the background color
                    labelSeat.Font = new Font("Calibri", 12, FontStyle.Bold);
                    labelSeat.ForeColor = Color.Black;
                    labelSeat.Tag = oneSeat;
                    oneSeat.MyLabel = labelSeat;
                    labelSeat.Click += new EventHandler(LabelSeat_Click);
                    // add the labelSeat into the seatLabels list
                    _seatLabels.Add(labelSeat);
                    // Adding this control to the Panel control, panelSeats 
                    this.panelLayout.Controls.Add(labelSeat);
                }
            }
            ButtonEnterEditor.Enabled = true;
            comboBoxPersonNo.Enabled = true;
            ButtonGenerateSeat.Enabled = false;
            PanelPerson.Enabled = true;
        }// end of ButtonGenerateSeat_Click()

        private void ButtonResetSimulation_Click(object sender, EventArgs e)
        {
            bookState = BookState.End;
            MessageBox.Show("Simulation reset!");
            // enable all the person label
            foreach (Label personLabel in _personLabels)
            {
                personLabel.Enabled = true;
            }
            UpdateLabel();
            textboxOutput.Text = "";
            TextMaxSeats.Text = "";
            ButtonEnterEditor.Enabled = true;
            ButtonGenerateSeat.Enabled = true;
            ButtonUndo.Enabled = false;
            ButtonRedo.Enabled = false;
            comboBoxPersonNo.Enabled = true;
            TextMaxSeats.Enabled = false;
        }// end of Button ResetSimulation_Click()

        private void ButtonEnterEditor_Click(object sender, EventArgs e)
        {
            bookState = BookState.Editor;
            comboBoxPersonNo.Enabled = false;
            ButtonEnable.Enabled = true;
            ButtonDisable.Enabled = true;
            RadDisable.Enabled = true;
            RadEnable.Enabled = true;
            ButtonEnterEditor.Visible = false;
            ButtonExitEditor.Visible = true;
            RadEnable.Checked = false;
            RadDisable.Checked = false;
            foreach (Label personLabel in _personLabels)
            {
                personLabel.Enabled = false;
            }
            foreach (Label seatLabel in _seatLabels)
            {
                seatLabel.Enabled = false;
            }
            textboxOutput.Text = "Seat Editor Enabled";
        }// end of ButtonEnterEditor_Click()

        private void ButtonExitEditor_Click(object sender, EventArgs e)
        {
            ButtonResetSimulation.Enabled = true;
            ButtonEnable.Enabled = false;
            ButtonDisable.Enabled = false;
            RadDisable.Enabled = false;
            RadEnable.Enabled = false;
            ButtonEnterEditor.Visible = true;
            RadEnable.Checked = false;
            RadDisable.Checked = false;
            ButtonExitEditor.Visible = false;
            foreach (Label personLabel in _personLabels)
            {
                personLabel.Enabled = true;
            }
            editorState = EditorState.None;
            textboxOutput.Text = "Exited Seat Editor!";
            bookState = BookState.Start;
            comboBoxPersonNo.Enabled = true;
            UpdateLabel();
        }// end of ButtonExitEditor_Click()

        private void ButtonEnable_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in _seatLabels)
            {
                Seat seat = (Seat)seatLabel.Tag;
                seat.status = true;
            }
            UpdateLabel();
        }// end of ButtonEnable_Click()

        private void ButtonDisable_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in _seatLabels)
            {
                Seat seat = (Seat)seatLabel.Tag;
                seat.status = false;
            }
            UpdateLabel();
        }// end of ButtonDisable_Click()

        //
        private void RadEnable_CheckedChanged(object sender, EventArgs e)
        {
            bookState = BookState.Start;
            UpdateLabel();
            foreach (Label seatLabel in _seatLabels)
            {
                seatLabel.Enabled = true;
            }
            editorState = EditorState.Enable;
            textboxOutput.Text = "\nClick seats to enable.";
            bookState = BookState.Editor; 
        }// end of RadEnable_CheckedChanged()
        private void RadDisable_CheckedChanged(object sender, EventArgs e)
        {
            bookState = BookState.Start;
            UpdateLabel();
            foreach (Label seatLabel in _seatLabels)
            {
                seatLabel.Enabled = true;
            }
            editorState = EditorState.Disable;
            textboxOutput.Text = "\nClick seats to disabled.";
            bookState = BookState.Editor; 
        }// end of RadDisable_CheckedChanged()
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            seatManager.SaveToFile();
            string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/person.txt";
            TextWriter tw = new StreamWriter(filepath);
            foreach (Label labelPerson in _personLabels)
            {
                Person person = (Person)labelPerson.Tag;
                String selectColor_str = person.SelectColor.ToString();
                selectColor_str = selectColor_str.Replace(',', '.');
                tw.WriteLine($"{person.Name},{selectColor_str},{person.IsCurrent},{person.IsPass},{person.Xcor},{person.Ycor},{person.MaxSeat}");
            }
            tw.Close();
            MessageBox.Show("Saved");
        }// end of ButtonSave_Click()

        private void LabelPerson_Click(object sender, EventArgs e)
        {
            bookState = BookState.Start;
            UpdateLabel();
            Label label = (Label)sender;
            // set _currentPerson.IsPass to true mean that the person already finish select the seat
            // set _currentPerson.IsCurrent to false mean that the person is not the one currently select seat already
            if (_currentPerson != null)
            {
                _currentPerson.IsPass = true;
                _currentPerson.IsCurrent = false;
            }
            _currentPerson = (Person)label.Tag;
            _currentPerson.IsCurrent = true;
            comboBoxPersonNo.Enabled = false;
            TextMaxSeats.Enabled = true;
            label.Enabled = false;
            ButtonEndSimulation.Enabled = true;
            ButtonEnterEditor.Enabled = false;
            ButtonRedo.Enabled = false;
            ButtonSave.Enabled = true;
            textboxOutput.Text = _currentPerson.Name + " is booking now";
        }// end of LabelPerson_Click()

        private void ComboBoxPersonNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _personLabels.Clear();
            PanelPerson.Controls.Clear();
            string selectedValue = comboBoxPersonNo.SelectedItem.ToString();
            int intSelectedValue = int.Parse(selectedValue);
            int current_xcor = 10, current_ycor = 10;
            for (int i = 1; i <= intSelectedValue; i++)
            {
                if (i == 5)
                {
                    current_ycor = 10;
                    current_xcor += 80;
                }
                // Create a Random object
                Random random = new Random();

                // Generate random values for RGB components
                int red = random.Next(256);
                int green = random.Next(256);
                int blue = random.Next(256);

                // Create a random color
                Color randomColor = Color.FromArgb(red, green, blue);
                Person newPerson = new Person()
                {
                    Name = "P" + i.ToString(),
                    SelectColor = randomColor,
                    Xcor = current_xcor,
                    Ycor = current_ycor
                };

                Label labelPerson = new Label(); // Instantiate a new label type object, labelSeat
                labelPerson.Text = newPerson.Name; // Set the Text property by using a string
                labelPerson.Location = new Point(current_xcor, current_ycor); // Create a Point type object which has x, y coordinate info
                labelPerson.Size = new Size(60, 60); // Create a Size type object which has the width, height info
                labelPerson.TextAlign = ContentAlignment.MiddleCenter; // Align the Text to mid - center
                labelPerson.BorderStyle = BorderStyle.FixedSingle; // Make the border visible
                labelPerson.BackColor = randomColor; // Set the background color
                labelPerson.Font = new Font("Calibri", 12, FontStyle.Bold);
                labelPerson.ForeColor = Color.Black;
                labelPerson.Tag = newPerson;
                labelPerson.Click += new EventHandler(LabelPerson_Click);
                current_ycor += 70;
                // Adding this control to the Panel control, panelSeats 
                this.PanelPerson.Controls.Add(labelPerson);
                _personLabels.Add(labelPerson);
            }
        }// end of ComboBoxPersonNo_SelectedIndexChanged()

        private void ButtonEndSimulation_Click(object sender, EventArgs e)
        {
            UpdateLabel();
            _currentPerson.IsCurrent = false;
            _currentPerson.IsPass = true;
            ButtonEndSimulation.Enabled = false;
            _currentPerson = null;
            bookState = BookState.End;
            foreach (Label personLabel in _personLabels)
            {
                personLabel.Enabled = false;
            }
            ButtonUndo.Enabled = false;
            ButtonResetSimulation.Enabled = true;
            TextMaxSeats.Enabled = false;
            textboxOutput.Text = "End Simulation!";
        }// end of ButtonEndSimulation_Click()

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((formNormalMode)this.MdiParent).form1 = null;
        }// end of form1_FormClosing

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            ButtonEndSimulation.Enabled = true;
            ButtonGenerateSeat.Enabled = false;
            ButtonResetSimulation.Enabled = false;
            bookState = BookState.Load;
            // settle all the load person part
            ReadFromPerson();
            // clear all the controls on the panel
            panelLayout.Controls.Clear();
            seatManager.SeatList.Start = null;
            _seatLabels.Clear();
            seatManager.ReadFromFile();
            Node seatNode = seatManager.SeatList.Start;
            Seat seat = seatNode.Seat;
            while (seat != null)
            {
                Label labelSeat = new Label();
                labelSeat.Text = seat.SeatLabel;
                labelSeat.Location = new Point(seat.Xcor, seat.Ycor);
                labelSeat.Size = new Size(60, 60);
                labelSeat.TextAlign = ContentAlignment.MiddleCenter;
                labelSeat.BorderStyle = BorderStyle.FixedSingle;
                labelSeat.BackColor = Color.Purple;
                labelSeat.Font = new Font("Calibri", 12, FontStyle.Bold);
                labelSeat.ForeColor = Color.Black;
                labelSeat.Tag = seat;
                seat.MyLabel = labelSeat;
                labelSeat.Click += new EventHandler(LabelSeat_Click);
                _seatLabels.Add(labelSeat);
                this.panelLayout.Controls.Add(labelSeat);
                seatNode = seatNode.Next;
                if (seatNode == null)
                {
                    UpdateLabel();
                    // generate screen
                    Label labelScreen = new Label();
                    labelScreen.Text = "Screen";
                    labelScreen.Location = new Point(60, 10); // Create a Point type object which has x, y coordinate info
                    labelScreen.Size = new Size(seat.Xcor + 60, 90); // Create a Size type object which has the width, height info
                    labelScreen.TextAlign = ContentAlignment.MiddleCenter; // Align the Text to mid - center
                    labelScreen.BorderStyle = BorderStyle.FixedSingle; // Make the border visible
                    labelScreen.BackColor = Color.LightBlue; // Set the background color
                    labelScreen.Font = new Font("Calibri", 20, FontStyle.Bold);
                    labelScreen.ForeColor = Color.Black;
                    this.panelLayout.Controls.Add(labelScreen);
                    return;
                }
                seat = seatNode.Seat;
            }
            //reset the redoActionLog and undoActionLog
            _redoActionLog.Current = null;
            _redoActionLog.Start = null;
            _undoActionLog.Current = null;
            _undoActionLog.Start = null;
        }// end of ButtonLoad_Click()

        // handle the load for the person part
        private void ReadFromPerson()
        {
            PanelPerson.Controls.Clear();
            _personLabels.Clear();
            string line = null;
            string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/person.txt";
            TextReader tr = new StreamReader(filepath);
            line = tr.ReadLine();
            do
            {
                string[] data = line.Split(",");
                Person person = new Person()
                {
                    Name = data[0],
                    SelectColor = RetrieveColorValue(data[1]),
                    IsCurrent = bool.Parse(data[2]),
                    IsPass = bool.Parse(data[3]),
                    Xcor = int.Parse(data[4]),
                    Ycor = int.Parse(data[5]),
                    MaxSeat = int.Parse(data[6]),
                };
                Label labelPerson = new Label(); // Instantiate a new label type object, labelSeat
                labelPerson.Text = person.Name; // Set the Text property by using a string
                labelPerson.Location = new Point(person.Xcor, person.Ycor); // Create a Point type object which has x, y coordinate info
                labelPerson.Size = new Size(60, 60); // Create a Size type object which has the width, height info
                labelPerson.TextAlign = ContentAlignment.MiddleCenter; // Align the Text to mid - center
                labelPerson.BorderStyle = BorderStyle.FixedSingle; // Make the border visible
                labelPerson.BackColor = person.SelectColor; // Set the background color
                labelPerson.Font = new Font("Calibri", 12, FontStyle.Bold);
                labelPerson.ForeColor = Color.Black;
                labelPerson.Tag = person;
                labelPerson.Click += new EventHandler(LabelPerson_Click);
                if (person.IsPass) // check the person already finish booking or not
                {
                    labelPerson.Enabled = false;
                }
                if (person.IsCurrent) // check the person is the last booking or not
                {
                    _currentPerson = person;
                    labelPerson.Enabled = false;
                    textboxOutput.Text = _currentPerson.Name + " is booking now";
                    if (person.MaxSeat == 0)
                    {
                        TextMaxSeats.Enabled = true;
                    }
                    else
                    {
                        TextMaxSeats.Text = _currentPerson.MaxSeat.ToString();
                    }
                }
                // Adding this control to the Panel control, panelSeats 
                this.PanelPerson.Controls.Add(labelPerson);
                _personLabels.Add(labelPerson);
                line = tr.ReadLine();
            } while (line != null);
            tr.Close();
            PanelPerson.Enabled = true;
        }// end of ReadFromPerson()


        // use to retrieve the color that save in text file
        private Color RetrieveColorValue(string selectColor)
        {
            // Extracting ARGB values from the string
            int startIndex = selectColor.IndexOf("[") + 1;
            int endIndex = selectColor.IndexOf("]");


            string valuesString = selectColor.Substring(startIndex, endIndex - startIndex);

            string[] colorValues = valuesString.Split('.');

            // Parsing the individual components

            int alpha = int.Parse(colorValues[0].Substring(colorValues[0].IndexOf("=") + 1));
            int red = int.Parse(colorValues[1].Substring(colorValues[1].IndexOf("=") + 1));
            int green = int.Parse(colorValues[2].Substring(colorValues[2].IndexOf("=") + 1));
            int blue = int.Parse(colorValues[3].Substring(colorValues[3].IndexOf("=") + 1));


            // Creating the Color object
            Color customColor = Color.FromArgb(alpha, red, green, blue);

            return customColor; // This will output the color: Color [A=255, R=148, G=204, B=51]
        }// end of RetrieveColorValue()

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            ActionNode prevAction = _undoActionLog.ReturnPrev();
            Seat seat = seatManager.Search(prevAction.Row, prevAction.Col);
            // when buttton undo is clicked, redoActionLog start to record the prevAction
            _redoActionLog.RecordAction(prevAction.Row, prevAction.Col, !prevAction.IsBook);
            seat.IAmBooked = prevAction.IsBook;
            if (prevAction.IsBook) // if the prevAction 
            {
                seat.MyLabel.BackColor = _currentPerson.SelectColor;
            }
            if (_undoActionLog.Current == null)
            {
                _undoActionLog.Current = null;
                ButtonUndo.Enabled = false;
            }
            ButtonRedo.Enabled = true;
        }// end of ButtonUndo_Click()
        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            ActionNode RedoAction = _redoActionLog.ReturnPrev();
            if (_undoActionLog.Current == null)
            {
                _undoActionLog.Current = _undoActionLog.Start;
            }
            else
            {
                _undoActionLog.Current = _undoActionLog.Current.Next;
            }
            Seat seat = seatManager.Search(RedoAction.Row, RedoAction.Col);
            seat.IAmBooked = RedoAction.IsBook;
            if (RedoAction.IsBook)
            {
                seat.MyLabel.BackColor = _currentPerson.SelectColor;
            }
            if (_redoActionLog.Current == null)
            {
                //_redoActionLog.Current = _redoActionLog.Start;
                _redoActionLog.Current = null;
                _redoActionLog.Start = null;
                ButtonRedo.Enabled = false;
            }
            ButtonUndo.Enabled = true;
        }// end of ButtonRedo_Click()

    }//end of Form1 class
}//end of namespace block
