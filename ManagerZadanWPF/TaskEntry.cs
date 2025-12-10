using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerZadan
{
    public class TaskEntry
    {
        public string Nazwa { get; set; } = " ";
        public string Opis { get; set; } = "opis";
        public DateTime DataRealizacji { get; set; } = DateTime.Now.AddDays(1);
        public string Status { get; set; } = "Gotowe";
    }

}
