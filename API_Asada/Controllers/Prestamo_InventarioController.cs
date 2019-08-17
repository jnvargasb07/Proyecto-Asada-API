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
    public class Prestamo_InventarioController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Prestamo_InventarioController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Prestamo_Inventario
        [HttpGet]
        public IEnumerable<Prestamo_Inventario> GetPrestamo_Inventario()
        {
            return _context.Prestamo_Inventario;
        }

        // GET: api/Prestamo_Inventario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrestamo_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prestamo_Inventario = await _context.Prestamo_Inventario.FindAsync(id);

            if (prestamo_Inventario == null)
            {
                return NotFound();
            }

            return Ok(prestamo_Inventario);
        }

        // PUT: api/Prestamo_Inventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo_Inventario([FromRoute] int id, [FromBody] Prestamo_Inventario prestamo_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo_Inventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(prestamo_Inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prestamo_InventarioExists(id))
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

        // POST: api/Prestamo_Inventario
        [HttpPost]
        public async Task<IActionResult> PostPrestamo_Inventario([FromBody] Prestamo_Inventario prestamo_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prestamo_Inventario.Add(prestamo_Inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrestamo_Inventario", new { id = prestamo_Inventario.Id }, prestamo_Inventario);
        }

        // DELETE: api/Prestamo_Inventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prestamo_Inventario = await _context.Prestamo_Inventario.FindAsync(id);
            if (prestamo_Inventario == null)
            {
                return NotFound();
            }

            _context.Prestamo_Inventario.Remove(prestamo_Inventario);
            await _context.SaveChangesAsync();

            return Ok(prestamo_Inventario);
        }

        private bool Prestamo_InventarioExists(int id)
        {
            return _context.Prestamo_Inventario.Any(e => e.Id == id);
        }
    }
}