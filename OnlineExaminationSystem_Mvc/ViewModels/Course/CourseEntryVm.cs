using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Course
{
    public class CourseEntryVm
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseCode { get; set; }
        public double Duration { get; set; }
        public double Credit { get; set; }
        public string Outline { get; set; }
        public int TagsId { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public int TrainerId { get; set; }
        public virtual ICollection<Models.Trainer> Trainers { get; set; }
        public bool TrainerType { get; set; }
        public virtual ICollection<Models.Student> Students { get; set; }
        public virtual ICollection<Exams> Examses { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }
        public List<SelectListItem> SelectCourseSelectListItemsListItems { get; set; }
        public List<SelectListItem> SelectTagListItems { get; set; }
        public List<SelectListItem> SelectTrainerListItem { get; set; }
        public List<SelectListItem> ExamTypeSelectListItems { get; set; }
    }
}