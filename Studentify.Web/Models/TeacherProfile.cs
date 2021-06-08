using AutoMapper;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Models
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, EditTeacherModel>();

            CreateMap<EditTeacherModel, Teacher>();
        }
    }
}
