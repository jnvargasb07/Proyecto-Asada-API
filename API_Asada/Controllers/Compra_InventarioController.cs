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
    public class Compra_InventarioController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Compra_InventarioController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Compra_Inventario
        [HttpGet]
        public IEnumerable<Compra_Inventario> GetCompra_Inventario()
        {
            return _context.Compra_Inventario;
        }

        // GET: api/Compra_Inventario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompra_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compra_Inventario = await _context.Compra_Inventario.FindAsync(id);

            if (compra_Inventario == null)
            {
                return NotFound();
            }

            return Ok(compra_Inventario);
        }

        // PUT: api/Compra_Inventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra_Inventario([FromRoute] int id, [FromBody] Compra_Inventario compra_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra_Inventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(compra_Inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Compra_InventarioExists(id))
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

        // POST: api/Compra_Inventario
        [HttpPost]
        public async Task<IActionResult> PostCompra_Inventario([FromBody] Compra_Inventario compra_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Compra_Inventario.Add(compra_Inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra_Inventario", new { id = compra_Inventario.Id }, compra_Inventario);
        }

        // DELETE: api/Compra_Inventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra_Inventario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compra_Inventario = await _context.Compra_Inventario.FindAsync(id);
            if (compra_Inventario == null)
            {
                return NotFound();
            }

            _context.Compra_Inventario.Remove(compra_Inventario);
            await _context.SaveChangesAsync();

            return Ok(compra_Inventario);
        }

        private bool Compra_InventarioExists(int id)
        {
            return _context.Compra_Inventario.Any(e => e.Id == id);
        }
    }
}