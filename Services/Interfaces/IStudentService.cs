using WebApplication1.Dto.Page;
using WebApplication1.Dto.Student;
using WebApplication1.Dto.Values;
using WebApplication1.Entities;
namespace WebApplication1.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        void Update(UpdateStudentDto input);
        void Delete(int id);
        List<Student> GetById(int id);
        List<Student> GetAll();
    }
}
