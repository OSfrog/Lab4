using System;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class AddWordsForm : Form, ITheme
    {
        private ControlDataGrid parent;
        public AddWordsForm(ControlDataGrid parent)
        {
            InitializeComponent();
            this.parent = parent;
        }


        private void AddWordsForm_Load(object sender, EventArgs e)
        {
            var wordlist = parent.SelectedList;
            ButtonAdd.Enabled = false;

            DataGrid.Columns.Add("Languages", "");
            DataGrid.Columns.Add("Words", "");

            foreach (var language in wordlist.Languages)
            {
                DataGrid.Rows.Add(language);
            }

            var rowHeight = DataGrid.ColumnHeadersHeight + DataGrid.Rows.Cast<DataGridViewRow>().Sum(r => r.Height); //Scales the form after the datagrid.
            Panel.Size = new Size(Panel.Size.Width, Panel.Size.Height - (Panel.Size.Height - rowHeight + 20));
            ClientSize = new Size(ClientSize.Width, Height - (ClientSize.Height - rowHeight + 20));
        }

        private void DataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) //Check if any cell doesn't have a value to disable/enable add button.
        {
            for (int i = 0; i < (DataGrid.Rows.Count); i++)
            {
                if (DataGrid.Rows[i].Cells["Words"].Value == null)
                {
                    ButtonAdd.Enabled = false;
                    break;
                }
                else if (string.IsNullOrWhiteSpace(DataGrid.Rows[i].Cells["Words"].Value.ToString()))
                {
                    ButtonAdd.Enabled = false;
                    break;
                }
                else
                {
                    ButtonAdd.Enabled = true;
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var wordArray = new string[parent.SelectedList.Languages.Length];
            for (int i = 0; i < (DataGrid.Rows.Count); i++)
            {
                wordArray[i] = DataGrid.Rows[i].Cells["Words"].Value.ToString();
            }
            parent.SelectedList.Add(wordArray);
            parent.SelectedList.Save();
            parent.RefreshList();
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DarkModeOn()
        {
            DataGrid.BackgroundColor = Color.FromArgb(44, 44, 46);
            DataGrid.GridColor = Color.White;
            DataGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 46);
            DataGrid.RowsDefaultCellStyle.ForeColor = Color.White;

            BackColor = Color.FromArgb(28, 28, 30);
        }

        public void DarkModeOff()
        {
            DataGrid.BackgroundColor = Color.White;
            DataGrid.GridColor = Color.FromKnownColor(KnownColor.ControlDark);
            DataGrid.RowsDefaultCellStyle.BackColor = Color.White;
            DataGrid.RowsDefaultCellStyle.ForeColor = Color.Black;

            BackColor = Color.White;
        }
    }
}
