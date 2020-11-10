using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class KorisniciAdmin : Form
    {

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciAdmin()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void KorisniciAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvKorisnici.AutoGenerateColumns = false;
        }


        private void LoadData(List<Korisnik> korisnici = null)
        {
            try
            {
                List<Korisnik> rezultati = korisnici ?? konekcijaNaBazu.Korisnici.ToList();

                dgvKorisnici.DataSource = null;
                dgvKorisnici.DataSource = rezultati;

                IzracunajProsjek(rezultati);

            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        private void IzracunajProsjek(List<Korisnik> korisnici)
        {
            int brojacOcjena = 0;
            float suma = 0;

            if (korisnici.Count() > 0)
            {
                foreach (var item in korisnici)
                {
                    float tempSuma = 0;
                    tempSuma += item.Uspjeh.Sum(x => x.Ocjena);//sumiranje svih ocjena jednog korisnika
                    if (tempSuma == 0)
                        continue;

                    tempSuma /= item.Uspjeh.Count();
                    suma += tempSuma;
                    brojacOcjena++;
                }
            }

            lblProsjek.Text = "Prosjecna ocjena je ";
            if (brojacOcjena > 0)
                lblProsjek.Text += (suma / brojacOcjena).ToString("0.##");
            else
                lblProsjek.Text += "0";
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            string filter = txtPretraga.Text.ToLower();
            List<Korisnik> korisnici = konekcijaNaBazu.Korisnici.Where(x => x.Ime.ToLower().Contains(filter)
            || x.Prezime.ToLower().Contains(filter)).ToList();

            LoadData(korisnici);

            if (String.IsNullOrEmpty(txtPretraga.Text) && String.IsNullOrWhiteSpace(txtPretraga.Text))
                LoadData();
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Korisnik korisnik = null;

            try
            {
                korisnik = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnik;
                if (korisnik == null)
                    throw new Exception("Niste selektovali korisnika!");
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }

            if (e.ColumnIndex == 5)
            {
                Form frm = new Form();
                frm = new KorisniciPolozeniPredmeti(korisnik);
                frm.ShowDialog();
            }
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            //brisanje svi polozenih predmeta iz baze
            //nije bilo na ispitu
            konekcijaNaBazu.KorisniciPredmeti.RemoveRange(konekcijaNaBazu.KorisniciPredmeti.ToList());
            LoadData();
            konekcijaNaBazu.SaveChanges();
        }

    }
}
