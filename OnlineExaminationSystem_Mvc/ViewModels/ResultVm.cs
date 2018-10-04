using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels
{
    public class ResultVm
    {
        public int Id { get; set; }
        public Exams Exams { get; set; }
        public int ExamsId { get; set; }
        public string Code { get; set; }
        public int StudentId     { get; set; }
        
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string OrganizationName { get; set; }





        public virtual List<Models.Student> Students { get; set; }
        public virtual List<Models.Course> Courses { get; set; }

        public int ObtainedMarks { get; set; }



    }
}