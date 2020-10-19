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
    public partial class ControlMain : UserControl
    {
        public event EventHandler ButtonClicked;
        public ControlMain()
        {
            InitializeComponent();
        }

        private void ControlMain_Load(object sender, EventArgs e)
        {
            wordListBindingSource.DataSource = WordList.GetLists();
            ListBoxWordLists.ClearSelected();
        }

        private void ListBoxWordLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxLanguages.Items.Clear();

            if (ListBoxWordLists.SelectedItem != null)
            {
                var list = WordList.LoadList(ListBoxWordLists.SelectedItem.ToString());

                foreach (var language in list.Languages)
                {
                    ListBoxLanguages.Items.Add(language);
                }
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, null);
        }
    }
}
