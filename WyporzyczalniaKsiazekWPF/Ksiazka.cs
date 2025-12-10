using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Ksiazka
    {
        public int id { get; set; } 
        public double ISBN { get; set; } = 0;
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; } = 2000;


        public Ksiazka(int id, double ISBN, string Title, string Author, int Year)
        {
            this.id = id;
            this.ISBN = ISBN;
            this.Title = Title;
            this.Author = Author;
            this.Year = Year;
        }
    }
}
