using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SampleUniversity.Models;
using SampleUniversity.Services;

namespace SampleUniversity.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
//        // GET
//        public IActionResult Index() {
//            return View();
//        }

        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService) {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get() => _studentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Student> Get(string id) {
            var student = _studentService.Get(id);

            if (student == null) {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student) {
            _studentService.Create(student);

            return CreatedAtRoute("GetStudent", new {id = student.Id}, student);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Student updatedStudent) {
            var student = _studentService.Get(id);

            if (student == null) {
                return NotFound();
            }

            _studentService.Update(id, updatedStudent);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id) {
            var student = _studentService.Get(id);

            if (student == null) {
                return NotFound();
            }

            _studentService.Remove(student.Id);

            return NoContent();
        }
    }
}