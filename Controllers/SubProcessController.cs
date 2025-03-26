using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProcessController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubProcessController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubProcess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubProcess>>> GetSubProcesses()
        {
            // Carregar SubProcess e seus Processos relacionados
            return await _context.SubProcesses
                .Include(s => s.Processos)
                .ToListAsync();
        }

        // POST: api/SubProcess
        [HttpPost]
        public async Task<ActionResult<SubProcess>> PostSubProcess(SubProcess subProcess)
        {
            _context.SubProcesses.Add(subProcess);
            await _context.SaveChangesAsync();

            // Usando o método CreatedAtAction para retornar o objeto criado
            return CreatedAtAction(nameof(GetSubProcesses), new { id = subProcess.id }, subProcess);
        }
    }
}