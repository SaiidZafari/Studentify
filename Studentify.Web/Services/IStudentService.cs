using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> Search(string name);
    }
}
