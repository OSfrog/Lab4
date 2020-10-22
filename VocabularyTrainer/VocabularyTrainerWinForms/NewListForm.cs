using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class NewListForm : Form
    {
        private ControlMain main;
        public NewListForm(ControlMain main)
        {
            this.main = main;
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
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("List name and languages is required to save.");
            }
        }

        private void NewListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.LoadLists();
        }
    }
}
