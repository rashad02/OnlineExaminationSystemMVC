using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exams
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public string ExamType { get; set; }
        public string ExamCode { get; set; }
        public string Topic { get; set; }
        public double  ObtainedMarks { get; set; }
        public double FullMarks { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Duration { get; set; }
        public string Serial { get; set; }
        public  virtual List<Question> Questions { get; set; }
        public  virtual List<Student> Students { get; set; }
    }

}
