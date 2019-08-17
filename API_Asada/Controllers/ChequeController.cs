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
    public class ChequeController : ControllerBase
    {
        private readonly AsadaContext _context;

        public ChequeController(AsadaContext context)
        {
            _context = context;
        }

        // GET: api/Cheque
        [HttpGet]
        public IEnumerable<Cheque> GetCheque()
        {
            return _context.Cheque;
        }

        // GET: api/Cheque/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cheque = await _context.Cheque.FindAsync(id);

            if (cheque == null)
            {
                return NotFound();
            }

            return Ok(cheque);
        }

        // PUT: api/Cheque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheque([FromRoute] int id, [FromBody] Cheque cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cheque.Id)
            {
                return BadRequest();
            }

            _context.Entry(cheque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeExists(id))
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

        // POST: api/Cheque
        [HttpPost]
        public async Task<IActionResult> PostCheque([FromBody] Cheque cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cheque.Add(cheque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheque", new { id = cheque.Id }, cheque);
        }

        // DELETE: api/Cheque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheque([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cheque = await _context.Cheque.FindAsync(id);
            if (cheque == null)
            {
                return NotFound();
            }

            _context.Cheque.Remove(cheque);
            await _context.SaveChangesAsync();

            return Ok(cheque);
        }

        private bool ChequeExists(int id)
        {
            return _context.Cheque.Any(e => e.Id == id);
        }
    }
}