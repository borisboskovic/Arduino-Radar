namespace MiksRadarDesktop
{
    partial class KorisnikRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRfid = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.btnPristup = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRfid
            // 
            this.lblRfid.AutoSize = true;
            this.lblRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRfid.Location = new System.Drawing.Point(2, 12);
            this.lblRfid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRfid.Name = "lblRfid";
            this.lblRfid.Size = new System.Drawing.Size(51, 20);
            this.lblRfid.TabIndex = 1;
            this.lblRfid.Text = "label2";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIme.Location = new System.Drawing.Point(187, 12);
            this.lblIme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(51, 20);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "label3";
            // 
            // btnPristup
            // 
            this.btnPristup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPristup.Location = new System.Drawing.Point(337, 4);
            this.btnPristup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPristup.Name = "btnPristup";
            this.btnPristup.Size = new System.Drawing.Size(132, 37);
            this.btnPristup.TabIndex = 3;
            this.btnPristup.Text = "Oduzmi pristup";
            this.btnPristup.UseVisualStyleBackColor = true;
            this.btnPristup.Click += new System.EventHandler(this.btnPristup_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUkloni.Location = new System.Drawing.Point(473, 4);
            this.btnUkloni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(66, 37);
            this.btnUkloni.TabIndex = 4;
            this.btnUkloni.Text = "Ukloni";
            this.btnUkloni.UseVisualStyleBackColor = true;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // KorisnikRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnPristup);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.lblRfid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KorisnikRow";
            this.Size = new System.Drawing.Size(550, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRfid;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Button btnPristup;
        private System.Windows.Forms.Button btnUkloni;
    }
}
