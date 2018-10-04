using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels.Student;
using OnlineExaminationSystem_Mvc.ViewModels.Trainer;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        TrainerManager trainerManager = new TrainerManager();

        // GET: Student
        public ActionResult TrainerEntry()
        {
            TrainerEntryVm trainerEntryVm = new TrainerEntryVm();
            trainerEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            trainerEntryVm.CourseSelectListItems = GetCourseListItem();

            return View(trainerEntryVm);
        }

        [HttpPost]
        public ActionResult TrainerEntry(TrainerEntryVm trainerEntryVm)
        {
            trainerEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            trainerEntryVm.CourseSelectListItems = GetCourseListItem();
            var trainer = Mapper.Map<Trainer>(trainerEntryVm);
            var organization = trainerManager.GetOrganizationsById(trainerEntryVm.OrganizationId);
            var course = trainerManager.GetCoursesById(trainerEntryVm.CourseId);
            trainer.Organizations = organization.ToList();
            trainer.Courses = course.ToList();

            bool isSaved = trainerManager.SaveStudent(trainer);
            if (isSaved)
            {
                return View(trainerEntryVm);
            }


            return View(trainerEntryVm);
        }


        public List<SelectListItem> GetOrganizationListItem()
        {
            var organizationList = trainerManager.GetOrganization();
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
            var courseList = trainerManager.GetCourses();
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
    }
}