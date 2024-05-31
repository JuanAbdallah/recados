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

        // GET: api/Recadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recado>>> GetRecContext()
        {
            return await _context.RecContext.ToListAsync();
        }

        // GET: api/Recadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recado>> GetRecado(int id)
        {
            var recado = await _context.RecContext.FindAsync(id);

            if (recado == null)
            {
                return NotFound();
            }

            return recado;
        }

        // PUT: api/Recadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecado(int id, Recado recado)
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
                if (!RecadoExists(id))
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

        // POST: api/Recadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recado>> PostRecado(Recado recado)
        {
            _context.RecContext.Add(recado);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRecado", new { id = recado.Id }, recado);
            return CreatedAtAction(nameof(PostRecado),new {id = recado.Id},recado);
        }

        // DELETE: api/Recadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecado(int id)
        {
            var recado = await _context.RecContext.FindAsync(id);
            if (recado == null)
            {
                return NotFound();
            }

            _context.RecContext.Remove(recado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecadoExists(int id)
        {
            return _context.RecContext.Any(e => e.Id == id);
        }
    }
}
