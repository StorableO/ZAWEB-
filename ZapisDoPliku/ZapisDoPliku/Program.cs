using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ZapisDoPliku
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string sciezkaDoPliku = @"D:\text\liczby.txt"; // Nazwa pliku, w którym zostaną zapisane liczby

            List<string> list = new List<string>(); 
            try
            {
                using (StreamReader reader = new StreamReader(sciezkaDoPliku))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    { 
                        int dlugosc = linia.Length;
                        if (linia[0] == linia[dlugosc-1])
                        {
                            list.Add(linia);
                        }
                    }
                    foreach (string line in list)
                    {
                        Console.WriteLine(line);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas zapisywania do pliku: " + ex.Message);
                
            }
            Console.ReadKey();
        }
    }
}
