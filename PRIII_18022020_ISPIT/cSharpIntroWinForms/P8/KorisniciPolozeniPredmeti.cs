using cSharpIntroWinForms.IspitniZadaci;
using cSharpIntroWinForms.IspitniZadaci.Report;
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik;

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
        }

        public KorisniciPolozeniPredmeti(Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
        }

        private void KorisniciPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            UcitajPredmete();
            UcitajOcjene();
            UcitajPolozenePredmete();
            UcitajGodine();
        }

        private void UcitajGodine()
        {
            foreach (var item in konekcijaNaBazu.Godine)
            {
                if (item.Aktivna > 0)
                {
                    cmbGodina.Items.Add(item);

                    cmbGodina.DisplayMember = "Naziv";
                    cmbGodina.ValueMember = "Id";
                }
            }
            cmbGodina.SelectedIndex = 0;
        }

        private void UcitajOcjene()
        {
            for (int i = 6; i <= 10; i++)
                cmbOcjene.Items.Add(i);
            cmbOcjene.SelectedIndex = 0;
        }

        private void UcitajPredmete()
        {
            try
            {
                cmbPredmeti.DataSource = null;
                cmbPredmeti.DataSource = konekcijaNaBazu.Predmeti.ToList();

                cmbPredmeti.DisplayMember = "Naziv";
                cmbPredmeti.ValueMember = "Id";
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void UcitajPolozenePredmete()
        {
            try
            {
                dgvPolozeniPredmeti.DataSource = null;
                dgvPolozeniPredmeti.DataSource = korisnik.Uspjeh.ToList();
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            Predmeti predmet = cmbPredmeti.SelectedItem as Predmeti;
            int ocjena = int.Parse(cmbOcjene.SelectedItem.ToString());
            GodineStudija godina = cmbGodina.SelectedItem as GodineStudija;

            if(!ProvjeriGodinuPredmet(predmet, godina))
            {
                KorisniciPredmeti novi = new KorisniciPredmeti();

                novi.Predmet = predmet;
                novi.Ocjena = ocjena;
                novi.Godina = godina;
                novi.Datum = dtpDatumPolaganja.Value.ToString("dd.MM.yyyy");

                korisnik.Uspjeh.Add(novi);
                konekcijaNaBazu.SaveChanges();

            }
            UcitajPolozenePredmete();
        }

        private bool ProvjeriGodinuPredmet(Predmeti predmet, GodineStudija godina)
        {
            if(konekcijaNaBazu.KorisniciPredmeti.Where(x => x.Predmet.Id == predmet.Id 
            && x.Godina.Id == godina.Id).Count() > 0)
            {
                MessageBox.Show($"Predmet {predmet} je vec evidentira korisniku {korisnik} na {godina}!");
                return true;
            }
            return false;
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            konekcijaNaBazu.KorisniciPredmeti.RemoveRange(konekcijaNaBazu.KorisniciPredmeti.ToList());
            UcitajPolozenePredmete();
            konekcijaNaBazu.SaveChanges();
            MessageBox.Show("Predmeti izbrisani!");

        }

        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            GodineStudija godineStudija = cmbGodina.SelectedItem as GodineStudija;
            Form frm = new Form();
            frm = new frmReport(korisnik, godineStudija);
            frm.ShowDialog();
        }
    }
}
