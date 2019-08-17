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
    public class Registro_CompraController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Registro_CompraController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Compra
        [HttpGet]
        public IEnumerable<Registro_Compra> GetRegistro_Compra()
        {
            return _context.Registro_Compra;
        }

        // GET: api/Registro_Compra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro_Compra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Compra = await _context.Registro_Compra.FindAsync(id);

            if (registro_Compra == null)
            {
                return NotFound();
            }

            return Ok(registro_Compra);
        }

        // PUT: api/Registro_Compra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro_Compra([FromRoute] int id, [FromBody] Registro_Compra registro_Compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(registro_Compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_CompraExists(id))
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

        // POST: api/Registro_Compra
        [HttpPost]
        public async Task<IActionResult> PostRegistro_Compra([FromBody] Registro_Compra registro_Compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registro_Compra.Add(registro_Compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro_Compra", new { id = registro_Compra.Id }, registro_Compra);
        }

        // DELETE: api/Registro_Compra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Compra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Compra = await _context.Registro_Compra.FindAsync(id);
            if (registro_Compra == null)
            {
                return NotFound();
            }

            _context.Registro_Compra.Remove(registro_Compra);
            await _context.SaveChangesAsync();

            return Ok(registro_Compra);
        }

        private bool Registro_CompraExists(int id)
        {
            return _context.Registro_Compra.Any(e => e.Id == id);
        }
    }
}