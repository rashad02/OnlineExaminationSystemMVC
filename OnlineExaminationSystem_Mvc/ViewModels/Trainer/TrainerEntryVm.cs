using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Trainer
{
    public class TrainerEntryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Models.Course> Courses { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public int OrganizationId { get; set; }
        public int  CourseId { get; set; }  


        [NotMapped]
        public byte Image { get; set; }

        public List<SelectListItem> OrganizationSelectListItems { get; set; }
        public List<SelectListItem> CourseSelectListItems { get; set; } 
    }
}