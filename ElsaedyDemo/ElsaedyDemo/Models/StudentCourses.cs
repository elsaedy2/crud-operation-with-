﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElsaedyDemo.Models
{
    public class StudentCourses
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCourseId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
