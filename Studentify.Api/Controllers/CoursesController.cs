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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                return Ok(await courseRepository.GetCourses());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        // GET: api/Courses/3
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var Course = await courseRepository.GetCourse(id);

                if (Course == null)
                {
                    return NotFound();
                }

                return Course;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }


        // PUT: api/Course/2
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Course>> PutCourse(int id, Course course)
        {
            try
            {
                if (id != course.CourseId)
                {
                    return BadRequest("Course ID mismatch");
                }

                var courseToUpdate = await courseRepository.GetCourse(id);

                if (courseToUpdate == null)
                {
                    return NotFound($"Course with Id = {id} not found");
                }

                return await courseRepository.UpdateCourse(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update data");
            }
        }


        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            try
            {
                var createdCourse = await courseRepository.AddCourse(course);
                return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.CourseId }, createdCourse);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add data");
            }

        }


        // DELETE: api/Courses/3
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {

            try
            {
                var courseToDelete = await courseRepository.GetCourse(id);

                if (courseToDelete == null)
                {
                    return NotFound($"Course with Id = {id} not found");
                }

                return await courseRepository.DeleteCourse(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }

        }


        //[HttpGet("{search}/{name}")]
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Course>>> Search(string name)
        {
            try
            {
                var result = await courseRepository.Search(name);
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


        [HttpGet("studentCourse/{studentId:int}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetStudentCourses(int studentId)
        {
            return Ok(await courseRepository.GetStudentCourses(studentId));
        }






        //private readonly AppDbContext _context;

        //public CoursesController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Courses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        //{
        //    return await _context.Courses.ToListAsync();
        //}

        //// GET: api/Courses/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Course>> GetCourse(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return course;
        //}

        //// PUT: api/Courses/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCourse(int id, Course course)
        //{
        //    if (id != course.CourseId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(course).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CourseExists(id))
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

        //// POST: api/Courses
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Course>> PostCourse(Course course)
        //{
        //    _context.Courses.Add(course);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        //}

        //// DELETE: api/Courses/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCourse(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Courses.Remove(course);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CourseExists(int id)
        //{
        //    return _context.Courses.Any(e => e.CourseId == id);
        //}
    }
}
