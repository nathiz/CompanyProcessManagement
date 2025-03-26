using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Data;
using CompanyProcessManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcessController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Process
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Process>>> GetProcesses()
        {
            // Carregar Processos, incluindo SubProcessos se houver, ou apenas retornar os Processos simples
            var processes = await _context.Processes
                .Include(p => p.SubProcessos)  // Caso você tenha a relação de SubProcessos em Process
                .ToListAsync();

            return Ok(processes);
        }

        // POST: api/Process
        [HttpPost]
        public async Task<ActionResult<Process>> PostProcess(Process process)
        {
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();

            // Usando o método CreatedAtAction para retornar o objeto criado
            return CreatedAtAction(nameof(GetProcesses), new { id = process.id }, process);
        }
    }
}