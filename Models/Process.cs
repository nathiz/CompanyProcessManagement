using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Models
{
    public class Process
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public List<SubProcess> Subprocessos { get; set; }
        public List<Ferramenta> Ferramentas { get; set; }
        public List<Responsavel> Responsaveis { get; set; }
        public List<Documento> Documentos { get; set; }

    }
}