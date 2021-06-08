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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }


        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            try
            {
                return Ok(await teacherRepository.GetTeachers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        // GET: api/Teachers/3
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            try
            {
                var Teacher = await teacherRepository.GetTeacher(id);

                if (Teacher == null)
                {
                    return NotFound();
                }

                return Teacher;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }


        //// PUT: api/Teacher/2
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<Teacher>> PutTeacher(int id, Teacher teacher)
        //{
        //    try
        //    {
        //        if (id != teacher.TeacherId)
        //        {
        //            return BadRequest("Teacher ID mismatch");
        //        }

        //        var teacherToUpdate = await teacherRepository.GetTeacher(id);

        //        if (teacherToUpdate == null)
        //        {
        //            return NotFound($"Teacher with Id = {id} not found");
        //        }

        //        return await teacherRepository.UpdateTeacher(teacher);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error update data");
        //    }
        //}


        // PUT: api/Teacher/2
        [HttpPut()]
        public async Task<ActionResult<Teacher>> PutTeacher(Teacher teacher)
        {
            try
            {
                
                var teacherToUpdate = await teacherRepository.GetTeacher(teacher.TeacherId);

                if (teacherToUpdate == null)
                {
                    return NotFound($"Teacher with Id = {teacher.TeacherId} not found");
                }

                return await teacherRepository.UpdateTeacher(teacher);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update data");
            }
        }


        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
        {
            try
            {
                var createdTeacher = await teacherRepository.AddTeacher(teacher);
                return CreatedAtAction(nameof(GetTeacher), new { id = createdTeacher.TeacherId }, createdTeacher);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add data");
            }

        }


        // DELETE: api/Teachers/3
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {

            try
            {
                var teacherToDelete = await teacherRepository.GetTeacher(id);

                if (teacherToDelete == null)
                {
                    return NotFound($"Teacher with Id = {id} not found");
                }

                return await teacherRepository.DeleteTeacher(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }

        }




        //[HttpGet("{search}/{name}")]
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Teacher>>> Search(string name)
        {
            try
            {
                var result = await teacherRepository.Search(name);
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











        //[HttpGet("{name}")]
        //public async Task<ActionResult<IEnumerable<Teacher>>> Search(string name)
        //{
        //    //IQueryable<Teacher> result = Context.Teachers;

        //    IQueryable<Teacher> result = Context.Teachers;

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        result = result.Where(t => t.TeacherName.Contains(name));
        //    }

        //    //if (Id != null)
        //    //{
        //    //    result = result.Where(t => t.TeacherId == Id);
        //    //}

        //    return await result.ToArrayAsync();
        //}

        //// GET: api/Teachers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        //{
        //    return await Context.Teachers.ToListAsync();
        //}

        //// GET: api/Teachers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Teacher>> GetTeacher(int id)
        //{
        //    var teacher = await Context.Teachers.FindAsync(id);

        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    return teacher;
        //}

        //// PUT: api/Teachers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        //{
        //    if (id != teacher.TeacherId)
        //    {
        //        return BadRequest();
        //    }

        //    Context.Entry(teacher).State = EntityState.Modified;

        //    try
        //    {
        //        await Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeacherExists(id))
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

        //// POST: api/Teachers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        //{
        //    Context.Teachers.Add(teacher);
        //    await Context.SaveChangesAsync();

        //    return CreatedAtAction("GetTeacher", new { id = teacher.TeacherId }, teacher);
        //}

        //// DELETE: api/Teachers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTeacher(int id)
        //{
        //    var teacher = await Context.Teachers.FindAsync(id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    Context.Teachers.Remove(teacher);
        //    await Context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TeacherExists(int id)
        //{
        //    return Context.Teachers.Any(e => e.TeacherId == id);
        //}
    }
}
