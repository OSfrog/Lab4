using System;
using System.Windows.Forms;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public ControlMain controlMain;
        private ControlDataGrid controlDataGrid;
        private ControlPractice controlPractice;
        public MainForm()
        {
            InitializeComponent();

            controlMain = new ControlMain(this);
            controlDataGrid = new ControlDataGrid(this);
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

        public bool DarkMode { get; set; }

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
            if (DarkMode)
            {
                newListForm.DarkModeOn();
            }
            else
            {
                newListForm.DarkModeOff();
            }
                newListForm.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            controlMain.LoadLists();
        }

        private void darkModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (darkModeToolStripMenuItem.Checked == true)
            {
                DarkMode = true;
                controlMain.DarkModeOn();
                controlPractice.DarkModeOn();
                
            }
            else
            {
                DarkMode = false;
                controlMain.DarkModeOff();
                controlPractice.DarkModeOff();
            }
        }
    }

}
