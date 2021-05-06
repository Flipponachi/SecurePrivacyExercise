using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Dto
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Int32? Age { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
