using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    internal class Program
    {
        public class Liczby
        {
            public int pierwsza { get; set; }
            public int druga { get; set; }
        }
        static void Main(string[] args)
        {
            string fileName2 = @"D:\liczby_losowe2.txt";
            List<Liczby> list = new List<Liczby>();
            List<int> list2 = new List<int>();
            List<Liczby> paryLiczbUjemnych = new List<Liczby>();

            try
            {
                using (StreamReader reader2 = new StreamReader(fileName2))
                {
                    string lin;
                    while ((lin = reader2.ReadLine()) != null)
                    {
                        string[] liczby = lin.Split(' ');
                        list.Add(new Liczby { pierwsza = Convert.ToInt32(liczby[0]), druga = Convert.ToInt32(liczby[1]) });

                    }
                    foreach (Liczby l in list)
                    {
                        if (l.pierwsza < 0 && l.druga < 0)
                        {
                            paryLiczbUjemnych.Add(l);
                        }
                    }
                    foreach (Liczby p in paryLiczbUjemnych)
                    {
                        Console.WriteLine($"{p.pierwsza} {p.druga}");
                    }
                    foreach (Liczby l in list)
                    {
                        list2.Add(l.pierwsza - l.druga);
                    }
                    int minimalna = list2.Min();
                    Console.WriteLine(" różnica L0-L1 jest najmniejsza: " + minimalna);
                    Console.WriteLine("  numer tego wiersza: " + list2.IndexOf(minimalna));
                }

             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }

    }

