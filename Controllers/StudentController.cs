using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Dto.Page;
using WebApplication1.Dto.Student;
using WebApplication1.Services.Implements;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentDto input)
        {
            
            _studentService.Create(input);
            return Ok();
            
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateStudentDto input)
        {
            _studentService.Update(input);
            return Ok();
            
          
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            _studentService.Delete(id);
            return Ok();
            
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }
    }
}
