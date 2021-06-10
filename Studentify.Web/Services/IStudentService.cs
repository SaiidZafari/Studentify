using Studentify.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> Search(string name);

        Task<Student> AddStudent(Student student);

        Task DeleteStudent(int id);
    }
}
