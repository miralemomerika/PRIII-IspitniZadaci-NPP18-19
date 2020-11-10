namespace cSharpIntroWinForms.P8
{
    partial class KorisniciPolozeniPredmeti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbPredmeti = new System.Windows.Forms.ComboBox();
            this.dtpDatumPolaganja = new System.Windows.Forms.DateTimePicker();
            this.btnDodajPolozeni = new System.Windows.Forms.Button();
            this.dgvPolozeniPredmeti = new System.Windows.Forms.DataGridView();
            this.Predmet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbOcjene = new System.Windows.Forms.ComboBox();
            this.btnASYNC = new System.Windows.Forms.Button();
            this.btnPrintajUvjerenje = new System.Windows.Forms.Button();
            this.cmbGodina = new System.Windows.Forms.ComboBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolozeniPredmeti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPredmeti
            // 
            this.cmbPredmeti.FormattingEnabled = true;
            this.cmbPredmeti.Location = new System.Drawing.Point(12, 9);
            this.cmbPredmeti.Name = "cmbPredmeti";
            this.cmbPredmeti.Size = new System.Drawing.Size(175, 21);
            this.cmbPredmeti.TabIndex = 0;
            // 
            // dtpDatumPolaganja
            // 
            this.dtpDatumPolaganja.Location = new System.Drawing.Point(401, 10);
            this.dtpDatumPolaganja.Name = "dtpDatumPolaganja";
            this.dtpDatumPolaganja.Size = new System.Drawing.Size(144, 20);
            this.dtpDatumPolaganja.TabIndex = 2;
            // 
            // btnDodajPolozeni
            // 
            this.btnDodajPolozeni.Location = new System.Drawing.Point(551, 7);
            this.btnDodajPolozeni.Name = "btnDodajPolozeni";
            this.btnDodajPolozeni.Size = new System.Drawing.Size(105, 23);
            this.btnDodajPolozeni.TabIndex = 3;
            this.btnDodajPolozeni.Text = "Dodaj";
            this.btnDodajPolozeni.UseVisualStyleBackColor = true;
            this.btnDodajPolozeni.Click += new System.EventHandler(this.btnDodajPolozeni_Click);
            // 
            // dgvPolozeniPredmeti
            // 
            this.dgvPolozeniPredmeti.AllowUserToAddRows = false;
            this.dgvPolozeniPredmeti.AllowUserToDeleteRows = false;
            this.dgvPolozeniPredmeti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolozeniPredmeti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Predmet,
            this.Godina,
            this.Ocjena,
            this.Datum});
            this.dgvPolozeniPredmeti.Location = new System.Drawing.Point(12, 59);
            this.dgvPolozeniPredmeti.Name = "dgvPolozeniPredmeti";
            this.dgvPolozeniPredmeti.ReadOnly = true;
            this.dgvPolozeniPredmeti.Size = new System.Drawing.Size(644, 214);
            this.dgvPolozeniPredmeti.TabIndex = 4;
            // 
            // Predmet
            // 
            this.Predmet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Predmet.DataPropertyName = "Predmet";
            this.Predmet.HeaderText = "Predmet";
            this.Predmet.Name = "Predmet";
            this.Predmet.ReadOnly = true;
            // 
            // Godina
            // 
            this.Godina.DataPropertyName = "Godina";
            this.Godina.HeaderText = "Godina";
            this.Godina.Name = "Godina";
            this.Godina.ReadOnly = true;
            // 
            // Ocjena
            // 
            this.Ocjena.DataPropertyName = "Ocjena";
            this.Ocjena.HeaderText = "Ocjena";
            this.Ocjena.Name = "Ocjena";
            this.Ocjena.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // cmbOcjene
            // 
            this.cmbOcjene.FormattingEnabled = true;
            this.cmbOcjene.Location = new System.Drawing.Point(321, 9);
            this.cmbOcjene.Name = "cmbOcjene";
            this.cmbOcjene.Size = new System.Drawing.Size(75, 21);
            this.cmbOcjene.TabIndex = 5;
            // 
            // btnASYNC
            // 
            this.btnASYNC.Location = new System.Drawing.Point(12, 298);
            this.btnASYNC.Name = "btnASYNC";
            this.btnASYNC.Size = new System.Drawing.Size(75, 23);
            this.btnASYNC.TabIndex = 7;
            this.btnASYNC.Text = "Run ASYNC";
            this.btnASYNC.UseVisualStyleBackColor = true;
            // 
            // btnPrintajUvjerenje
            // 
            this.btnPrintajUvjerenje.Location = new System.Drawing.Point(500, 298);
            this.btnPrintajUvjerenje.Name = "btnPrintajUvjerenje";
            this.btnPrintajUvjerenje.Size = new System.Drawing.Size(149, 23);
            this.btnPrintajUvjerenje.TabIndex = 7;
            this.btnPrintajUvjerenje.Text = "Printaj uvjerenje";
            this.btnPrintajUvjerenje.UseVisualStyleBackColor = true;
            this.btnPrintajUvjerenje.Click += new System.EventHandler(this.btnPrintajUvjerenje_Click);
            // 
            // cmbGodina
            // 
            this.cmbGodina.FormattingEnabled = true;
            this.cmbGodina.Location = new System.Drawing.Point(192, 9);
            this.cmbGodina.Name = "cmbGodina";
            this.cmbGodina.Size = new System.Drawing.Size(123, 21);
            this.cmbGodina.TabIndex = 8;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnBrisi
            // 
            this.btnBrisi.Location = new System.Drawing.Point(345, 298);
            this.btnBrisi.Name = "btnBrisi";
            this.btnBrisi.Size = new System.Drawing.Size(149, 23);
            this.btnBrisi.TabIndex = 9;
            this.btnBrisi.Text = "Izbrisi sve polozene";
            this.btnBrisi.UseVisualStyleBackColor = true;
            this.btnBrisi.Click += new System.EventHandler(this.btnBrisi_Click);
            // 
            // KorisniciPolozeniPredmeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 333);
            this.Controls.Add(this.btnBrisi);
            this.Controls.Add(this.cmbGodina);
            this.Controls.Add(this.btnPrintajUvjerenje);
            this.Controls.Add(this.btnASYNC);
            this.Controls.Add(this.cmbOcjene);
            this.Controls.Add(this.dgvPolozeniPredmeti);
            this.Controls.Add(this.btnDodajPolozeni);
            this.Controls.Add(this.dtpDatumPolaganja);
            this.Controls.Add(this.cmbPredmeti);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KorisniciPolozeniPredmeti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Položeni predmeti korisnika";
            this.Load += new System.EventHandler(this.KorisniciPolozeniPredmeti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolozeniPredmeti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPredmeti;
        private System.Windows.Forms.DateTimePicker dtpDatumPolaganja;
        private System.Windows.Forms.Button btnDodajPolozeni;
        private System.Windows.Forms.DataGridView dgvPolozeniPredmeti;
        private System.Windows.Forms.ComboBox cmbOcjene;
        private System.Windows.Forms.Button btnASYNC;
        private System.Windows.Forms.Button btnPrintajUvjerenje;
        private System.Windows.Forms.ComboBox cmbGodina;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.DataGridViewTextBoxColumn Predmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ocjena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.Button btnBrisi;
    }
}