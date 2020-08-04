namespace MiksRadarDesktop
{
    partial class DodavanjeKorisnika
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.chbxPristup = new System.Windows.Forms.CheckBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(125, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(40, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pravo pristupa:";
            // 
            // txtIme
            // 
            this.txtIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtIme.Location = new System.Drawing.Point(179, 38);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(134, 23);
            this.txtIme.TabIndex = 4;
            this.txtIme.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // chbxPristup
            // 
            this.chbxPristup.AutoSize = true;
            this.chbxPristup.Checked = true;
            this.chbxPristup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxPristup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbxPristup.Location = new System.Drawing.Point(179, 97);
            this.chbxPristup.Name = "chbxPristup";
            this.chbxPristup.Size = new System.Drawing.Size(15, 14);
            this.chbxPristup.TabIndex = 5;
            this.chbxPristup.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Enabled = false;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(165, 148);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(130, 40);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nakon pritiska na taster \"Dodaj\", skenirajte kartiicu";
            // 
            // DodavanjeKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 229);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.chbxPristup);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "DodavanjeKorisnika";
            this.Text = "DodavanjeKorisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.CheckBox chbxPristup;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
    }
}