using AutoMapper;
using SecurePrivacyExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentDto, Student>();

            CreateMap<EditStudentDto, Student>();
            CreateMap<Student, DetailsStudentDto>();
        }
    }
}
