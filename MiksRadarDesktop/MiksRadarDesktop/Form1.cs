﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiksRadarDesktop
{
    public partial class Form1 : Form
    {
        MiksRadarDatabaseContext db;
        SerialPort port;
        bool isPortOpen = false;
        List<Korisnik> korisnici;
        KorisniciForm korisniciForm;

        public Form1()
        {
            InitializeComponent();
            db = new MiksRadarDatabaseContext();
            korisnici = db.Korisniks.ToList();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consoleBox.AppendText(DateTime.Now + " -- Program pokrenut.\n");
            string[] availablePorts = SerialPort.GetPortNames();
            foreach (string port in availablePorts)
                cmbPorts.Items.Add(port);
            try
            {
                cmbPorts.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        //Otvaranje i zatvaranje porta (Connect/Disconnect)
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isPortOpen)
            {
                if (cmbPorts.Items.Count == 0)
                {
                    string[] availablePorts = SerialPort.GetPortNames();
                    foreach (string port in availablePorts)
                        cmbPorts.Items.Add(port);
                    cmbPorts.SelectedIndex = 0;
                }
                string portName = cmbPorts.SelectedItem.ToString();
                port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                port.DtrEnable = false;
                port.Open();
                btnConnect.Text = "Prekini";
                lblConnectionStatus.Text = "Veza uspostavljena";
                lblConnectionStatus.ForeColor = Color.DarkGreen;
                cmbPorts.Enabled = false;
                port.Write("CONPovezano: " + portName + "#");
                isPortOpen = true;
                Thread listeningThread = new Thread(Listen);
                listeningThread.Start();
                consoleBox.AppendText(DateTime.Now + " -- Povezano sa Arduino Uno na portu " + portName + ".\n");
                consoleBox.ScrollToCaret();
            }
            else
            {
                port.Write("DSCVeza prekinuta#");
                port.Close();
                btnConnect.Text = "Povezi";
                btnPause.Text = "Pauza";
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
                btnUsers.Enabled = false;
                btnHistory.Enabled = false;
                lblKorisnik.Text = "";
                lblConnectionStatus.Text = "Veza prekinuta";
                lblConnectionStatus.ForeColor = Color.DarkRed;
                cmbPorts.Enabled = true;
                isPortOpen = false;
                btnConnect.Enabled = false;
                btnPause.Enabled = false;
                radarPanel.ClearMeasurements();
                radarPanel.Refresh();
                Thread.Sleep(1000);
                btnConnect.Enabled = true;
                consoleBox.AppendText(DateTime.Now + " -- Prekinuta veza sa Arduino Uno na portu " + port.PortName + ".\n");
                consoleBox.ScrollToCaret();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
            {
                try
                {
                    port.Write("DSCVeza prekinuta#");
                    port.Close();

                }
                catch (InvalidOperationException) { }
            }
            Environment.Exit(Environment.ExitCode);
        }

        public void ExecuteCommand(string cmd)
        {
            switch (cmd.Substring(0, 3))
            {
                case "RFD":
                    string tag = cmd.Substring(3, cmd.Length - 4);
                    Authorize(tag);
                    break;
                case "RES":
                    ProcessResult(cmd.Substring(3, cmd.Length - 4));
                    break;
                case "PAU":
                    if (btnPause.Text == "Pauza")
                    {
                        btnPause.Text = "Nastavi";
                        consoleBox.AppendText(DateTime.Now + " -- Radar zaustavljen (pritiskom tastera)\n");
                        consoleBox.ScrollToCaret();
                    }
                    else
                    {
                        btnPause.Text = "Pauza";
                        consoleBox.AppendText(DateTime.Now + " -- Radar pokrenut (pritiskom tastera)\n");
                        consoleBox.ScrollToCaret();
                    }
                    break;
                case "ADD":
                    string rfid = cmd.Substring(3, cmd.Length - 4);
                    Korisnik noviKorisnik = new Korisnik
                    {
                        Ime = NewUserTempData.ime,
                        RFID = rfid,
                        Pristup = NewUserTempData.pristup
                    };
                    List<Korisnik> korisnici = db.Korisniks.ToList();
                    bool add = true;
                    foreach (Korisnik k in korisnici)
                        if (k.RFID == noviKorisnik.RFID)
                            add = false;
                    if (add)
                    {
                        db.Korisniks.Add(noviKorisnik);
                        db.SaveChanges();
                        korisniciForm.RefreshUsers();
                        MessageBox.Show("Dodat je novi korisnik.", "Dodato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Ta kartica vec postoji u bazi podataka.", "Nije dodato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void Authorize(string tag)
        {
            var korisnik = db.Korisniks.FirstOrDefault(k => k.RFID == tag);
            if (korisnik != null && korisnik.Pristup)
            {
                lblKorisnik.Text = korisnik.Ime;
                btnPause.Enabled = true;
                btnSend.Enabled = true;
                btnUsers.Enabled = true;
                btnHistory.Enabled = true;
                txtMessage.Enabled = true;
                db.Prijavas.Add(new Prijava
                {
                    Korisnik = korisnik,
                    Pristup = true,
                    RFID = korisnik.RFID,
                    Vrijeme = DateTime.Now,
                    Kor_Id = korisnik.Id,
                    Ime=korisnik.Ime
                });
                port.Write("LSCBoris#");
                consoleBox.AppendText(DateTime.Now + " -- Prijava RFID tagom: " + tag + ". Korisnik: " + korisnik.Ime + ". PRISTUP ODOBREN\n");
                consoleBox.ScrollToCaret();
            }
            else if (korisnik != null && !korisnik.Pristup)
            {
                db.Prijavas.Add(new Prijava
                {
                    Korisnik = korisnik,
                    Pristup = false,
                    RFID = korisnik.RFID,
                    Vrijeme = DateTime.Now,
                    Kor_Id = korisnik.Id,
                    Ime=korisnik.Ime
                });
                port.Write("LFDNemate pristup!#");
                consoleBox.AppendText(DateTime.Now + " -- Prijava RFID tagom: " + tag + ". Korisnik: " + korisnik.Ime + ". PRISTUP ODBIJEN\n");
                consoleBox.ScrollToCaret();
            }
            else
            {
                db.Prijavas.Add(new Prijava
                {
                    Pristup = false,
                    RFID = tag,
                    Vrijeme = DateTime.Now
                });
                port.Write("LFDNemate pristup!#");
                consoleBox.AppendText(DateTime.Now + " -- Pokusaj prijave RFID tagom: " + tag + ". Korisnik nije pronadjen. PRISTUP ODBIJEN\n");
                consoleBox.ScrollToCaret();
            }
            db.SaveChangesAsync();
        }

        private void ProcessResult(string result)
        {
            radarPanel.AddMeasurement(result);
            radarPanel.Refresh();
        }

        public void Listen()
        {
            while (port.IsOpen)
            {
                try
                {
                    string msg = port.ReadLine();
                    Invoke(new MethodInvoker(
                        delegate
                        {
                            ExecuteCommand(msg);
                        }
                        ));
                }
                catch { }
            }
            string[] availPorts = SerialPort.GetPortNames();
            bool exit = true;
            foreach (string portName in availPorts)
                if (portName.Equals(port.PortName))
                    exit = false;
            if (exit) Environment.Exit(Environment.ExitCode);

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (port != null)
            {
                if (port.IsOpen)
                {
                    if (btnPause.Text == "Pauza")
                    {
                        port.Write("PAU#");
                        btnPause.Text = "Nastavi";
                        consoleBox.AppendText(DateTime.Now + " -- Radar zaustavljen (iz aplikacije)\n");
                        consoleBox.ScrollToCaret();
                    }
                    else
                    {
                        port.Write("RSM#");
                        btnPause.Text = "Pauza";
                        consoleBox.AppendText(DateTime.Now + " -- Radar pokrenut (iz aplikacije)\n");
                        consoleBox.ScrollToCaret();
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (port != null)
            {
                if (port.IsOpen)
                {
                    string message = txtMessage.Text;
                    txtMessage.Text = "";
                    port.Write("MSG" + message + "#");
                    consoleBox.AppendText(DateTime.Now + " -- Poslata poruka: " + message + "\n");
                    consoleBox.ScrollToCaret();
                }
            }
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(txtMessage, null);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Prijave prijaveWindow = new Prijave(db);
            prijaveWindow.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            korisniciForm = new KorisniciForm(port, db);
            korisniciForm.Show();
        }
    }
}