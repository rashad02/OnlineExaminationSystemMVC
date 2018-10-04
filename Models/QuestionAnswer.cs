using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class QuestionAnswer
    {
        public int Id { get; set; }
       public int OptionOder { get; set; }
        public string OptionText { get; set; }
        public bool IsAnswer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
