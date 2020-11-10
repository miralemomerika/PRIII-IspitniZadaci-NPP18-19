using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using cSharpIntroWinForms.Report;
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
            this.Text = $"Polozeni predmeti {korisnik} korisnika:";
            UcitajPredmete();
            UcitajOcjene();
            UcitajPolozenePredmete();
        }

        private void UcitajPolozenePredmete()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = korisnik.Uspjeh;
        }

        private void UcitajOcjene()
        {
            for (int i = 6; i <= 10; i++)
                cmbOcjene.Items.Add(i);
            cmbOcjene.SelectedIndex = 0;
        }

        private void UcitajPredmete(List<Predmeti> predmeti = null)
        {
            cmbPredmeti.DataSource = null;

            try
            {
                if (predmeti == null)
                    cmbPredmeti.DataSource = konekcijaNaBazu.Predmeti.ToList();
                else
                    cmbPredmeti.DataSource = predmeti;

                cmbPredmeti.DisplayMember = "Naziv";
                cmbPredmeti.ValueMember = "Id";
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void cbUcitajNepolozene_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbUcitajNepolozene.Checked)
                {
                    var query = from c in konekcijaNaBazu.Predmeti.AsEnumerable()
                                where !(from o in korisnik.Uspjeh select o.Predmet.Id).Contains(c.Id)
                                select c;

                    UcitajPredmete(query.ToList());
                }
                else
                    UcitajPredmete();
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm = new Uvjerenja(korisnik);
            frm.ShowDialog();
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            try
            {
                int ocjena = int.Parse(cmbOcjene.SelectedItem.ToString());
                if (ocjena < 6 || ocjena > 10)
                    throw new Exception("Unesena ocjena nije validna!");

                Predmeti odabraniPredmet = cmbPredmeti.SelectedItem as Predmeti;
                ProvjeriOdabraniPredmet(odabraniPredmet);

                KorisniciPredmeti novi = new KorisniciPredmeti();
                novi.Predmet = odabraniPredmet;
                novi.Ocjena = ocjena;
                novi.Datum = dtpDatumPolaganja.Value.ToString("dd.MM.yyyy");

                korisnik.Uspjeh.Add(novi);
                konekcijaNaBazu.SaveChanges();

                UcitajPolozenePredmete();
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void ProvjeriOdabraniPredmet(Predmeti odabraniPredmet)
        {
            if (korisnik.Uspjeh.Where(x => x.Predmet.Id == odabraniPredmet.Id).Count() > 0)
                throw new Exception($"Odabrani predmet {odabraniPredmet} je vec evidentiran korisniku {korisnik}!");
        }

        private void btnASYNC_Click(object sender, EventArgs e)
        {
            //ovo se mora vani odraditi da se thread ne bi zeznuo, odma se ovdje definise sta se unosi 500 puta
            Predmeti odabraniPredmet = cmbPredmeti.SelectedItem as Predmeti;
            int ocjena = int.Parse(cmbOcjene.SelectedItem.ToString());

            var dodavanjePredmetaTask = Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 500; i++)
                    {
                        KorisniciPredmeti kp = new KorisniciPredmeti();

                        kp.Predmet = odabraniPredmet;
                        kp.Ocjena = ocjena;
                        kp.Datum = DateTime.Now.ToString("dd.MM.yyyy");

                        //dodavanje korisniku
                        korisnik.Uspjeh.Add(kp);

                        //spasavanje u bazu
                        konekcijaNaBazu.SaveChanges();
                    }
                }
                catch (Exception er)
                {
                    MboxHelper.PrikaziGresku(er);
                }
            });

            var cekanje = dodavanjePredmetaTask.GetAwaiter();//kreiramo awaitera
            cekanje.OnCompleted(() =>
            {
                MessageBox.Show("Uspjesno je dodano 500 predmeta.");
                UcitajPolozenePredmete();
            });
        }
    }
}
