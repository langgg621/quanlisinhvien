using WebApplication1.Dto.Page;
using WebApplication1.Dto.Subject;
using WebApplication1.Dto.Values;
using WebApplication1.Entities;
namespace WebApplication1.Services.Interfaces
{
    public interface ISubjectService
    {
        void Create(CreateSubjectDto input);
        void Update(UpdateSubjectDto input);
        void Delete(int id);
        List<Subject> GetAll();
        List<Subject> GetById(int id);
        List<Student> GetAllStudent(int id);
        void AddStudentInClass(int subjectId, int studentId);
    }
}
