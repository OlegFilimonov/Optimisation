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
            this.methodList = new System.Windows.Forms.ComboBox();
            this.playList = new System.Windows.Forms.ComboBox();
            this.methodRadioButton = new System.Windows.Forms.RadioButton();
            this.playListRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.graph.FixYtoX = true;
            this.graph.Legend = false;
            this.graph.Location = new System.Drawing.Point(13, 211);
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
            this.graph.y0 = -8.0710202809589813D;
            this.graph.y1 = 8.1255609156222146D;
            this.graph.yAxis = true;
            this.graph.yGrid = true;
            this.graph.yRaster = false;
            this.graph.yScale = true;
            this.graph.z0 = 0D;
            this.graph.z1 = 20D;
            this.graph.zScale = true;
            // 
            // functionList
            // 
            this.functionList.FormattingEnabled = true;
            this.functionList.Location = new System.Drawing.Point(126, 32);
            this.functionList.Margin = new System.Windows.Forms.Padding(4);
            this.functionList.Name = "functionList";
            this.functionList.Size = new System.Drawing.Size(327, 24);
            this.functionList.TabIndex = 3;
            this.functionList.SelectedIndexChanged += new System.EventHandler(this.functionList_SelectedIndexChanged);
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Location = new System.Drawing.Point(17, 35);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(67, 17);
            this.functionLabel.TabIndex = 4;
            this.functionLabel.Text = "Функция";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.playListRadioButton);
            this.groupBox1.Controls.Add(this.methodRadioButton);
            this.groupBox1.Controls.Add(this.playList);
            this.groupBox1.Controls.Add(this.methodList);
            this.groupBox1.Controls.Add(this.functionLabel);
            this.groupBox1.Controls.Add(this.functionList);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель ввода";
            // 
            // methodList
            // 
            this.methodList.Enabled = false;
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(126, 71);
            this.methodList.Margin = new System.Windows.Forms.Padding(4);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(327, 24);
            this.methodList.TabIndex = 3;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.functionList_SelectedIndexChanged);
            // 
            // playList
            // 
            this.playList.Enabled = false;
            this.playList.FormattingEnabled = true;
            this.playList.Location = new System.Drawing.Point(126, 110);
            this.playList.Margin = new System.Windows.Forms.Padding(4);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(327, 24);
            this.playList.TabIndex = 3;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.functionList_SelectedIndexChanged);
            // 
            // methodRadioButton
            // 
            this.methodRadioButton.AutoSize = true;
            this.methodRadioButton.Enabled = false;
            this.methodRadioButton.Location = new System.Drawing.Point(20, 69);
            this.methodRadioButton.Name = "methodRadioButton";
            this.methodRadioButton.Size = new System.Drawing.Size(71, 21);
            this.methodRadioButton.TabIndex = 5;
            this.methodRadioButton.TabStop = true;
            this.methodRadioButton.Text = "Метод";
            this.methodRadioButton.UseVisualStyleBackColor = true;
            // 
            // playListRadioButton
            // 
            this.playListRadioButton.AutoSize = true;
            this.playListRadioButton.Enabled = false;
            this.playListRadioButton.Location = new System.Drawing.Point(17, 111);
            this.playListRadioButton.Name = "playListRadioButton";
            this.playListRadioButton.Size = new System.Drawing.Size(93, 21);
            this.playListRadioButton.TabIndex = 5;
            this.playListRadioButton.TabStop = true;
            this.playListRadioButton.Text = "Плейлист";
            this.playListRadioButton.UseVisualStyleBackColor = true;
            this.playListRadioButton.CheckedChanged += new System.EventHandler(this.playListRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(497, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 191);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Панель вывода";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(381, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(84, 22);
            this.textBox2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Минимум";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Точность";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.ComboBox playList;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}