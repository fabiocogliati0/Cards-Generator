namespace Cards_Generator
{
    partial class LocalizationForm
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
            this.rdbEnglish = new System.Windows.Forms.RadioButton();
            this.rdbItalian = new System.Windows.Forms.RadioButton();
            this.lblLanguageSelection = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbEnglish
            // 
            this.rdbEnglish.AutoSize = true;
            this.rdbEnglish.Location = new System.Drawing.Point(50, 71);
            this.rdbEnglish.Name = "rdbEnglish";
            this.rdbEnglish.Size = new System.Drawing.Size(75, 21);
            this.rdbEnglish.TabIndex = 0;
            this.rdbEnglish.TabStop = true;
            this.rdbEnglish.Text = "English";
            this.rdbEnglish.UseVisualStyleBackColor = true;
            this.rdbEnglish.CheckedChanged += new System.EventHandler(this.rdbEnglish_CheckedChanged);
            // 
            // rdbItalian
            // 
            this.rdbItalian.AutoSize = true;
            this.rdbItalian.Location = new System.Drawing.Point(50, 98);
            this.rdbItalian.Name = "rdbItalian";
            this.rdbItalian.Size = new System.Drawing.Size(74, 21);
            this.rdbItalian.TabIndex = 1;
            this.rdbItalian.TabStop = true;
            this.rdbItalian.Text = "Italiano";
            this.rdbItalian.UseVisualStyleBackColor = true;
            this.rdbItalian.CheckedChanged += new System.EventHandler(this.rdbItalian_CheckedChanged);
            // 
            // lblLanguageSelection
            // 
            this.lblLanguageSelection.AutoSize = true;
            this.lblLanguageSelection.Location = new System.Drawing.Point(33, 24);
            this.lblLanguageSelection.Name = "lblLanguageSelection";
            this.lblLanguageSelection.Size = new System.Drawing.Size(119, 17);
            this.lblLanguageSelection.TabIndex = 2;
            this.lblLanguageSelection.Text = "#SelectLanguage";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(27, 149);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(238, 37);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "#Ok";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // LocalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 219);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblLanguageSelection);
            this.Controls.Add(this.rdbItalian);
            this.Controls.Add(this.rdbEnglish);
            this.Name = "LocalizationForm";
            this.Text = "LocalizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbEnglish;
        private System.Windows.Forms.RadioButton rdbItalian;
        private System.Windows.Forms.Label lblLanguageSelection;
        private System.Windows.Forms.Button btnContinue;
    }
}