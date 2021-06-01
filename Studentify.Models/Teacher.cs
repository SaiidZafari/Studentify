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

        public string ImageUrl { get; set; }

        //public int CourseId { get; set; }


        //public Course Course { get; set; }

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();        

    }
}
