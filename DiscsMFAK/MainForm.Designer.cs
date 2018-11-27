namespace DiscsMFAK
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.massSlider = new System.Windows.Forms.TrackBar();
            this.attractorMassLabel = new System.Windows.Forms.Label();
            this.gSlider = new System.Windows.Forms.TrackBar();
            this.cSlider = new System.Windows.Forms.TrackBar();
            this.gLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.massSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // massSlider
            // 
            this.massSlider.Location = new System.Drawing.Point(120, 12);
            this.massSlider.Maximum = 3500;
            this.massSlider.Minimum = 10;
            this.massSlider.Name = "massSlider";
            this.massSlider.Size = new System.Drawing.Size(50, 45);
            this.massSlider.TabIndex = 0;
            this.massSlider.Value = 10;
            this.massSlider.Scroll += new System.EventHandler(this.massSlider_Scroll);
            // 
            // attractorMassLabel
            // 
            this.attractorMassLabel.AutoSize = true;
            this.attractorMassLabel.Location = new System.Drawing.Point(302, 12);
            this.attractorMassLabel.Name = "attractorMassLabel";
            this.attractorMassLabel.Size = new System.Drawing.Size(35, 13);
            this.attractorMassLabel.TabIndex = 1;
            this.attractorMassLabel.Text = "label1";
            // 
            // gSlider
            // 
            this.gSlider.Location = new System.Drawing.Point(183, 12);
            this.gSlider.Maximum = 1000;
            this.gSlider.Minimum = 10;
            this.gSlider.Name = "gSlider";
            this.gSlider.Size = new System.Drawing.Size(50, 45);
            this.gSlider.TabIndex = 2;
            this.gSlider.Value = 10;
            this.gSlider.Scroll += new System.EventHandler(this.gSlider_Scroll);
            // 
            // cSlider
            // 
            this.cSlider.Location = new System.Drawing.Point(246, 12);
            this.cSlider.Maximum = 3500;
            this.cSlider.Minimum = 10;
            this.cSlider.Name = "cSlider";
            this.cSlider.Size = new System.Drawing.Size(50, 45);
            this.cSlider.TabIndex = 3;
            this.cSlider.Value = 10;
            this.cSlider.Scroll += new System.EventHandler(this.cSlider_Scroll);
            // 
            // gLabel
            // 
            this.gLabel.AutoSize = true;
            this.gLabel.Location = new System.Drawing.Point(302, 25);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size(35, 13);
            this.gLabel.TabIndex = 4;
            this.gLabel.Text = "label1";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(302, 38);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(35, 13);
            this.cLabel.TabIndex = 5;
            this.cLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.cLabel);
            this.Controls.Add(this.gLabel);
            this.Controls.Add(this.cSlider);
            this.Controls.Add(this.gSlider);
            this.Controls.Add(this.attractorMassLabel);
            this.Controls.Add(this.massSlider);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.massSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar massSlider;
        private System.Windows.Forms.Label attractorMassLabel;
        private System.Windows.Forms.TrackBar gSlider;
        private System.Windows.Forms.TrackBar cSlider;
        private System.Windows.Forms.Label gLabel;
        private System.Windows.Forms.Label cLabel;
    }
}