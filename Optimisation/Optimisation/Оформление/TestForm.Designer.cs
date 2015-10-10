namespace Optimisation.Оформление
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.testOutputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testOutputBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.func1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.func2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.func3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.func4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.func1,
            this.func2,
            this.func3,
            this.func4});
            this.dataGridView1.DataSource = this.testOutputBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(765, 420);
            this.dataGridView1.TabIndex = 0;
            // 
            // testOutputBindingSource
            // 
            this.testOutputBindingSource.DataSource = typeof(Optimisation.Тестирование.TestOutput);
            // 
            // testOutputBindingSource1
            // 
            this.testOutputBindingSource1.DataSource = typeof(Optimisation.Тестирование.TestOutput);
            // 
            // func1
            // 
            this.func1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.func1.HeaderText = "Функция #1";
            this.func1.Name = "func1";
            this.func1.ReadOnly = true;
            this.func1.Width = 116;
            // 
            // func2
            // 
            this.func2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.func2.HeaderText = "Функция #2";
            this.func2.Name = "func2";
            this.func2.ReadOnly = true;
            this.func2.Width = 116;
            // 
            // func3
            // 
            this.func3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.func3.HeaderText = "Функция #3";
            this.func3.Name = "func3";
            this.func3.ReadOnly = true;
            this.func3.Width = 116;
            // 
            // func4
            // 
            this.func4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.func4.HeaderText = "Функция #4";
            this.func4.Name = "func4";
            this.func4.ReadOnly = true;
            this.func4.Width = 116;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 444);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn func1;
        private System.Windows.Forms.DataGridViewTextBoxColumn func2;
        private System.Windows.Forms.DataGridViewTextBoxColumn func3;
        private System.Windows.Forms.DataGridViewTextBoxColumn func4;
        private System.Windows.Forms.BindingSource testOutputBindingSource;
        private System.Windows.Forms.BindingSource testOutputBindingSource1;
    }
}