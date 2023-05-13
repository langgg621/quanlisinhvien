using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string SubjectName { get; set; } //tối đa 50 kí tự
        public string SubjectCode { get; set; } // Tối thiểu 5 kí tự
        public int MaxStudent { get; set; }  // Số sinh viên lớn  hơn 0
        
    }
}
