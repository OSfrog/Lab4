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

            controlMain.Clicked += ControlMain_DoubleClick;
            dataGrid  = new ControlDataGrid(this);

            Panel.Controls.Add(controlMain);
        }

        private void ControlMain_DoubleClick(object sender, EventArgs e)
        {
            controlMain.Visible = false;
            Panel.Controls.Add(dataGrid);
        }
    }
}
