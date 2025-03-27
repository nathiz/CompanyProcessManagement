using CompanyProcessManagement.Data;
using CompanyProcessManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsaveisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResponsaveisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Responsaveis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsavel>>> GetResponsaveis()
        {
            return await _context.Responsaveis.ToListAsync();
        }

        // GET: api/Responsaveis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsavel>> GetResponsavel(int id)
        {
            var responsavel = await _context.Responsaveis.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }
            return responsavel;
        }

        // POST: api/Responsaveis
        [HttpPost]
        public async Task<ActionResult<Responsavel>> PostResponsavel(Responsavel responsavel)
        {
            _context.Responsaveis.Add(responsavel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetResponsavel", new { id = responsavel.Id }, responsavel);
        }

        // PUT: api/Responsaveis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsavel(int id, Responsavel responsavel)
        {
            if (id != responsavel.Id)
            {
                return BadRequest();
            }
            _context.Entry(responsavel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsavelExists(id))
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

        // DELETE: api/Responsaveis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsavel(int id)
        {
            var responsavel = await _context.Responsaveis.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }
            _context.Responsaveis.Remove(responsavel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ResponsavelExists(int id)
        {
            return _context.Responsaveis.Any(e => e.Id == id);
        }
    }
}