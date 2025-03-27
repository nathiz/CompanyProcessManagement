using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly ResponsavelService _service; // A dependência do serviço de Responsável

        public ResponsavelController(ResponsavelService service)
        {
            _service = service; // Injeção de dependência do service
        }

        // GET: api/Responsavel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsavel>>> GetResponsaveis()
        {
            return Ok(await _service.GetResponsaveisAsync()); // Retorna a lista de responsáveis
        }

        // GET: api/Responsavel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsavel>> GetResponsavel(int id)
        {
            var responsavel = await _service.GetResponsavelByIdAsync(id); // Busca um responsável pelo id
            if (responsavel == null)
            {
                return NotFound();
            }
            return Ok(responsavel); // Retorna o responsável encontrado
        }

        // POST: api/Responsavel
        [HttpPost]
        public async Task<ActionResult<Responsavel>> PostResponsavel(Responsavel responsavel)
        {
            var createdResponsavel = await _service.CreateResponsavelAsync(responsavel); // Cria um novo responsável
            return CreatedAtAction(nameof(GetResponsavel), new { id = createdResponsavel.Id }, createdResponsavel);
        }

        // PUT: api/Responsavel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsavel(int id, Responsavel responsavel)
        {
            if (id != responsavel.Id)
            {
                return BadRequest();
            }
            await _service.UpdateResponsavelAsync(responsavel); // Atualiza o responsável
            return NoContent();
        }

        // DELETE: api/Responsavel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsavel(int id)
        {
            var deleted = await _service.DeleteResponsavelAsync(id); // Deleta o responsável
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}