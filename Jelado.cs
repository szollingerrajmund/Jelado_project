using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelado_proj
{
    internal class Jelado
    {
        public int ora { set; get; }
        public int perc { set; get; }
        public int masodperc { set; get; }
        public int x { set; get; }
        public int y { set; get; }

        public string GetCoordinates()
        {
            return $"x={x} y={y}";
        }

        public int[] Idő()
        {
            return new int[] { ora, perc, masodperc };
        }

        public double DistanceTo(Jelado masikJelado)
        {
            return Math.Sqrt(Math.Pow(x - masikJelado.x, 2) + Math.Pow(y - masikJelado.y, 2));
        }

        public Jelado() {}
    }

}
