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
    public class Inventario_StockController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Inventario_StockController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Inventario_Stock
        [HttpGet]
        public IEnumerable<Inventario_Stock> GetInventario_Stock()
        {
            return _context.Inventario_Stock;
        }

        // GET: api/Inventario_Stock/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventario_Stock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventario_Stock = await _context.Inventario_Stock.FindAsync(id);

            if (inventario_Stock == null)
            {
                return NotFound();
            }

            return Ok(inventario_Stock);
        }

        // PUT: api/Inventario_Stock/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario_Stock([FromRoute] int id, [FromBody] Inventario_Stock inventario_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario_Stock.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventario_Stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Inventario_StockExists(id))
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

        // POST: api/Inventario_Stock
        [HttpPost]
        public async Task<IActionResult> PostInventario_Stock([FromBody] Inventario_Stock inventario_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventario_Stock.Add(inventario_Stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventario_Stock", new { id = inventario_Stock.Id }, inventario_Stock);
        }

        // DELETE: api/Inventario_Stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario_Stock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventario_Stock = await _context.Inventario_Stock.FindAsync(id);
            if (inventario_Stock == null)
            {
                return NotFound();
            }

            _context.Inventario_Stock.Remove(inventario_Stock);
            await _context.SaveChangesAsync();

            return Ok(inventario_Stock);
        }

        private bool Inventario_StockExists(int id)
        {
            return _context.Inventario_Stock.Any(e => e.Id == id);
        }
    }
}