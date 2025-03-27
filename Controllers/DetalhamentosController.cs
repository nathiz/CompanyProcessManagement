using CompanyProcessManagement.Data;
using CompanyProcessManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalhamentoProcessosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalhamentoProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalhamentoProcessos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhamentoProcesso>>> GetDetalhamentoProcessos()
        {
            return await _context.DetalhamentoProcessos.ToListAsync();
        }

        // GET: api/DetalhamentoProcessos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhamentoProcesso>> GetDetalhamentoProcesso(int id)
        {
            var detalhamentoProcesso = await _context.DetalhamentoProcessos.FindAsync(id);
            if (detalhamentoProcesso == null)
            {
                return NotFound();
            }
            return detalhamentoProcesso;
        }

        // POST: api/DetalhamentoProcessos
        [HttpPost]
        public async Task<ActionResult<DetalhamentoProcesso>> PostDetalhamentoProcesso(DetalhamentoProcesso detalhamentoProcesso)
        {
            _context.DetalhamentoProcessos.Add(detalhamentoProcesso);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDetalhamentoProcesso", new { id = detalhamentoProcesso.Id }, detalhamentoProcesso);
        }

        // PUT: api/DetalhamentoProcessos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhamentoProcesso(int id, DetalhamentoProcesso detalhamentoProcesso)
        {
            if (id != detalhamentoProcesso.Id)
            {
                return BadRequest();
            }
            _context.Entry(detalhamentoProcesso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DetalhamentoProcessos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalhamentoProcesso(int id)
        {
            var detalhamentoProcesso = await _context.DetalhamentoProcessos.FindAsync(id);
            if (detalhamentoProcesso == null)
            {
                return NotFound();
            }
            _context.DetalhamentoProcessos.Remove(detalhamentoProcesso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}