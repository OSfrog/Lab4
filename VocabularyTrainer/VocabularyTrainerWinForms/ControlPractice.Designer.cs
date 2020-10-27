namespace VocabularyTrainerWinForms
{
    partial class ControlPractice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.LabelTranslations = new System.Windows.Forms.Label();
            this.LabelWordCounter = new System.Windows.Forms.Label();
            this.ButtonRestart = new System.Windows.Forms.Button();
            this.ButtonEndPractice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(164, 167);
            this.textBox.Margin = new System.Windows.Forms.Padding(2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(172, 20);
            this.textBox.TabIndex = 0;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // LabelTranslations
            // 
            this.LabelTranslations.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelTranslations.AutoSize = true;
            this.LabelTranslations.Location = new System.Drawing.Point(150, 134);
            this.LabelTranslations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTranslations.Name = "LabelTranslations";
            this.LabelTranslations.Size = new System.Drawing.Size(64, 13);
            this.LabelTranslations.TabIndex = 1;
            this.LabelTranslations.Text = "Translations";
            // 
            // LabelWordCounter
            // 
            this.LabelWordCounter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LabelWordCounter.AutoSize = true;
            this.LabelWordCounter.Location = new System.Drawing.Point(192, 202);
            this.LabelWordCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelWordCounter.Name = "LabelWordCounter";
            this.LabelWordCounter.Size = new System.Drawing.Size(35, 13);
            this.LabelWordCounter.TabIndex = 2;
            this.LabelWordCounter.Text = "label1";
            this.LabelWordCounter.Visible = false;
            // 
            // ButtonRestart
            // 
            this.ButtonRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRestart.AutoSize = true;
            this.ButtonRestart.Location = new System.Drawing.Point(164, 234);
            this.ButtonRestart.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonRestart.Name = "ButtonRestart";
            this.ButtonRestart.Size = new System.Drawing.Size(75, 23);
            this.ButtonRestart.TabIndex = 3;
            this.ButtonRestart.Text = "Restart";
            this.ButtonRestart.UseVisualStyleBackColor = true;
            this.ButtonRestart.Click += new System.EventHandler(this.ButtonRestart_Click);
            // 
            // ButtonEndPractice
            // 
            this.ButtonEndPractice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEndPractice.AutoSize = true;
            this.ButtonEndPractice.Location = new System.Drawing.Point(258, 234);
            this.ButtonEndPractice.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonEndPractice.Name = "ButtonEndPractice";
            this.ButtonEndPractice.Size = new System.Drawing.Size(78, 23);
            this.ButtonEndPractice.TabIndex = 4;
            this.ButtonEndPractice.Text = "End Practice";
            this.ButtonEndPractice.UseVisualStyleBackColor = true;
            this.ButtonEndPractice.Click += new System.EventHandler(this.ButtonEndPractice_Click);
            // 
            // ControlPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ButtonEndPractice);
            this.Controls.Add(this.ButtonRestart);
            this.Controls.Add(this.LabelWordCounter);
            this.Controls.Add(this.LabelTranslations);
            this.Controls.Add(this.textBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(501, 374);
            this.Name = "ControlPractice";
            this.Size = new System.Drawing.Size(501, 374);
            this.Load += new System.EventHandler(this.ControlPractice_Load);
            this.VisibleChanged += new System.EventHandler(this.ControlPractice_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label LabelTranslations;
        private System.Windows.Forms.Label LabelWordCounter;
        private System.Windows.Forms.Button ButtonRestart;
        private System.Windows.Forms.Button ButtonEndPractice;
    }
}
