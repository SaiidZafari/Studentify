﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentify.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

        public Uri ImageUrl { get; set; }
    }
}
