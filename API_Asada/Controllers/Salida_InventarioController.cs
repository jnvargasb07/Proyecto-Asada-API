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
    public class Salida_InventarioController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Salida_InventarioController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Salida_Inventario
        [HttpGet]
        public IEnumerable<Salida_Inventario> GetSalida_Inventario()
        {
            return _context.Salida_Inventario;
        }

        // GET: api/Salida_Inventario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalida_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salida_Inventario = await _context.Salida_Inventario.FindAsync(id);

            if (salida_Inventario == null)
            {
                return NotFound();
            }

            return Ok(salida_Inventario);
        }

        // PUT: api/Salida_Inventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalida_Inventario([FromRoute] int id, [FromBody] Salida_Inventario salida_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salida_Inventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(salida_Inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Salida_InventarioExists(id))
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

        // POST: api/Salida_Inventario
        [HttpPost]
        public async Task<IActionResult> PostSalida_Inventario([FromBody] Salida_Inventario salida_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Salida_Inventario.Add(salida_Inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalida_Inventario", new { id = salida_Inventario.Id }, salida_Inventario);
        }

        // DELETE: api/Salida_Inventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalida_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salida_Inventario = await _context.Salida_Inventario.FindAsync(id);
            if (salida_Inventario == null)
            {
                return NotFound();
            }

            _context.Salida_Inventario.Remove(salida_Inventario);
            await _context.SaveChangesAsync();

            return Ok(salida_Inventario);
        }

        private bool Salida_InventarioExists(int id)
        {
            return _context.Salida_Inventario.Any(e => e.Id == id);
        }
    }
}