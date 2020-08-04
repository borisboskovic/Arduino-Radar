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
    public partial class KorisniciForm : Form
    {
        MiksRadarDatabaseContext db;
        SerialPort port;
        public KorisniciForm(SerialPort port, MiksRadarDatabaseContext db)
        {
            InitializeComponent();
            this.port = port;
            this.db = db;
            List<Korisnik> korisnici = db.Korisniks.ToList();
            foreach (Korisnik k in korisnici)
                flowLayoutPanel1.Controls.Add(new KorisnikRow(k, this));
        }

        public void Remove(Korisnik k)
        {
            db.Korisniks.Remove(k);
            db.SaveChanges();
            flowLayoutPanel1.Controls.Clear();
            List<Korisnik> korisnici = db.Korisniks.ToList();
            foreach (Korisnik korisnik in korisnici)
                flowLayoutPanel1.Controls.Add(new KorisnikRow(korisnik, this));
        }

        public void ToggleAccess(Korisnik k)
        {
            k.Pristup = !k.Pristup;
            db.SaveChanges();
            flowLayoutPanel1.Controls.Clear();
            List<Korisnik> korisnici = db.Korisniks.ToList();
            foreach (Korisnik korisnik in korisnici)
                flowLayoutPanel1.Controls.Add(new KorisnikRow(korisnik, this));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodavanjeKorisnika window = new DodavanjeKorisnika(port);
            window.Show();
        }
    }
}
