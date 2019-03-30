using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Model
{
    [Table("Course")]
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }

        public ICollection<StudentCourse> Students { get; } = new List<StudentCourse>();
    }
}