using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels.Batch;
using OnlineExaminationSystem_Mvc.ViewModels.Course;
using OnlineExaminationSystem_Mvc.ViewModels.Exam;
using OnlineExaminationSystem_Mvc.ViewModels.Trainer;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class BatchController : Controller
    {
        BatchManager batchManager=new BatchManager();
        //
        // GET: /Batch/
        public ActionResult Entry()
        {
            BatchEntryVm batchEntryVm=new BatchEntryVm();
            batchEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
            batchEntryVm.CourseSelectListItems = GetCourseListItem();
            return View(batchEntryVm);
        }
        [HttpPost]
        public ActionResult Entry(BatchEntryVm batchEntryVm)
        {

            var batch = Mapper.Map<Batch>(batchEntryVm);
            batch.StartDate = Convert.ToDateTime(batchEntryVm.StartDate);
            batch.EndDate = Convert.ToDateTime(batchEntryVm.EndDate.Date);
            bool isSave = batchManager.SaveBatch(batch);
            
            batchEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
            batchEntryVm.CourseSelectListItems = GetCourseListItem();
            return RedirectToAction("UpdateBatch");
        }

       
        public ActionResult UpdateBatch()
        {
            Batch batch = batchManager.GetLastAddedBatch();
            BatchEntryVm batchEntryVm = Mapper.Map<BatchEntryVm>(batch);
            batchEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
            batchEntryVm.CourseSelectListItems = GetCourseListItem();
            batchEntryVm.TrainerSelectListItems = GetTrainerListItem();
            batchEntryVm.StudentsSelectListItems = GetStudentsSelectListItem();
            return View(batchEntryVm);
        }
         [HttpPost]
        public ActionResult UpdateBatch(BatchEntryVm batchEntryVm)
        {
            var batch = Mapper.Map<Batch>(batchEntryVm);
            bool isUpdated = batchManager.UpdateBatch(batch);
            batchEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
            batchEntryVm.CourseSelectListItems = GetCourseListItem();
            batchEntryVm.TrainerSelectListItems = GetTrainerListItem();
             batchEntryVm.StudentsSelectListItems = GetStudentsSelectListItem();
            return View(batchEntryVm);

        }


        public List<SelectListItem> GetTrainerListItem()
        {
            var TrainerList = batchManager.GetTrainer();
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
            var courseList = batchManager.GetCourse();
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

        public List<SelectListItem> GetOrganizationsSelectListItem()
        {
            var organizations = batchManager.GetOrganization();
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
        public List<SelectListItem> GetStudentsSelectListItem()
        {
            var organizations = batchManager.GetStudents();
            List<SelectListItem> studentSelectListItems = new List<SelectListItem>();
            foreach (var organizatio in organizations)
            {
                var osli = new SelectListItem();
                osli.Text = organizatio.Name;
                osli.Value = organizatio.Id.ToString();
                studentSelectListItems.Add(osli);
            }
            return studentSelectListItems;
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

        public ActionResult TrainerUpdate(TrainerEntryVm trainerEntryVm)
        {

            HttpPostedFileBase file = Request.Files["Logo"];
            if (file == null)
            {
                ModelState.AddModelError("Image", "Upload a Image to Update!!");
            }
            else
            {
                trainerEntryVm.Image = ConvertToBytes(file);
            }
            trainerEntryVm.Organizations = batchManager.GetOrganizationsById(trainerEntryVm.OrganizationId);
            Course course = (batchManager.GetCoursesById(trainerEntryVm.CourseId));
            trainerEntryVm.Courses.Add(course);
            var trainer = Mapper.Map<Trainer>(trainerEntryVm);
            if (ModelState.IsValid)
            {
                bool isUpdated = batchManager.UpdateTrainer(trainer);
                if (isUpdated)
                {
                    //TrainerEntryVm trainerVm = new TrainerEntryVm();
                    //trainerVm.OrganizationSelectListItems = GetSelectListItem();
                    //trainerVm.CourseSelectListItems = GetCourseListItem();
                    //return PartialView("~\\Views\\Shared\\UpdateTrainer.cshtml", trainerVm);
                    var data = trainer.Name;

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }

            trainerEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
            trainerEntryVm.CourseSelectListItems = GetCourseListItem();
            return PartialView("~\\Views\\Shared\\UpdateTrainer.cshtml", trainerEntryVm);

        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }

        [HttpPost]
        public ActionResult TrainerAdded(BatchEntryVm batchEntryVm)
        {
            bool isSaved = false;
            var batch = Mapper.Map<Batch>(batchEntryVm);
            batch = batchManager.GetLastAddedBatch();
            foreach (var trainer in batchEntryVm.Trainers)
            {

                //var trainerAdd = batchManager.GetTrainerByName(trainer);
                //if (batchEntryVm.TrainerType)
                //{
                //    batch.LeadTrainer = trainerAdd[0].Id;
                //}
                //batch.Trainers = trainerAdd;
                //isSaved = batchManager.UpdateBatchInfo(batch);
                //if (!isSaved)
                //{

                //}
            }

            return View("UpdateBatch");


        }

     


        //public ActionResult CourseExamAdd()
        //{
        //    ExamEntryVm examEntryVm = new ExamEntryVm();
        //    examEntryVm.Batch = batchManager.GetLastAddedBatch();
        //    examEntryVm.OrganizationId = examEntryVm.Courses.Organizations[0].Id;
        //    examEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
        //    examEntryVm.CourseSelectListItems = GetCourseListItem();
        //    examEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();
        //    return PartialView("~\\Views\\Shared\\ExamAssign.cshtml", examEntryVm);
        //}

        [HttpPost]
        public ActionResult ExamAssign(BatchEntryVm batchEntryVm)
        {

            var batch = batchManager.GetLastAddedBatch();
            batch.ExamDate = batchEntryVm.ExamDate;
           
            bool isUpdated = batchManager.UpdateBatch(batch);
            if (isUpdated)
            {
                batch.Examses = batchManager.GetExamById(batchEntryVm.Id);
              
                return Json(new { batch.ExamDate, Exam = batch.Examses.Select(e => new { e.ExamType, e.Topic, e.ExamCode, e.Duration, e.FullMarks }) });
            }

            return null;
        }

        public ActionResult BatchExamAssign()
        {
            BatchEntryVm batchEntryVm=new BatchEntryVm();
            batchEntryVm = Mapper.Map<BatchEntryVm>(batchManager.GetLastAddedBatch());
            batchEntryVm.Examses = batchManager.GetExamsByCourseId(batchEntryVm.CourseId);
            batchEntryVm.ExamSelectListItems = new List<SelectListItem>();
            foreach (var exams in batchEntryVm.Examses)
            {
                var osli=new SelectListItem();
                osli.Text = exams.ExamCode;
                osli.Value = exams.Id.ToString();
                batchEntryVm.ExamSelectListItems.Add(osli);
            }
            return PartialView("~\\Views\\Shared\\ExamAssignBatch.cshtml", batchEntryVm);
        }
        //public List<SelectListItem> GetExamTypeListItem()
        //{

        //    List<SelectListItem> examTypeStItems = new List<SelectListItem>()
        //    {
        //        new SelectListItem(){
        //                      Text = "Class Test",
        //                      Value = "1"
        //        },
        //        new SelectListItem(){
        //                      Text = "Lab Test",
        //                      Value = "2"
        //        }
    
        //    };
        //    return examTypeStItems;
        //}

        //public ActionResult BatchExamAdd()
        //{
        //    ExamEntryVm examEntryVm = new ExamEntryVm();
        //    examEntryVm.Batch = batchManager.GetLastAddedBatch();
        //    examEntryVm.Courses = batchManager.GetCoursesById(examEntryVm.Batch.CourseId);
        //    examEntryVm.OrganizationId = examEntryVm.Batch.OrganizationId;
        //    examEntryVm.OrganizationSelectListItems = GetOrganizationsSelectListItem();
        //    examEntryVm.CourseSelectListItems = GetCourseListItem();
        //    examEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();
        //    return PartialView("~\\Views\\Shared\\ExamAssignBatch.cshtml", examEntryVm);
        //}]


        public JsonResult GetStudentById(int id)
        {
            var data = batchManager.GetStudentById(id);
            return Json(new {data.Id, data.Name, data.Profession},JsonRequestBehavior.AllowGet);
        }

        public ActionResult StudentAdded(BatchEntryVm batchEntryVm)
        {
            Batch batch = batchManager.GetBatchById(batchEntryVm.Id);
            batch.Students=new List<Student>();
            foreach (var student in batchEntryVm.Students)
            {
                batch.Students.Add(batchManager.GetStudentById(student.Id));
            }
           // Batch batch = Mapper.Map<Batch>(batchEntryVm);
            bool isUpdated = batchManager.UpdateBatch(batch);

            return View("UpdateBatch",batchEntryVm);
        }

    }
}