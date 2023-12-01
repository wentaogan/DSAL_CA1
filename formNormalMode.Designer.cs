
namespace Experiment_DSAL_assignment_1
{
    partial class formNormalMode
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            normalModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            normalModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            safeDistanceModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            safeDistanceSmartModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { normalModeToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // normalModeToolStripMenuItem
            // 
            normalModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { normalModeToolStripMenuItem1, safeDistanceModeToolStripMenuItem, safeDistanceSmartModeToolStripMenuItem });
            normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            normalModeToolStripMenuItem.Size = new System.Drawing.Size(164, 29);
            normalModeToolStripMenuItem.Text = "Simulation mode";
            // 
            // normalModeToolStripMenuItem1
            // 
            normalModeToolStripMenuItem1.Name = "normalModeToolStripMenuItem1";
            normalModeToolStripMenuItem1.Size = new System.Drawing.Size(320, 34);
            normalModeToolStripMenuItem1.Text = "Normal mode";
            // 
            // safeDistanceModeToolStripMenuItem
            // 
            safeDistanceModeToolStripMenuItem.Name = "safeDistanceModeToolStripMenuItem";
            safeDistanceModeToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            safeDistanceModeToolStripMenuItem.Text = "Safe distance mode";
            // 
            // safeDistanceSmartModeToolStripMenuItem
            // 
            safeDistanceSmartModeToolStripMenuItem.Name = "safeDistanceSmartModeToolStripMenuItem";
            safeDistanceSmartModeToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            safeDistanceSmartModeToolStripMenuItem.Text = "Safe distance smart mode";
            // 
            // formNormalMode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "formNormalMode";
            Text = "formNormalMode";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem normalModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem safeDistanceModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeDistanceSmartModeToolStripMenuItem;
    }
}