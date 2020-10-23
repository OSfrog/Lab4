using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class AddWordsForm : Form
    {
        private ControlDataGrid parent;
        public AddWordsForm(ControlDataGrid parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddWordsForm_Load(object sender, EventArgs e)
        {
            var wordlist = parent.SelectedList;

            foreach (var language in wordlist.Languages)
            {
                DataGrid.Columns.Add("C1", "");
            }

            foreach (var language in wordlist.Languages)
            {
                DataGrid.Rows.Add(language);
            }
        }
    }
}
