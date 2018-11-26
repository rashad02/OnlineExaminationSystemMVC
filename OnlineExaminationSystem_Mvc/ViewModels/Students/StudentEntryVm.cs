using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineExaminationSystem_Mvc.ViewModels.Student
{
    public class StudentEntryVm
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string RegNo { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Models.Course> Courses { get; set; }
        public ICollection<Models.Batch> Batches { get; set; }
        [DataType(DataType.PhoneNumber)]
      
        [Required(ErrorMessage = "Contact Number Required!")]
        [RegularExpression(@"^\(?([0-9]{5})[-. ]?([0-9]{6})$", ErrorMessage = "Entered Contact Number format is not valid.")]
        public string ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
         [StringLength(50, MinimumLength = 3)]
        public string Address1 { get; set; }
          [StringLength(50, MinimumLength = 3)]
        public string Address2 { get; set; }
          [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }
         
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
          [StringLength(50, MinimumLength = 3)]
        public string Country { get; set; }
        [Required]
          [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }
        [Required]
          [StringLength(50, MinimumLength = 3)]
        public string HighestAcademic { get; set; }
       
      
        public byte[] Image { get; set; }
        public int  OrganizationId { get; set; }
        public int  CourseId { get; set; }  

        public ICollection<SelectListItem> OrganizationSelectListItems { get; set; }
        public ICollection<SelectListItem> CourseSelectListItems { get; set; }
        
    }
}