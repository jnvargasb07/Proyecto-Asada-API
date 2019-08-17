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
    public class Registro_SalidaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Registro_SalidaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Salida
        [HttpGet]
        public IEnumerable<Registro_Salida> GetRegistro_Salida()
        {
            return _context.Registro_Salida;
        }

        // GET: api/Registro_Salida/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro_Salida([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Salida = await _context.Registro_Salida.FindAsync(id);

            if (registro_Salida == null)
            {
                return NotFound();
            }

            return Ok(registro_Salida);
        }

        // PUT: api/Registro_Salida/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro_Salida([FromRoute] int id, [FromBody] Registro_Salida registro_Salida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Salida.Id)
            {
                return BadRequest();
            }

            _context.Entry(registro_Salida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_SalidaExists(id))
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

        // POST: api/Registro_Salida
        [HttpPost]
        public async Task<IActionResult> PostRegistro_Salida([FromBody] Registro_Salida registro_Salida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registro_Salida.Add(registro_Salida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro_Salida", new { id = registro_Salida.Id }, registro_Salida);
        }

        // DELETE: api/Registro_Salida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Salida([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Salida = await _context.Registro_Salida.FindAsync(id);
            if (registro_Salida == null)
            {
                return NotFound();
            }

            _context.Registro_Salida.Remove(registro_Salida);
            await _context.SaveChangesAsync();

            return Ok(registro_Salida);
        }

        private bool Registro_SalidaExists(int id)
        {
            return _context.Registro_Salida.Any(e => e.Id == id);
        }
    }
}