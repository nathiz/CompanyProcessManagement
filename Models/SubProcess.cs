using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Models;

namespace CompanyProcessManagement
{
    public class SubProcess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
        public List<SubProcess> SubprocessosFilhos { get; set; } = new List<SubProcess>();

        public List<string> FerramentasUtilizadas { get; set; } = new List<string>();
        public List<Responsavel> Responsaveis { get; set; } = new List<Responsavel>();
        public List<string> DocumentacaoAssociada { get; set; } = new List<string>();
    }
}