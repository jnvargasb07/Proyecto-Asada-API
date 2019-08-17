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
    public class Inventario_AveriaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Inventario_AveriaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Inventario_Averia
        [HttpGet]
        public IEnumerable<Inventario_Averia> GetInventario_Averia()
        {
            return _context.Inventario_Averia;
        }

        // GET: api/Inventario_Averia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventario_Averia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventario_Averia = await _context.Inventario_Averia.FindAsync(id);

            if (inventario_Averia == null)
            {
                return NotFound();
            }

            return Ok(inventario_Averia);
        }

        // PUT: api/Inventario_Averia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario_Averia([FromRoute] int id, [FromBody] Inventario_Averia inventario_Averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario_Averia.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventario_Averia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Inventario_AveriaExists(id))
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

        // POST: api/Inventario_Averia
        [HttpPost]
        public async Task<IActionResult> PostInventario_Averia([FromBody] Inventario_Averia inventario_Averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventario_Averia.Add(inventario_Averia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventario_Averia", new { id = inventario_Averia.Id }, inventario_Averia);
        }

        // DELETE: api/Inventario_Averia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario_Averia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventario_Averia = await _context.Inventario_Averia.FindAsync(id);
            if (inventario_Averia == null)
            {
                return NotFound();
            }

            _context.Inventario_Averia.Remove(inventario_Averia);
            await _context.SaveChangesAsync();

            return Ok(inventario_Averia);
        }

        private bool Inventario_AveriaExists(int id)
        {
            return _context.Inventario_Averia.Any(e => e.Id == id);
        }
    }
}