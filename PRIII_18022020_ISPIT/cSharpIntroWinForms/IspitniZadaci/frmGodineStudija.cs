using cSharpIntroWinForms.P10;
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
using System.Data.Entity;

namespace cSharpIntroWinForms.IspitniZadaci
{
    public partial class frmGodineStudija : Form
    {
        GodineStudija godineStudija = new GodineStudija();
        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        private bool Edit { get; set; }

        public frmGodineStudija()
        {
            InitializeComponent();
            dgvGodine.AutoGenerateColumns = false;
        }

        private void frmGodineStudija_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvGodine.DataSource = null;
                dgvGodine.DataSource = konekcijaNaBazu.Godine.ToList();
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                string godina = txtNazivGodine.Text;
                if (ProvjeriGodinu(godina))
                {
                    int aktivna = 0;
                    if (cbAktivna.Checked)
                        aktivna = 1;
                    else
                        aktivna = 0;

                    godineStudija.Naziv = godina;
                    godineStudija.Aktivna = aktivna;
                    if (!Edit)
                    {
                        konekcijaNaBazu.Godine.Add(godineStudija);
                        konekcijaNaBazu.SaveChanges();
                        MessageBox.Show("Dodali ste godinu!");
                    }
                    else
                    {
                        konekcijaNaBazu.Entry(godineStudija).State = EntityState.Modified;
                        konekcijaNaBazu.SaveChanges();
                        MessageBox.Show("Editovali ste godinu!");
                        Edit = false;
                    }
                }
            }
            LoadData();
            dgvGodine.ClearSelection();
        }

        private bool ProvjeriGodinu(string godina)
        {
            if (!Edit)
            {
                if (konekcijaNaBazu.Godine.ToList().Where(x => x.Naziv == godina).Count() > 0)
                {
                    MessageBox.Show("Unesena godina je vec evidentirana u sistem!");
                    return false;
                }
            }
                return true;
        }

        private bool ValidirajUnos()
        {
            if (string.IsNullOrEmpty(txtNazivGodine.Text))
            {
                err.SetError(txtNazivGodine, "Obavezan unos!");
                return false;
            }
            else
            {
                err.Clear();
                return true;
            }
        }

        private void dgvGodine_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            godineStudija = dgvGodine.SelectedRows[0].DataBoundItem as GodineStudija;
            if(godineStudija != null)
            {
                txtNazivGodine.Text = godineStudija.Naziv;
                if (godineStudija.Aktivna > 0)
                    cbAktivna.Checked = true;
                else
                    cbAktivna.Checked = false;
                Edit = true;
            }
        }
    }
}
