using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Models
{
    public class AddTeacherModel
    {
        public int TecherId { get; set; }

        public string TeacherName { get; set; }

        public string ImageUrl { get; set; }

        public Course Course { get; set; }
    }
}
