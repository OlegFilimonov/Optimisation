namespace Optimisation.Тестирование
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

        #region Windows Form1 Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.methodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab1and2RadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.iterCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestedEpsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realEpsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labs1and2 = new System.Windows.Forms.BindingSource(this.components);
            this.lab3 = new System.Windows.Forms.BindingSource(this.components);
            this.lab4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labs1and2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.methodName,
            this.iterCountDataGridViewTextBoxColumn,
            this.answerDataGridViewTextBoxColumn,
            this.realMinDataGridViewTextBoxColumn,
            this.requestedEpsDataGridViewTextBoxColumn,
            this.realEpsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.labs1and2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1075, 573);
            this.dataGridView1.TabIndex = 0;
            // 
            // methodName
            // 
            this.methodName.DataPropertyName = "MethodName";
            this.methodName.HeaderText = "Название";
            this.methodName.Name = "methodName";
            this.methodName.ReadOnly = true;
            this.methodName.Width = 95;
            // 
            // lab1and2RadioButton
            // 
            this.lab1and2RadioButton.AutoSize = true;
            this.lab1and2RadioButton.Checked = true;
            this.lab1and2RadioButton.Location = new System.Drawing.Point(13, 13);
            this.lab1and2RadioButton.Name = "lab1and2RadioButton";
            this.lab1and2RadioButton.Size = new System.Drawing.Size(214, 21);
            this.lab1and2RadioButton.TabIndex = 1;
            this.lab1and2RadioButton.TabStop = true;
            this.lab1and2RadioButton.Text = "Лабораторные работы #1-2";
            this.lab1and2RadioButton.UseVisualStyleBackColor = true;
            this.lab1and2RadioButton.CheckedChanged += new System.EventHandler(this.lab1and2RadioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(233, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(203, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Лабораторная работа №3";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(919, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Экспортировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(442, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(203, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Лабораторная работа №4";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // iterCountDataGridViewTextBoxColumn
            // 
            this.iterCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iterCountDataGridViewTextBoxColumn.DataPropertyName = "IterCount";
            this.iterCountDataGridViewTextBoxColumn.HeaderText = "Итерации";
            this.iterCountDataGridViewTextBoxColumn.Name = "iterCountDataGridViewTextBoxColumn";
            this.iterCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // answerDataGridViewTextBoxColumn
            // 
            this.answerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answerDataGridViewTextBoxColumn.DataPropertyName = "Answer";
            this.answerDataGridViewTextBoxColumn.HeaderText = "Заданный минимум";
            this.answerDataGridViewTextBoxColumn.Name = "answerDataGridViewTextBoxColumn";
            this.answerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // realMinDataGridViewTextBoxColumn
            // 
            this.realMinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.realMinDataGridViewTextBoxColumn.DataPropertyName = "RealMin";
            this.realMinDataGridViewTextBoxColumn.HeaderText = "Фактический минимум";
            this.realMinDataGridViewTextBoxColumn.Name = "realMinDataGridViewTextBoxColumn";
            this.realMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestedEpsDataGridViewTextBoxColumn
            // 
            this.requestedEpsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.requestedEpsDataGridViewTextBoxColumn.DataPropertyName = "RequestedEps";
            this.requestedEpsDataGridViewTextBoxColumn.HeaderText = "Заданная точность";
            this.requestedEpsDataGridViewTextBoxColumn.Name = "requestedEpsDataGridViewTextBoxColumn";
            this.requestedEpsDataGridViewTextBoxColumn.ReadOnly = true;
            this.requestedEpsDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // realEpsDataGridViewTextBoxColumn
            // 
            this.realEpsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.realEpsDataGridViewTextBoxColumn.DataPropertyName = "RealEps";
            this.realEpsDataGridViewTextBoxColumn.HeaderText = "Фактическая точность";
            this.realEpsDataGridViewTextBoxColumn.Name = "realEpsDataGridViewTextBoxColumn";
            this.realEpsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // labs1and2
            // 
            this.labs1and2.DataSource = typeof(Optimisation.Тестирование.ExportOneDim);
            // 
            // lab3
            // 
            this.lab3.DataSource = typeof(Optimisation.Тестирование.ExportOneDim);
            // 
            // lab4
            // 
            this.lab4.DataSource = typeof(Optimisation.Тестирование.ExportOneDim);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 623);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lab1and2RadioButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labs1and2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource labs1and2;
        private System.Windows.Forms.RadioButton lab1and2RadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.BindingSource lab3;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iterCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestedEpsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realEpsDataGridViewTextBoxColumn;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.BindingSource lab4;
    }
}