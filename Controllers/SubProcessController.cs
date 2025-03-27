using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubprocessoController : ControllerBase
    {
        private readonly SubprocessoService _service; // A dependência do service de Subprocesso

        public SubprocessoController(SubprocessoService service)
        {
            _service = service; // Injeção de dependência do service
        }

        // GET: api/Subprocesso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subprocesso>>> GetSubprocessos()
        {
            return Ok(await _service.GetSubprocessosAsync()); // Retorna a lista de subprocessos
        }

        // GET: api/Subprocesso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subprocesso>> GetSubprocesso(int id)
        {
            var subprocesso = await _service.GetSubprocessoByIdAsync(id); // Busca um subprocesso pelo id
            if (subprocesso == null)
            {
                return NotFound();
            }
            return Ok(subprocesso); // Retorna o subprocesso encontrado
        }

        // POST: api/Subprocesso
        [HttpPost]
        public async Task<ActionResult<Subprocesso>> PostSubprocesso(Subprocesso subprocesso)
        {
            var createdSubprocesso = await _service.CreateSubprocessoAsync(subprocesso); // Cria um novo subprocesso
            return CreatedAtAction(nameof(GetSubprocesso), new { id = createdSubprocesso.Id }, createdSubprocesso);
        }

        // PUT: api/Subprocesso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubprocesso(int id, Subprocesso subprocesso)
        {
            if (id != subprocesso.Id)
            {
                return BadRequest();
            }
            await _service.UpdateSubprocessoAsync(subprocesso); // Atualiza o subprocesso
            return NoContent();
        }

        // DELETE: api/Subprocesso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubprocesso(int id)
        {
            var deleted = await _service.DeleteSubprocessoAsync(id); // Deleta o subprocesso
            if (!deleted)
            {
                return NotFound();
            return NoContent();
        }
    }
}