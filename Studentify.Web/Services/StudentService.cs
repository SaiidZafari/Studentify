using Microsoft.AspNetCore.Components;
using Studentify.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient httpClient;

        public StudentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Student> AddStudent(Student student)
        {
            return await httpClient.PostJsonAsync<Student>("api/students", student);
        }

        public async Task<Student> GetStudent(int id)
        {
            return await httpClient.GetJsonAsync<Student>($"api/students/{id}");
        }


        public async Task DeleteStudent(int id)
        {
            await httpClient.DeleteAsync($"api/students/{id}");
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await httpClient.GetJsonAsync<Student[]>("api/students");
        }

        public async Task<IEnumerable<Student>> Search(string name)
        {
            return await httpClient.GetJsonAsync<Student[]>($"api/students/search/{name}");
        }
    }
}
