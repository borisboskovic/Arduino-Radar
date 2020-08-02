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

        public Form1()
        {
            InitializeComponent();
            db = new MiksRadarDatabaseContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] availablePorts = SerialPort.GetPortNames();
            foreach (string port in availablePorts)
                cmbPorts.Items.Add(port);
            cmbPorts.SelectedIndex = 0;
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
            consoleBox.AppendText(cmd + "\n");
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