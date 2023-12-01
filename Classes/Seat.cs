using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Experiment_DSAL_assignment_1.Classes
{
    [Serializable]
    class Seat 
    {
        private bool _status = true;
        private int _rowNumber = 0;
        private int _colNumber = 0;
        private int _xcor = 0;
        private int _ycor = 0;
        private string _rowLabel = "";
        private bool _iAmBooked = false;
        private string _iAmBookedBy = "";

        [NonSerialized]
        private Label _myLabel = new Label();
        public Seat()
        {
            _iAmBooked = false;
            _iAmBookedBy = "";
        }

        public int Xcor
        {
            get { return _xcor; }
            set { _xcor = value; }
        }

        public int Ycor
        {
            get { return _ycor; }
            set { _ycor = value; }
        }
       
        public bool status
        {
            get { return _status; }
            set
            {
                if (value == true && _status == false)
                {
                    _status = value;
                }
                if (value == false && _status == true)
                {
                    _status = value;
                }
            }
        }
        public bool IAmBooked
        {
            get { return _iAmBooked; }
            set
            {
                if (value == true && _iAmBooked == false)
                {
                    _iAmBooked = value;
                }
                if (value== false && _iAmBooked == true)
                {
                    _iAmBooked = value;
                    _myLabel.BackColor = Color.LightCyan;
                } 
            }
        }

        public string IAmBookedBy
        {
            get { return _iAmBookedBy; }
            set
            {
                _iAmBookedBy = value;
            }
        }
        public Label  MyLabel
        {
            get { return _myLabel; }
            set
            {
                _myLabel = value;
            }
        }


        public int RowNumber { 
            get { return _rowNumber; }
            set { _rowNumber = value;
                _rowLabel = ((char)(64+_rowNumber)).ToString(); //Google and get the code
            } 
        }
        public int ColumnNumber { 
            get { return _colNumber; } 
            set { _colNumber = value; } 
        }
        public string SeatLabel
        {
            get { return _rowLabel + _colNumber.ToString(); }
           //Does not make sense to let calling program set the seat label
        }
    }//end of class
}//end of namespace
