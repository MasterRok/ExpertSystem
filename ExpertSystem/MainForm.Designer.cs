namespace ExpertSystem
{
    partial class MainForm
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
            this.lvCv = new System.Windows.Forms.ListView();
            this.cvKey = new System.Windows.Forms.ColumnHeader();
            this.cvValue = new System.Windows.Forms.ColumnHeader();
            this.btnLoadCv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCv
            // 
            this.lvCv.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvCv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lvCv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.cvKey, this.cvValue});
            this.lvCv.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.lvCv.FullRowSelect = true;
            this.lvCv.GridLines = true;
            this.lvCv.HideSelection = false;
            this.lvCv.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.lvCv.Location = new System.Drawing.Point(514, 89);
            this.lvCv.Margin = new System.Windows.Forms.Padding(2);
            this.lvCv.MultiSelect = false;
            this.lvCv.Name = "lvCv";
            this.lvCv.Size = new System.Drawing.Size(359, 341);
            this.lvCv.TabIndex = 12;
            this.lvCv.UseCompatibleStateImageBehavior = false;
            this.lvCv.View = System.Windows.Forms.View.Details;
            // 
            // cvKey
            // 
            this.cvKey.Text = "Key";
            this.cvKey.Width = 129;
            // 
            // cvValue
            // 
            this.cvValue.Text = "Value";
            this.cvValue.Width = 130;
            // 
            // btnLoadCv
            // 
            this.btnLoadCv.Location = new System.Drawing.Point(59, 89);
            this.btnLoadCv.Name = "btnLoadCv";
            this.btnLoadCv.Size = new System.Drawing.Size(150, 36);
            this.btnLoadCv.TabIndex = 11;
            this.btnLoadCv.Text = "Load cv";
            this.btnLoadCv.UseVisualStyleBackColor = true;
            this.btnLoadCv.Click += new System.EventHandler(this.btnLoadCv_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.lvCv);
            this.Controls.Add(this.btnLoadCv);
            this.Name = "MainForm";
            this.Text = "Main";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnLoadCv;
        private System.Windows.Forms.ColumnHeader cvValue;
        private System.Windows.Forms.ColumnHeader cvKey;
        private System.Windows.Forms.ListView lvCv;
    }
}