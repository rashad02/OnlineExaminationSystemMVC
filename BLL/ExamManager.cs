using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
    public class ExamManager
    {
        ExamRepositories examRepositories = new ExamRepositories();
        public List<Course> GetCourse()
        {
            return examRepositories.GetCourse();
        }
        public List<Organization> GetOrganization()
        {
            return examRepositories.GetOrganization();
        }

        public List<Organization> GetOrganizationById(int id)
        {
            return examRepositories.GetOrganizationById(id);
        }

        public bool AddExam(Exams exam)
        {
            return examRepositories.AddExam(exam);
        }

        public bool AddQuestion(Question question)
        {
            return examRepositories.AddQuestion(question);  
        }

        public List<Exams> GetQuestionByExamId(int id)
        {
            return examRepositories.GetQuestionByExamId(id);
        }

        public List<Question> GetQuestionWithOption()
        {
            return examRepositories.GetQuestionWithOption();
        }

        public List<QuestionAnswer> GetOption(int id)
        {
            return examRepositories.GetOption(id);
        }

        public Exams GetExamByCourseExam(Exams exams)
        {
            return examRepositories.GetExamByCourseExam(exams);
        }

        public Course GetCourseById(int courseId)
        {
            return examRepositories.GetCourseById(courseId);
        }

        public List<Student> GetParticipants()
        {
            return examRepositories.GetParticipants();
        }

        public Course GetStudentExamById(int id)
        {
            return examRepositories.GetStudentExamById(id);
        }

      

        public List<Exams> GetExamCodeById(int id)
        {
            return examRepositories.GetExamCodeById(id);
        }

        public Question GetQuestionByQuestionId(int id)
        {
            return examRepositories.GetQuestionByQuestionId(id);
        }

        public Exams GetExamById(int examsId)
        {
            return examRepositories.GetExamById(examsId);
        }

        public bool UpdateExamResult(Exams exam)
        {
            return examRepositories.UpdateExamResult(exam);
        }

        public Question GetQuestionbyOrder(Question question)
        {
            return examRepositories.GetQuestionbyOrder(question);
        }

        public QuestionAnswer GetQuestionAnswer(Question data)
        {
            return examRepositories.GetQuestionAnswer(data);
        }

        public bool SaveResult(Result result)
        {
            return examRepositories.SaveResult(result);
        }


        public string GetStudentNameById(int studentId)
        {
            return examRepositories.GetStudentNameById(studentId);
        }

       
        public Student GetStudentById(int studentId)
        {
            return examRepositories.GetStudentById(studentId);
        }

        public List<Result> GetResult(int courseId, int studentId)
        {
            return examRepositories.GetResult(courseId, studentId);
        }

        public Exams GetExamByStudentCourseId(int courseId,int studentId)
        {
            return examRepositories.GetExamByStudentCourseId(courseId, studentId);
        }
    }
}
