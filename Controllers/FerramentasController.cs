using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProcessManagement.Controllers
{
    // Define a rota base para o controlador de Ferramentas
    [Route("api/[controller]")]
    [ApiController]
    public class FerramentasController : ControllerBase
    {
        private readonly FerramentasService _service;

        // Construtor que injeta o service de Ferramentas
        public FerramentasController(FerramentasService service)
        {
            _service = service;
        }

        // Método para obter todas as Ferramentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ferramenta>>> GetFerramentas()
        {
            var ferramentas = await _service.GetFerramentasAsync();
            return Ok(ferramentas);
        }

        // Método para obter uma Ferramenta específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Ferramenta>> GetFerramenta(int id)
        {
            var ferramenta = await _service.GetFerramentaByIdAsync(id);
            if (ferramenta == null)
            {
                return NotFound(); 
            }
            return Ok(ferramenta);
        }

        // Método para criar uma nova Ferramenta
        [HttpPost]
        public async Task<ActionResult<Ferramenta>> PostFerramenta(Ferramenta ferramenta)
        {
            var createdFerramenta = await _service.AddFerramentaAsync(ferramenta);
            return CreatedAtAction(nameof(GetFerramenta), new { id = createdFerramenta.Id }, createdFerramenta); 
        }

        // Método para atualizar uma Ferramenta
        [HttpPut("{id}")]
        public async Task<IActionResult> Put
                // Método para atualizar uma Ferramenta
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFerramenta(int id, Ferramenta ferramenta)
        {
            if (id != ferramenta.Id)
            {
                return BadRequest();
            }

            await _service.UpdateFerramentaAsync(ferramenta); // Atualiza a Ferramenta
            return NoContent();
        }

        // Método para excluir uma Ferramenta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFerramenta(int id)
        {
            var deleted = await _service.DeleteFerramentaAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}