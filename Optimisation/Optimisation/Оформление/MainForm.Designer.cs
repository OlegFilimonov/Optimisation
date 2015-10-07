namespace Optimisation
{
    partial class MainForm
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
            this.graph = new FPlotLibrary.GraphControl();
            this.functionList1 = new System.Windows.Forms.ComboBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startingPoint1 = new System.Windows.Forms.NumericUpDown();
            this.startingEps1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.methodList1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diffBox1 = new System.Windows.Forms.TextBox();
            this.iterBox1 = new System.Windows.Forms.TextBox();
            this.minBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lab1tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startingPoint1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.lab1tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graph.BackColor = System.Drawing.Color.White;
            this.graph.Border = true;
            this.graph.Cursor = System.Windows.Forms.Cursors.Cross;
            this.graph.FixYtoX = false;
            this.graph.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.graph.Legend = false;
            this.graph.Location = new System.Drawing.Point(1, 227);
            this.graph.Margin = new System.Windows.Forms.Padding(4);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(1022, 497);
            this.graph.TabIndex = 1;
            this.graph.Text = "graph";
            this.graph.x0 = -20D;
            this.graph.x1 = 20D;
            this.graph.xAxis = true;
            this.graph.xGrid = true;
            this.graph.xRaster = true;
            this.graph.xScale = true;
            this.graph.y0 = -27D;
            this.graph.y1 = -21D;
            this.graph.yAxis = true;
            this.graph.yGrid = true;
            this.graph.yRaster = true;
            this.graph.yScale = true;
            this.graph.z0 = 0D;
            this.graph.z1 = 1D;
            this.graph.zScale = false;
            // 
            // functionList1
            // 
            this.functionList1.FormattingEnabled = true;
            this.functionList1.Location = new System.Drawing.Point(125, 32);
            this.functionList1.Margin = new System.Windows.Forms.Padding(4);
            this.functionList1.Name = "functionList1";
            this.functionList1.Size = new System.Drawing.Size(327, 24);
            this.functionList1.TabIndex = 3;
            this.functionList1.SelectedIndexChanged += new System.EventHandler(this.functionList1_SelectedIndexChanged);
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Location = new System.Drawing.Point(17, 34);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(67, 17);
            this.functionLabel.TabIndex = 4;
            this.functionLabel.Text = "Функция";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startingPoint1);
            this.groupBox1.Controls.Add(this.startingEps1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.methodList1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.functionLabel);
            this.groupBox1.Controls.Add(this.functionList1);
            this.groupBox1.Location = new System.Drawing.Point(18, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(477, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // startingPoint1
            // 
            this.startingPoint1.Location = new System.Drawing.Point(147, 111);
            this.startingPoint1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.startingPoint1.Name = "startingPoint1";
            this.startingPoint1.Size = new System.Drawing.Size(120, 22);
            this.startingPoint1.TabIndex = 6;
            this.startingPoint1.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.startingPoint1.ValueChanged += new System.EventHandler(this.startingPoint1_ValueChanged);
            // 
            // startingEps1
            // 
            this.startingEps1.Location = new System.Drawing.Point(368, 109);
            this.startingEps1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startingEps1.Name = "startingEps1";
            this.startingEps1.Size = new System.Drawing.Size(84, 22);
            this.startingEps1.TabIndex = 0;
            this.startingEps1.Text = "1e-2";
            this.startingEps1.TextChanged += new System.EventHandler(this.startingEps1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Точность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Начальная точка";
            // 
            // methodList1
            // 
            this.methodList1.FormattingEnabled = true;
            this.methodList1.Location = new System.Drawing.Point(125, 71);
            this.methodList1.Margin = new System.Windows.Forms.Padding(4);
            this.methodList1.Name = "methodList1";
            this.methodList1.Size = new System.Drawing.Size(327, 24);
            this.methodList1.TabIndex = 3;
            this.methodList1.SelectedIndexChanged += new System.EventHandler(this.methodList1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Метод";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.diffBox1);
            this.groupBox2.Controls.Add(this.iterBox1);
            this.groupBox2.Controls.Add(this.minBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(501, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(478, 148);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель вывода";
            // 
            // diffBox1
            // 
            this.diffBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diffBox1.Location = new System.Drawing.Point(122, 110);
            this.diffBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diffBox1.Name = "diffBox1";
            this.diffBox1.ReadOnly = true;
            this.diffBox1.Size = new System.Drawing.Size(342, 22);
            this.diffBox1.TabIndex = 0;
            this.diffBox1.Text = " ";
            // 
            // iterBox1
            // 
            this.iterBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iterBox1.Location = new System.Drawing.Point(122, 71);
            this.iterBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iterBox1.Name = "iterBox1";
            this.iterBox1.ReadOnly = true;
            this.iterBox1.Size = new System.Drawing.Size(342, 22);
            this.iterBox1.TabIndex = 0;
            // 
            // minBox1
            // 
            this.minBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minBox1.Location = new System.Drawing.Point(122, 32);
            this.minBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minBox1.Name = "minBox1";
            this.minBox1.ReadOnly = true;
            this.minBox1.Size = new System.Drawing.Size(342, 22);
            this.minBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Разница A-B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Итерации";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Минимум";
            // 
            // lab1tab
            // 
            this.lab1tab.Controls.Add(this.tabPage1);
            this.lab1tab.Controls.Add(this.tabPage2);
            this.lab1tab.Controls.Add(this.tabPage3);
            this.lab1tab.Controls.Add(this.tabPage4);
            this.lab1tab.Controls.Add(this.tabPage5);
            this.lab1tab.Controls.Add(this.tabPage6);
            this.lab1tab.Controls.Add(this.tabPage7);
            this.lab1tab.Location = new System.Drawing.Point(20, 14);
            this.lab1tab.Name = "lab1tab";
            this.lab1tab.SelectedIndex = 0;
            this.lab1tab.Size = new System.Drawing.Size(997, 206);
            this.lab1tab.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(989, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Лабораторная #1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(989, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Лабораторная #2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(989, 177);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Лабораторная #3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(989, 177);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Лабораторная #4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(989, 177);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Лабораторная #5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(989, 177);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Лабораторная #6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(989, 177);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Лабораторная #7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Location = new System.Drawing.Point(14, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(477, 148);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Панель ввода";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(147, 111);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(368, 109);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1e-2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Точность";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Начальная точка";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 71);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(327, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Метод";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Функция";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(125, 32);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(327, 24);
            this.comboBox2.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(497, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(478, 148);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Панель вывода";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Location = new System.Drawing.Point(122, 110);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(342, 22);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = " ";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox3.Location = new System.Drawing.Point(122, 71);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(342, 22);
            this.textBox3.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Location = new System.Drawing.Point(122, 32);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(342, 22);
            this.textBox4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Разница A-B";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Итерации";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Минимум";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 729);
            this.Controls.Add(this.lab1tab);
            this.Controls.Add(this.graph);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startingPoint1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.lab1tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FPlotLibrary.GraphControl graph;
        private System.Windows.Forms.ComboBox functionList1;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox methodList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox minBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iterBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startingEps1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diffBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startingPoint1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl lab1tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}