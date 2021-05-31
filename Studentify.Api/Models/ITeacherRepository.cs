using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Search(string name);

        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int teacherId);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(int teacherId);
    }
}
