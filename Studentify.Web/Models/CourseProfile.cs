using AutoMapper;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Models
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, EditCourseModel>();

            CreateMap<EditCourseModel, Course>();
        }
    }
}
