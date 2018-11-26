using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
        //[Remote("CheckCourseExistByCourseName", "Course", HttpMethod = "POST",ErrorMessage = "Course already registered!!")]
         
        public string CourseName { get; set; }
        [Required]
        [StringLength(30,MinimumLength = 3)]
       
        public string CourseCode { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        [Range(1,10)]
        public double Credit { get; set; }
        [DataType(DataType.Text)]
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