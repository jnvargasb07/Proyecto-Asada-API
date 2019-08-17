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
    public class Cuenta_BancariaController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Cuenta_BancariaController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Cuenta_Bancaria
        [HttpGet]
        public IEnumerable<Cuenta_Bancaria> GetCuenta_Bancaria()
        {
            return _context.Cuenta_Bancaria;
        }

        // GET: api/Cuenta_Bancaria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuenta_Bancaria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cuenta_Bancaria = await _context.Cuenta_Bancaria.FindAsync(id);

            if (cuenta_Bancaria == null)
            {
                return NotFound();
            }

            return Ok(cuenta_Bancaria);
        }

        // PUT: api/Cuenta_Bancaria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta_Bancaria([FromRoute] int id, [FromBody] Cuenta_Bancaria cuenta_Bancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta_Bancaria.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuenta_Bancaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cuenta_BancariaExists(id))
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

        // POST: api/Cuenta_Bancaria
        [HttpPost]
        public async Task<IActionResult> PostCuenta_Bancaria([FromBody] Cuenta_Bancaria cuenta_Bancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cuenta_Bancaria.Add(cuenta_Bancaria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuenta_Bancaria", new { id = cuenta_Bancaria.Id }, cuenta_Bancaria);
        }

        // DELETE: api/Cuenta_Bancaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta_Bancaria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cuenta_Bancaria = await _context.Cuenta_Bancaria.FindAsync(id);
            if (cuenta_Bancaria == null)
            {
                return NotFound();
            }

            _context.Cuenta_Bancaria.Remove(cuenta_Bancaria);
            await _context.SaveChangesAsync();

            return Ok(cuenta_Bancaria);
        }

        private bool Cuenta_BancariaExists(int id)
        {
            return _context.Cuenta_Bancaria.Any(e => e.Id == id);
        }
    }
}