using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicREST.Data;
using BasicREST.Models;

/// <summary>
/// Autogen, nothing changed :(
/// 
/// Almost all methods of this class are a good candidate for weaving into them an aspect.
/// EG:
///     (almost)All methods before they execute, have to check for validation of ModelState
///     "if (!ModelState.IsValid)
///		    return BadRequest(ModelState.GetErrorMessages());"
/// </summary>
namespace BasicREST.Controllers
{
    [Route("BasicREST/[controller]")]
    [ApiController]
    public class MeatsController : ControllerBase
    {
        private readonly MeatContext _context;

        public MeatsController(MeatContext context)
        {
            _context = context;
        }

        // GET: api/Meats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meat>>> GetMeat()
        {
            return await _context.Meat.ToListAsync();
        }

        // GET: api/Meats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meat>> GetMeat(int id)
        {
            var meat = await _context.Meat.FindAsync(id);

            if (meat == null)
            {
                return NotFound();
            }

            return meat;
        }

        // PUT: api/Meats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeat(int id, Meat meat)
        {
            if (id != meat.Id)
            {
                return BadRequest();
            }

            _context.Entry(meat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeatExists(id))
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

        // POST: api/Meats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Meat>> PostMeat(Meat meat)
        {
            _context.Meat.Add(meat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeat", new { id = meat.Id }, meat);
        }

        // DELETE: api/Meats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meat>> DeleteMeat(int id)
        {
            var meat = await _context.Meat.FindAsync(id);
            if (meat == null)
            {
                return NotFound();
            }

            _context.Meat.Remove(meat);
            await _context.SaveChangesAsync();

            return meat;
        }

        private bool MeatExists(int id)
        {
            return _context.Meat.Any(e => e.Id == id);
        }
    }
}
