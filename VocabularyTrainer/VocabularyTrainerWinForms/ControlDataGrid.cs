using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerWinForms
{
    public partial class ControlDataGrid : UserControl
    {

        private MainForm mainform;
        public ControlDataGrid(MainForm form)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            mainform = form;
            
        }

        private void ControlDataGrid_Load(object sender, EventArgs e)
        {
            var wordList = WordList.LoadList(mainform.controlMain.SelectedList);

            //DataGrid.DataSource = wordList;
            foreach (var language in wordList.Languages)
            {
                DataGrid.Columns.Add("C1", language.ToUpper());
            }



            wordList.List(x =>
            {
                DataGrid.Rows.Add(x);
            });


        }
    }
}
