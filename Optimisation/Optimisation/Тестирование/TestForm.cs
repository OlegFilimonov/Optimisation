using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Optimisation.Оформление
{
    public partial class TestForm : Form
    {
        private List<ExportOneDim> lab1and2List; 
         
        public TestForm(List<ExportOneDim> lab1and2List)
        {
            this.lab1and2List = lab1and2List;
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            foreach (var export in lab1and2List)
            {
                labs1and2.Add(export);
            }
        }
    }
}
