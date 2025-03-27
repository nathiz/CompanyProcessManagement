using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _service; // A dependência do service de Área

        public AreaController(AreaService service)
        {
            _service = service; // Injeção de dependência do service
        }

        // GET: api/Area
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return Ok(await _service.GetAreasAsync()); // Retorna a lista de áreas
        }

        // GET: api/Area/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _service.GetAreaByIdAsync(id); // Busca uma área pelo id
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area); // Retorna a área encontrada
        }

        // POST: api/Area
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            var createdArea = await _service.CreateAreaAsync(area); // Cria uma nova área
            return CreatedAtAction(nameof(GetArea), new { id = createdArea.Id }, createdArea);
        }

        // PUT: api/Area/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAreaAsync(area); // Atualiza a área
            return NoContent();
        }

        // DELETE: api/Area/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var deleted = await _service.DeleteAreaAsync(id); // Deleta a área
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}