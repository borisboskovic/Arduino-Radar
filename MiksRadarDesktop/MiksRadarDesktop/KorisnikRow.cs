using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiksRadarDesktop
{
    public partial class KorisnikRow : UserControl
    {
        Korisnik korisnik;
        KorisniciForm form;
        public KorisnikRow(Korisnik k, KorisniciForm form)
        {
            InitializeComponent();
            korisnik = k;
            lblIme.Text = k.Ime;
            lblIme.ForeColor = (k.Pristup) ? Color.DarkGreen : Color.DarkRed;
            lblRfid.Text = k.RFID;
            btnPristup.Text = (k.Pristup) ? "Oduzmi pristup" : "Dodijeli pristup";
            this.form = form;
        }

        private void btnPristup_Click(object sender, EventArgs e)
        {
            form.ToggleAccess(korisnik);
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            form.Remove(korisnik);
        }
    }
}
