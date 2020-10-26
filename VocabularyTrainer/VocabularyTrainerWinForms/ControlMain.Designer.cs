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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).BeginInit();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
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
            this.ListBoxWordLists.ItemHeight = 24;
            this.ListBoxWordLists.Location = new System.Drawing.Point(4, 41);
            this.ListBoxWordLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBoxWordLists.Name = "ListBoxWordLists";
            this.ListBoxWordLists.Size = new System.Drawing.Size(391, 309);
            this.ListBoxWordLists.TabIndex = 1;
            this.ListBoxWordLists.TabStop = false;
            this.ListBoxWordLists.SelectedIndexChanged += new System.EventHandler(this.ListBoxWordLists_SelectedIndexChanged);
            this.ListBoxWordLists.DoubleClick += new System.EventHandler(this.ListBoxWordLists_DoubleClick);
            // 
            // wordListBindingSource
            // 
            this.wordListBindingSource.DataSource = typeof(VocabularyTrainerLibrary.WordList);
            // 
            // ListBoxLanguages
            // 
            this.ListBoxLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.ListBoxLanguages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxLanguages.ForeColor = System.Drawing.Color.White;
            this.ListBoxLanguages.FormattingEnabled = true;
            this.ListBoxLanguages.ItemHeight = 24;
            this.ListBoxLanguages.Location = new System.Drawing.Point(403, 41);
            this.ListBoxLanguages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBoxLanguages.Name = "ListBoxLanguages";
            this.ListBoxLanguages.Size = new System.Drawing.Size(392, 309);
            this.ListBoxLanguages.TabIndex = 2;
            this.ListBoxLanguages.TabStop = false;
            // 
            // LabelLists
            // 
            this.LabelLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelLists.AutoSize = true;
            this.LabelLists.ForeColor = System.Drawing.Color.White;
            this.LabelLists.Location = new System.Drawing.Point(4, 12);
            this.LabelLists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLists.Name = "LabelLists";
            this.LabelLists.Size = new System.Drawing.Size(52, 25);
            this.LabelLists.TabIndex = 3;
            this.LabelLists.Text = "Lists";
            // 
            // LabelLanguages
            // 
            this.LabelLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelLanguages.AutoSize = true;
            this.LabelLanguages.ForeColor = System.Drawing.Color.White;
            this.LabelLanguages.Location = new System.Drawing.Point(403, 12);
            this.LabelLanguages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLanguages.Name = "LabelLanguages";
            this.LabelLanguages.Size = new System.Drawing.Size(110, 25);
            this.LabelLanguages.TabIndex = 4;
            this.LabelLanguages.Text = "Languages";
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelect.AutoSize = true;
            this.ButtonSelect.ForeColor = System.Drawing.Color.Black;
            this.ButtonSelect.Location = new System.Drawing.Point(654, 358);
            this.ButtonSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(141, 42);
            this.ButtonSelect.TabIndex = 5;
            this.ButtonSelect.Text = "Select";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonNew
            // 
            this.ButtonNew.ForeColor = System.Drawing.Color.Black;
            this.ButtonNew.Location = new System.Drawing.Point(4, 358);
            this.ButtonNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(86, 42);
            this.ButtonNew.TabIndex = 6;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // TableLayout
            // 
            this.TableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.Controls.Add(this.ListBoxLanguages, 1, 1);
            this.TableLayout.Controls.Add(this.ListBoxWordLists, 0, 1);
            this.TableLayout.Controls.Add(this.LabelLanguages, 1, 0);
            this.TableLayout.Controls.Add(this.LabelLists, 0, 0);
            this.TableLayout.Controls.Add(this.ButtonSelect, 1, 2);
            this.TableLayout.Controls.Add(this.ButtonNew, 0, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 3;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayout.Size = new System.Drawing.Size(799, 404);
            this.TableLayout.TabIndex = 7;
            // 
            // ControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.TableLayout);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControlMain";
            this.Size = new System.Drawing.Size(799, 404);
            this.Load += new System.EventHandler(this.ControlMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordListBindingSource)).EndInit();
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxWordLists;
        private System.Windows.Forms.ListBox ListBoxLanguages;
        private System.Windows.Forms.Label LabelLists;
        private System.Windows.Forms.Label LabelLanguages;
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.BindingSource wordListBindingSource;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
    }
}
