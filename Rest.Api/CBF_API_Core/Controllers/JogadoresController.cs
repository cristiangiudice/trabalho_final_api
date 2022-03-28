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
    public class JogadoresController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public JogadoresController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Jogadores
        [HttpGet]
        public IEnumerable<Jogador> GetJogadores()
        {
            return _context.Jogadores;
        }

        // GET: api/Jogadores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJogador([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jogador = await _context.Jogadores.FindAsync(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }

        // PUT: api/Jogadores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogador([FromRoute] Guid id, [FromBody] Jogador jogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jogador.Id)
            {
                return BadRequest();
            }

            _context.Entry(jogador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogadorExists(id))
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

        // POST: api/Jogadores
        [HttpPost]
        public async Task<IActionResult> PostJogador([FromBody] Jogador jogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogador", new { id = jogador.Id }, jogador);
        }

        // DELETE: api/Jogadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogador([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jogador = await _context.Jogadores.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }

            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();

            return Ok(jogador);
        }

        private bool JogadorExists(Guid id)
        {
            return _context.Jogadores.Any(e => e.Id == id);
        }
    }
}