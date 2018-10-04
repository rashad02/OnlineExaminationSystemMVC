using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
    public class TrainerRepositories
    {
        OnlineExaminationSystem db = new OnlineExaminationSystem();
        public List<Organization> GetOrganization()
        {
            var data = db.Organizations;
            return data.ToList();
        }
        public List<Course> GetCourses()
        {
            var data = db.Courses;
            return data.ToList();
        }

        public bool SaveStudent(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            return db.SaveChanges() > 0;
        }

        public List<Organization> GetOrganizationsById(int organizationId)
        {
            var data = db.Organizations.Where(o => o.Id == organizationId);
            return data.ToList();
        }

        public List<Course> GetCoursesById(int courseId)
        {
            var data = db.Courses.Where(c => c.Id == courseId);
            return data.ToList();
        }
    }
}
