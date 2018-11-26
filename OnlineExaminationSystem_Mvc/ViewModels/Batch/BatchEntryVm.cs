using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Batch
{
    public class BatchEntryVm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30 ,MinimumLength = 3)]
        public string BatchNo { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Organization Organizations { get; set; }
        public Models.Course Courses { get; set; }
        public ICollection<Exams> Examses { get; set; }
        public ICollection<Models.Student> Students { get; set; }

        public DateTime ExamDate { get; set; }
        public int  TrainerId { get; set; } 
        public ICollection<Models.Trainer> Trainers { get; set; }
        public bool TrainerType { get; set;}

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate { get; set; }


        public ICollection<SelectListItem> OrganizationSelectListItems { get; set; }
        public ICollection<SelectListItem> CourseSelectListItems { get; set; }  
        public ICollection<SelectListItem> TrainerSelectListItems { get; set; }  
        public ICollection<SelectListItem> ExamSelectListItems { get; set; }
        public ICollection<SelectListItem> StudentsSelectListItems { get; set; }  
    }
}