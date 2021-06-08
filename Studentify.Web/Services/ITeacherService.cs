using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetTeachers();

        Task<Teacher> GetTeacher(int id);

        Task<IEnumerable<Teacher>> Search(string name);

        Task<Teacher> UpdateTeacher(Teacher UpdateTeacher);

        Task DeleteTeacher(int id);

        Task<Teacher> CreateTeacher(Teacher newTeacher);
    }
}
