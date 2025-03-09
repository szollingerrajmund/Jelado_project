using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelado_proj
{
    public enum ElteresTipusa {
        SEMMI = 0,
        IDO = 1,
        KOORDINATA = 2
    }

    class Elteres
    {
        public int óra;
        public int perc;
        public int másodperc;
        public int kimaradtJelek;
        public string kimaradasTipusa;

        public Elteres(Jelado kovetkezoJel, int kimaradtJelekSzama, ElteresTipusa elteresTipusa)
        {
            óra = kovetkezoJel.ora;
            perc = kovetkezoJel.perc;
            másodperc = kovetkezoJel.masodperc;
            kimaradtJelek = kimaradtJelekSzama;
            kimaradasTipusa = elteresTipusa == ElteresTipusa.IDO ? "időeltérés" : "koordináta-eltérés";
        }
    }
}
