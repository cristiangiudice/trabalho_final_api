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
    public class TransferenciasController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TransferenciasController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Transferencias
        [HttpGet]
        public IEnumerable<Transferencia> GetTransferencias()
        {
            return _context.Transferencias;
        }

        // GET: api/Transferencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransferencia([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transferencia = await _context.Transferencias.FindAsync(id);

            if (transferencia == null)
            {
                return NotFound();
            }

            return Ok(transferencia);
        }

        // PUT: api/Transferencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransferencia([FromRoute] Guid id, [FromBody] Transferencia transferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transferencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferenciaExists(id))
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

        // POST: api/Transferencias
        [HttpPost]
        public async Task<IActionResult> PostTransferencia([FromBody] Transferencia transferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Transferencias.Add(transferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransferencia", new { id = transferencia.Id }, transferencia);
        }

        // DELETE: api/Transferencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransferencia([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transferencia = await _context.Transferencias.FindAsync(id);
            if (transferencia == null)
            {
                return NotFound();
            }

            _context.Transferencias.Remove(transferencia);
            await _context.SaveChangesAsync();

            return Ok(transferencia);
        }

        private bool TransferenciaExists(Guid id)
        {
            return _context.Transferencias.Any(e => e.Id == id);
        }
    }
}