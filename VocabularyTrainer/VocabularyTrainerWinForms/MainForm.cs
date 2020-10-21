using System;
using System.Windows.Forms;

namespace VocabularyTrainerWinForms
{
    public partial class MainForm : Form
    {
        public ControlMain controlMain = new ControlMain();
        private ControlDataGrid dataGrid;
        public MainForm()
        {
            InitializeComponent();

            dataGrid  = new ControlDataGrid(this);
            controlMain.MainButtons += ControlMain_DoubleClick;
            dataGrid.DataGridButtons += DataGrid_ButtonBack;

            Panel.Controls.Add(controlMain);
            Panel.Controls.Add(dataGrid);
        }

        private void DataGrid_ButtonBack(object sender, EventArgs e)
        {
            dataGrid.Visible = false;
            controlMain.Visible = true;
        }

        private void ControlMain_DoubleClick(object sender, EventArgs e)
        {
            controlMain.Visible = false;
            dataGrid.Visible = true;
        }
    }
}
