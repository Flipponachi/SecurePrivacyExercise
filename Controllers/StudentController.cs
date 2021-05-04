using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePrivacyExercise.Models;
using SecurePrivacyExercise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> Get(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            _studentService.Create(model);

            return CreatedAtRoute("GetStudent", new { id = model.Id.ToString() }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Student model)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Remove(student.Id);

            return NoContent();
        }
    }
}
