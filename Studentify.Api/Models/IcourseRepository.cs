﻿using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
     public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int courseId);
    }
}
