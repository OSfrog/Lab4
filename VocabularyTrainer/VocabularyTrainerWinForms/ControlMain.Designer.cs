namespace VocabularyTrainerWinForms
{
    partial class ControlMain
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
            this.components = new System.ComponentModel.Container();
            this.ListBoxWordLists = new System.Windows.Forms.ListBox();
            this.wordListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListBoxLanguages = new System.Windows.Forms.ListBox();
            this.LabelLists = new System.Windows.Forms.Label();
            this.LabelLanguages = new System.Windows.Forms.Label();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxWordLists
            // 
            this.ListBoxWordLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxWordLists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ListBoxWordLists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxWordLists.DataSource = this.wordListBindingSource;
            this.ListBoxWordLists.DisplayMember = "Name";
            this.ListBoxWordLists.ForeColor = System.Drawing.Color.White;
            this.ListBoxWordLists.FormattingEnabled = true;
            this.ListBoxWordLists.Location = new System.Drawing.Point(7, 39);
            this.ListBoxWordLists.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListBoxWordLists.Name = "ListBoxWordLists";
            this.ListBoxWordLists.Size = new System.Drawing.Size(213, 169);
            this.ListBoxWordLists.TabIndex = 1;
            this.ListBoxWordLists.TabStop = false;
            this.ListBoxWordLists.SelectedIndexChanged += new System.EventHandler(this.ListBoxWordLists_SelectedIndexChanged);
            // 
            // wordListBindingSource
            // 
            this.wordListBindingSource.DataSource = typeof(VocabularyTrainerLibrary.WordList);
            // 
            // ListBoxLanguages
            // 
            this.ListBoxLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ListBoxLanguages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxLanguages.ForeColor = System.Drawing.Color.White;
            this.ListBoxLanguages.FormattingEnabled = true;
            this.ListBoxLanguages.Location = new System.Drawing.Point(217, 39);
            this.ListBoxLanguages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListBoxLanguages.Name = "ListBoxLanguages";
            this.ListBoxLanguages.Size = new System.Drawing.Size(213, 169);
            this.ListBoxLanguages.TabIndex = 2;
            this.ListBoxLanguages.TabStop = false;
            // 
            // LabelLists
            // 
            this.LabelLists.AutoSize = true;
            this.LabelLists.ForeColor = System.Drawing.Color.White;
            this.LabelLists.Location = new System.Drawing.Point(4, 24);
            this.LabelLists.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLists.Name = "LabelLists";
            this.LabelLists.Size = new System.Drawing.Size(28, 13);
            this.LabelLists.TabIndex = 3;
            this.LabelLists.Text = "Lists";
            // 
            // LabelLanguages
            // 
            this.LabelLanguages.AutoSize = true;
            this.LabelLanguages.ForeColor = System.Drawing.Color.White;
            this.LabelLanguages.Location = new System.Drawing.Point(214, 24);
            this.LabelLanguages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLanguages.Name = "LabelLanguages";
            this.LabelLanguages.Size = new System.Drawing.Size(60, 13);
            this.LabelLanguages.TabIndex = 4;
            this.LabelLanguages.Text = "Languages";
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelect.AutoSize = true;
            this.ButtonSelect.ForeColor = System.Drawing.Color.Black;
            this.ButtonSelect.Location = new System.Drawing.Point(385, 211);
            this.ButtonSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(47, 26);
            this.ButtonSelect.TabIndex = 5;
            this.ButtonSelect.Text = "Select";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonNew
            // 
            this.ButtonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonNew.ForeColor = System.Drawing.Color.Black;
            this.ButtonNew.Location = new System.Drawing.Point(7, 211);
            this.ButtonNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(41, 26);
            this.ButtonNew.TabIndex = 6;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            // 
            // ControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.ButtonNew);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.LabelLanguages);
            this.Controls.Add(this.LabelLists);
            this.Controls.Add(this.ListBoxLanguages);
            this.Controls.Add(this.ListBoxWordLists);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlMain";
            this.Size = new System.Drawing.Size(824, 514);
            this.Load += new System.EventHandler(this.ControlMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxWordLists;
        private System.Windows.Forms.ListBox ListBoxLanguages;
        private System.Windows.Forms.Label LabelLists;
        private System.Windows.Forms.Label LabelLanguages;
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.BindingSource wordListBindingSource;
    }
}
