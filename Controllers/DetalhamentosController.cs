using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProcessManagement.Controllers
{
    // Define a rota base para o controller de DetalhamentoProcessos
    [Route("api/[controller]")]
    [ApiController]
    public class DetalhamentosController : ControllerBase
    {
        private readonly DetalhamentosService _service;

        // Construtor que injeta o service de DetalhamentosProcessos
        public DetalhamentoProcessosController(DetalhamentoProcessosService service)
        {
            _service = service;
        }

        // Método para obter todos os DetalhamentosProcessos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhamentoProcesso>>> GetDetalhamentoProcessos()
        {
            var detalhamentoProcessos = await _service.GetDetalhamentoProcessosAsync();
            return Ok(detalhamentoProcessos);
        }

        // Método para obter um DetalhamentosProcesso específico por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhamentoProcesso>> GetDetalhamentoProcesso(int id)
        {
            var detalhamentoProcesso = await _service.GetDetalhamentoProcessoByIdAsync(id);
            if (detalhamentoProcesso == null)
            {
                return NotFound();
            }
            return Ok(detalhamentoProcesso);
        }

        // Método para criar um novo DetalhamentoProcesso
        [HttpPost]
        public async Task<ActionResult<DetalhamentoProcesso>> PostDetalhamentoProcesso(DetalhamentoProcesso detalhamentoProcesso)
        {
            var createdProcesso = await _service.AddDetalhamentoProcessoAsync(detalhamentoProcesso);
            return CreatedAtAction(nameof(GetDetalhamentoProcesso), new { id = createdProcesso.Id }, createdProcesso);
        }

        // Método para atualizar um DetalhamentoProcesso
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhamentoProcesso(int id, DetalhamentoProcesso detalhamentoProcesso)
        {
            if (id != detalhamentoProcesso.Id)
            {
                return BadRequest();
            }

            await _service.UpdateDetalhamentoProcessoAsync(detalhamentoProcesso); // Atualiza o DetalhamentoProcesso
            return NoContent();
        }

        // Método para excluir um DetalhamentoProcesso
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalhamentoProcesso(int id)
        {
            var deleted = await _service.DeleteDetalhamentoProcessoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}