using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string TagList { get; set; }
        public virtual ICollection<Course> Courses { get; set; }    
    }
}
