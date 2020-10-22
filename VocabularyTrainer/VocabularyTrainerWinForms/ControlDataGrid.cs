using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlDataGrid : UserControl
    {
        public event EventHandler DataGridButtons;

        private MainForm mainform;
        private WordList wordlist { get; set; }
        public ControlDataGrid(MainForm form)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            mainform = form;

        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DataGridButtons?.Invoke(this, null);

        }



        private void ControlDataGrid_VisibleChanged(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            DataGrid.Columns.Clear();
            DataGrid.Refresh();

            if (this.Visible == true)
            {
                var wordList = WordList.LoadList(mainform.controlMain.SelectedList);
                wordlist = wordList;

                foreach (var language in wordList.Languages)
                {
                    DataGrid.Columns.Add("C1", language.ToUpper());
                }

                wordList.List(x =>
                {
                    DataGrid.Rows.Add(x);
                });
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Add();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DataGrid.SelectedRows)
            {
                DataGrid.Rows.RemoveAt(item.Index);
            }

            var rowCollection = DataGrid.Rows;
        }
    }
}
