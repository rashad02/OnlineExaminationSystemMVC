using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Question
    {
        public int Id { get; set; }


        [AllowHtml]
        public string QuestionText { get; set; }
        public double Marks { get; set; }
        public int QuestionOrder { get; set; }
        public int ExamsId { get; set; }
        public Exams Exams { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
