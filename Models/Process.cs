using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Models
{
    public class Process
    {
        public int id { get; set; }
        public string name { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public List<SubProcess> SubProcessos { get; set; }
    }
}