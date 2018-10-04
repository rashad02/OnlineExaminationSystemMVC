using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Exam
{
    public class ExamAttendVm
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string OrganizationName { get; set; }   
        public string CourseName { get; set; }   
        public int OrganizationId { get; set; }
        public int  StudentId { get; set; }
        public Models.Course Courses { get; set; }
        public string ExamType { get; set; }
        public string ExamCode { get; set; }
        public string Topic { get; set; }
        public double FullMarks { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }

        public double ObtainedMarks { get; set; }

        public TimeSpan Duration { get; set; }
        public string Serial { get; set; }
        public List<Question> Question { get; set; }


        public List<SelectListItem> CourseSelectListItems { get; set; }
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> ExamTypeSelectListItems { get; set; }
        public List<SelectListItem> ParticipantSelectListItems { get; set; }
    }
}