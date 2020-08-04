using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiksRadarDesktop
{
    public partial class DodavanjeKorisnika : Form
    {
        SerialPort port;
        public DodavanjeKorisnika(SerialPort port)
        {
            InitializeComponent();
            this.port = port;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnDodaj.Enabled = (txtIme.Text.Length >= 3) ? true : false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            NewUserTempData.ime = txtIme.Text;
            NewUserTempData.pristup = chbxPristup.Checked;
            port.Write("ADD#");
            this.Close();
        }
    }
}
