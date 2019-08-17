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
    public class Agua_No_ContabilizadaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Agua_No_ContabilizadaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Agua_No_Contabilizada
        [HttpGet]
        public IEnumerable<Agua_No_Contabilizada> GetAgua_No_Contabilizada()
        {
            return _context.Agua_No_Contabilizada;
        }

        // GET: api/Agua_No_Contabilizada/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgua_No_Contabilizada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agua_No_Contabilizada = await _context.Agua_No_Contabilizada.FindAsync(id);

            if (agua_No_Contabilizada == null)
            {
                return NotFound();
            }

            return Ok(agua_No_Contabilizada);
        }

        // PUT: api/Agua_No_Contabilizada/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgua_No_Contabilizada([FromRoute] int id, [FromBody] Agua_No_Contabilizada agua_No_Contabilizada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agua_No_Contabilizada.Id)
            {
                return BadRequest();
            }

            _context.Entry(agua_No_Contabilizada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Agua_No_ContabilizadaExists(id))
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

        // POST: api/Agua_No_Contabilizada
        [HttpPost]
        public async Task<IActionResult> PostAgua_No_Contabilizada([FromBody] Agua_No_Contabilizada agua_No_Contabilizada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Agua_No_Contabilizada.Add(agua_No_Contabilizada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgua_No_Contabilizada", new { id = agua_No_Contabilizada.Id }, agua_No_Contabilizada);
        }

        // DELETE: api/Agua_No_Contabilizada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgua_No_Contabilizada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agua_No_Contabilizada = await _context.Agua_No_Contabilizada.FindAsync(id);
            if (agua_No_Contabilizada == null)
            {
                return NotFound();
            }

            _context.Agua_No_Contabilizada.Remove(agua_No_Contabilizada);
            await _context.SaveChangesAsync();

            return Ok(agua_No_Contabilizada);
        }

        private bool Agua_No_ContabilizadaExists(int id)
        {
            return _context.Agua_No_Contabilizada.Any(e => e.Id == id);
        }
    }
}