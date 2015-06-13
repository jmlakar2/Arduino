namespace gamepadApp
{
    partial class mainForm
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
            this.naslov = new System.Windows.Forms.Label();
            this.btnSpoji = new System.Windows.Forms.Button();
            this.btnOdspoji = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblZadnja = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrenutna = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // naslov
            // 
            this.naslov.AutoSize = true;
            this.naslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 100.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.naslov.Location = new System.Drawing.Point(13, 13);
            this.naslov.Name = "naslov";
            this.naslov.Size = new System.Drawing.Size(578, 153);
            this.naslov.TabIndex = 0;
            this.naslov.Text = "mroPAD";
            // 
            // btnSpoji
            // 
            this.btnSpoji.Location = new System.Drawing.Point(50, 248);
            this.btnSpoji.Name = "btnSpoji";
            this.btnSpoji.Size = new System.Drawing.Size(165, 69);
            this.btnSpoji.TabIndex = 1;
            this.btnSpoji.Text = "Spoji";
            this.btnSpoji.UseVisualStyleBackColor = true;
            this.btnSpoji.Click += new System.EventHandler(this.btnSpoji_Click);
            // 
            // btnOdspoji
            // 
            this.btnOdspoji.Location = new System.Drawing.Point(366, 248);
            this.btnOdspoji.Name = "btnOdspoji";
            this.btnOdspoji.Size = new System.Drawing.Size(165, 69);
            this.btnOdspoji.TabIndex = 2;
            this.btnOdspoji.Text = "Odspoji";
            this.btnOdspoji.UseVisualStyleBackColor = true;
            this.btnOdspoji.Click += new System.EventHandler(this.btnOdspoji_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "zadnja poruka:";
            // 
            // lblZadnja
            // 
            this.lblZadnja.AutoSize = true;
            this.lblZadnja.Location = new System.Drawing.Point(134, 344);
            this.lblZadnja.Name = "lblZadnja";
            this.lblZadnja.Size = new System.Drawing.Size(26, 13);
            this.lblZadnja.TabIndex = 4;
            this.lblZadnja.Text = "XxX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "trenutna poruka:";
            // 
            // lblTrenutna
            // 
            this.lblTrenutna.AutoSize = true;
            this.lblTrenutna.Location = new System.Drawing.Point(458, 344);
            this.lblTrenutna.Name = "lblTrenutna";
            this.lblTrenutna.Size = new System.Drawing.Size(26, 13);
            this.lblTrenutna.TabIndex = 6;
            this.lblTrenutna.Text = "XxX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 384);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrenutna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblZadnja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOdspoji);
            this.Controls.Add(this.btnSpoji);
            this.Controls.Add(this.naslov);
            this.Name = "mainForm";
            this.Text = "mroPad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zatvaraneForme);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label naslov;
        private System.Windows.Forms.Button btnSpoji;
        private System.Windows.Forms.Button btnOdspoji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblZadnja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrenutna;
        private System.Windows.Forms.Label label3;
    }
}

