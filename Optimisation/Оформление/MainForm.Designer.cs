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
            this.startingEps = new System.Windows.Forms.TextBox();
            this.startingPoint = new System.Windows.Forms.TextBox();
            this.playListRadioButton = new System.Windows.Forms.RadioButton();
            this.methodRadioButton = new System.Windows.Forms.RadioButton();
            this.chainList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diffBox = new System.Windows.Forms.TextBox();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.ansBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.graph.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.graph.Legend = false;
            this.graph.Location = new System.Drawing.Point(13, 210);
            this.graph.Margin = new System.Windows.Forms.Padding(4);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(981, 422);
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
            this.functionList.Location = new System.Drawing.Point(125, 32);
            this.functionList.Margin = new System.Windows.Forms.Padding(4);
            this.functionList.Name = "functionList";
            this.functionList.Size = new System.Drawing.Size(327, 24);
            this.functionList.TabIndex = 3;
            this.functionList.SelectedIndexChanged += new System.EventHandler(this.functionList_SelectedIndexChanged);
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
            this.groupBox1.Controls.Add(this.startingEps);
            this.groupBox1.Controls.Add(this.startingPoint);
            this.groupBox1.Controls.Add(this.playListRadioButton);
            this.groupBox1.Controls.Add(this.methodRadioButton);
            this.groupBox1.Controls.Add(this.chainList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.methodList);
            this.groupBox1.Controls.Add(this.functionLabel);
            this.groupBox1.Controls.Add(this.functionList);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(477, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // startingEps
            // 
            this.startingEps.Location = new System.Drawing.Point(363, 149);
            this.startingEps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startingEps.Name = "startingEps";
            this.startingEps.Size = new System.Drawing.Size(84, 22);
            this.startingEps.TabIndex = 0;
            this.startingEps.Text = "1e-2";
            this.startingEps.TextChanged += new System.EventHandler(this.startingEps_TextChanged);
            // 
            // startingPoint
            // 
            this.startingPoint.Location = new System.Drawing.Point(143, 149);
            this.startingPoint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startingPoint.Name = "startingPoint";
            this.startingPoint.Size = new System.Drawing.Size(84, 22);
            this.startingPoint.TabIndex = 0;
            this.startingPoint.Text = "1.0";
            this.startingPoint.TextChanged += new System.EventHandler(this.startingPoint_TextChanged);
            // 
            // playListRadioButton
            // 
            this.playListRadioButton.AutoSize = true;
            this.playListRadioButton.Enabled = false;
            this.playListRadioButton.Location = new System.Drawing.Point(17, 111);
            this.playListRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playListRadioButton.Name = "playListRadioButton";
            this.playListRadioButton.Size = new System.Drawing.Size(87, 21);
            this.playListRadioButton.TabIndex = 5;
            this.playListRadioButton.TabStop = true;
            this.playListRadioButton.Text = "Цепочки";
            this.playListRadioButton.UseVisualStyleBackColor = true;
            this.playListRadioButton.CheckedChanged += new System.EventHandler(this.playListRadioButton_CheckedChanged);
            // 
            // methodRadioButton
            // 
            this.methodRadioButton.AutoSize = true;
            this.methodRadioButton.Enabled = false;
            this.methodRadioButton.Location = new System.Drawing.Point(20, 69);
            this.methodRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.methodRadioButton.Name = "methodRadioButton";
            this.methodRadioButton.Size = new System.Drawing.Size(71, 21);
            this.methodRadioButton.TabIndex = 5;
            this.methodRadioButton.TabStop = true;
            this.methodRadioButton.Text = "Метод";
            this.methodRadioButton.UseVisualStyleBackColor = true;
            // 
            // chainList
            // 
            this.chainList.Enabled = false;
            this.chainList.FormattingEnabled = true;
            this.chainList.Location = new System.Drawing.Point(125, 110);
            this.chainList.Margin = new System.Windows.Forms.Padding(4);
            this.chainList.Name = "chainList";
            this.chainList.Size = new System.Drawing.Size(327, 24);
            this.chainList.TabIndex = 3;
            this.chainList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Точность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Начальная точка";
            // 
            // methodList
            // 
            this.methodList.Enabled = false;
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(125, 71);
            this.methodList.Margin = new System.Windows.Forms.Padding(4);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(327, 24);
            this.methodList.TabIndex = 3;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.diffBox);
            this.groupBox2.Controls.Add(this.iterationBox);
            this.groupBox2.Controls.Add(this.ansBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(497, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(497, 191);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель вывода";
            // 
            // diffBox
            // 
            this.diffBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diffBox.Location = new System.Drawing.Point(122, 110);
            this.diffBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diffBox.Name = "diffBox";
            this.diffBox.ReadOnly = true;
            this.diffBox.Size = new System.Drawing.Size(351, 22);
            this.diffBox.TabIndex = 0;
            this.diffBox.Text = " ";
            // 
            // iterationBox
            // 
            this.iterationBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iterationBox.Location = new System.Drawing.Point(122, 71);
            this.iterationBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.ReadOnly = true;
            this.iterationBox.Size = new System.Drawing.Size(351, 22);
            this.iterationBox.TabIndex = 0;
            // 
            // ansBox
            // 
            this.ansBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ansBox.Location = new System.Drawing.Point(122, 33);
            this.ansBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ansBox.Name = "ansBox";
            this.ansBox.ReadOnly = true;
            this.ansBox.Size = new System.Drawing.Size(351, 22);
            this.ansBox.TabIndex = 0;
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
            this.label1.Location = new System.Drawing.Point(48, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Минимум";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 646);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graph);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ComboBox chainList;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ansBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startingEps;
        private System.Windows.Forms.TextBox startingPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diffBox;
        private System.Windows.Forms.Label label2;
    }
}