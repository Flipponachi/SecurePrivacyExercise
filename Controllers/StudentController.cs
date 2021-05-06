using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePrivacyExercise.Dto;
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
        private IMapper _mapper;
        public StudentController(StudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint to get all students
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Get()
        {
            List<Student> value = _studentService.Get();

            List<DetailsStudentDto> data = _mapper.Map<List<DetailsStudentDto>>(value);
            return Ok(data);
        }


        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetById(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DetailsStudentDto>(student));
        }

        [HttpGet("grouped-students")]
        public async Task<IActionResult> GroupStudentByAge() => Ok(await _studentService.GroupStudentsByAge());

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto model)
        {
            Student student = _mapper.Map<Student>(model);
            _studentService.Create(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id.ToString() }, student);
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

            return Ok(new { message = "Updated Successfully" });
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

            return Ok(new { message = "Deleted Successfully" });
        }


    }
}
