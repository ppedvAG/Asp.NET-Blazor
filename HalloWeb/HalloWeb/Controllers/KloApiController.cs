using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalloWeb.Data;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KloApiController : ControllerBase
    {
        private readonly HalloWebContext _context;

        public KloApiController(HalloWebContext context)
        {
            _context = context;
        }

        // GET: api/KloApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klopapier>>> GetKlopapier()
        {
            return await _context.Klopapier.ToListAsync();
        }

        // GET: api/KloApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Klopapier>> GetKlopapier(int id)
        {
            var klopapier = await _context.Klopapier.FindAsync(id);

            if (klopapier == null)
            {
                return NotFound();
            }

            return klopapier;
        }

        // PUT: api/KloApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlopapier(int id, Klopapier klopapier)
        {
            if (id != klopapier.Id)
            {
                return BadRequest();
            }

            _context.Entry(klopapier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlopapierExists(id))
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

        // POST: api/KloApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Klopapier>> PostKlopapier(Klopapier klopapier)
        {
            _context.Klopapier.Add(klopapier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKlopapier", new { id = klopapier.Id }, klopapier);
        }

        // DELETE: api/KloApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Klopapier>> DeleteKlopapier(int id)
        {
            var klopapier = await _context.Klopapier.FindAsync(id);
            if (klopapier == null)
            {
                return NotFound();
            }

            _context.Klopapier.Remove(klopapier);
            await _context.SaveChangesAsync();

            return klopapier;
        }

        private bool KlopapierExists(int id)
        {
            return _context.Klopapier.Any(e => e.Id == id);
        }
    }
}
