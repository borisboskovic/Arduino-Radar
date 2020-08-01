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
    public partial class Form1 : Form
    {
        MiksRadarDatabaseContext db;

        public Form1()
        {
            InitializeComponent();
            db = new MiksRadarDatabaseContext();
        }
    }
}
