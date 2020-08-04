namespace MiksRadarDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblLabela = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.radarPanel = new MiksRadarDesktop.RadarPanel();
            this.SuspendLayout();
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(320, 521);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(1024, 197);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            // 
            // cmbPorts
            // 
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(76, 74);
            this.cmbPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(59, 21);
            this.cmbPorts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(46, 99);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 31);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Povezi";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblLabela
            // 
            this.lblLabela.AutoSize = true;
            this.lblLabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLabela.Location = new System.Drawing.Point(11, 9);
            this.lblLabela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLabela.Name = "lblLabela";
            this.lblLabela.Size = new System.Drawing.Size(62, 17);
            this.lblLabela.TabIndex = 4;
            this.lblLabela.Text = "Korisnik:";
            this.lblLabela.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Location = new System.Drawing.Point(11, 26);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(149, 24);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "Veza prekinuta";
            this.lblConnectionStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKorisnik.Location = new System.Drawing.Point(78, 9);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(0, 17);
            this.lblKorisnik.TabIndex = 7;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(170, 74);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(89, 56);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "Pauza";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Poruka:";
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(14, 208);
            this.txtMessage.MaxLength = 32;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(289, 20);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(14, 234);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(289, 31);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Posalji";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Enabled = false;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.Location = new System.Drawing.Point(15, 602);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(288, 49);
            this.btnUsers.TabIndex = 12;
            this.btnUsers.Text = "Korisnici";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Enabled = false;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHistory.Location = new System.Drawing.Point(15, 668);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(288, 49);
            this.btnHistory.TabIndex = 13;
            this.btnHistory.Text = "Istorija prijava";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
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
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.radarPanel);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.lblLabela);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.consoleBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblLabela;
        private System.Windows.Forms.Label lblConnectionStatus;
        private RadarPanel radarPanel;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnHistory;
    }
}

