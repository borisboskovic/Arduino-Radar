using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiksRadarDesktop
{
    public partial class Prijave : Form
    {
        public Prijave(MiksRadarDatabaseContext db)
        {
            InitializeComponent();
            var korisnici = db.Korisniks.ToList();
            var prijave = db.Prijavas.ToList().OrderByDescending(p=>p.Vrijeme).Select(p => new
            {
                p.RFID,
                Datum = p.Vrijeme.ToShortDateString(),
                Vrijeme = p.Vrijeme.ToShortTimeString(),
                p.Ime,
                p.Pristup
            }).ToList();
            dataGridPrijave.DataSource = prijave;
        }
    }
}
