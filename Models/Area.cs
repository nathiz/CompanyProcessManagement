using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Models
{
    public class Area
    {
        public int id { get; set; }
        public string nome { get; set; }
        public List<Process> Processos { get; set; }

    }
}