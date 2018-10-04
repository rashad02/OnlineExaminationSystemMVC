using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels.Student;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class StudentController : Controller
    {

        StudentManager studentManager=new StudentManager();

        // GET: Student
        public ActionResult StudentEntry()
        {
            StudentEntryVm studentEntryVm=new StudentEntryVm();
            studentEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            studentEntryVm.CourseSelectListItems = GetCourseListItem();

            return View(studentEntryVm);
        }
    
    [HttpPost]
        public ActionResult StudentEntry(StudentEntryVm studentEntryVm)
        {
            HttpPostedFileBase file = Request.Files["Logo"];
            studentEntryVm.Image = ConvertToBytes(file); 
            studentEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            studentEntryVm.CourseSelectListItems = GetCourseListItem();
        var student = Mapper.Map<Student>(studentEntryVm);
        var organization = studentManager.GetOrganizationsById(studentEntryVm.OrganizationId);
        var course = studentManager.GetCoursesById(studentEntryVm.CourseId);
        student.Organizations = organization.ToList();
        student.Courses = course.ToList();

        bool isSaved = studentManager.SaveStudent(student);
        if (isSaved)
        {
            return View(studentEntryVm);
        }
           

            return View(studentEntryVm);
        }

    public byte[] ConvertToBytes(HttpPostedFileBase image)
    {

        byte[] imageBytes = null;

        BinaryReader reader = new BinaryReader(image.InputStream);

        imageBytes = reader.ReadBytes((int)image.ContentLength);

        return imageBytes;

    }
         public List<SelectListItem> GetOrganizationListItem()
        {
            var organizationList = studentManager.GetOrganization();
            List<SelectListItem> organizationStItems = new List<SelectListItem>();
            foreach (var organization in organizationList)
            {
                var osli = new SelectListItem();
                osli.Text = organization.Name;
                osli.Value = organization.Id.ToString();
                organizationStItems.Add(osli);
            }
            return organizationStItems;
        }
        public List<SelectListItem> GetCourseListItem()
        {
            var courseList = studentManager.GetCourses();
            List<SelectListItem> courseStItems = new List<SelectListItem>();
            foreach (var courses in courseList)
            {
                var osli = new SelectListItem();
                osli.Text = courses.CourseName;
                osli.Value = courses.Id.ToString();
                courseStItems.Add(osli);
            }
            return courseStItems;
        }

        public JsonResult GetLastRegNo()
        {
            var data = studentManager.GetStudent();
            var regNo = 0;
            if (data.Count != 0)
            {
                 regNo = studentManager.GetRegNo();
                
            }

            return Json(regNo, JsonRequestBehavior.AllowGet);
            
        }

    }
}