using FPlotLibrary;

namespace OptimisationCat
{
    partial class GraphForm
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
            this.graph = new GraphControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.graph.Location = new System.Drawing.Point(11, 78);
            this.graph.Margin = new System.Windows.Forms.Padding(4);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(694, 414);
            this.graph.TabIndex = 2;
            this.graph.Text = "graph";
            this.graph.x0 = -20D;
            this.graph.x1 = 20D;
            this.graph.xAxis = true;
            this.graph.xGrid = true;
            this.graph.xRaster = true;
            this.graph.xScale = true;
            this.graph.y0 = -20D;
            this.graph.y1 = 20D;
            this.graph.yAxis = true;
            this.graph.yGrid = true;
            this.graph.yRaster = true;
            this.graph.yScale = true;
            this.graph.z0 = 0D;
            this.graph.z1 = 1D;
            this.graph.zScale = true;
            this.graph.Click += new System.EventHandler(this.graph_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(11, 499);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(694, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 562);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.graph);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FPlotLibrary.GraphControl graph;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}