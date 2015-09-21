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
            this.functionList = new System.Windows.Forms.ComboBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playListRadioButton = new System.Windows.Forms.RadioButton();
            this.methodRadioButton = new System.Windows.Forms.RadioButton();
            this.playList = new System.Windows.Forms.ComboBox();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startingPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startingStep = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.BackColor = System.Drawing.Color.White;
            this.graph.Border = true;
            this.graph.Cursor = System.Windows.Forms.Cursors.Cross;
            this.graph.FixYtoX = false;
            this.graph.Legend = false;
            this.graph.Location = new System.Drawing.Point(10, 171);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(736, 343);
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
            // functionList
            // 
            this.functionList.FormattingEnabled = true;
            this.functionList.Location = new System.Drawing.Point(94, 26);
            this.functionList.Name = "functionList";
            this.functionList.Size = new System.Drawing.Size(246, 21);
            this.functionList.TabIndex = 3;
            this.functionList.SelectedIndexChanged += new System.EventHandler(this.functionList_SelectedIndexChanged);
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Location = new System.Drawing.Point(13, 28);
            this.functionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(53, 13);
            this.functionLabel.TabIndex = 4;
            this.functionLabel.Text = "Функция";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startingStep);
            this.groupBox1.Controls.Add(this.startingPoint);
            this.groupBox1.Controls.Add(this.playListRadioButton);
            this.groupBox1.Controls.Add(this.methodRadioButton);
            this.groupBox1.Controls.Add(this.playList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.methodList);
            this.groupBox1.Controls.Add(this.functionLabel);
            this.groupBox1.Controls.Add(this.functionList);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(358, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // playListRadioButton
            // 
            this.playListRadioButton.AutoSize = true;
            this.playListRadioButton.Enabled = false;
            this.playListRadioButton.Location = new System.Drawing.Point(13, 90);
            this.playListRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.playListRadioButton.Name = "playListRadioButton";
            this.playListRadioButton.Size = new System.Drawing.Size(74, 17);
            this.playListRadioButton.TabIndex = 5;
            this.playListRadioButton.TabStop = true;
            this.playListRadioButton.Text = "Плейлист";
            this.playListRadioButton.UseVisualStyleBackColor = true;
            this.playListRadioButton.CheckedChanged += new System.EventHandler(this.playListRadioButton_CheckedChanged);
            // 
            // methodRadioButton
            // 
            this.methodRadioButton.AutoSize = true;
            this.methodRadioButton.Enabled = false;
            this.methodRadioButton.Location = new System.Drawing.Point(15, 56);
            this.methodRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.methodRadioButton.Name = "methodRadioButton";
            this.methodRadioButton.Size = new System.Drawing.Size(57, 17);
            this.methodRadioButton.TabIndex = 5;
            this.methodRadioButton.TabStop = true;
            this.methodRadioButton.Text = "Метод";
            this.methodRadioButton.UseVisualStyleBackColor = true;
            // 
            // playList
            // 
            this.playList.Enabled = false;
            this.playList.FormattingEnabled = true;
            this.playList.Location = new System.Drawing.Point(94, 89);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(246, 21);
            this.playList.TabIndex = 3;
            // 
            // methodList
            // 
            this.methodList.Enabled = false;
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(94, 58);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(246, 21);
            this.methodList.TabIndex = 3;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(373, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(373, 155);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель вывода";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(256, 58);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 58);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(287, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Итерации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Точность";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Минимум";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Начальная точка";
            // 
            // startingPoint
            // 
            this.startingPoint.Location = new System.Drawing.Point(107, 121);
            this.startingPoint.Margin = new System.Windows.Forms.Padding(2);
            this.startingPoint.Name = "startingPoint";
            this.startingPoint.Size = new System.Drawing.Size(64, 20);
            this.startingPoint.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Точность";
            // 
            // startingStep
            // 
            this.startingStep.Location = new System.Drawing.Point(272, 121);
            this.startingStep.Margin = new System.Windows.Forms.Padding(2);
            this.startingStep.Name = "startingStep";
            this.startingStep.Size = new System.Drawing.Size(64, 20);
            this.startingStep.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graph);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FPlotLibrary.GraphControl graph;
        private System.Windows.Forms.ComboBox functionList;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton playListRadioButton;
        private System.Windows.Forms.RadioButton methodRadioButton;
        private System.Windows.Forms.ComboBox playList;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startingStep;
        private System.Windows.Forms.TextBox startingPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}