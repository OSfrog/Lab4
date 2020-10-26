using System;
using System.Windows.Forms;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public ControlMain controlMain = new ControlMain();
        private ControlDataGrid controlDataGrid;
        private ControlPractice controlPractice;
        public MainForm()
        {
            InitializeComponent();

            controlDataGrid  = new ControlDataGrid(this);
            controlPractice = new ControlPractice(this);
            controlMain.buttonHandler += ControlMain_DoubleClick;
            controlMain.practiceHandler += ControlMain_practiceButton;
            controlDataGrid.buttonHandler += DataGrid_ButtonBack;
            

            Panel.Controls.Add(controlPractice);
            Panel.Controls.Add(controlMain);
            Panel.Controls.Add(controlDataGrid);
            controlDataGrid.Visible = false;
            controlPractice.Visible = false;
        }

        private void ControlMain_practiceButton(object sender, EventArgs e)
        {
            controlMain.Visible = false;
            controlDataGrid.Visible = false;
            controlPractice.Visible = true;
        }

        private void DataGrid_ButtonBack(object sender, EventArgs e)
        {
            controlPractice.Visible = false;
            controlDataGrid.Visible = false;
            controlMain.Visible = true;
        }

        private void ControlMain_DoubleClick(object sender, EventArgs e)
        {
            controlPractice.Visible = false;
            controlMain.Visible = false;
            controlDataGrid.Visible = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newListForm = new NewListForm(controlMain);
            newListForm.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            controlMain.LoadLists();
        }
    }
}
