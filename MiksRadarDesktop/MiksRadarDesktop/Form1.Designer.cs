﻿namespace MiksRadarDesktop
{
    partial class Form1
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
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblKorisik = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.radarPanel = new MiksRadarDesktop.RadarPanel();
            this.SuspendLayout();
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(9, 595);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(582, 123);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(53, 66);
            this.cmbPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(59, 21);
            this.cmbPorts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(23, 91);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 21);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblKorisik
            // 
            this.lblKorisik.AutoSize = true;
            this.lblKorisik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKorisik.Location = new System.Drawing.Point(32, 142);
            this.lblKorisik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKorisik.Name = "lblKorisik";
            this.lblKorisik.Size = new System.Drawing.Size(62, 17);
            this.lblKorisik.TabIndex = 4;
            this.lblKorisik.Text = "Korisnik:";
            this.lblKorisik.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Location = new System.Drawing.Point(22, 118);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(138, 24);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // radarPanel
            // 
            this.radarPanel.Location = new System.Drawing.Point(320, 4);
            this.radarPanel.Name = "radarPanel";
            this.radarPanel.Size = new System.Drawing.Size(1024, 512);
            this.radarPanel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.radarPanel);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.lblKorisik);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.consoleBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form1";
            this.Text = "Arduino Radar - by Boris Boskovic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblKorisik;
        private System.Windows.Forms.Label lblConnectionStatus;
        private RadarPanel radarPanel;
    }
}

