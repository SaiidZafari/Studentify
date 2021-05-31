using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentify.Api.Models;
using Studentify.Models;

namespace Studentify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {

        //private readonly IGradeRepository gradeRepository;

        //public GradesController(IGradeRepository gradeRepository)
        //{
        //    this.gradeRepository = gradeRepository;
        //}


        //// GET: api/Grades
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        //{
        //    try
        //    {
        //        return Ok(await gradeRepository.GetGrades());
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
        //    }
        //}

        //// GET: api/Grades/3
        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Grade>> GetGrade(int id)
        //{
        //    try
        //    {
        //        var theGrade = await gradeRepository.GetGrade(id);

        //        if (theGrade == null)
        //        {
        //            return NotFound();
        //        }

        //        return theGrade;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
        //    }
        //}


        //// PUT: api/Grade/2
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<Grade>> PutGrade(int id, Grade grade)
        //{
        //    try
        //    {
        //        if (id != grade.GradeId)
        //        {
        //            return BadRequest("Grade ID mismatch");
        //        }

        //        var gradeToUpdate = await gradeRepository.GetGrade(id);

        //        if (gradeToUpdate == null)
        //        {
        //            return NotFound($"Grade with Id = {id} not found");
        //        }

        //        return await gradeRepository.UpdateGrade(grade);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error update data");
        //    }
        //}


        //// POST: api/Grades
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Grade>> CreateGrade(Grade grade)
        //{
        //    try
        //    {
        //        var createdGrade = await gradeRepository.AddGrade(grade);
        //        return CreatedAtAction(nameof(GetGrade), new { id = createdGrade.GradeId }, createdGrade);

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Add data");
        //    }

        //}


        //// DELETE: api/Grades/3
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Grade>> DeleteGrade(int id)
        //{

        //    try
        //    {
        //        var gradeToDelete = await gradeRepository.GetGrade(id);

        //        if (gradeToDelete == null)
        //        {
        //            return NotFound($"Grade with Id = {id} not found");
        //        }

        //        return await gradeRepository.DeleteGrade(id);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
        //    }

        //}


        ////[HttpGet("{search}/{name}")]
        //[HttpGet("search/{name}")]
        //public async Task<ActionResult<IEnumerable<Grade>>> Search(string name)
        //{
        //    try
        //    {
        //        var result = await gradeRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        //    }
        //}


        //----------------------------------------------------------------------------------------------------

        private readonly AppDbContext _context;

        public GradesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrade", new { id = grade.GradeId }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
    }
}
