using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Dto
{
    public class EditStudentDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Int32? Age { get; set; }

        public string Address { get; set; }
    }
}
