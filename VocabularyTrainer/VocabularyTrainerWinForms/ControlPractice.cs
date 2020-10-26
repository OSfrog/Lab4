using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlPractice : UserControl
    {
        private MainForm mainform;
        private WordList wordlist;
        private Word word;
        public ControlPractice(MainForm form)
        {
            InitializeComponent();
            mainform = form;
        }

        private string SelectedList => mainform.controlMain.SelectedList;
        public int WordCounter { get; set; }
        public int CorrectCounter { get; set; }

        private void ControlPractice_VisibleChanged(object sender, EventArgs e)
        {
            if (SelectedList != null)
            {
                Practice();
            }
        }
        private void ControlPractice_Load(object sender, EventArgs e)
        {
            Practice();
        }
        private void ButtonEndPractice_Click(object sender, EventArgs e)
        {
            Visible = false;
            WordCounter = 0;
            CorrectCounter = 0;
            LabelWordCounter.Visible = false;
            mainform.controlMain.Visible = true;
        }
        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            WordCounter = 0;
            CorrectCounter = 0;
            LabelWordCounter.Visible = false;
            Practice();
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Text.ToLower() == word.Translations[word.ToLanguage].ToLower())
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
            if (WordList.LoadList(SelectedList) != null)
            {
                wordlist = WordList.LoadList(SelectedList);
            }
            var languagearray = wordlist.Languages;
            word = wordlist.GetWordToPractice();
            LabelTranslations.Text = $"Translate the {languagearray[word.FromLanguage]} word {word.Translations[word.FromLanguage]}" +
                $" to {languagearray[word.ToLanguage]}.";
        }

    }
}
