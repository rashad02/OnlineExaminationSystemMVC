using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public Organization Organizations { get; set; }
        public Course Courses { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }  
    }
}
