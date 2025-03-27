using CompanyProcessManagement.Data;
using CompanyProcessManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerramentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FerramentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ferramentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ferramenta>>> GetFerramentas()
        {
            return await _context.Ferramentas.ToListAsync();
        }

        // GET: api/Ferramentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ferramenta>> GetFerramenta(int id)
        {
            var ferramenta = await _context.Ferramentas.FindAsync(id);
            if (ferramenta == null)
            {
                return NotFound();
            }
            return ferramenta;
        }

        // POST: api/Ferramentas
        [HttpPost]
        public async Task<ActionResult<Ferramenta>> PostFerramenta(Ferramenta ferramenta)
        {
            _context.Ferramentas.Add(ferramenta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFerramenta", new { id = ferramenta.Id }, ferramenta);
        }

        // PUT: api/Ferramentas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFerramenta(int id, Ferramenta ferramenta)
        {
            if (id != ferramenta.Id)
            {
                return BadRequest();
            }
            _context.Entry(ferramenta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FerramentaExists(id))
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

        // DELETE: api/Ferramentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFerramenta(int id)
        {
            var ferramenta = await _context.Ferramentas.FindAsync(id);
            if (ferramenta == null)
            {
                return NotFound();
            }
            _context.Ferramentas.Remove(ferramenta);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool FerramentaExists(int id)
        {
            return _context.Ferramentas.Any(e => e.Id == id);
        }
    }
}