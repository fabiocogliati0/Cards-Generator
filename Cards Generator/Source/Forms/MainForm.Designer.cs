namespace Cards_Generator
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
            this.btnGenerator = new System.Windows.Forms.Button();
            this.btnMapGenerator = new System.Windows.Forms.Button();
            this.lblCredits = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnGenerator
            // 
            this.btnGenerator.Location = new System.Drawing.Point(24, 19);
            this.btnGenerator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(80, 62);
            this.btnGenerator.TabIndex = 0;
            this.btnGenerator.Text = "Card Generator";
            this.btnGenerator.UseVisualStyleBackColor = true;
            this.btnGenerator.Click += new System.EventHandler(this.btnGenerator_Click);
            // 
            // btnMapGenerator
            // 
            this.btnMapGenerator.Location = new System.Drawing.Point(120, 19);
            this.btnMapGenerator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMapGenerator.Name = "btnMapGenerator";
            this.btnMapGenerator.Size = new System.Drawing.Size(80, 62);
            this.btnMapGenerator.TabIndex = 1;
            this.btnMapGenerator.Text = "Map Generator";
            this.btnMapGenerator.UseVisualStyleBackColor = true;
            this.btnMapGenerator.Click += new System.EventHandler(this.btnMapGenerator_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(409, 318);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(39, 13);
            this.lblCredits.TabIndex = 2;
            this.lblCredits.TabStop = true;
            this.lblCredits.Text = "Credits";
            this.lblCredits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCredits_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 340);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.btnMapGenerator);
            this.Controls.Add(this.btnGenerator);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Cards Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.Button btnMapGenerator;
        private System.Windows.Forms.LinkLabel lblCredits;
    }
}

