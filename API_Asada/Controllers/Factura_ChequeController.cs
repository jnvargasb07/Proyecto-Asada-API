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
    public class Factura_ChequeController : ControllerBase
    {
        private readonly AsadaContext _context;

        public Factura_ChequeController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Factura_Cheque
        [HttpGet]
        public IEnumerable<Factura_Cheque> GetFactura_Cheque()
        {
            return _context.Factura_Cheque;
        }

        // GET: api/Factura_Cheque/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFactura_Cheque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factura_Cheque = await _context.Factura_Cheque.FindAsync(id);

            if (factura_Cheque == null)
            {
                return NotFound();
            }

            return Ok(factura_Cheque);
        }

        // PUT: api/Factura_Cheque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura_Cheque([FromRoute] int id, [FromBody] Factura_Cheque factura_Cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura_Cheque.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura_Cheque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Factura_ChequeExists(id))
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

        // POST: api/Factura_Cheque
        [HttpPost]
        public async Task<IActionResult> PostFactura_Cheque([FromBody] Factura_Cheque factura_Cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Factura_Cheque.Add(factura_Cheque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura_Cheque", new { id = factura_Cheque.Id }, factura_Cheque);
        }

        // DELETE: api/Factura_Cheque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura_Cheque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factura_Cheque = await _context.Factura_Cheque.FindAsync(id);
            if (factura_Cheque == null)
            {
                return NotFound();
            }

            _context.Factura_Cheque.Remove(factura_Cheque);
            await _context.SaveChangesAsync();

            return Ok(factura_Cheque);
        }

        private bool Factura_ChequeExists(int id)
        {
            return _context.Factura_Cheque.Any(e => e.Id == id);
        }
    }
}