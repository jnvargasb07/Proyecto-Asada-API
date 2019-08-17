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
    public class ReciclajeController : ControllerBase
    {
        private readonly AsadaContext _context;

        public ReciclajeController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Reciclaje
        [HttpGet]
        public IEnumerable<Reciclaje> GetReciclaje()
        {
            return _context.Reciclaje;
        }

        // GET: api/Reciclaje/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReciclaje([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reciclaje = await _context.Reciclaje.FindAsync(id);

            if (reciclaje == null)
            {
                return NotFound();
            }

            return Ok(reciclaje);
        }

        // PUT: api/Reciclaje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciclaje([FromRoute] int id, [FromBody] Reciclaje reciclaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reciclaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(reciclaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciclajeExists(id))
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

        // POST: api/Reciclaje
        [HttpPost]
        public async Task<IActionResult> PostReciclaje([FromBody] Reciclaje reciclaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reciclaje.Add(reciclaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciclaje", new { id = reciclaje.Id }, reciclaje);
        }

        // DELETE: api/Reciclaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciclaje([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reciclaje = await _context.Reciclaje.FindAsync(id);
            if (reciclaje == null)
            {
                return NotFound();
            }

            _context.Reciclaje.Remove(reciclaje);
            await _context.SaveChangesAsync();

            return Ok(reciclaje);
        }

        private bool ReciclajeExists(int id)
        {
            return _context.Reciclaje.Any(e => e.Id == id);
        }
    }
}