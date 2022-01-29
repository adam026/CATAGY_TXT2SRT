
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_TXT2SRT
{
    internal class Program
    {
        static List<IdozitettFelirat> feliratok = new List<IdozitettFelirat>();
        static Dictionary<string,string> adatok = new Dictionary<string,string>(); 
        static void Main(string[] args)
        {
            Beolvas();
            F05();
            F07();
            Kiir();
        }

        private static void Kiir()
        {
            var sw = new StreamWriter(@"..\..\RES\felirat.srt", false, Encoding.UTF8);
            var counter = 1;
            foreach (var felirat in feliratok)
            {
                sw.WriteLine($"{counter}\n{felirat.SrtIdozites}\n{felirat.Felirat}");
                sw.WriteLine();
                counter+=1;
            }
            Console.WriteLine("8. Feladat: Kiírás kész!");

        }

        private static void F07()
        {
            var lszaf = feliratok.OrderBy(x => x.SzavakSzama).Last();
            Console.WriteLine($"7. Feladat - Legtöbb szóból álló felirat: \n{lszaf.Felirat}");
        }

        private static void F05()
        {
            Console.WriteLine($"5. Feladat - Feliratok száma: {adatok.Count}");
        }

        private static void Beolvas()
        {
            using (var sr = new StreamReader(@"..\..\RES\feliratok.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    adatok.Add(sr.ReadLine(), sr.ReadLine());
                }
            }
            foreach (var adat in adatok)
            {
                feliratok.Add(new IdozitettFelirat(adat));
            }

        }
    }
}
