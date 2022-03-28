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
    public class TorneiosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TorneiosController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Torneios
        [HttpGet]
        public IEnumerable<Torneio> GetTorneios()
        {
            return _context.Torneios;
        }

        // GET: api/Torneios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTorneio([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var torneio = await _context.Torneios.FindAsync(id);

            if (torneio == null)
            {
                return NotFound();
            }

            return Ok(torneio);
        }

        // PUT: api/Torneios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTorneio([FromRoute] Guid id, [FromBody] Torneio torneio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != torneio.Id)
            {
                return BadRequest();
            }

            _context.Entry(torneio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneioExists(id))
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

        // POST: api/Torneios
        [HttpPost]
        public async Task<IActionResult> PostTorneio([FromBody] Torneio torneio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Torneios.Add(torneio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTorneio", new { id = torneio.Id }, torneio);
        }

        // DELETE: api/Torneios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTorneio([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var torneio = await _context.Torneios.FindAsync(id);
            if (torneio == null)
            {
                return NotFound();
            }

            _context.Torneios.Remove(torneio);
            await _context.SaveChangesAsync();

            return Ok(torneio);
        }

        private bool TorneioExists(Guid id)
        {
            return _context.Torneios.Any(e => e.Id == id);
        }
    }
}