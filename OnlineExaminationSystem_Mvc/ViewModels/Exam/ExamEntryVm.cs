using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Exam
{
    public class ExamEntryVm
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public Models.Course Courses { get; set; }
        public ICollection<Models.Batch> Batch { get; set; }

       
        [StringLength(20,MinimumLength = 3)]
        public string ExamType { get; set; }
        [Required]
        public int ExamTypeId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        
        public string ExamCode { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Topic { get; set; }
        [Required]
        [Range(1,100)]
        public double FullMarks { get; set; }
        [Required]
        
        public string Hour { get; set; }
         [Required]
        public string Minute { get; set; }
         [Required]
        [DataType(DataType.DateTime)]
        public TimeSpan Duration { get; set; }
        public DateTime ExamDate { get; set; }
        public string Serial { get; set; }
        public List<Question> Question { get; set; }


        public List<SelectListItem> CourseSelectListItems { get; set; }
        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> ExamTypeSelectListItems { get; set; }
    }
}