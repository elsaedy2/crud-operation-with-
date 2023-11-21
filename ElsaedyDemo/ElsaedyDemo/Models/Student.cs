using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElsaedyDemo.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(50)]
        public string StudentName { get; set; }
        public bool IsActive { get; set; }
        [Range(5, 18)]
        public int StudentAge { get; set; }
    }
}
