﻿using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
     public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
    }
}
