using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DbContexts;
using WebApplication1.Dto.Page;
using WebApplication1.Dto.Subject;
using WebApplication1.Services.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace WebApplication1.Controllers
{
    [Route("api/Subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpPost("create")]
        public IActionResult Create(CreateSubjectDto input)
        {
            _subjectService.Create(input);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(UpdateSubjectDto input)
        {
            
            _subjectService.Update(input);
            return Ok();
            
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            
             return Ok(_subjectService.GetById(id));
            
        }
        [HttpGet("Get-all")]
        public IActionResult GetAll()
        {
            
            return Ok(_subjectService.GetAll());

            
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            
            _subjectService.Delete(id);
            return Ok();
            
        }
        [HttpPatch("add-Student")]
        public IActionResult AddStudent(int subjectId, int studentId)
        {
            
            _subjectService.AddStudentInClass(subjectId, studentId);
            return Ok();
            
        }
        
        [HttpGet("get-all-students")]
        
        public IActionResult GetAllStudent(int subjectid)
        {
            var result = _subjectService.GetAllStudent(subjectid);
            return Ok(result);
        }
    }
}
