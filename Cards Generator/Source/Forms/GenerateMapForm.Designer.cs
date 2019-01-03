namespace Cards_Generator
{
    partial class GenerateMapForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkAutorefresh = new System.Windows.Forms.CheckBox();
            this.tmrAutorefresh = new System.Windows.Forms.Timer(this.components);
            this.MapVisualizer = new Cards_Generator.MapVisualizer();
            ((System.ComponentModel.ISupportInitialize)(this.MapVisualizer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 747);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 52);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(654, 747);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(134, 52);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkAutorefresh
            // 
            this.chkAutorefresh.AutoSize = true;
            this.chkAutorefresh.Location = new System.Drawing.Point(348, 764);
            this.chkAutorefresh.Name = "chkAutorefresh";
            this.chkAutorefresh.Size = new System.Drawing.Size(104, 21);
            this.chkAutorefresh.TabIndex = 4;
            this.chkAutorefresh.Text = "Autorefresh";
            this.chkAutorefresh.UseVisualStyleBackColor = true;
            this.chkAutorefresh.CheckedChanged += new System.EventHandler(this.chkAutorefresh_CheckedChanged);
            // 
            // tmrAutorefresh
            // 
            this.tmrAutorefresh.Interval = 1000;
            this.tmrAutorefresh.Tick += new System.EventHandler(this.tmrAutorefresh_Tick);
            // 
            // MapVisualizer
            // 
            this.MapVisualizer.Location = new System.Drawing.Point(12, 12);
            this.MapVisualizer.Name = "MapVisualizer";
            this.MapVisualizer.Size = new System.Drawing.Size(776, 729);
            this.MapVisualizer.TabIndex = 3;
            this.MapVisualizer.TabStop = false;
            // 
            // GenerateMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 811);
            this.Controls.Add(this.chkAutorefresh);
            this.Controls.Add(this.MapVisualizer);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnBack);
            this.Name = "GenerateMapForm";
            this.Text = "GenerateMapForm";
            ((System.ComponentModel.ISupportInitialize)(this.MapVisualizer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGenerate;
        private MapVisualizer MapVisualizer;
        private System.Windows.Forms.CheckBox chkAutorefresh;
        private System.Windows.Forms.Timer tmrAutorefresh;
    }
}