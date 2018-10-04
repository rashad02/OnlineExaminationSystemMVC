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
    public class CourseManager
    {
        CourseRepositories repositories = new CourseRepositories();
        public List<Organization> GetOrganization()
        {
            return repositories.GetOrganization();
        }

        public List<Tags> GetTag()
        {
            return repositories.GetTag();
        }

        public List<Tags> GetSubjectsByStudentId(string text)
        {
            return repositories.GetSubjectsByStudentId(text);
        }

        public ICollection<Organization> GetOrganizationsById(int id)
        {
            return repositories.GetOrganizationsById(id);
        }

        public bool addCourse(Course course)
        {
            return repositories.addCourse(course);
        }

        public ICollection<Tags> GetTagById(int tagsId)
        {
            return repositories.GetTagById(tagsId);
        }

        public bool UpdateCourseInfo(Course course)
        {
            return repositories.UpdateCourseInfo(course);
        }

        public List<Trainer> GetTrainer()
        {
            return repositories.GetTrainer();
        }

        public List<Trainer> GetTrainerByName(Trainer trainer)
        {
            return repositories.GetTrainerByName(trainer);
        }

        public List<Course> GetLastAddedCourse()
        {
            return repositories.GetLastAddedCourse();
        }

        public List<Course> GetCourseByName(Course course)
        {
            return repositories.GetCourseByName(course);
        }

        public List<Course> GetCoursesByOrganizationId(int id)
        {
            return repositories.GetCoursesByOrganizationId(id);
        }

        public bool AddExam(Exams exam)
        {
            return repositories.AddExam(exam);
        }

        public List<Exams> GetLastAddedExam()
        {
            return repositories.GetLastAddedExam();
        }

        public List<Course> GetCourse()
        {
                return repositories.GetCourse();
        }
    }
}
