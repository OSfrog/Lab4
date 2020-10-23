using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;
using System.Drawing;

namespace VocabularyTrainerWinForms
{
    public partial class ControlDataGrid : UserControl
    {
        public event EventHandler DataGridButtons;

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
            DataGridButtons?.Invoke(this, null);
            mainform.controlMain.LabelListAndWordCount();
        }



        private void ControlDataGrid_VisibleChanged(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();
            DataGrid.Refresh();

            if (Visible == true)
            {
                SelectedList = WordList.LoadList(mainform.controlMain.SelectedList);

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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addWordsForm = new AddWordsForm(this);
            addWordsForm.ShowDialog(this);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            var wordlist = WordList.LoadList(mainform.controlMain.SelectedList);
            foreach (DataGridViewRow item in DataGrid.SelectedRows) //Remove the row in the datagrid
            {
                DataGrid.Rows.RemoveAt(item.Index);
            }

            var newWordList = new WordList(wordlist.Name, wordlist.Languages);

            for (int i = 0; i < DataGrid.Rows.Count; i++) //Save the new words and write to the list.
            {
                var words = new string[wordlist.Languages.Length];
                if (DataGrid.Rows.Count != 0)
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        words[j] = DataGrid.Rows[i].Cells[j].Value.ToString();
                    }

                    newWordList.Add(words);
                    newWordList.Save();
                }
            }
            if (DataGrid.Rows.Count == 0)
            {
                newWordList.Save();
            }
        }
    }
}
