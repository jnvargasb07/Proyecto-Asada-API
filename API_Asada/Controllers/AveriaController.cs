using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Asada.Models;

namespace API_Asada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AveriaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public AveriaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Averia
        [HttpGet]
        public IEnumerable<Averia> GetAveria()
        {
            return _context.Averia;
        }

        // GET: api/Averia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAveria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var averia = await _context.Averia.FindAsync(id);

            if (averia == null)
            {
                return NotFound();
            }

            return Ok(averia);
        }

        // PUT: api/Averia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAveria([FromRoute] int id, [FromBody] Averia averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != averia.Id)
            {
                return BadRequest();
            }

            _context.Entry(averia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AveriaExists(id))
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

        // POST: api/Averia
        [HttpPost]
        public async Task<IActionResult> PostAveria([FromBody] Averia averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Averia.Add(averia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAveria", new { id = averia.Id }, averia);
        }

        // DELETE: api/Averia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAveria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var averia = await _context.Averia.FindAsync(id);
            if (averia == null)
            {
                return NotFound();
            }

            _context.Averia.Remove(averia);
            await _context.SaveChangesAsync();

            return Ok(averia);
        }

        private bool AveriaExists(int id)
        {
            return _context.Averia.Any(e => e.Id == id);
        }
    }
}