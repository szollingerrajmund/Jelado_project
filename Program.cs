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
            int mp1 = idő1[0]*3600 + idő1[1] * 60 + idő1[2];
            int mp2 = idő2[0] * 3600 + idő2[1] * 60 + idő2[2];

            return Math.Abs(mp1-mp2);

        }


        static void NegyedikFeladat()
        {
            Console.WriteLine(eltelt(jeladok[0]);
        }

        static Jelado GetSignalByIndex(int index)
        {
            return jeladok[index - 1];
        }
    }
}
