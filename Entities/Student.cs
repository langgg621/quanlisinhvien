using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [MaxLength(100)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCode { get; set; }
        public DateTime DOB { get; set; }
        
    }
}
