namespace Cards_Generator
{
    partial class CreditForm
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
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblFabio = new System.Windows.Forms.Label();
            this.lblManuele = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle1.Location = new System.Drawing.Point(12, 9);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(117, 13);
            this.lblTitle1.TabIndex = 0;
            this.lblTitle1.Text = "Project Programmer";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle2.Location = new System.Drawing.Point(12, 61);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(134, 13);
            this.lblTitle2.TabIndex = 1;
            this.lblTitle2.Text = "This Page Programmer";
            // 
            // lblFabio
            // 
            this.lblFabio.AutoSize = true;
            this.lblFabio.Location = new System.Drawing.Point(12, 26);
            this.lblFabio.Name = "lblFabio";
            this.lblFabio.Size = new System.Drawing.Size(70, 13);
            this.lblFabio.TabIndex = 2;
            this.lblFabio.Text = "Fabio Cogliati";
            this.lblFabio.MouseEnter += new System.EventHandler(this.lblManuele_MouseEnter);
            // 
            // lblManuele
            // 
            this.lblManuele.AutoSize = true;
            this.lblManuele.Location = new System.Drawing.Point(12, 77);
            this.lblManuele.Name = "lblManuele";
            this.lblManuele.Size = new System.Drawing.Size(86, 13);
            this.lblManuele.TabIndex = 3;
            this.lblManuele.Text = "Manuele Ferrario";
            this.lblManuele.MouseEnter += new System.EventHandler(this.lblManuele_MouseEnter);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(71, 128);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 163);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblManuele);
            this.Controls.Add(this.lblFabio);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblTitle1);
            this.Name = "CreditForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblFabio;
        private System.Windows.Forms.Label lblManuele;
        private System.Windows.Forms.Button btnBack;
    }
}