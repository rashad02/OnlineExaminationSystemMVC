using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Internal;
using BLL;
using DatabaseContext;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels.Course;
using OnlineExaminationSystem_Mvc.ViewModels.Exam;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class CourseController : Controller
    {
        CourseManager manager = new CourseManager();
        
        //
        // GET: /Course/
        public ActionResult Entry()
        {

            CourseEntryVm courseEntryVm = new CourseEntryVm();


            courseEntryVm.SelectListItems = GetSelectListItem();
            courseEntryVm.SelectTagListItems = GetTextListItem();
            return View(courseEntryVm);

        }


        [HttpPost]
        public ActionResult Entry(CourseEntryVm courseVm)
        {



            // var tuple = new Tuple<Organization, Tags>(new Organization(), new Tags());

            //tuple.Item1.SelectListItems = GetSelectListItem();
            //tuple.Item2.SelectTagListItems = GetTextListItem();

            var course = Mapper.Map<Course>(courseVm);
            var organization = manager.GetOrganizationsById(courseVm.OrganizationId);
            var Tags = manager.GetTagById(courseVm.TagsId);
            course.Organizations = organization.ToList();
            course.Tags = Tags.ToList();
           
            bool isSaved = manager.addCourse(course);
            if (isSaved)
            {
                courseVm.SelectTrainerListItem = GetTrainerListItem();
                courseVm.SelectCourseSelectListItemsListItems = GetCourseListItem();
                courseVm.ExamTypeSelectListItems = GetExamTypeListItem();
                courseVm.SelectListItems = GetSelectListItem();
                courseVm.SelectTagListItems = GetTextListItem();
                courseVm.Id = course.Id;
                courseVm.Organizations = course.Organizations;
                courseVm.Tags = course.Tags;
                return View("AddCourse", courseVm);
            }
            return View();
        }
        public ActionResult AddCourse()
        {
            //  courseVm.SelectTrainerListItem = GetTrainerListItem();
            CourseEntryVm courseEntryVm = new CourseEntryVm();
            courseEntryVm.SelectCourseSelectListItemsListItems = GetCourseListItem();
            courseEntryVm.SelectListItems = GetSelectListItem();
            courseEntryVm.SelectTagListItems = GetTextListItem();
            courseEntryVm.SelectTrainerListItem = GetTrainerListItem();
            courseEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();
            return View(courseEntryVm);
        }
        [HttpPost]
        public ActionResult AddCourse(CourseEntryVm courseVm)
        {
            //  courseVm.SelectTrainerListItem = GetTrainerListItem();
            courseVm.SelectListItems = GetSelectListItem();
            courseVm.SelectCourseSelectListItemsListItems = GetCourseListItem();
            courseVm.SelectTagListItems = GetTextListItem();
            courseVm.SelectTrainerListItem = GetTrainerListItem();
            courseVm.ExamTypeSelectListItems = GetExamTypeListItem();
            var course = Mapper.Map<Course>(courseVm);
            var organization = manager.GetOrganizationsById(courseVm.OrganizationId);
            var Tags = manager.GetTagById(courseVm.TagsId);
            course.Organizations = organization.ToList();
            course.Tags = Tags.ToList();
            var courseVmM = Mapper.Map<CourseEntryVm>(course);
            courseVmM.SelectTrainerListItem = GetTrainerListItem();
            return View(courseVmM);
        }
        public List<SelectListItem> GetExamTypeListItem()
        {

            List<SelectListItem> examTypeStItems = new List<SelectListItem>()
            {
                new SelectListItem(){
                              Text = "Class Test",
                              Value = "1"
                },
                new SelectListItem(){
                              Text = "Lab Test",
                              Value = "2"
                }
    
            };
            return examTypeStItems;
        }

        public ActionResult TrainerAdded()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrainerAdded(CourseEntryVm courseEntryVm)
        {
            bool isSaved = false;
            var course = Mapper.Map<Course>(courseEntryVm);
            course = manager.GetLastAddedCourse()[0];
            foreach (var trainer in courseEntryVm.Trainers)
            {

                var trainerAdd = manager.GetTrainerByName(trainer);
                if (courseEntryVm.TrainerType)
                {
                    course.LeadTrainer = trainerAdd[0].Id;
                }
                course.Trainers = trainerAdd;
                isSaved = manager.UpdateCourseInfo(course);
                if (!isSaved)
                {
                    return View("AddCourse");
                }
            }


            return View();

        }

        public ActionResult SearchCourse()
        {
            CourseEntryVm courseEntryVm = new CourseEntryVm();


            courseEntryVm.SelectListItems = GetSelectListItem();
            courseEntryVm.SelectTagListItems = GetTextListItem();
            return View(courseEntryVm);
        }


        public ActionResult UpdatedCourseView(CourseEntryVm courseVm)
        {

            courseVm.SelectListItems = GetSelectListItem();
            courseVm.SelectTagListItems = GetTextListItem();

            return View(courseVm);
        }
        [HttpPost]
        public ActionResult UpdatedCourseView(CourseUpdateVm courseUpdateVm)
        {

            var course = Mapper.Map<Course>(courseUpdateVm);
            var organization = manager.GetOrganizationsById(courseUpdateVm.OrganizationId);
            var Tags = manager.GetTagById(courseUpdateVm.TagsId);
            course.Organizations = organization.ToList();
            course.Tags = Tags.ToList();
            bool isSave = manager.UpdateCourseInfo(course);
            var courseEntryVm = Mapper.Map<CourseEntryVm>(course);
            courseEntryVm.SelectTrainerListItem = GetTrainerListItem();
            courseEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();
            courseEntryVm.SelectCourseSelectListItemsListItems = GetCourseListItem();
            courseEntryVm.SelectListItems = GetSelectListItem();
            if (isSave)
            {    
                return View("AddCourse", courseEntryVm);
            }

            return View(courseEntryVm);

        }




        //public PartialViewResult AddCourse(Course course)
        //{
        //    bool isSaved=manager.addCourse(course);
        //    if (isSaved)
        //    {
        //        return PartialView("~\\VIews\\Shared\\AddCourse\\Add.cshtml");
        //    }
        //    return PartialView("~\\VIews\\Shared\\AddCourse\\Add.cshtml");
        //}


        public List<SelectListItem> GetTextListItem()
        {
            var TagList = manager.GetTag();
            List<SelectListItem> TagSTItems = new List<SelectListItem>();
            foreach (var Tags in TagList)
            {
                var osli = new SelectListItem();
                osli.Text = Tags.TagList;
                osli.Value = Tags.Id.ToString();
                TagSTItems.Add(osli);
            }
            return TagSTItems;
        }
        public List<SelectListItem> GetTrainerListItem()
        {
            var TrainerList = manager.GetTrainer();
            List<SelectListItem> TrainerSTItems = new List<SelectListItem>();
            foreach (var trainers in TrainerList)
            {
                var osli = new SelectListItem();
                osli.Text = trainers.Name;
                osli.Value = trainers.Id.ToString();
                TrainerSTItems.Add(osli);
            }
            return TrainerSTItems;
        }
        public List<SelectListItem> GetCourseListItem()
        {
            var courseList = manager.GetCourse();
            List<SelectListItem> CourseSTItems = new List<SelectListItem>();
            foreach (var courses in courseList)
            {
                var osli = new SelectListItem();
                osli.Text = courses.CourseName;
                osli.Value = courses.Id.ToString();
                CourseSTItems.Add(osli);
            }
            return CourseSTItems;
        }

        public List<SelectListItem> GetSelectListItem()
        {
            var organizations = manager.GetOrganization();
            List<SelectListItem> OrganizationSLItems = new List<SelectListItem>();
            foreach (var organizatio in organizations)
            {
                var osli = new SelectListItem();
                osli.Text = organizatio.Name;
                osli.Value = organizatio.Id.ToString();
                OrganizationSLItems.Add(osli);
            }
            return OrganizationSLItems;
        }




        public JsonResult SearchByCourseProperty(Course course)
        {
            var dataList = manager.GetCourseByName(course);        
            return Json(dataList.Select(c=> new {c.Id, c.CourseName,c.Duration, TrainerData = c.Trainers.Select(t=>new{t.Name}) }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult CourseExamAdd(ExamEntryVm examEntryVm)
        {
            var course=manager.GetLastAddedCourse();
            examEntryVm.CourseId = course[0].Id;
            examEntryVm.Duration = TimeSpan.FromHours(Convert.ToDouble(examEntryVm.Hour)) + TimeSpan.FromMinutes(Convert.ToDouble(examEntryVm.Minute));

            var exam = Mapper.Map<Exams>(examEntryVm);
            var data=new List<Exams>();
            bool isSaved = manager.AddExam(exam);
            if (isSaved)
            {
                data=manager.GetLastAddedExam();

            }
           return Json(data.Select(e=>new{e.ExamType,e.Topic,e.ExamCode,e.FullMarks,e.Duration}), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchByOrganizationId(int Id)
        {
            var courses = new List<Course>();
            var dataList = manager.GetOrganizationsById(Id);

            foreach (var organization in dataList)
            {
                foreach (var course in organization.Courses)
                {
                    courses.Add(course);
                }
            }

            return Json(courses.Select(c => new { c.Id, c.CourseName, c.Duration, TrainerData = c.Trainers.Select(t => new { t.Name }) }), JsonRequestBehavior.AllowGet);
        }
    }
}