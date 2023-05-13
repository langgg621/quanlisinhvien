using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto.Subject
{
    public class CreateSubjectDto
    {
        [Required(ErrorMessage ="Id không được bỏ trống")]
        public int SubjectId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Tối đa 50 ký tự")]
        public string SubjectName { get; set; } //tối đa 50 kí tự
        [MinLength(5, ErrorMessage = "Tối thiểu 5 ký tự")]
        public string SubjectCode { get; set; } // Tối thiểu 5 kí tự
        [Range(0, 5, ErrorMessage ="Giá trị tối thiểu lớn hơn 0")]
        public int MaxStudent { get; set; }  // Số sinh viên lớn  hơn 0
        
        
    }
}
