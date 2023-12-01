using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Experiment_DSAL_assignment_1
{
    public partial class formNormalMode : Form
    {
        public Form1 form1;
        public Form2 form2;
        public Form3 form3;
        public formNormalMode()
        {
            InitializeComponent();
            this.normalModeToolStripMenuItem1.Click += new EventHandler(this.normalModeToolStripMenuItem_Click);
            this.safeDistanceModeToolStripMenuItem.Click += new EventHandler(this.safeDistanceModeToolStripMenuItem_Click);
            this.safeDistanceSmartModeToolStripMenuItem.Click += new EventHandler(this.safeDistanceSmartModeToolStripMenuItem_Click);
        }
        private void normalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(form1 != null)
            {
                form1.Show();
            }

            if(form1 == null)
            {
                form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            }
        }

        private void safeDistanceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2 != null)
            {
                form2.Show();
            }

            if (form2 == null)
            {
                form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
            }
        }

        private void safeDistanceSmartModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form3 != null)
            {
                form3.Show();
            }

            if (form3 == null)
            {
                form3 = new Form3();
                form3.MdiParent = this;
                form3.Show();
            }
        }
    }
}
