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
    public class CourseRepositories
    {
        OnlineExaminationSystem db = new OnlineExaminationSystem();
        public List<Organization> GetOrganization()
        {
            return db.Organizations.ToList();
        }

        public List<Tags> GetTag()
        {
            return db.Tagses.ToList();
        }

        public List<Tags> GetSubjectsByStudentId(string text)
        {
            var dataList = db.Tagses.Where(c => c.TagList.Contains(text)).ToList();
            return dataList;
        }

        public bool addCourse(Course course)
        {
            db.Courses.Add(course);


            return db.SaveChanges() > 0;
        }

        public ICollection<Organization> GetOrganizationsById(int id)
        {
            var organization = db.Organizations.Where(o => o.Id == id);
            return organization.ToList();
        }

        public ICollection<Tags> GetTagById(int tagsId)
        {
            var tags = db.Tagses.Where(t => t.Id == tagsId);
            return tags.ToList();
        }

        public bool UpdateCourseInfo(Course course)
        {

            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;


            return db.SaveChanges() > 0;

        }

        public List<Trainer> GetTrainer()
        {
            return db.Trainers.ToList();
        }

        public List<Trainer> GetTrainerByName(Trainer trainer)
        {
            var trainers = db.Trainers.Where(c => c.Name.Contains(trainer.Name)).ToList();

            return trainers;


        }

        public List<Course> GetLastAddedCourse()
        {
            int maxId = db.Courses.Max(c => c.Id);
            var course = db.Courses.Where(c => c.Id == maxId);

            return course.ToList();
        }
        public List<Course> GetCourseByName(Course course)
        {
            var dataList = db.Courses.Include("Tags").Include("Organizations").Include("Trainers").Where(c=>c.CourseName==course.CourseName || c.CourseCode==course.CourseCode || c.Duration==course.Duration || c.Credit==course.Credit || c.Outline==course.Outline).ToList();
           
            
            return dataList;
        }

        public List<Course> GetCoursesByOrganizationId(int id)
        {
            var courses = new List<Course>();
           
            foreach (var organizations in db.Organizations)
            {
                if (organizations.Id == id)
                {
                    foreach (var course in organizations.Courses)
                    {
                        courses.Add(course);
                    }
                }
            }
            return courses;
        }

        public bool AddExam(Exams exam)
        {
            db.Examses.Add(exam);

            return db.SaveChanges() > 0;
        }

        public List<Exams> GetLastAddedExam()
        {
            int maxId = db.Examses.Max(c => c.Id);
            var data = db.Examses.Where(c => c.Id == maxId);
            return data.ToList();
        }

        public List<Course> GetCourse()
        {
            return db.Courses.ToList();
        }
    }
}
