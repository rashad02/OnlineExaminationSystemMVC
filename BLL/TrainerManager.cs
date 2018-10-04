using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
    public class TrainerManager
    {
        TrainerRepositories trainerRepositories = new TrainerRepositories();
        public List<Organization> GetOrganization()
        {
            return trainerRepositories.GetOrganization();
        }
        public List<Course> GetCourses()
        {
            return trainerRepositories.GetCourses();
        }

        public bool SaveStudent(Trainer trainer)
        {
            return trainerRepositories.SaveStudent(trainer);
        }

        public List<Organization> GetOrganizationsById(int organizationId)
        {
            return trainerRepositories.GetOrganizationsById(organizationId);
        }

        public List<Course> GetCoursesById(int courseId)
        {
            return trainerRepositories.GetCoursesById(courseId);
        }

    }
}
