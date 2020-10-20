using System;
using System.Windows.Forms;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public ControlMain controlMain = new ControlMain();
        public ControlDataGrid dataGrid = new ControlDataGrid();
        public MainForm()
        {
            InitializeComponent();

            controlMain.ButtonClicked += ControlMain_ButtonClicked;

            Controls.Add(controlMain);
        }

        private void ControlMain_ButtonClicked(object sender, EventArgs e)
        {
            controlMain.Visible = false;
            Controls.Add(dataGrid);
        }
    }
}
