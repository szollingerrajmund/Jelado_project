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


        static void Main(string[] args)
        {
            Megoldas mo = new Megoldas("jel.json");

            Console.WriteLine("2. feladat:");
            Console.Write("Adja meg a jel sorszámát! ");
            mo.MasodikFeladat();

            Console.WriteLine("\n4. feladat");
            mo.NegyedikFeladat();

            Console.WriteLine("\n5. feladat");
            mo.OtodikFeladat();

            Console.WriteLine("\n6. feladat");
            mo.HatodikFeladat();

            Console.ReadKey();
        }
    }

        
}
