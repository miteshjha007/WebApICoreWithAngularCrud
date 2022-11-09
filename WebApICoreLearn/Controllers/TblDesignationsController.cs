using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApICoreLearn.Model;

namespace WebApICoreLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDesignationsController : ControllerBase
    {
        private readonly EployeeContext _context;

        public TblDesignationsController(EployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblDesignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDesignation>>> GetTblDesignations()
        {
            return await _context.TblDesignations.ToListAsync();
        }

        // GET: api/TblDesignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDesignation>> GetTblDesignation(int id)
        {
            var tblDesignation = await _context.TblDesignations.FindAsync(id);

            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        // PUT: api/TblDesignations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDesignation(int id, TblDesignation tblDesignation)
        {
            if (id != tblDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDesignationExists(id))
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

        // POST: api/TblDesignations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblDesignation>> PostTblDesignation(TblDesignation tblDesignation)
        {
            _context.TblDesignations.Add(tblDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDesignation", new { id = tblDesignation.Id }, tblDesignation);
        }

        // DELETE: api/TblDesignations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblDesignation>> DeleteTblDesignation(int id)
        {
            var tblDesignation = await _context.TblDesignations.FindAsync(id);
            if (tblDesignation == null)
            {
                return NotFound();
            }

            _context.TblDesignations.Remove(tblDesignation);
            await _context.SaveChangesAsync();

            return tblDesignation;
        }

        private bool TblDesignationExists(int id)
        {
            return _context.TblDesignations.Any(e => e.Id == id);
        }
    }
}
