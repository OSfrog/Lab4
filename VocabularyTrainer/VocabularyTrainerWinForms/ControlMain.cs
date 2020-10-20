using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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
            Dock = DockStyle.Fill;
        }

        public string SelectedList { get; set; }

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

                ButtonSelect.Enabled = true;
            }
            else
            {
                ButtonSelect.Enabled = false;
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            SelectedList = ListBoxWordLists.SelectedItem.ToString();
            ButtonClicked?.Invoke(this, e);
        }

    }
}
