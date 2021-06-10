using Microsoft.AspNetCore.Components;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient httpClient;

        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await httpClient.GetJsonAsync<Course[]>("api/courses");
        }

        public async Task<Course> GetCourse(int id)
        {
            return await httpClient.GetJsonAsync<Course>($"api/courses/{id}");
        }

        public async Task<IEnumerable<Course>> Search(string name)
        {
            return await httpClient.GetJsonAsync<Course[]>($"api/courses/search/{name}");
        }

        public async Task<IEnumerable<Course>> GetStudentCourses(int studentId)
        {
            return await httpClient.GetJsonAsync<Course[]>($"api/courses/studentCourse/{studentId}");
        }

        public async Task<Course> CreateCourse(Course course)
        {
            return await httpClient.PostJsonAsync<Course>("api/courses", course);
        }

        public async Task DeleteCourse(int id)
        {
            await httpClient.DeleteAsync($"api/courses/{id}");
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            return await httpClient.PutJsonAsync<Course>("api/courses", course);
        }
    }
}
