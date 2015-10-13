using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Optimisation.Базовые_и_вспомогательные;
using Application = Microsoft.Office.Interop.Excel.Application;
// ReSharper disable NotAccessedField.Local

namespace Optimisation.Тестирование
{
    public partial class TestForm : Form
    {
        private List<FunctionHolder> _lab1And2Functions;
        private readonly List<List<ExportOneDim>> _lab1And2List;
        private List<FunctionHolder> _lab3Functions;
        private readonly List<List<ExportOneDim>> _lab3List;

        public TestForm(List<List<ExportOneDim>> lab1And2List, List<FunctionHolder> lab1And2Functions,
            List<List<ExportOneDim>> lab3List, List<FunctionHolder> lab3Functions)
        {
            _lab1And2List = lab1And2List;
            _lab1And2Functions = lab1And2Functions;
            _lab3List = lab3List;
            _lab3Functions = lab3Functions;
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            foreach (var export in _lab1And2List.SelectMany(exportList => exportList))
            {
                labs1and2.Add(export);
            }

            foreach (var export in _lab3List.SelectMany(exportList => exportList))
            {
                lab3.Add(export);
            }
        }

        private void lab1and2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = labs1and2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lab3;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ToCsV();
        }
    }
}