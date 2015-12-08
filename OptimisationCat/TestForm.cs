using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Application=Microsoft.Office.Interop.Excel.Application;

namespace OptimisationCat
{
    public partial class TestForm : MaterialForm
    {
        private List<TestExport> _exports; 

        public TestForm(List<TestExport> exports)
        {
            _exports = exports;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500,
                Accent.LightBlue200, TextShade.WHITE);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            foreach (var export in _exports)
            {
                testExportBindingSource.Add(export);
            }
        }
        private void ToCsV()
        {
            if (dataGridView1.Rows.Count <= 0) return;
            var xcelApp = new Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (var i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (var j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(',', '.');
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ToCsV();
        }
    }
}
