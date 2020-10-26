using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;
using System.Linq;

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
            if (!string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                var listName = TextBoxName.Text;
                var languages = TextBoxLanguages.Lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                
                if (languages.Length >= 2)
                {
                var newList = new WordList(listName, languages);
                newList.Save();
                Close();
                }
                else
                {
                    MessageBox.Show("Minimum of 2 languages are required to save.");
                }
            }
            else
            {
                MessageBox.Show("List name and languages are required to save.");
                            
            }
        }

        private void NewListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.LoadLists();
        }
    }
}
