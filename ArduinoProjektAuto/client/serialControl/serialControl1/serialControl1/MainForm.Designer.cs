namespace serialControl1
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.naslovnaSlika = new System.Windows.Forms.PictureBox();
            this.uputeNaslovna = new System.Windows.Forms.RichTextBox();
            this.spojiButton = new System.Windows.Forms.Button();
            this.odspojiButton = new System.Windows.Forms.Button();
            this.volan = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.naslovnaSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volan)).BeginInit();
            this.SuspendLayout();
            // 
            // naslovnaSlika
            // 
            this.naslovnaSlika.Image = ((System.Drawing.Image)(resources.GetObject("naslovnaSlika.Image")));
            this.naslovnaSlika.Location = new System.Drawing.Point(370, 213);
            this.naslovnaSlika.Name = "naslovnaSlika";
            this.naslovnaSlika.Size = new System.Drawing.Size(235, 190);
            this.naslovnaSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.naslovnaSlika.TabIndex = 0;
            this.naslovnaSlika.TabStop = false;
            // 
            // uputeNaslovna
            // 
            this.uputeNaslovna.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uputeNaslovna.Location = new System.Drawing.Point(12, 12);
            this.uputeNaslovna.Name = "uputeNaslovna";
            this.uputeNaslovna.ReadOnly = true;
            this.uputeNaslovna.Size = new System.Drawing.Size(318, 327);
            this.uputeNaslovna.TabIndex = 1;
            this.uputeNaslovna.Text = resources.GetString("uputeNaslovna.Text");
            this.uputeNaslovna.KeyDown += new System.Windows.Forms.KeyEventHandler(this.upravljanje);
            // 
            // spojiButton
            // 
            this.spojiButton.Location = new System.Drawing.Point(12, 393);
            this.spojiButton.Name = "spojiButton";
            this.spojiButton.Size = new System.Drawing.Size(111, 74);
            this.spojiButton.TabIndex = 2;
            this.spojiButton.Text = "Spoji";
            this.spojiButton.UseVisualStyleBackColor = true;
            this.spojiButton.Click += new System.EventHandler(this.spojiButton_Click);
            // 
            // odspojiButton
            // 
            this.odspojiButton.Enabled = false;
            this.odspojiButton.Location = new System.Drawing.Point(152, 393);
            this.odspojiButton.Name = "odspojiButton";
            this.odspojiButton.Size = new System.Drawing.Size(110, 74);
            this.odspojiButton.TabIndex = 3;
            this.odspojiButton.Text = "Odspoji";
            this.odspojiButton.UseVisualStyleBackColor = true;
            this.odspojiButton.Click += new System.EventHandler(this.odspojiButton_Click);
            // 
            // volan
            // 
            this.volan.Image = ((System.Drawing.Image)(resources.GetObject("volan.Image")));
            this.volan.Location = new System.Drawing.Point(373, 25);
            this.volan.Name = "volan";
            this.volan.Size = new System.Drawing.Size(117, 106);
            this.volan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volan.TabIndex = 7;
            this.volan.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "STATUS:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.status.Location = new System.Drawing.Point(71, 519);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(86, 13);
            this.status.TabIndex = 9;
            this.status.Text = "NIJE SPOJEN";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 557);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volan);
            this.Controls.Add(this.odspojiButton);
            this.Controls.Add(this.spojiButton);
            this.Controls.Add(this.uputeNaslovna);
            this.Controls.Add(this.naslovnaSlika);
            this.Name = "ControlPanel";
            this.Text = "JA SAM NOVI VOZAČ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zatvaranjeForme);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.upravljanje);
            ((System.ComponentModel.ISupportInitialize)(this.naslovnaSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox naslovnaSlika;
        private System.Windows.Forms.RichTextBox uputeNaslovna;
        private System.Windows.Forms.Button spojiButton;
        private System.Windows.Forms.Button odspojiButton;
        private System.Windows.Forms.PictureBox volan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
    }
}

