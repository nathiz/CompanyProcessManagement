using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly ProcessoService _service; // A dependência do service de Processo

        public ProcessoController(ProcessoService service)
        {
            _service = service; // Injeção de dependência do service
        }

        // GET: api/Processo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processo>>> GetProcessos()
        {
            return Ok(await _service.GetProcessosAsync()); // Retorna a lista de processos
        }

        // GET: api/Processo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Processo>> GetProcesso(int id)
        {
            var processo = await _service.GetProcessoByIdAsync(id); // Busca um processo pelo id
            if (processo == null)
            {
                return NotFound();
            }
            return Ok(processo); // Retorna o processo encontrado
        }

        // POST: api/Processo
        [HttpPost]
        public async Task<ActionResult<Processo>> PostProcesso(Processo processo)
        {
            var createdProcesso = await _service.CreateProcessoAsync(processo); // Cria um novo processo
            return CreatedAtAction(nameof(GetProcesso), new { id = createdProcesso.Id }, createdProcesso);
        }

        // PUT: api/Processo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcesso(int id, Processo processo)
        {
            if (id != processo.Id)
            {
                return BadRequest();
            }
            await _service.UpdateProcessoAsync(processo); // Atualiza o processo
            return NoContent();
        }

        // DELETE: api/Processo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcesso(int id)
        {
            var deleted = await _service.DeleteProcessoAsync(id); // Deleta o processo
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}