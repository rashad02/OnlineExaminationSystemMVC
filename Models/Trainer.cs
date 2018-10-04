using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
       
        [NotMapped]
        public byte Image { get; set; } 
    }
}
