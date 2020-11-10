using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IspitniZadaci
{
    public partial class Glavna : Form
    {
        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnGodineStudija_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm = new frmGodineStudija();
            frm.ShowDialog();
        }

        private void btnPolozeni_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = konekcijaNaBazu.Korisnici.FirstOrDefault();
            Form frm = new Form();
            frm = new KorisniciPolozeniPredmeti(korisnik);
            frm.ShowDialog();
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            ulong suma = 0;
            ulong uneseniBroj = ulong.Parse(txtSuma.Text);

            var Izracunaj = Task.Run(() =>
            {
                try
                {
                    for (ulong i = 1; i <= uneseniBroj; i++)
                        suma += i;
                }
                catch (Exception er)
                {
                    MboxHelper.PrikaziGresku(er);
                }
            });

            var awaiter = Izracunaj.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                MessageBox.Show($"Suma brojeva od 1 do {uneseniBroj} je: {suma}");
            });

        }
    }
}
