namespace test
{
    partial class OpenScreen
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
            this.newProject = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // newProject
            // 
            this.newProject.AutoSize = true;
            this.newProject.Location = new System.Drawing.Point(332, 99);
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(65, 13);
            this.newProject.TabIndex = 0;
            this.newProject.TabStop = true;
            this.newProject.Text = "New Project";
            this.newProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newProject_LinkClicked);
            // 
            // OpenScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newProject);
            this.Name = "OpenScreen";
            this.Text = "OpenScreen";
            this.Load += new System.EventHandler(this.OpenScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel newProject;
    }
}