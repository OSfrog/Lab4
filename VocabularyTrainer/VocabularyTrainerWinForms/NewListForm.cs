using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class NewListForm : Form
    {
        public NewListForm()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxName.Text) && !string.IsNullOrEmpty(TextBoxLanguages.Text))
            {
                var listName = TextBoxName.Text;
                var languages = TextBoxLanguages.Lines;

                var newList = new WordList(listName, languages);
                newList.Save();
                
                Close();
            }
            else
            {
                MessageBox.Show("List name and languages is required to save.");
            }
        }
    }
}
