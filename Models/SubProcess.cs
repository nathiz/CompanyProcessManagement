using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Models;

namespace CompanyProcessManagement
{
    public class SubProcess
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ProcessId { get; set; }
        public Process Processos { get; set; }
    }
}