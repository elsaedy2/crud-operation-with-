using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElsaedyDemo.Models
{
    public class Teacher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(50)]
        public string TeacherName { get; set; }

        [Range(5, 18)]
        public int TeacherAge { get; set; }

    }
}
