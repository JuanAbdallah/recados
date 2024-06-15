using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecadosInfra.DAOs;
using RecadoModel;

namespace Recados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecadoesController : ControllerBase
    {

        private readonly RecadosDAO _dao;
        public RecadoesController()
        {
            _dao = new RecadosDAO();
        }

        // GET: api/Recados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecModel>>> GetRecados()
        {
            var recados = _dao.ListarTodos();
            return Ok(recados);
        }

        // GET: api/Recados/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecModel>> GetRecado(int id)
        {
            var recado = _dao.BuscarPorId(id);
            if (recado == null)
            {
                return NotFound();
            }
            return Ok(recado);
        }

        // GET: api/Recados/mensagem/5
        [HttpGet("mensagem/{id}")]
        public async Task<ActionResult<string>> GetMensagem(int id)
        {
            var recado = _dao.BuscarPorId(id);
            if (recado == null)
            {
                return NotFound();
            }
            return Ok(recado.Mensagem);
        }

        // GET: api/Recados/remetente={remetente}
        [HttpGet("remetente={remetente}")]
        public async Task<ActionResult<List<RecModel>>> GetRecadoByRemetente(string remetente)
        {
            var recados = _dao.ListarTodos().Where(r => r.Remetente == remetente).ToList();
            if (!recados.Any())
            {
                return NotFound();
            }
            return Ok(recados);
        }

        // GET: api/Recados/destinatario={destinatario}
        [HttpGet("destinatario={destinatario}")]
        public async Task<ActionResult<List<RecModel>>> GetMensagemByDestinatario(string destinatario)
        {
            var recados = _dao.ListarTodos().Where(r => r.Destinatario == destinatario).ToList();
            if (!recados.Any())
            {
                return NotFound();
            }
            return Ok(recados);
        }

        // PUT: api/Recados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecados(int id, RecModel recado)
        {
            if (id != recado.Id)
            {
                return BadRequest();
            }

            try
            {
                _dao.Alterar(recado);
            }
            catch (Exception)
            {
                if (_dao.BuscarPorId(id) == null)
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

        // POST: api/Recados
        [HttpPost]
        public async Task<ActionResult<RecModel>> PostRecados(RecModel recado)
        {
            _dao.Inserir(recado);
            return CreatedAtAction(nameof(GetRecado), new { id = recado.Id }, recado);
        }

        // DELETE: api/Recados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecados(int id)
        {
            var recado = _dao.BuscarPorId(id);
            if (recado == null)
            {
                return NotFound();
            }

            _dao.Deletar(id);
            return NoContent();
        }
    }
}
