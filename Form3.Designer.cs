namespace Experiment_DSAL_assignment_1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonEndSimulation = new System.Windows.Forms.Button();
            PanelPerson = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            comboBoxPersonNo = new System.Windows.Forms.ComboBox();
            ButtonSave = new System.Windows.Forms.Button();
            ButtonLoad = new System.Windows.Forms.Button();
            TextMaxSeats = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            TextColDiv = new System.Windows.Forms.TextBox();
            TextRowDiv = new System.Windows.Forms.TextBox();
            TextSeatPerRow = new System.Windows.Forms.TextBox();
            TextNumRow = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panelLayout = new System.Windows.Forms.Panel();
            ButtonGenerateSeat = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ButtonExitEditor = new System.Windows.Forms.Button();
            ButtonDisable = new System.Windows.Forms.Button();
            ButtonEnable = new System.Windows.Forms.Button();
            RadDisable = new System.Windows.Forms.RadioButton();
            RadEnable = new System.Windows.Forms.RadioButton();
            ButtonEnterEditor = new System.Windows.Forms.Button();
            ButtonResetSimulation = new System.Windows.Forms.Button();
            textboxOutput = new System.Windows.Forms.TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonEndSimulation
            // 
            ButtonEndSimulation.BackColor = System.Drawing.Color.Silver;
            ButtonEndSimulation.Enabled = false;
            ButtonEndSimulation.Location = new System.Drawing.Point(42, 720);
            ButtonEndSimulation.Name = "ButtonEndSimulation";
            ButtonEndSimulation.Size = new System.Drawing.Size(298, 34);
            ButtonEndSimulation.TabIndex = 44;
            ButtonEndSimulation.Text = "End Simulation";
            ButtonEndSimulation.UseVisualStyleBackColor = false;
            ButtonEndSimulation.Click += ButtonEndSimulation_Click;
            // 
            // PanelPerson
            // 
            PanelPerson.BackColor = System.Drawing.Color.White;
            PanelPerson.Location = new System.Drawing.Point(32, 385);
            PanelPerson.Name = "PanelPerson";
            PanelPerson.Size = new System.Drawing.Size(308, 312);
            PanelPerson.TabIndex = 29;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Silver;
            button1.Location = new System.Drawing.Point(36, 614);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(298, 34);
            button1.TabIndex = 43;
            button1.Text = "Reset Simulation";
            button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(21, 354);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(116, 25);
            label6.TabIndex = 42;
            label6.Text = "No of Person";
            // 
            // comboBoxPersonNo
            // 
            comboBoxPersonNo.FormattingEnabled = true;
            comboBoxPersonNo.Location = new System.Drawing.Point(174, 346);
            comboBoxPersonNo.Name = "comboBoxPersonNo";
            comboBoxPersonNo.Size = new System.Drawing.Size(176, 33);
            comboBoxPersonNo.TabIndex = 27;
            comboBoxPersonNo.SelectedIndexChanged += ComboBoxPersonNo_SelectedIndexChanged;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new System.Drawing.Point(200, 27);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new System.Drawing.Size(113, 34);
            ButtonSave.TabIndex = 41;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonLoad
            // 
            ButtonLoad.Location = new System.Drawing.Point(36, 27);
            ButtonLoad.Name = "ButtonLoad";
            ButtonLoad.Size = new System.Drawing.Size(113, 34);
            ButtonLoad.TabIndex = 40;
            ButtonLoad.Text = "Load";
            ButtonLoad.UseVisualStyleBackColor = true;
            ButtonLoad.Click += ButtonLoad_Click;
            // 
            // TextMaxSeats
            // 
            TextMaxSeats.Enabled = false;
            TextMaxSeats.Location = new System.Drawing.Point(174, 302);
            TextMaxSeats.Name = "TextMaxSeats";
            TextMaxSeats.Size = new System.Drawing.Size(176, 31);
            TextMaxSeats.TabIndex = 39;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(21, 302);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(92, 25);
            label5.TabIndex = 38;
            label5.Text = "Max Seats";
            // 
            // TextColDiv
            // 
            TextColDiv.Location = new System.Drawing.Point(200, 200);
            TextColDiv.Name = "TextColDiv";
            TextColDiv.Size = new System.Drawing.Size(150, 31);
            TextColDiv.TabIndex = 37;
            // 
            // TextRowDiv
            // 
            TextRowDiv.Location = new System.Drawing.Point(200, 161);
            TextRowDiv.Name = "TextRowDiv";
            TextRowDiv.Size = new System.Drawing.Size(150, 31);
            TextRowDiv.TabIndex = 36;
            // 
            // TextSeatPerRow
            // 
            TextSeatPerRow.Location = new System.Drawing.Point(200, 121);
            TextSeatPerRow.Name = "TextSeatPerRow";
            TextSeatPerRow.Size = new System.Drawing.Size(150, 31);
            TextSeatPerRow.TabIndex = 35;
            // 
            // TextNumRow
            // 
            TextNumRow.Location = new System.Drawing.Point(200, 81);
            TextNumRow.Name = "TextNumRow";
            TextNumRow.Size = new System.Drawing.Size(150, 31);
            TextNumRow.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(21, 203);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(156, 25);
            label4.TabIndex = 33;
            label4.Text = "Column divider (s)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 121);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(120, 25);
            label3.TabIndex = 32;
            label3.Text = "Seats per row";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 161);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 25);
            label2.TabIndex = 31;
            label2.Text = "Row divider (s)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 81);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 25);
            label1.TabIndex = 30;
            label1.Text = "Number of rows";
            // 
            // panelLayout
            // 
            panelLayout.BackColor = System.Drawing.Color.White;
            panelLayout.Location = new System.Drawing.Point(364, 27);
            panelLayout.Name = "panelLayout";
            panelLayout.Size = new System.Drawing.Size(1366, 1342);
            panelLayout.TabIndex = 28;
            // 
            // ButtonGenerateSeat
            // 
            ButtonGenerateSeat.Location = new System.Drawing.Point(36, 246);
            ButtonGenerateSeat.Name = "ButtonGenerateSeat";
            ButtonGenerateSeat.Size = new System.Drawing.Size(298, 34);
            ButtonGenerateSeat.TabIndex = 26;
            ButtonGenerateSeat.Text = "Generate seats";
            ButtonGenerateSeat.UseVisualStyleBackColor = true;
            ButtonGenerateSeat.Click += ButtonGenerateSeat_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(ButtonExitEditor);
            groupBox1.Controls.Add(ButtonDisable);
            groupBox1.Controls.Add(ButtonEnable);
            groupBox1.Controls.Add(RadDisable);
            groupBox1.Controls.Add(RadEnable);
            groupBox1.Controls.Add(ButtonEnterEditor);
            groupBox1.Location = new System.Drawing.Point(40, 775);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(300, 262);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manual Editor";
            // 
            // ButtonExitEditor
            // 
            ButtonExitEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonExitEditor.Location = new System.Drawing.Point(36, 30);
            ButtonExitEditor.Name = "ButtonExitEditor";
            ButtonExitEditor.Size = new System.Drawing.Size(243, 34);
            ButtonExitEditor.TabIndex = 28;
            ButtonExitEditor.Text = "Exit Editor Mode";
            ButtonExitEditor.UseVisualStyleBackColor = false;
            ButtonExitEditor.Visible = false;
            ButtonExitEditor.Click += ButtonExitEditor_Click;
            // 
            // ButtonDisable
            // 
            ButtonDisable.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonDisable.Enabled = false;
            ButtonDisable.Location = new System.Drawing.Point(62, 186);
            ButtonDisable.Name = "ButtonDisable";
            ButtonDisable.Size = new System.Drawing.Size(170, 34);
            ButtonDisable.TabIndex = 27;
            ButtonDisable.Text = "Disable All";
            ButtonDisable.UseVisualStyleBackColor = false;
            ButtonDisable.Click += ButtonDisable_Click;
            // 
            // ButtonEnable
            // 
            ButtonEnable.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonEnable.Enabled = false;
            ButtonEnable.Location = new System.Drawing.Point(62, 130);
            ButtonEnable.Name = "ButtonEnable";
            ButtonEnable.Size = new System.Drawing.Size(170, 34);
            ButtonEnable.TabIndex = 26;
            ButtonEnable.Text = "Enable All";
            ButtonEnable.UseVisualStyleBackColor = false;
            ButtonEnable.Click += ButtonEnable_Click;
            // 
            // RadDisable
            // 
            RadDisable.AutoSize = true;
            RadDisable.Enabled = false;
            RadDisable.Location = new System.Drawing.Point(166, 82);
            RadDisable.Name = "RadDisable";
            RadDisable.Size = new System.Drawing.Size(95, 29);
            RadDisable.TabIndex = 25;
            RadDisable.TabStop = true;
            RadDisable.Text = "Disable";
            RadDisable.UseVisualStyleBackColor = true;
            RadDisable.CheckedChanged += RadDisable_CheckedChanged;
            // 
            // RadEnable
            // 
            RadEnable.AutoSize = true;
            RadEnable.Enabled = false;
            RadEnable.Location = new System.Drawing.Point(40, 82);
            RadEnable.Name = "RadEnable";
            RadEnable.Size = new System.Drawing.Size(89, 29);
            RadEnable.TabIndex = 24;
            RadEnable.TabStop = true;
            RadEnable.Text = "Enable";
            RadEnable.UseVisualStyleBackColor = true;
            RadEnable.CheckedChanged += RadEnable_CheckedChanged;
            // 
            // ButtonEnterEditor
            // 
            ButtonEnterEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonEnterEditor.Enabled = false;
            ButtonEnterEditor.Location = new System.Drawing.Point(36, 30);
            ButtonEnterEditor.Name = "ButtonEnterEditor";
            ButtonEnterEditor.Size = new System.Drawing.Size(243, 34);
            ButtonEnterEditor.TabIndex = 23;
            ButtonEnterEditor.Text = "Enter Editor Mode";
            ButtonEnterEditor.UseVisualStyleBackColor = false;
            ButtonEnterEditor.Click += ButtonEnterEditor_Click;
            // 
            // ButtonResetSimulation
            // 
            ButtonResetSimulation.BackColor = System.Drawing.Color.Silver;
            ButtonResetSimulation.Location = new System.Drawing.Point(40, 1056);
            ButtonResetSimulation.Name = "ButtonResetSimulation";
            ButtonResetSimulation.Size = new System.Drawing.Size(298, 34);
            ButtonResetSimulation.TabIndex = 46;
            ButtonResetSimulation.Text = "Reset Simulation";
            ButtonResetSimulation.UseVisualStyleBackColor = false;
            ButtonResetSimulation.Click += ButtonResetSimulation_Click;
            // 
            // textboxOutput
            // 
            textboxOutput.Location = new System.Drawing.Point(16, 1096);
            textboxOutput.Multiline = true;
            textboxOutput.Name = "textboxOutput";
            textboxOutput.Size = new System.Drawing.Size(337, 273);
            textboxOutput.TabIndex = 45;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1790, 1387);
            Controls.Add(groupBox1);
            Controls.Add(ButtonResetSimulation);
            Controls.Add(textboxOutput);
            Controls.Add(ButtonEndSimulation);
            Controls.Add(PanelPerson);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(comboBoxPersonNo);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonLoad);
            Controls.Add(TextMaxSeats);
            Controls.Add(label5);
            Controls.Add(TextColDiv);
            Controls.Add(TextRowDiv);
            Controls.Add(TextSeatPerRow);
            Controls.Add(TextNumRow);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelLayout);
            Controls.Add(ButtonGenerateSeat);
            Name = "Form3";
            Text = "Form3";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ButtonEndSimulation;
        private System.Windows.Forms.Panel PanelPerson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPersonNo;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.TextBox TextMaxSeats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextColDiv;
        private System.Windows.Forms.TextBox TextRowDiv;
        private System.Windows.Forms.TextBox TextSeatPerRow;
        private System.Windows.Forms.TextBox TextNumRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLayout;
        private System.Windows.Forms.Button ButtonGenerateSeat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonExitEditor;
        private System.Windows.Forms.Button ButtonDisable;
        private System.Windows.Forms.Button ButtonEnable;
        private System.Windows.Forms.RadioButton RadDisable;
        private System.Windows.Forms.RadioButton RadEnable;
        private System.Windows.Forms.Button ButtonEnterEditor;
        private System.Windows.Forms.Button ButtonResetSimulation;
        private System.Windows.Forms.TextBox textboxOutput;
    }
}