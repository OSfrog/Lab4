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
            parentControl = main;
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
            parentControl.LoadLists();
        }
        public void DarkMode()
        {
            BackColor = Color.FromArgb(28, 28, 30);

            LabelLanguages.ForeColor = Color.White;
            LabelName.ForeColor = Color.White;
        }

        public void ResetMode()
        {
            throw new NotImplementedException();
        }
    }
}
