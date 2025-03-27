using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Area> Areas { get; set; }
        public DbSet<Process> Processos { get; set; }
        public DbSet<SubProcess> Subprocessos { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
    }
}