using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElsaedyDemo.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(50)]
        public string CourseName { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Range(0, 25)]
        public int CourseCapcity { get; set; }

    }
}
