using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Model
{
    [Table("Student")]
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [StringLength(50)]
        [ConcurrencyCheck]
        public string Name { get; set; }

        public ICollection<StudentCourse> Attends { get; } = new List<StudentCourse>();
    }
}
