namespace cSharpIntroWinForms.IspitniZadaci
{
    partial class frmGodineStudija
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
            this.txtNazivGodine = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvGodine = new System.Windows.Forms.DataGridView();
            this.Nazic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbAktivna = new System.Windows.Forms.CheckBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNazivGodine
            // 
            this.txtNazivGodine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazivGodine.Location = new System.Drawing.Point(13, 13);
            this.txtNazivGodine.Name = "txtNazivGodine";
            this.txtNazivGodine.Size = new System.Drawing.Size(132, 26);
            this.txtNazivGodine.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.Location = new System.Drawing.Point(221, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Sacuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvGodine
            // 
            this.dgvGodine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGodine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGodine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazic,
            this.Aktivna});
            this.dgvGodine.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGodine.Location = new System.Drawing.Point(13, 46);
            this.dgvGodine.Name = "dgvGodine";
            this.dgvGodine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGodine.Size = new System.Drawing.Size(283, 150);
            this.dgvGodine.TabIndex = 2;
            this.dgvGodine.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGodine_CellMouseDoubleClick);
            // 
            // Nazic
            // 
            this.Nazic.DataPropertyName = "Naziv";
            this.Nazic.FillWeight = 137.0559F;
            this.Nazic.HeaderText = "Naziv";
            this.Nazic.Name = "Nazic";
            // 
            // Aktivna
            // 
            this.Aktivna.DataPropertyName = "Aktivna";
            this.Aktivna.FalseValue = "0";
            this.Aktivna.FillWeight = 62.94416F;
            this.Aktivna.HeaderText = "Aktivna";
            this.Aktivna.Name = "Aktivna";
            this.Aktivna.TrueValue = "1";
            // 
            // cbAktivna
            // 
            this.cbAktivna.AutoSize = true;
            this.cbAktivna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbAktivna.Location = new System.Drawing.Point(151, 18);
            this.cbAktivna.Name = "cbAktivna";
            this.cbAktivna.Size = new System.Drawing.Size(64, 19);
            this.cbAktivna.TabIndex = 3;
            this.cbAktivna.Text = "Aktivna";
            this.cbAktivna.UseVisualStyleBackColor = true;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmGodineStudija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 206);
            this.Controls.Add(this.cbAktivna);
            this.Controls.Add(this.dgvGodine);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNazivGodine);
            this.Name = "frmGodineStudija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGodineStudija";
            this.Load += new System.EventHandler(this.frmGodineStudija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNazivGodine;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvGodine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivna;
        private System.Windows.Forms.CheckBox cbAktivna;
        private System.Windows.Forms.ErrorProvider err;
    }
}