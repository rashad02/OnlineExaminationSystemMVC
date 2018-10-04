using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        public int Id { get; set; }
        public virtual List<Organization> Organizations { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseCode { get; set; }
        public double Duration { get; set; }
        public double Credit { get; set; }
        public string Outline { get; set; }
        public int LeadTrainer { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Exams> Examses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
