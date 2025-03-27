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
            return await _context.Subprocessos.Include(sp => sp.SubprocessosFilhos).ToListAsync();
        }

        // GET: api/SubProcess/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SubProcess>> GetSubProcess(int id)
        {
            var subProcess = await _context.Subprocessos.Include(sp => 
                sp.SubprocessosFilhos).FirstOrDefaultAsync(sp => sp.Id == id);
            if (subProcess == null)
            {
                return NotFound();
            }
            return subProcess;
        }

        // POST: api/SubProcess
        [HttpPost]
        public async Task<ActionResult<SubProcess>> CreateSubProcess(SubProcess subProcess)
        {
            _context.Subprocessos.Add(subProcess);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubProcess), new { id = subProcess.Id }, subProcess);
        }

        // PUT: api/SubProcess/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubProcess(int id, SubProcess subProcess)
        {
            if (id != subProcess.Id)
            {
                return BadRequest();
            }
            _context.Entry(subProcess).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubProcessExists(id))
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

        // DELETE: api/SubProcess/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubProcess(int id)
        {
            var subProcess = await _context.Subprocessos.FindAsync(id);
            if (subProcess == null)
            {
                return NotFound();
            }
            _context.Subprocessos.Remove(subProcess);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SubProcessExists(int id)
        {
            return _context.Subprocessos.Any(e => e.Id == id);
        }
    }
}