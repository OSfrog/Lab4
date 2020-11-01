using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlDataGrid : UserControl
    {
        public event EventHandler buttonHandler;

        private MainForm mainform;
        public WordList SelectedList { get; set; }
        public ControlDataGrid(MainForm form)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            mainform = form;

        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            buttonHandler?.Invoke(this, null);
            mainform.controlMain.LabelListAndWordCount();
        }




        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addWordsForm = new AddWordsForm(this);
            addWordsForm.ShowDialog(this);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (mainform.controlMain.SelectedList != null || SelectedList != null)
            {
                if (SelectedList == null || mainform.controlMain.SelectedList != null)
                {
                    SelectedList = WordList.LoadList(mainform.controlMain.SelectedList);
                }

                if (DataGrid.SelectedRows.Count != 0)
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
            }
        }
        private void ControlDataGrid_VisibleChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();

            if (mainform.controlMain.SelectedList != null || SelectedList != null)
            {
                if (SelectedList == null || mainform.controlMain.SelectedList != null)
                {
                    SelectedList = WordList.LoadList(mainform.controlMain.SelectedList);
                }

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
    }
}
