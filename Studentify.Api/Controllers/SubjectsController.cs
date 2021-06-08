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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            try
            {
                return Ok(await subjectRepository.GetSubjects());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        // GET: api/Subjects/3
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            try
            {
                var Subject = await subjectRepository.GetSubject(id);

                if (Subject == null)
                {
                    return NotFound();
                }

                return Subject;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }


        // PUT: api/Subject/2
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Subject>> PutSubject(int id, Subject subject)
        {
            try
            {
                if (id != subject.SubjectId)
                {
                    return BadRequest("Subject ID mismatch");
                }

                var subjectToUpdate = await subjectRepository.GetSubject(id);

                if (subjectToUpdate == null)
                {
                    return NotFound($"Subject with Id = {id} not found");
                }

                return await subjectRepository.UpdateSubject(subject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update data");
            }
        }


        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject(Subject subject)
        {
            try
            {
                var createdSubject = await subjectRepository.AddSubject(subject);
                return CreatedAtAction(nameof(GetSubject), new { id = createdSubject.SubjectId }, createdSubject);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add data");
            }

        }


        // DELETE: api/Subjects/3
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {

            try
            {
                var subjectToDelete = await subjectRepository.GetSubject(id);

                if (subjectToDelete == null)
                {
                    return NotFound($"Subject with Id = {id} not found");
                }

                return await subjectRepository.DeleteSubject(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }

        }


        //[HttpGet("{search}/{name}")]
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Subject>>> Search(string name)
        {
            try
            {
                var result = await subjectRepository.Search(name);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }




        //private readonly AppDbContext _context;

        //public SubjectsController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Subjects
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        //{
        //    return await _context.Subjects.ToListAsync();
        //}

        //// GET: api/Subjects/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Subject>> GetSubject(int id)
        //{
        //    var subject = await _context.Subjects.FindAsync(id);

        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return subject;
        //}

        //// PUT: api/Subjects/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSubject(int id, Subject subject)
        //{
        //    if (id != subject.SubjectId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(subject).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Subjects
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        //{
        //    _context.Subjects.Add(subject);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subject);
        //}

        //// DELETE: api/Subjects/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSubject(int id)
        //{
        //    var subject = await _context.Subjects.FindAsync(id);
        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Subjects.Remove(subject);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SubjectExists(int id)
        //{
        //    return _context.Subjects.Any(e => e.SubjectId == id);
        //}
    }
}
