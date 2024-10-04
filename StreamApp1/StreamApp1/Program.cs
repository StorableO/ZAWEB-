using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StreamApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName1 = @"D:\liczby_losowe1.txt";

            List<int> list = new List<int>();

            try
            {
                using (StreamReader reader1 = new StreamReader(fileName1))
                {
                    string line;
                    while ((line = reader1.ReadLine()) != null)
                    {
                        list.Add(Convert.ToInt32(line));
                        
                    }
                }
                int min = list.Min();
                int max = list.Max();
                Console.WriteLine("najmniejszą liczbę MIN: " + min + " na pozycji: " + list.IndexOf(min));
                Console.WriteLine("największą liczbę MAX: " + max);
                Console.WriteLine("Roznica: " + (max - min));

                list.Sort();
                Console.WriteLine("posortowana tablica: ");
                foreach (int number in list)
                {
                    Console.Write(number+ ", ");
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
