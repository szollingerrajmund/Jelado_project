using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Jelado_proj
{
    internal class Megoldas
    {

        public string allomanyNev = "jel.txt";
        public List<Jelado> jeladok = new List<Jelado>();
        public Megoldas(string forrás)
        {
            foreach (string sor in File.ReadAllLines(allomanyNev))
            {
                jeladok.Add(new Jelado(sor));
            }
        }
        public void MasodikFeladat()
        {

            int inputIndex = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSignalByIndex(inputIndex).Coordinates);
        }


        public int eltelt(int[] idő1, int[] idő2)
        {
            int mp1 = idő1[0] * 3600 + idő1[1] * 60 + idő1[2];
            int mp2 = idő2[0] * 3600 + idő2[1] * 60 + idő2[2];

            return Math.Abs(mp1 - mp2);

        }


        public void NegyedikFeladat()
        {
            int elteltmp = eltelt(jeladok[0].idő, jeladok[jeladok.Count - 1].idő);
            int óra = elteltmp / 3600;
            int perc = (elteltmp / 60) % 60;
            int másodperc = elteltmp % 60;


            Console.WriteLine($"Időtartam: {óra}:{perc}:{másodperc}");

        }

        public void OtodikFeladat()
        {
            int[] koordinatak = Koordináták();
            Console.WriteLine($"Bal alsó: {koordinatak[0]} {koordinatak[1]}, jobb felső: {koordinatak[2]} {koordinatak[3]}");
        }

        public void HatodikFeladat()
        {
            Console.WriteLine($"Elmozdulás: {TotalDistanceTraveled():f3} egység");
        }

        public void HetedikFeladat()
        {
            KimaradasokIrasa("kimaradasok.json");
        }

        public List<Elteres> KimaradtEszlelesek()
        {
            List<Elteres> kimaradasok = new List<Elteres>();

            for (int i = 0; i < jeladok.Count - 2; i++)
            {
                int kimaradtJelekMennyisege = 0;
                ElteresTipusa kimaradasTipusa = KimaradtJelTipusa(jeladok[i], jeladok[i + 1], out kimaradtJelekMennyisege);

                if (kimaradasTipusa == ElteresTipusa.SEMMI) continue;

                kimaradasok.Add(new Elteres(jeladok[i + 1], kimaradtJelekMennyisege, kimaradasTipusa));
            }
            return kimaradasok;
        }

        public void KimaradasokIrasa(string allomanyNeve)
        {
            List<Elteres> kimaradasok = KimaradtEszlelesek();

            string json = JsonConvert.SerializeObject(kimaradasok);
            File.WriteAllText(allomanyNeve, json);
        }

        public ElteresTipusa KimaradtJelTipusa(Jelado elso, Jelado masodik, out int kimaradtJelekMennyisege)
        {
            kimaradtJelekMennyisege = 0;

            int koordinataElteres = Math.Max((int)Math.Ceiling(Math.Abs(elso.x - masodik.x) / (double)10), (int)Math.Ceiling(Math.Abs(elso.y - masodik.y) / (double)10));
            int idoElteres = (int)Math.Ceiling(eltelt(elso.idő, masodik.idő) / (double)(5 * 60));

            if (idoElteres <= 1 && koordinataElteres <= 1) return ElteresTipusa.SEMMI;
            else if (idoElteres > koordinataElteres)
            {
                kimaradtJelekMennyisege = idoElteres;
                return ElteresTipusa.IDO;
            }

            kimaradtJelekMennyisege = koordinataElteres;
            return ElteresTipusa.KOORDINATA;
        }

        public Jelado GetSignalByIndex(int index)
        {
            return jeladok[index - 1];
        }

        public double TotalDistanceTraveled()
        {
            double distance = 0;
            for (int i = 0; i < jeladok.Count - 1; i++)
            {
                distance += jeladok[i].DistanceTo(jeladok[i + 1]);
            }
            return distance;
        }

        public int[] Koordináták()
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
            return new int[] { minimumx, minimumy, maximumx, maximumy };
        }
    }
}

