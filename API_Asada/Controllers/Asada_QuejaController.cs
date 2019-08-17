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
    public class Asada_QuejaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Asada_QuejaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Asada_Queja
        [HttpGet]
        public IEnumerable<Asada_Queja> GetAsada_Queja()
        {
            return _context.Asada_Queja;
        }

        // GET: api/Asada_Queja/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsada_Queja([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asada_Queja = await _context.Asada_Queja.FindAsync(id);

            if (asada_Queja == null)
            {
                return NotFound();
            }

            return Ok(asada_Queja);
        }

        // PUT: api/Asada_Queja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsada_Queja([FromRoute] int id, [FromBody] Asada_Queja asada_Queja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asada_Queja.Id)
            {
                return BadRequest();
            }

            _context.Entry(asada_Queja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asada_QuejaExists(id))
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

        // POST: api/Asada_Queja
        [HttpPost]
        public async Task<IActionResult> PostAsada_Queja([FromBody] Asada_Queja asada_Queja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Asada_Queja.Add(asada_Queja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsada_Queja", new { id = asada_Queja.Id }, asada_Queja);
        }

        // DELETE: api/Asada_Queja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsada_Queja([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asada_Queja = await _context.Asada_Queja.FindAsync(id);
            if (asada_Queja == null)
            {
                return NotFound();
            }

            _context.Asada_Queja.Remove(asada_Queja);
            await _context.SaveChangesAsync();

            return Ok(asada_Queja);
        }

        private bool Asada_QuejaExists(int id)
        {
            return _context.Asada_Queja.Any(e => e.Id == id);
        }
    }
}