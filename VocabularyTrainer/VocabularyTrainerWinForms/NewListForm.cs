using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;
using System.Linq;
using System.Drawing;

namespace VocabularyTrainerWinForms
{
    public partial class NewListForm : Form, ITheme 
    {
        private ControlMain parentControl;
        public NewListForm(ControlMain main)
        {
            InitializeComponent();
            parentControl = main;
        }


        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxName.Text) &&
                !HasSpecialChars(TextBoxName.Text))
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
            else if (HasSpecialChars(TextBoxName.Text))
            {
                MessageBox.Show("List name cannot contain special characters.");
            }
            else
            {
                MessageBox.Show("List name and languages are required to save.");            
            }
        }

        private void NewListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentControl.LoadLists();
        }

        private bool HasSpecialChars(string input)
        {
            return input.Any(x => !char.IsLetterOrDigit(x));
        }
        public void DarkModeOn()
        {
            BackColor = Color.FromArgb(28, 28, 30);

            LabelLanguages.ForeColor = Color.White;
            LabelName.ForeColor = Color.White;
        }

        public void DarkModeOff()
        {
            BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);

            LabelLanguages.ForeColor = Color.Black;
            LabelName.ForeColor = Color.Black;
        }
    }
}
