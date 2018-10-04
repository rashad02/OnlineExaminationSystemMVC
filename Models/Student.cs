using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Profession { get; set; }
        public string HighestAcademic { get; set; }
        public byte[] Image { get; set; }
       public virtual ICollection<Exams>   Examses  { get; set; }
       public virtual ICollection<Result>   Results  { get; set; }
    }
}
