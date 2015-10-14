namespace Optimisation.Оформление
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
            this.startBox1 = new System.Windows.Forms.NumericUpDown();
            this.epsBox1 = new System.Windows.Forms.TextBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.startBox2 = new System.Windows.Forms.NumericUpDown();
            this.epsBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.methodList2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.functionList2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.diffBox2 = new System.Windows.Forms.TextBox();
            this.iterBox2 = new System.Windows.Forms.TextBox();
            this.minBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.startBox3x2 = new System.Windows.Forms.TextBox();
            this.startBox3x1 = new System.Windows.Forms.TextBox();
            this.epsBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.methodList3 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.functionList3 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.diffBox3 = new System.Windows.Forms.TextBox();
            this.iterBox3 = new System.Windows.Forms.TextBox();
            this.minBox3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.низкаяТочностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.высокаяТочностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.lab1tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.graph.Location = new System.Drawing.Point(1, 266);
            this.graph.Margin = new System.Windows.Forms.Padding(4);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(1023, 475);
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
            this.graph.zScale = true;
            this.graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graph_MouseClick);
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
            this.functionLabel.Location = new System.Drawing.Point(51, 35);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(67, 17);
            this.functionLabel.TabIndex = 4;
            this.functionLabel.Text = "Функция";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startBox1);
            this.groupBox1.Controls.Add(this.epsBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.methodList1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.functionLabel);
            this.groupBox1.Controls.Add(this.functionList1);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(477, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // startBox1
            // 
            this.startBox1.Location = new System.Drawing.Point(147, 111);
            this.startBox1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.startBox1.Name = "startBox1";
            this.startBox1.Size = new System.Drawing.Size(120, 22);
            this.startBox1.TabIndex = 6;
            this.startBox1.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.startBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startingPoint1_KeyUp);
            // 
            // epsBox1
            // 
            this.epsBox1.Location = new System.Drawing.Point(368, 109);
            this.epsBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.epsBox1.Name = "epsBox1";
            this.epsBox1.Size = new System.Drawing.Size(84, 22);
            this.epsBox1.TabIndex = 0;
            this.epsBox1.Text = "1e-2";
            this.epsBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startingPoint1_KeyUp);
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
            this.label6.Location = new System.Drawing.Point(68, 74);
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
            this.groupBox2.Location = new System.Drawing.Point(489, 5);
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
            this.label2.Location = new System.Drawing.Point(21, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Погрешность";
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
            this.lab1tab.Location = new System.Drawing.Point(12, 40);
            this.lab1tab.Name = "lab1tab";
            this.lab1tab.SelectedIndex = 0;
            this.lab1tab.Size = new System.Drawing.Size(997, 206);
            this.lab1tab.TabIndex = 7;
            this.lab1tab.SelectedIndexChanged += new System.EventHandler(this.lab1tab_SelectedIndexChanged);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startBox2);
            this.groupBox3.Controls.Add(this.epsBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.methodList2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.functionList2);
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(477, 148);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Панель ввода";
            // 
            // startBox2
            // 
            this.startBox2.Location = new System.Drawing.Point(147, 111);
            this.startBox2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.startBox2.Name = "startBox2";
            this.startBox2.Size = new System.Drawing.Size(120, 22);
            this.startBox2.TabIndex = 6;
            this.startBox2.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.startBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startingPoint1_KeyUp);
            // 
            // epsBox
            // 
            this.epsBox.Location = new System.Drawing.Point(368, 109);
            this.epsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.epsBox.Name = "epsBox";
            this.epsBox.Size = new System.Drawing.Size(84, 22);
            this.epsBox.TabIndex = 0;
            this.epsBox.Text = "1e-2";
            this.epsBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startingPoint1_KeyUp);
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
            // methodList2
            // 
            this.methodList2.FormattingEnabled = true;
            this.methodList2.Location = new System.Drawing.Point(125, 71);
            this.methodList2.Margin = new System.Windows.Forms.Padding(4);
            this.methodList2.Name = "methodList2";
            this.methodList2.Size = new System.Drawing.Size(327, 24);
            this.methodList2.TabIndex = 3;
            this.methodList2.SelectedIndexChanged += new System.EventHandler(this.methodList2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Цепочка";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Функция";
            // 
            // functionList2
            // 
            this.functionList2.FormattingEnabled = true;
            this.functionList2.Location = new System.Drawing.Point(125, 32);
            this.functionList2.Margin = new System.Windows.Forms.Padding(4);
            this.functionList2.Name = "functionList2";
            this.functionList2.Size = new System.Drawing.Size(327, 24);
            this.functionList2.TabIndex = 3;
            this.functionList2.SelectedIndexChanged += new System.EventHandler(this.functionList2_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.diffBox2);
            this.groupBox4.Controls.Add(this.iterBox2);
            this.groupBox4.Controls.Add(this.minBox2);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(489, 5);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(478, 148);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Панель вывода";
            // 
            // diffBox2
            // 
            this.diffBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diffBox2.Location = new System.Drawing.Point(122, 110);
            this.diffBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diffBox2.Name = "diffBox2";
            this.diffBox2.ReadOnly = true;
            this.diffBox2.Size = new System.Drawing.Size(342, 22);
            this.diffBox2.TabIndex = 0;
            this.diffBox2.Text = " ";
            // 
            // iterBox2
            // 
            this.iterBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iterBox2.Location = new System.Drawing.Point(122, 71);
            this.iterBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iterBox2.Name = "iterBox2";
            this.iterBox2.ReadOnly = true;
            this.iterBox2.Size = new System.Drawing.Size(342, 22);
            this.iterBox2.TabIndex = 0;
            // 
            // minBox2
            // 
            this.minBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minBox2.Location = new System.Drawing.Point(122, 32);
            this.minBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minBox2.Name = "minBox2";
            this.minBox2.ReadOnly = true;
            this.minBox2.Size = new System.Drawing.Size(342, 22);
            this.minBox2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Погрешность";
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(989, 177);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Лабораторная #3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.startBox3x2);
            this.groupBox5.Controls.Add(this.startBox3x1);
            this.groupBox5.Controls.Add(this.epsBox3);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.methodList3);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.functionList3);
            this.groupBox5.Location = new System.Drawing.Point(6, 5);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(477, 148);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Панель ввода";
            // 
            // startBox3x2
            // 
            this.startBox3x2.Location = new System.Drawing.Point(208, 110);
            this.startBox3x2.Name = "startBox3x2";
            this.startBox3x2.Size = new System.Drawing.Size(61, 22);
            this.startBox3x2.TabIndex = 5;
            this.startBox3x2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyUp);
            // 
            // startBox3x1
            // 
            this.startBox3x1.Location = new System.Drawing.Point(141, 110);
            this.startBox3x1.Name = "startBox3x1";
            this.startBox3x1.Size = new System.Drawing.Size(61, 22);
            this.startBox3x1.TabIndex = 5;
            this.startBox3x1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyUp);
            // 
            // epsBox3
            // 
            this.epsBox3.Location = new System.Drawing.Point(368, 110);
            this.epsBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.epsBox3.Name = "epsBox3";
            this.epsBox3.Size = new System.Drawing.Size(84, 22);
            this.epsBox3.TabIndex = 0;
            this.epsBox3.Text = "1e-2";
            this.epsBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(292, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Точность";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 17);
            this.label15.TabIndex = 4;
            this.label15.Text = "Стартовый вектор";
            // 
            // methodList3
            // 
            this.methodList3.FormattingEnabled = true;
            this.methodList3.Location = new System.Drawing.Point(125, 71);
            this.methodList3.Margin = new System.Windows.Forms.Padding(4);
            this.methodList3.Name = "methodList3";
            this.methodList3.Size = new System.Drawing.Size(327, 24);
            this.methodList3.TabIndex = 3;
            this.methodList3.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(68, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 17);
            this.label21.TabIndex = 4;
            this.label21.Text = "Метод";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(51, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "Функция";
            // 
            // functionList3
            // 
            this.functionList3.FormattingEnabled = true;
            this.functionList3.Location = new System.Drawing.Point(125, 32);
            this.functionList3.Margin = new System.Windows.Forms.Padding(4);
            this.functionList3.Name = "functionList3";
            this.functionList3.Size = new System.Drawing.Size(327, 24);
            this.functionList3.TabIndex = 3;
            this.functionList3.SelectedIndexChanged += new System.EventHandler(this.functionList3_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.diffBox3);
            this.groupBox6.Controls.Add(this.iterBox3);
            this.groupBox6.Controls.Add(this.minBox3);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Location = new System.Drawing.Point(489, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(478, 148);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Панель вывода";
            // 
            // diffBox3
            // 
            this.diffBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diffBox3.Location = new System.Drawing.Point(122, 110);
            this.diffBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diffBox3.Name = "diffBox3";
            this.diffBox3.ReadOnly = true;
            this.diffBox3.Size = new System.Drawing.Size(342, 22);
            this.diffBox3.TabIndex = 0;
            this.diffBox3.Text = " ";
            // 
            // iterBox3
            // 
            this.iterBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iterBox3.Location = new System.Drawing.Point(122, 71);
            this.iterBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iterBox3.Name = "iterBox3";
            this.iterBox3.ReadOnly = true;
            this.iterBox3.Size = new System.Drawing.Size(342, 22);
            this.iterBox3.TabIndex = 0;
            // 
            // minBox3
            // 
            this.minBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minBox3.Location = new System.Drawing.Point(122, 32);
            this.minBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minBox3.Name = "minBox3";
            this.minBox3.ReadOnly = true;
            this.minBox3.Size = new System.Drawing.Size(342, 22);
            this.minBox3.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 17);
            this.label18.TabIndex = 4;
            this.label18.Text = "Погрешность";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(43, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 17);
            this.label19.TabIndex = 4;
            this.label19.Text = "Итерации";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(48, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 4;
            this.label20.Text = "Минимум";
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.тестированиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // тестированиеToolStripMenuItem
            // 
            this.тестированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.низкаяТочностьToolStripMenuItem,
            this.высокаяТочностьToolStripMenuItem});
            this.тестированиеToolStripMenuItem.Name = "тестированиеToolStripMenuItem";
            this.тестированиеToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.тестированиеToolStripMenuItem.Text = "Тестирование";
            // 
            // низкаяТочностьToolStripMenuItem
            // 
            this.низкаяТочностьToolStripMenuItem.Name = "низкаяТочностьToolStripMenuItem";
            this.низкаяТочностьToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.низкаяТочностьToolStripMenuItem.Text = "Низкая точность";
            this.низкаяТочностьToolStripMenuItem.Click += new System.EventHandler(this.низкаяТочностьToolStripMenuItem_Click);
            // 
            // высокаяТочностьToolStripMenuItem
            // 
            this.высокаяТочностьToolStripMenuItem.Name = "высокаяТочностьToolStripMenuItem";
            this.высокаяТочностьToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.высокаяТочностьToolStripMenuItem.Text = "Высокая точность";
            this.высокаяТочностьToolStripMenuItem.Click += new System.EventHandler(this.высокаяТочностьToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 15;
            this.trackBar1.Location = new System.Drawing.Point(16, 735);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(993, 56);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 811);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lab1tab);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.lab1tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox epsBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diffBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startBox1;
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
        private System.Windows.Forms.NumericUpDown startBox2;
        private System.Windows.Forms.TextBox epsBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox methodList2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox functionList2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox diffBox2;
        private System.Windows.Forms.TextBox iterBox2;
        private System.Windows.Forms.TextBox minBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox epsBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox methodList3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox functionList3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox diffBox3;
        private System.Windows.Forms.TextBox iterBox3;
        private System.Windows.Forms.TextBox minBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox startBox3x2;
        private System.Windows.Forms.TextBox startBox3x1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem низкаяТочностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem высокаяТочностьToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}