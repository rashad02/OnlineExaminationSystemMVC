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
   public class StudentManager
    {
       StudentRepositories studentRepositories = new StudentRepositories();
       public List<Organization> GetOrganization()
       {
           return studentRepositories.GetOrganization();
       }
       public List<Course> GetCourses()
       {
           return studentRepositories.GetCourses();
       }

       public bool SaveStudent(Student student)
       {
           return studentRepositories.SaveStudent(student);
       }

       public List<Organization> GetOrganizationsById(int organizationId)
       {
           return studentRepositories.GetOrganizationsById(organizationId);
       }

       public List<Course> GetCoursesById(int courseId)
       {
           return studentRepositories.GetCoursesById(courseId);
       }

       public int GetRegNo()
       {
           return studentRepositories.GetRegNo();
       }

       public List<Student> GetStudent()
       {
           return studentRepositories.GetStudent();
       }
    }
}
