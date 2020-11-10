﻿using cSharpIntroWinForms.IspitniZadaci;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpIntroWinForms.P10
{
    public class KorisniciPredmeti
    {
        public int Id { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Predmeti Predmet { get; set; }
        public int Ocjena { get; set; }
        public string Datum { get; set; }
        public virtual GodineStudija Godina { get; set; }

    }
}
