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
    public class TblEmployeesController : ControllerBase
    {
        private readonly EployeeContext _context;

        public TblEmployeesController(EployeeContext context)
        {
            _context = context;
        }

        // GET: api/TblEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> GetTblEmployees()
        {
            //return await _context.TblEmployees.ToListAsync();


            //Using Linq 
            var employee = (from e in _context.TblEmployees
                            join d in _context.TblDesignations
                            on e.DesignationID equals d.Id

                            select new TblEmployee
                            {
                                Id = e.Id,
                                Name = e.Name,
                                LastName = e.LastName,
                                Email = e.Email,
                                Age = e.Age,
                                DesignationID = e.DesignationID,
                                Designation = d.Designation,
                                Doj = e.Doj,
                                Gender = e.Gender,
                                IsActive = e.IsActive,
                                IsMarried = e.IsMarried
                            }
                            ).ToListAsync();
            return await employee;
        }

        // GET: api/TblEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployee>> GetTblEmployee(int id)
        {
            var tblEmployee = await _context.TblEmployees.FindAsync(id);

            if (tblEmployee == null)
            {
                return NotFound();
            }

            return tblEmployee;
        }

        // PUT: api/TblEmployees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmployee(int id, TblEmployee tblEmployee)
        {
            if (id != tblEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeExists(id))
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

        // POST: api/TblEmployees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblEmployee>> PostTblEmployee(TblEmployee tblEmployee)
        {
            _context.TblEmployees.Add(tblEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployee", new { id = tblEmployee.Id }, tblEmployee);
        }

        // DELETE: api/TblEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEmployee>> DeleteTblEmployee(int id)
        {
            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            _context.TblEmployees.Remove(tblEmployee);
            await _context.SaveChangesAsync();

            return tblEmployee;
        }

        private bool TblEmployeeExists(int id)
        {
            return _context.TblEmployees.Any(e => e.Id == id);
        }
    }
}
