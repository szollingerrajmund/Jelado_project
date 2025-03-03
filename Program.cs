using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelado_proj
{
    internal class Program
    {

        static string allomanyNev = "jel.txt";
        static List<Jelado> jeladok = new List<Jelado>();

        static void Main(string[] args)
        {
            foreach (string sor in File.ReadAllLines(allomanyNev))
            {
                jeladok.Add(new Jelado(sor));
            }

            MasodikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            Console.ReadKey();

        }


        static void MasodikFeladat()
        {
            Console.WriteLine("2. feladat:");
            Console.Write("Adja meg a jel sorszámát! ");
            int inputIndex = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSignalByIndex(inputIndex).Coordinates);
        }


        static int eltelt(int[] idő1, int[] idő2)
        {
            int mp1 = idő1[0] * 3600 + idő1[1] * 60 + idő1[2];
            int mp2 = idő2[0] * 3600 + idő2[1] * 60 + idő2[2];

            return Math.Abs(mp1 - mp2);

        }


        static void NegyedikFeladat()
        {
            int elteltmp = eltelt(jeladok[0].idő, jeladok[jeladok.Count - 1].idő);
            int óra = elteltmp / 3600;
            int perc = (elteltmp / 60) % 60;
            int másodperc = elteltmp % 60;


            Console.WriteLine("4. feladat");
            Console.WriteLine($"Időtartam: {óra}:{perc}:{másodperc}");

        }

        static void OtodikFeladat()
        {
            Console.WriteLine("5. feladat");
            int[] koordinatak = Koordináták();
            Console.WriteLine($"Bal alsó: {koordinatak[0]} {koordinatak[1]}, jobb felső: {koordinatak[2]} {koordinatak[3]}");
        }

        static Jelado GetSignalByIndex(int index)
        {
            return jeladok[index - 1];
        }

        static int[] Koordináták()
        {
            int minimumx = int.MaxValue;
            int minimumy = int.MaxValue;
            int maximumx = int.MinValue;
            int maximumy = int.MinValue;

            foreach (var jelado in jeladok)
            {
                if (jelado.x < minimumx)
                {
                    minimumx = jelado.x;
                }

                if (jelado.y < minimumy)
                {
                    minimumy = jelado.y;
                }

                if (jelado.x > maximumx)
                {
                    maximumx = jelado.x;
                }

                if (jelado.y > maximumy)
                {
                    maximumy = jelado.y;
                }

            }
            return new int[] {minimumx, minimumy, maximumx, maximumy};
        }
    }
}
