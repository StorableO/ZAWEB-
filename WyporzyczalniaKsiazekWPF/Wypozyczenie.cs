using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Wypozyczenie
    {
        public int id {  get; set; }
        public double id_Book { get; set; }
        public string SurName { get; set; }
        public DateTime Data {  get; set; } = DateTime.Now;
        
        public Wypozyczenie(int id, double id_Book, string SurName, DateTime Data)
        {
            this.id = id;
            this.id_Book = id_Book;
            this.SurName = SurName;
            this.Data = Data;
        } 
    }
}
