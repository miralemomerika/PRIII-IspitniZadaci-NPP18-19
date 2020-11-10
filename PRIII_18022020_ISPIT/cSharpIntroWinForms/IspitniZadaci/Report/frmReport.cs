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
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using cSharpIntroWinForms.P8;

namespace cSharpIntroWinForms.IspitniZadaci.Report
{

    public partial class frmReport : Form
    {
        Korisnik korisnik = new Korisnik();
        GodineStudija godineStudija = new GodineStudija();
        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;
        public frmReport()
        {
            InitializeComponent();
        }

        public frmReport(Korisnik korisnik, GodineStudija godineStudija): this()
        {
            this.korisnik = korisnik;
            this.godineStudija = godineStudija;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (korisnik == null)
                return;

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImePrezime", $"{korisnik.Ime} {korisnik.Prezime}"));
            reportViewer1.LocalReport.SetParameters(rpc);

            List<object> lista = new List<object>();
            int i = 1;

            foreach (var item in korisnik.Uspjeh)
            {
                if (item.Godina.Id == godineStudija.Id)
                {
                    lista.Add(new
                    {
                        Rb = i++,
                        Predmet = item.Predmet.Naziv,
                        Godina = godineStudija.Naziv,
                        Ocjena = item.Ocjena,
                        Datum = item.Datum
                    });
                }
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = lista;
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
