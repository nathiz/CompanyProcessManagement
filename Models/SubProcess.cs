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
        public string Nome { get; set; }
        public int ProcessId { get; set; }
        public Process Processo { get; set; }
        public List<SubProcess> SubprocessosFilhos { get; set; }
        public List<Ferramenta> Ferramentas { get; set; }
        public List<Responsavel> Responsaveis { get; set; }
        public List<Documento> Documentos { get; set; }
    }
}