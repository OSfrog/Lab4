using System;
using System.Drawing;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlDataGrid : UserControl, ITheme
    {
        public event EventHandler buttonHandler;

        private MainForm parentform;
        public WordList SelectedList { get; set; }
        public ControlDataGrid(MainForm form)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            parentform = form;

        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            buttonHandler?.Invoke(this, null);
            parentform.controlMain.LabelListAndWordCount();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addWordsForm = new AddWordsForm(this);
            if (parentform.DarkMode)
            {
                addWordsForm.DarkModeOn();
            }
            else
            {
                addWordsForm.DarkModeOff();
            }
            addWordsForm.ShowDialog(this);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            NullCheck();

            if (DataGrid.SelectedRows.Count != 0 && SelectedList != null)
            {
                var selectedRowItems = DataGrid.SelectedRows;
                foreach (DataGridViewRow item in selectedRowItems) //Remove the row in the datagrid
                {
                    DataGrid.Rows.RemoveAt(item.Index);
                }

                var wordToRemove = selectedRowItems[0].Cells[0].Value.ToString();
                SelectedList.Remove(0, wordToRemove);
                SelectedList.Save();
            }

            ButtonRemove.Enabled = DataGrid.Rows.Count != 0;
        }
        private void DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ButtonRemove.Enabled = DataGrid.Rows.Count != 0;
        }

        private void ControlDataGrid_VisibleChanged(object sender, EventArgs e)
        {
            RefreshList();

            ButtonRemove.Enabled = DataGrid.Rows.Count != 0;
        }

        public void RefreshList()
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();

            NullCheck();

            if (SelectedList != null)
            {
                foreach (var language in SelectedList.Languages)
                {
                    DataGrid.Columns.Add("C1", language.ToUpper());
                }

                SelectedList.List(x =>
                {
                    DataGrid.Rows.Add(x);
                });
            }
        }

        public void DarkModeOn()
        {
            TableLayoutPanel.BackColor = Color.FromArgb(28, 28, 30);

            DataGrid.BackgroundColor = Color.FromArgb(44, 44, 46);
            DataGrid.GridColor = Color.White;
            DataGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 46);
            DataGrid.RowsDefaultCellStyle.ForeColor = Color.White;
        }

        public void DarkModeOff()
        {
            TableLayoutPanel.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);

            DataGrid.BackgroundColor = Color.White;
            DataGrid.GridColor = Color.FromKnownColor(KnownColor.ControlDark);
            DataGrid.RowsDefaultCellStyle.BackColor = Color.White;
            DataGrid.RowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void NullCheck()  //Saves the current list before the new form will make the SelectedList property null.
        {
            if (parentform.controlMain.SelectedList != null || SelectedList != null)
            {
                if (SelectedList == null || parentform.controlMain.SelectedList != null)
                {
                    SelectedList = WordList.LoadList(parentform.controlMain.SelectedList);
                }
            }
        }

    }
}
