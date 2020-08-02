using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
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

        public Form1()
        {
            InitializeComponent();
            db = new MiksRadarDatabaseContext();
            korisnici = db.Korisniks.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                string portName = cmbPorts.SelectedItem.ToString();
                port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                btnConnect.Text = "Discconect";
                cmbPorts.Enabled = false;
                port.Write("CONConnected: " + portName + "#");
                isPortOpen = true;
                Thread listeningThread = new Thread(Listen);
                listeningThread.Start();
            }
            else
            {
                port.Write("DSCDisconnected#");
                port.Close();
                btnConnect.Text = "Connect";
                cmbPorts.Enabled = true;
                isPortOpen = false;
                btnConnect.Enabled = false;
                Thread.Sleep(1000);
                btnConnect.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
            {
                try
                {
                    port.Write("DSCDisconnected#");
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
            }
            consoleBox.AppendText(cmd + "\n");
        }

        private void Authorize(string tag)
        {
            var korisnik = db.Korisniks.FirstOrDefault(k => k.RFID == tag);
            if (korisnik != null)
            {
                consoleBox.AppendText(korisnik.Ime+"\n");
                db.Prijavas.Add(new Prijava {
                    Korisnik=korisnik,
                    Pristup=true,
                    RFID=korisnik.RFID,
                    Vrijeme=DateTime.Now,
                    Kor_Id=korisnik.Id
                });
                port.Write("LSCBoris#");
            }
            else
            {
                db.Prijavas.Add(new Prijava
                {
                    Pristup=false,
                    RFID=tag,
                    Vrijeme=DateTime.Now
                });
                port.Write("LFDUser not found!#");
            }
            db.SaveChangesAsync();
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
        }
    }
}