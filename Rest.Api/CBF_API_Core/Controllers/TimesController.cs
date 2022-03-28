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
    public class TimesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TimesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Times
        [HttpGet]
        public IEnumerable<Time> GetTimes()
        {
            return _context.Times;
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTime([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var time = await _context.Times.FindAsync(id);

            if (time == null)
            {
                return NotFound();
            }

            return Ok(time);
        }

        // PUT: api/Times/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTime([FromRoute] Guid id, [FromBody] Time time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != time.Id)
            {
                return BadRequest();
            }

            _context.Entry(time).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Times
        [HttpPost]
        public async Task<IActionResult> PostTime([FromBody] Time time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Times.Add(time);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTime", new { id = time.Id }, time);
        }

        // DELETE: api/Times/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var time = await _context.Times.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }

            _context.Times.Remove(time);
            await _context.SaveChangesAsync();

            return Ok(time);
        }

        private bool TimeExists(Guid id)
        {
            return _context.Times.Any(e => e.Id == id);
        }
    }
}