using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlMain : UserControl
    {
        public event EventHandler buttonHandler;
        public event EventHandler practiceHandler;
        public ControlMain()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public string SelectedList
        {
            get { return ListBoxWordLists.SelectedItem?.ToString(); }
        }


        private void ControlMain_Load(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void ListBoxWordLists_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxWordLists.SelectedItem != null)
            {
                buttonHandler?.Invoke(this, null);
            }
        }

        private void ListBoxWordLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxLanguages.Items.Clear();

            if (ListBoxWordLists.SelectedItem != null &&
                 !string.IsNullOrWhiteSpace(ListBoxWordLists.SelectedItem.ToString()))
            {
                var list = WordList.LoadList(SelectedList);
                foreach (var language in list.Languages)
                {
                    ListBoxLanguages.Items.Add(language);
                }

                ButtonSelect.Enabled = true;

                LabelListAndWordCount();
            }
            else
            {
                ButtonSelect.Enabled = false;
            }

        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            buttonHandler?.Invoke(this, null);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            var listForm = new NewListForm(this);
            listForm.ShowDialog();
        }


        private void ButtonPractice_Click(object sender, EventArgs e)
        {
            if (ListBoxWordLists.SelectedItem != null &&
                WordList.LoadList(SelectedList).Count() != 0 &&
                WordList.LoadList(SelectedList).Languages.Length > 1)
            {
                practiceHandler?.Invoke(this, null);
            }
            else
            {
                MessageBox.Show("List must contain words or at least 2 languages to practice.", "Error");
            }
        }
        public void LoadLists()
        {
            wordListBindingSource.DataSource = WordList.GetLists();
            ListBoxWordLists.ClearSelected();
        }

        public void LabelListAndWordCount()
        {
            var text = WordList.LoadList(SelectedList) != null ? $"Lists                            " +
                    $"Words: {WordList.LoadList(SelectedList).Count()}" : "Lists";
            
            LabelLists.Text = text;
        }
    }
}
