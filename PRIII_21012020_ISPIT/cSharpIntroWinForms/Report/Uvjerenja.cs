using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.Report
{
    public partial class Uvjerenja : Form
    {
        private Korisnik korisnik;
        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;
        public Uvjerenja()
        {
            InitializeComponent();
        }

        public Uvjerenja(Korisnik korisnik): this()
        {
            this.korisnik = korisnik;
        }

        private void Uvjerenja_Load(object sender, EventArgs e)
        {
            try
            {
                if (korisnik == null)
                    return;

                ReportParameterCollection rpc = new ReportParameterCollection();
                rpc.Add(new ReportParameter("ImePrezime", $"{korisnik.Ime} {korisnik.Prezime}"));
                rpc.Add(new ReportParameter("Indeks", $"{korisnik.KorisnickoIme}"));

                reportViewer1.LocalReport.SetParameters(rpc);

                List<object> list = new List<object>();
                int i = 0;

                foreach (var polozeni in konekcijaNaBazu.Predmeti)
                {
                    var podaci = konekcijaNaBazu.KorisniciPredmeti.ToList().Where(x => x.Predmet.Id
                    == polozeni.Id && x.Korisnik.Id == korisnik.Id).Select(y => new { ocjena = y.Ocjena, datum = y.Datum }).FirstOrDefault();

                    list.Add(new
                    {
                        Id = i++,
                        Naziv = polozeni.Naziv,
                        Ocjena = podaci?.ocjena.ToString() ?? "Nije polozeno",
                        Datum = podaci?.datum.ToString() ?? "Nije polozeno"
                    });
                }

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DLWMS";
                rds.Value = list;

                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception er)
            {
                MboxHelper.PrikaziGresku(er);
            }
        }
    }
}
