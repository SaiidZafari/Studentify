using Microsoft.EntityFrameworkCore;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        public async Task<Student> AddStudent(Student student)
        {
            var result = await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Student> DeleteStudent(int studentId)
        {
            var result = await dbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (result != null)
            {
                dbContext.Students.Remove(result);
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await dbContext.Students
                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string studentName)
        {
            IQueryable<Student> query = dbContext.Students;

            if (!string.IsNullOrEmpty(studentName))
            {
                query = query.Where(s => s.StudentName.Contains(studentName));
            }


            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var theStudent = await dbContext.Students
               .FirstOrDefaultAsync(t => t.StudentId == student.StudentId);

            if (theStudent != null)
            {
                theStudent.StudentName = student.StudentName;
                theStudent.ImageUrl = student.ImageUrl;
                //theStudent.Courses = student.Courses;               

                await dbContext.SaveChangesAsync();

                return theStudent;
            }

            return null;
        }

    }
}
