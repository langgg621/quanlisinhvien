using WebApplication1.DbContexts;
using WebApplication1.Dto.Student;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implements
{
    public class StudentService : IStudentService
    {
        //thêm, sửa, xoá, xem danh sách
        private readonly ApplicationDbContexts _context;
        public StudentService(ApplicationDbContexts context)
        {
            _context = context;
        }
        public void Create(CreateStudentDto input)
        {
            // thêm sinh viên vào list
            _context.Students.Add(new Student
            {
                //Name = input.Name,
            });
            _context.SaveChanges();
        }
        public void Delete(int Id)
        {
            // xóa sinh viên theo id
            var student = _context.Students.FirstOrDefault(s => s.Id   == Id);
            if (student == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có id = {Id}");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public void Update(UpdateStudentDto input)
        {
            // sửa sinh viên theo id
            var student = _context.Students.FirstOrDefault(s => s.Id   == input.Id);
            if (student == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input.Id}");
            }
            student.Name = input.Name;
            student.DOB = input.DOB;
            _context.SaveChanges();
        }
        public List<Student> GetById(int Id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == Id);
            var results = new List<Student>();
            if (student == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có id = {Id}");
            }
            results.Add(new Student
            {
                Id = student.Id,
                Name = student.Name,
                StudentCode = student.StudentCode,
                DOB = student.DOB
            });
            return results;
        }

        public List<Student> GetAll()
        {
            var results = new List<Student>();
            foreach (var student in _context.Students)
            {
                results.Add(new Student
                {   
                    Id = student.Id,
                    Name = student.Name,
                    StudentCode = student.StudentCode,
                    DOB = student.DOB
                });
            }
            return results;
        }


    }
}
    