using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Process> Processos { get; set; } = new List<Process>();

    }
}