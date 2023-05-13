using System.ComponentModel.DataAnnotations;
using WebApplication1.Validations;

namespace WebApplication1.Dto.Student
{
    public class CreateStudentDto
        
    {
        [Required(ErrorMessage ="Id không được bỏ trống")]
        public int StudentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        [StringLength(50,ErrorMessage ="Tối đa 50 kí tự")]
        public string Name { get; set; }

        public int StudentCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

    }
}
