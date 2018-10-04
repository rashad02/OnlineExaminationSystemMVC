using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
    public class ExamRepositories
    {
        OnlineExaminationSystem db = new OnlineExaminationSystem();
        public List<Course> GetCourse()
        {
            return db.Courses.ToList();
        }
        public List<Organization> GetOrganization()
        {
            return db.Organizations.ToList();
        }

        public List<Organization> GetOrganizationById(int id)
        {
            var organization = db.Organizations.Where(o => o.Id == id);
            return organization.ToList();
           

        }

        public bool AddExam(Exams exam)
        {
            db.Examses.Add(exam);

            return db.SaveChanges() > 0;
        }

        public bool AddQuestion(Question question)
        {
            db.Questions.Add(question);
            return db.SaveChanges() > 0;

        }

        public List<Exams> GetQuestionByExamId(int id)
        {
            var data = db.Examses.Include("Question").Where(e => e.Id == id);
            return data.ToList();
        }

        public List<Question> GetQuestionWithOption()
        {
            var data = db.Questions.Include("QuestionAnswers");
            return data.ToList();
        }

        public List<QuestionAnswer> GetOption(int id)
        {
            var data = db.QuestionAnswers.Where(qa => qa.QuestionId == id);
            return data.ToList();
        }

        public Exams GetExamByCourseExam(Exams exams)
        {
            var data = db.Examses.FirstOrDefault(e => e.Id == exams.Id);
            
            return data;

        }

        public Course GetCourseById(int courseId)
        {
            var data = db.Courses.FirstOrDefault(c => c.Id == courseId);
            return data;
        }

        public List<Student> GetParticipants()
        {
            var data = db.Students;
            return data.ToList();
        }

        public Course GetStudentExamById(int id)
        {
            var data = db.Courses.FirstOrDefault(c => c.Id == id);
            return data;
        }

       
        public List<Exams> GetExamCodeById(int id)
        {
            var data = db.Examses.Where(e => e.CourseId == id);
            return data.ToList();
        }

        public Question GetQuestionByQuestionId(int id)
        {
            var data = db.Questions.FirstOrDefault(q => q.Id == id);
            return data;
        }


        public Exams GetExamById(int examsId)
        {
            var data = db.Examses.FirstOrDefault(e => e.Id == examsId);
            return data;
        }

        public bool UpdateExamResult(Exams exam)
        {
            db.Examses.Attach(exam);
            db.Entry(exam).State = EntityState.Modified;


            return db.SaveChanges() > 0;
        }

        public Question GetQuestionbyOrder(Question question)
        {
            var data =
                db.Questions.FirstOrDefault(
                    q => q.ExamsId == question.ExamsId && q.QuestionOrder == question.QuestionOrder);
            return data;
        }

        public QuestionAnswer GetQuestionAnswer(Question data)
        {
            var answer = db.QuestionAnswers.FirstOrDefault(qa => qa.Id == data.Id);
            return answer;
        }

        public bool SaveResult(Result result)
        {
            db.Results.Add(result);
            return  db.SaveChanges() > 0;
        }


        public string GetStudentNameById(int studentId)
        {
            string name = db.Students.Where(s => s.Id == studentId).Select(s => s.Name).ToString();
            return name;
        }

      

        public Student GetStudentById(int studentId)
        {
            var data = db.Students.FirstOrDefault(s => s.Id == studentId);
            return data;
        }

        public List<Result> GetResult(int courseId, int studentId)
        {
            var data = db.Results.Where(r => r.Students.Any(s=>s.Id==studentId));
            return data.ToList();
        }

        public Exams GetExamByStudentCourseId(int courseId, int studentId)
        {
            var data = db.Examses.FirstOrDefault(e => e.CourseId == courseId && e.Students.Any(s => s.Id == studentId));
            return data;
        }
    }
}
