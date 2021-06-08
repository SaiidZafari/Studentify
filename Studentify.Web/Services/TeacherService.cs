using Microsoft.AspNetCore.Components;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient httpClient;

        public TeacherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task DeleteTeacher(int id)
        {
            await httpClient.DeleteAsync($"api/Teachers/{id}");
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await httpClient.GetJsonAsync<Teacher>($"api/Teachers/{id}");
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await httpClient.GetJsonAsync<Teacher[]>("api/Teachers");
        }

        public async Task<Teacher> CreateTeacher(Teacher newTeacher)
        {
            return await httpClient.PostJsonAsync<Teacher>("api/Teachers", newTeacher);
        }

        public async Task<IEnumerable<Teacher>> Search(string name)
        {
            return await httpClient.GetJsonAsync<Teacher[]>($"api/Teachers/Search/{name}");
        }

        public async Task<Teacher> UpdateTeacher(Teacher updateTeacher)
        {
            return await httpClient.PutJsonAsync<Teacher>("api/Teachers", updateTeacher);
        }
    }
}
