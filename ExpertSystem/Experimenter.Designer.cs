using System.ComponentModel;

namespace ExpertSystem
{
    partial class Experimenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.header = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(320, 126);
            this.header.TabIndex = 0;
            this.header.Text = "Проводится собеседование...";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(31, 129);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(257, 24);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 1;
            this.progressBar.UseWaitCursor = true;
            // 
            // Experimenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 228);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.header);
            this.Name = "Experimenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experimenter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Experimenter_FormClosing);
            this.Load += new System.EventHandler(this.Experimenter_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}