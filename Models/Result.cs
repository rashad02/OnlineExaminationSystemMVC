using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Result
    {
        public int Id { get; set; }
        public Exams Exams { get; set; }    
        public int ExamsId { get; set; }


        public  virtual List<Student> Students  { get; set; }
        public virtual List<Course>   Courses { get; set; }

        public int  ObtainedMarks { get; set; }
       
    }
}
