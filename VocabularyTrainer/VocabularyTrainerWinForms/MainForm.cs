using System;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var controlMain = new ControlMain();
            var dataGrid = new ControlDataGrid();

            controlMain.ButtonClicked += ControlMain_ButtonClicked;

            Controls.Add(controlMain);
        }

        private void ControlMain_ButtonClicked(object sender, EventArgs e)
        {
            Controls.Add(new ControlDataGrid());
        }
    }
}
