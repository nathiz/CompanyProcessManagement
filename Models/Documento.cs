using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int? ProcessoId { get; set; }
        public Process Processo { get; set; }
        public int? SubProcessId { get; set; }
        public SubProcess SubProcesso { get; set; }
    }
}