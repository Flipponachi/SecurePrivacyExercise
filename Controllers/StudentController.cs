using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePrivacyExercise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Endpoint to get all students
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Get() => Ok(_studentService.Get());
    }
}
