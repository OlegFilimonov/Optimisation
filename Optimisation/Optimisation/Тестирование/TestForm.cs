using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Тестирование;

namespace Optimisation.Оформление
{
    public partial class TestForm : Form
    {
        private List<List<ExportOneDim>> lab1and2List;
        private List<Function> lab1And2Functions;
        private List<List<ExportOneDim>> lab3List;
        private List<Function> lab3Functions;

        public TestForm(List<List<ExportOneDim>> lab1and2List, List<Function> lab1And2Functions, List<List<ExportOneDim>> lab3List, List<Function> lab3Functions)
        {
            this.lab1and2List = lab1and2List;
            this.lab1And2Functions = lab1And2Functions;
            this.lab3List = lab3List;
            this.lab3Functions = lab3Functions;
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            foreach (var export in lab1and2List.SelectMany(exportList => exportList))
            {
                labs1and2.Add(export);
            }

            foreach (var export in lab3List.SelectMany(exportList => exportList))
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
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ToCsV(); 

        }
    }
}
