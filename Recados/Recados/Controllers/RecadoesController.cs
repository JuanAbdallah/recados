using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recados.Models;

namespace Recados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecadoesController : ControllerBase
    {
        private readonly RecadosContext _context;

        public RecadoesController(RecadosContext context)
        {
            _context = context;
        }


        // GET: api/Recados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recado>>> GetRecados()
        {
            return await _context.RecadoItem.ToListAsync();
        }

        // GET: api/Recados/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recado>> GetRecado(int id)
        {
            var recados = await _context.RecadoItem.FindAsync(id);

            if (recados == null)
            {
                return NotFound();
            }

            return recados;
        }
        [HttpGet("mensagem/{id}")]
        public async Task<ActionResult<String>> GetMensagem(int id)
        {
            var recado = await _context.RecadoItem.FindAsync(id);

            if (recado == null)
            {
                return NotFound();
            }

            return Ok(recado.Mensagem);
        }

        [HttpGet("remetente={remetente}")]
        public async Task<ActionResult<List<Recado>>> GetRecadoByRemetente(String remetente)
        {
            var recados = await _context.RecadoItem.Where(r => r.Remetente == remetente).ToListAsync();

            if (recados == null || !recados.Any())
            {
                return NotFound();
            }

            return Ok(recados);
        }

        [HttpGet("destinatario={destinatario}")]
        public async Task<ActionResult<List<String>>> GetMensagemByDestinatariio(String destinatario)
        {
            var recados = await _context.RecadoItem.Where(r => r.Destinatario == destinatario).ToListAsync();
            if (recados == null || !recados.Any())
            {
                return NotFound();
            }

            return Ok(recados);
        }


        // PUT: api/Recados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecados(int id, Recado recado)
        {
            if (id != recado.Id)
            {
                return BadRequest();
            }

            _context.Entry(recado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecadosExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recado>> PostRecados(Recado recado)
        {
            _context.RecadoItem.Add(recado);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRecados", new { id = recados.Id }, recados);
            return CreatedAtAction(nameof(PostRecados), new { id = recado.Id }, recado);
        }

        // DELETE: api/Recados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecados(int id)
        {
            var recado = await _context.RecadoItem.FindAsync(id);
            if (recado == null)
            {
                return NotFound();
            }

            _context.RecadoItem.Remove(recado);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool RecadosExists(int id)
        {
            return _context.RecadoItem.Any(e => e.Id == id);
        }
    }
}
