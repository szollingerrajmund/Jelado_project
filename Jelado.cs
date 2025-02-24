using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelado_proj
{
    internal class Jelado
    {
        public int ora { private set; get; }
        public int perc {  private set; get; }
        public int masodperc { private set; get; }
        public int x { private set; get; }
        public int y { private set; get; }

        public Jelado(string adatsor)
        {
            string[] adatok = adatsor.Split(' ');
            ora = int.Parse(adatok[0]);
            perc = int.Parse(adatok[1]);
            masodperc = int.Parse(adatok[2]);
            x = int.Parse(adatok[3]);
            y = int.Parse(adatok[4]);

        }
    }

}
