namespace termostatApp
{
    partial class FrmTerm
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
            this.hcText = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.hcC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hcText
            // 
            this.hcText.AutoSize = true;
            this.hcText.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hcText.Location = new System.Drawing.Point(12, 41);
            this.hcText.Name = "hcText";
            this.hcText.Size = new System.Drawing.Size(607, 64);
            this.hcText.TabIndex = 0;
            this.hcText.Text = "Trenutna temperatura:";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTemp.Location = new System.Drawing.Point(358, 165);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(173, 64);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "22.31";
            // 
            // hcC
            // 
            this.hcC.AutoSize = true;
            this.hcC.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hcC.Location = new System.Drawing.Point(537, 165);
            this.hcC.Name = "hcC";
            this.hcC.Size = new System.Drawing.Size(69, 64);
            this.hcC.TabIndex = 2;
            this.hcC.Text = "C";
            // 
            // FrmTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 395);
            this.Controls.Add(this.hcC);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.hcText);
            this.Name = "FrmTerm";
            this.Text = "Termostat App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zatvaranjeForme);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hcText;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label hcC;
    }
}

