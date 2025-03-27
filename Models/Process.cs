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
        public List<SubProcess> Subprocessos { get; set; } = new List<SubProcess>();
    
        public List<string> FerramentasUtilizadas { get; set; } = new List<string>();
        public List<Responsavel> Responsaveis { get; set; } = new List<Responsavel>();
        public List<string> DocumentacaoAssociada { get; set; } = new List<string>();

    }
}