using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentService _studentService;
		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		// GET: api/<StudentsController>
		[HttpGet]
		public ActionResult<List<Student>> GetList()
		{
			return _studentService.GetList();
		}

		// GET api/<StudentsController>/5
		[HttpGet("{id}")]
		public ActionResult<Student> Get(string id)
		{
			var result = _studentService.GetById(id);
			if (result == null)
			{
				return NotFound("Not found");
			}

			return result;
		}

		// POST api/<StudentsController>
		[HttpPost]
		public ActionResult<Student> Post([FromBody] Student student)
		{
			_studentService.Create(student);
			return CreatedAtAction(nameof(Student), new { id = student.Id }, student);
		}

		// PUT api/<StudentsController>/5
		[HttpPut("{id}")]
		public ActionResult<Student> Put(string id, [FromBody] Student student)
		{
			var existingStudent = _studentService.GetById(id);
			if (existingStudent == null)
			{
				return NotFound("Not found");
			}
			_studentService.Update(id, student);
			return NoContent();
		}

		// DELETE api/<StudentsController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(string id)
		{
			var existingStudent = _studentService.GetById(id);
			if (existingStudent == null)
			{
				return NotFound("Not found");
			}
			_studentService.Remove(id);
			return Ok("Student deleted");
		}
	}
}
