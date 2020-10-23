namespace VocabularyTrainerWinForms
{
    partial class AddWordsForm
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
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(-1, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.DataGrid.Size = new System.Drawing.Size(248, 173);
            this.DataGrid.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ForeColor = System.Drawing.Color.Black;
            this.ButtonCancel.Location = new System.Drawing.Point(12, 187);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ForeColor = System.Drawing.Color.Black;
            this.ButtonAdd.Location = new System.Drawing.Point(159, 187);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // AddWordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(246, 222);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.DataGrid);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddWordsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add word";
            this.Load += new System.EventHandler(this.AddWordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonAdd;
    }
}