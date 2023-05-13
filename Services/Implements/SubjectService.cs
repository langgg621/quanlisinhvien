using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Dto.Page;
using WebApplication1.Dto.Student;
using WebApplication1.Dto.Subject;
using WebApplication1.Dto.Values;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implements
{
    public class SubjectSerive : ISubjectService
    {
        private readonly ApplicationDbContexts _contexts;
        public SubjectSerive(ApplicationDbContexts contexts)
        {
            _contexts = contexts;
        }
        public List<Student> GetAllStudent(int subjectId)
        {
            var query = from studentClass in _contexts.Classs
                       join student in _contexts.Students
                       on studentClass.StudentId equals student.Id
                       where studentClass.SubjectId == subjectId
                       select new Student
                       {
                           Id = student.Id,
                           Name = student.Name,
                           DOB = student.DOB,
                           StudentCode = student.StudentCode
                       };
            return query.ToList();
        }

        //thêm, sửa, xoá, xem danh sách

        public void Create(CreateSubjectDto input)
        {
            // thêm môn học vào list
            _contexts.Subjects.Add(new Subject
            {
            });
        }
        public void Delete(int Id)
        {
            // xóa môn học  theo id
            var subject = _contexts.Subjects.FirstOrDefault(s => s.Id == Id);
            if (subject == null)
            {
                throw new UserFriendlyException($"Không tìm thấy môn học có id = {Id}");
            }
            _contexts.Subjects.Remove(subject);
        }
        public void Update(UpdateSubjectDto input)
        {
            // sửa môn học  theo id
            var subject = _contexts.Subjects.FirstOrDefault(s => s.Id == input.Id);
            if (subject == null)
            {
                throw new Exception($"Không tìm thấy môn học có id = {input.Id}");
            }
            subject.SubjectName = input.SubjectName;
            subject.SubjectCode = input.SubjectCode;
            subject.MaxStudent = input.MaxStudent;
        }
        public List<Subject> GetById(int Id)
        {
            var subject = _contexts.Subjects.FirstOrDefault(s => s.Id == Id);
            var results = new List<Subject>();
            if (subject == null)
            {
                throw new UserFriendlyException($"Không tìm thấy môn học có id = {Id}");
            }
            results.Add(new Subject
            {
                Id = subject.Id,
                SubjectName = subject.SubjectName,
                SubjectCode = subject.SubjectCode,
                MaxStudent  = subject.MaxStudent
            });
            return results;
        }

        public List<Subject> GetAll()
        {
            var result = new List<Subject>();
            foreach (var subject in _contexts.Subjects)
            {
                result.Add(new Subject
                {
                    Id= subject.Id,
                    SubjectName = subject.SubjectName,
                    SubjectCode = subject.SubjectCode,
                    MaxStudent = subject.MaxStudent
                });
                
            }
            return result;
        }

        public void AddStudentInClass(int subjectId, int studentId)
        {
            if(_contexts.Classs.Any(s => s.StudentId ==studentId && s.SubjectId == subjectId))
            {
                throw new UserFriendlyException("Sinh viên đã thêm môn học");
            }
            var student = _contexts.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new UserFriendlyException("không tìm thấy sinh viên");
            }
            var subject = _contexts.Subjects.FirstOrDefault(s => s.Id == subjectId);
            if (subject == null)
            {
                throw new UserFriendlyException("Không tìm thấy môn học");
            }
            _contexts.Classs.Add(new Class
            {
                StudentId = studentId,
                SubjectId = subjectId
            });
        }
    }
}
