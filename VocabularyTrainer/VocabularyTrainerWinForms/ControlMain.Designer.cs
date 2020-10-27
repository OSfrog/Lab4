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
            this.wordListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListBoxLanguages = new System.Windows.Forms.ListBox();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.LabelLists = new System.Windows.Forms.Label();
            this.LabelLanguages = new System.Windows.Forms.Label();
            this.ListBoxWordLists = new System.Windows.Forms.ListBox();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonPractice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).BeginInit();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // wordListBindingSource
            // 
            this.wordListBindingSource.DataSource = typeof(VocabularyTrainerLibrary.WordList);
            // 
            // ListBoxLanguages
            // 
            this.ListBoxLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ListBoxLanguages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableLayout.SetColumnSpan(this.ListBoxLanguages, 2);
            this.ListBoxLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxLanguages.ForeColor = System.Drawing.Color.White;
            this.ListBoxLanguages.FormattingEnabled = true;
            this.ListBoxLanguages.Location = new System.Drawing.Point(212, 20);
            this.ListBoxLanguages.Margin = new System.Windows.Forms.Padding(0);
            this.ListBoxLanguages.Name = "ListBoxLanguages";
            this.ListBoxLanguages.Size = new System.Drawing.Size(224, 172);
            this.ListBoxLanguages.TabIndex = 2;
            this.ListBoxLanguages.TabStop = false;
            // 
            // ButtonNew
            // 
            this.ButtonNew.ForeColor = System.Drawing.Color.Black;
            this.ButtonNew.Location = new System.Drawing.Point(0, 192);
            this.ButtonNew.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(56, 27);
            this.ButtonNew.TabIndex = 6;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelect.ForeColor = System.Drawing.Color.Black;
            this.ButtonSelect.Location = new System.Drawing.Point(380, 192);
            this.ButtonSelect.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(56, 27);
            this.ButtonSelect.TabIndex = 5;
            this.ButtonSelect.Text = "Select";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // LabelLists
            // 
            this.LabelLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelLists.AutoSize = true;
            this.LabelLists.ForeColor = System.Drawing.Color.White;
            this.LabelLists.Location = new System.Drawing.Point(2, 7);
            this.LabelLists.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLists.Name = "LabelLists";
            this.LabelLists.Size = new System.Drawing.Size(28, 13);
            this.LabelLists.TabIndex = 3;
            this.LabelLists.Text = "Lists";
            // 
            // LabelLanguages
            // 
            this.LabelLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelLanguages.AutoSize = true;
            this.LabelLanguages.ForeColor = System.Drawing.Color.White;
            this.LabelLanguages.Location = new System.Drawing.Point(214, 7);
            this.LabelLanguages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLanguages.Name = "LabelLanguages";
            this.LabelLanguages.Size = new System.Drawing.Size(60, 13);
            this.LabelLanguages.TabIndex = 4;
            this.LabelLanguages.Text = "Languages";
            // 
            // ListBoxWordLists
            // 
            this.ListBoxWordLists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ListBoxWordLists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxWordLists.DataSource = this.wordListBindingSource;
            this.ListBoxWordLists.DisplayMember = "Name";
            this.ListBoxWordLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxWordLists.ForeColor = System.Drawing.Color.White;
            this.ListBoxWordLists.FormattingEnabled = true;
            this.ListBoxWordLists.Location = new System.Drawing.Point(0, 20);
            this.ListBoxWordLists.Margin = new System.Windows.Forms.Padding(0);
            this.ListBoxWordLists.Name = "ListBoxWordLists";
            this.ListBoxWordLists.Size = new System.Drawing.Size(212, 172);
            this.ListBoxWordLists.TabIndex = 1;
            this.ListBoxWordLists.TabStop = false;
            this.ListBoxWordLists.SelectedIndexChanged += new System.EventHandler(this.ListBoxWordLists_SelectedIndexChanged);
            this.ListBoxWordLists.DoubleClick += new System.EventHandler(this.ListBoxWordLists_DoubleClick);
            // 
            // TableLayout
            // 
            this.TableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.TableLayout.ColumnCount = 3;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.73066F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.26934F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.TableLayout.Controls.Add(this.ListBoxLanguages, 1, 1);
            this.TableLayout.Controls.Add(this.ListBoxWordLists, 0, 1);
            this.TableLayout.Controls.Add(this.LabelLanguages, 1, 0);
            this.TableLayout.Controls.Add(this.LabelLists, 0, 0);
            this.TableLayout.Controls.Add(this.ButtonNew, 0, 2);
            this.TableLayout.Controls.Add(this.ButtonSelect, 2, 2);
            this.TableLayout.Controls.Add(this.ButtonPractice, 1, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 3;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.TableLayout.Size = new System.Drawing.Size(436, 219);
            this.TableLayout.TabIndex = 7;
            // 
            // ButtonPractice
            // 
            this.ButtonPractice.AutoSize = true;
            this.ButtonPractice.Location = new System.Drawing.Point(212, 192);
            this.ButtonPractice.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonPractice.Name = "ButtonPractice";
            this.ButtonPractice.Size = new System.Drawing.Size(56, 27);
            this.ButtonPractice.TabIndex = 7;
            this.ButtonPractice.Text = "Practice";
            this.ButtonPractice.UseVisualStyleBackColor = true;
            this.ButtonPractice.Click += new System.EventHandler(this.ButtonPractice_Click);
            // 
            // ControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.TableLayout);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlMain";
            this.Size = new System.Drawing.Size(436, 219);
            this.Load += new System.EventHandler(this.ControlMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).EndInit();
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource wordListBindingSource;
        private System.Windows.Forms.ListBox ListBoxLanguages;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.ListBox ListBoxWordLists;
        private System.Windows.Forms.Label LabelLanguages;
        private System.Windows.Forms.Label LabelLists;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.Button ButtonPractice;
    }
}
