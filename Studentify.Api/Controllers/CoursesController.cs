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



    }
}
