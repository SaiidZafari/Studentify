using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Search(string name);

        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int studentId);
    }
}
