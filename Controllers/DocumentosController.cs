using CompanyProcessManagement.Models;
using CompanyProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProcessManagement.Controllers
{
    // Define a rota base para o controlador de Documentos
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly DocumentosService _service;

        // Construtor que injeta o service de Documentos
        public DocumentosController(DocumentosService service)
        {
            _service = service;
        }

        // Método para obter todos os Documentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumentos()
        {
            var documentos = await _service.GetDocumentosAsync();
            return Ok(documentos);
        }

        // Método para obter um Documento específico por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetDocumento(int id)
        {
            var documento = await _service.GetDocumentoByIdAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            return Ok(documento);
        }

        // Método para criar um novo Documento
        [HttpPost]
        public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
        {
            var createdDocumento = await _service.AddDocumentoAsync(documento);
            return CreatedAtAction(nameof(GetDocumento), new { id = createdDocumento.Id }, createdDocumento);
        }

        // Método para atualizar um Documento
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento(int id, Documento documento)
        {
            if (id != documento.Id)
            {
                return BadRequest();
            }

            await _service.UpdateDocumentoAsync(documento); // Atualiza o Documento
            return NoContent();
        }

        // Método para excluir um Documento
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            var deleted = await _service.DeleteDocumentoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}