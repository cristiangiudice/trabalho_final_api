using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CBF_API_Core;
using CBF_API_Core.Model;

namespace CBF_API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PartidasController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Partidas
        [HttpGet]
        public IEnumerable<Partida> GetPartidas()
        {
            return _context.Partidas;
        }

        // GET: api/Partidas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartida([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partida = await _context.Partidas.FindAsync(id);

            if (partida == null)
            {
                return NotFound();
            }

            return Ok(partida);
        }

        // PUT: api/Partidas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartida([FromRoute] Guid id, [FromBody] Partida partida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partida.Id)
            {
                return BadRequest();
            }

            _context.Entry(partida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidaExists(id))
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

        // POST: api/Partidas
        [HttpPost]
        public async Task<IActionResult> PostPartida([FromBody] Partida partida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Partidas.Add(partida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartida", new { id = partida.Id }, partida);
        }

        // DELETE: api/Partidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }

            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();

            return Ok(partida);
        }

        private bool PartidaExists(Guid id)
        {
            return _context.Partidas.Any(e => e.Id == id);
        }
    }
}