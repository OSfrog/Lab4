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
using System.Threading;

namespace VocabularyTrainerWinForms
{
    public partial class ControlPractice : UserControl
    {
        private MainForm mainform;
        private WordList Wordlist => WordList.LoadList(mainform.controlMain.SelectedList);
        private Word word;
        public ControlPractice(MainForm form)
        {
            InitializeComponent();
            mainform = form;
        }

        public int WordCounter { get; set; }
        public int CorrectCounter { get; set; }

        private void ButtonEndPractice_Click(object sender, EventArgs e)
        {
            
        }

        private void ControlPractice_Load(object sender, EventArgs e)
        {
            Practice();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Text == word.Translations[word.ToLanguage])
                {
                    textBox.Clear();

                    WordCounter++;
                    CorrectCounter++;
                }
                else
                {
                    textBox.Clear();
                    WordCounter++;
                    MessageBox.Show($"The correct answer was {word.Translations[word.ToLanguage]}.", "Incorrect answer");
                }
                    LabelWordCounter.Text = $"{CorrectCounter} of {WordCounter} words were correct.";
                    LabelWordCounter.Visible = true;
                Practice();
            }
        }

        private void Practice()
        {
            var languagearray = Wordlist.Languages;
            word = Wordlist.GetWordToPractice();
            LabelTranslations.Text = $"Translate the {languagearray[word.FromLanguage]} word {word.Translations[word.FromLanguage]}" +
                $" to {languagearray[word.ToLanguage]}.";
        }
    }
}
