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
            return await _context.Processos.Include(p => p.Subprocessos).ToListAsync();
        }

        // GET: api/Process/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Process>> GetProcess(int id)
        {
            var process = await _context.Processos.Include(p => p.Subprocessos).FirstOrDefaultAsync(p => p.Id == id);
            if (process == null)
            {
                return NotFound();
            }
            return process;
        }

        // POST: api/Process
        [HttpPost]
        public async Task<ActionResult<Process>> CreateProcess(Process process)
        {
            _context.Processos.Add(process);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProcess), new { id = process.Id }, process);
        }

        // PUT: api/Process/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcess(int id, Process process)
        {
            if (id != process.Id)
            {
                return BadRequest();
            }
            _context.Entry(process).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Process/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcess(int id)
        {
            var process = await _context.Processos.FindAsync(id);
            if (process == null)
            {
                return NotFound();
            }
            _context.Processos.Remove(process);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProcessExists(int id)
        {
            return _context.Processos.Any(e => e.Id == id);
        }
    }
}