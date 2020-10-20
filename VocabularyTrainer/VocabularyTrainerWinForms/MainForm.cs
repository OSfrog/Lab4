using System;
using System.Windows.Forms;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public ControlMain controlMain = new ControlMain();
        public ControlDataGrid dataGrid = new ControlDataGrid();
        public static string SelectedList { get; set; }
        public MainForm()
        {
            InitializeComponent();

            controlMain.ButtonClicked += ControlMain_ButtonClicked;

            Controls.Add(controlMain);
        }

        private void ControlMain_ButtonClicked(object sender, EventArgs e)
        {
            controlMain.Visible = false;
            SelectedList = controlMain.SelectedList;
            Controls.Add(dataGrid);
        }
    }
}
