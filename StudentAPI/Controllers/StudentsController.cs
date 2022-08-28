using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;
using StudentAPI.ViewModels;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ENROLLMENT_SYSTEMContext _context;

        public StudentsController(ENROLLMENT_SYSTEMContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsWithTheirCourses>>> GetSTUDENTS()
        {
          if (_context.STUDENTS == null)
          {
              return NotFound();
          }
            return await _context.STUDENTS.Select(x => new StudentsWithTheirCourses
            {
                ID = x.ID,
                LastName = x.LNAME,
                FirstName = x.FNAME,
                Courses = (from sc in _context.STUDENTS_COURSES
                          where sc.STUDENT_ID == x.ID
                          from c in _context.COURSES
                          where c.ID == sc.COURSE_ID
                          select c.COURSE_TITLE).ToList()
            }).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<STUDENTS>> GetSTUDENTS(int id)
        {
          if (_context.STUDENTS == null)
          {
              return NotFound();
          }
            var sTUDENTS = await _context.STUDENTS.FindAsync(id);

            if (sTUDENTS == null)
            {
                return NotFound();
            }

            return sTUDENTS;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSTUDENTS(int id, STUDENTS sTUDENTS)
        {
            if (id != sTUDENTS.ID)
            {
                return BadRequest();
            }

            _context.Entry(sTUDENTS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STUDENTSExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<STUDENTS>> PostSTUDENTS(STUDENTS sTUDENTS)
        {
          if (_context.STUDENTS == null)
          {
              return Problem("Entity set 'ENROLLMENT_SYSTEMContext.STUDENTS'  is null.");
          }
            _context.STUDENTS.Add(sTUDENTS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSTUDENTS", new { id = sTUDENTS.ID }, sTUDENTS);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSTUDENTS(int id)
        {
            if (_context.STUDENTS == null)
            {
                return NotFound();
            }
            var sTUDENTS = await _context.STUDENTS.FindAsync(id);
            if (sTUDENTS == null)
            {
                return NotFound();
            }

            _context.STUDENTS.Remove(sTUDENTS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool STUDENTSExists(int id)
        {
            return (_context.STUDENTS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
