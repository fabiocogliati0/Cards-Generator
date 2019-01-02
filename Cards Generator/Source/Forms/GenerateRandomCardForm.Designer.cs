namespace Cards_Generator
{
    partial class GenerateRandomCardForm
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
            this.cmbRarity = new System.Windows.Forms.ComboBox();
            this.lblRarity = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblGeneratedCardTitle = new System.Windows.Forms.Label();
            this.txtGeneratedCardDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbRarity
            // 
            this.cmbRarity.FormattingEnabled = true;
            this.cmbRarity.Items.AddRange(new object[] {
            "Common",
            "Magic",
            "Rare"});
            this.cmbRarity.Location = new System.Drawing.Point(82, 31);
            this.cmbRarity.Name = "cmbRarity";
            this.cmbRarity.Size = new System.Drawing.Size(121, 24);
            this.cmbRarity.TabIndex = 0;
            // 
            // lblRarity
            // 
            this.lblRarity.AutoSize = true;
            this.lblRarity.Location = new System.Drawing.Point(13, 34);
            this.lblRarity.Name = "lblRarity";
            this.lblRarity.Size = new System.Drawing.Size(45, 17);
            this.lblRarity.TabIndex = 1;
            this.lblRarity.Text = "Rarity";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 70);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Creature",
            "Equipment"});
            this.cmbType.Location = new System.Drawing.Point(82, 70);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(645, 28);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 59);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(629, 371);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(126, 45);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblGeneratedCardTitle
            // 
            this.lblGeneratedCardTitle.AutoSize = true;
            this.lblGeneratedCardTitle.Location = new System.Drawing.Point(49, 124);
            this.lblGeneratedCardTitle.Name = "lblGeneratedCardTitle";
            this.lblGeneratedCardTitle.Size = new System.Drawing.Size(110, 17);
            this.lblGeneratedCardTitle.TabIndex = 6;
            this.lblGeneratedCardTitle.Text = "GeneratedCard:";
            this.lblGeneratedCardTitle.Click += new System.EventHandler(this.lblGeneratedCardTitle_Click);
            // 
            // txtGeneratedCardDesc
            // 
            this.txtGeneratedCardDesc.Location = new System.Drawing.Point(52, 144);
            this.txtGeneratedCardDesc.Multiline = true;
            this.txtGeneratedCardDesc.Name = "txtGeneratedCardDesc";
            this.txtGeneratedCardDesc.Size = new System.Drawing.Size(585, 205);
            this.txtGeneratedCardDesc.TabIndex = 7;
            // 
            // GenerateRandomCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtGeneratedCardDesc);
            this.Controls.Add(this.lblGeneratedCardTitle);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblRarity);
            this.Controls.Add(this.cmbRarity);
            this.Name = "GenerateRandomCardForm";
            this.Text = "GenerateRandomCardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRarity;
        private System.Windows.Forms.Label lblRarity;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblGeneratedCardTitle;
        private System.Windows.Forms.TextBox txtGeneratedCardDesc;
    }
}