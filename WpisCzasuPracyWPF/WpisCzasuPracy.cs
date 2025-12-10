using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1WPF
{
    public class WpisCzasuPracy
    {
        public string Pracownik { get; set; }
        public DateTime? Data { get; set; }
        public int Godziny { get; set; }

        public WpisCzasuPracy(string imie, DateTime data, int godziny)
        {
            Pracownik = imie;
            Data = data;
            Godziny = godziny;
        }
    }
}
