using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels;
using OnlineExaminationSystem_Mvc.ViewModels.Exam;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class ExamController : Controller
    {
        ExamManager examManager = new ExamManager();

        // GET: Exam
        public ActionResult Entry()
        {
            ExamEntryVm examEntryVm = new ExamEntryVm();
            examEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            examEntryVm.CourseSelectListItems = GetCourseListItem();
            examEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();

            return View(examEntryVm);
        }

        [HttpPost]
        public ActionResult Entry(ExamEntryVm examEntryVm)
        {
            examEntryVm.Duration = TimeSpan.FromHours(Convert.ToDouble(examEntryVm.Hour))+TimeSpan.FromMinutes(Convert.ToDouble(examEntryVm.Minute));
            
            var exam = Mapper.Map<Exams>(examEntryVm);
            bool isSaved = examManager.AddExam(exam);
            if (isSaved)
            {
               return RedirectToAction("QuestionAnswerEntry");
            }
            return View();
        }

        public ActionResult QuestionAnswerEntry()
        {
            ExamEntryVm examEntryVm = new ExamEntryVm();
            examEntryVm.OrganizationSelectListItems = GetOrganizationListItem();
            examEntryVm.CourseSelectListItems = GetCourseListItem();
            examEntryVm.ExamTypeSelectListItems = GetExamTypeListItem();
            return View(examEntryVm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QuestionAnswerEntry(Question question)
        {

         
            bool isSaved = examManager.AddQuestion(question);
            if (isSaved)
            {

                return RedirectToAction("QuestionSummary", question);
            }


            return View();
        }


        public ActionResult QuestionSummary(Question question)
        {

            return View(question);
        }



        public ActionResult ExamAttend()
        {
            ExamAttendVm examAttendVm = new ExamAttendVm();
            examAttendVm.OrganizationSelectListItems = GetOrganizationListItem();
            examAttendVm.CourseSelectListItems = GetCourseListItem();
            examAttendVm.ExamTypeSelectListItems = GetExamTypeListItem();
            examAttendVm.ParticipantSelectListItems = GetParticipantsListItem();

            return View(examAttendVm);
        }

        [HttpPost]
        public ActionResult ExamAttend(ExamAttendVm examAttendVm)
        {

            var exams = Mapper.Map<Exams>(examAttendVm);
            var data = examManager.GetExamByCourseExam(exams);
            var courseName = examManager.GetCourseById(exams.CourseId);
            var examStartData = Mapper.Map<ExamAttendVm>(data);
            examStartData.Question = data.Questions;
            examStartData.CourseName = courseName.CourseName;
            examStartData.OrganizationName = examAttendVm.OrganizationName;
            examStartData.StudentId = examAttendVm.StudentId;
            return View("ExamStart", examStartData);
        }
     

        public ActionResult ExamResult()
        {
            ExamAttendVm examAttendVm = new ExamAttendVm();
            examAttendVm.OrganizationSelectListItems = GetOrganizationListItem();
            examAttendVm.CourseSelectListItems = GetCourseListItem();
            examAttendVm.ParticipantSelectListItems = GetParticipantsListItem();
            return View(examAttendVm);
        }

        [HttpPost]
        public ActionResult ExamResult(ExamAttendVm examAttendVm)
        {
            var result=new List<ResultVm>();
            var data = examManager.GetResult(examAttendVm.CourseId,examAttendVm.StudentId);
            foreach (Result results in data)
            {

                var resultVm = Mapper.Map<ResultVm>(results);
                var course=examManager.GetCourseById(examAttendVm.CourseId);
                foreach (var exams in course.Examses)
                {
                    if (exams.Id == resultVm.ExamsId)
                    {
                        resultVm.Code = exams.ExamCode;
                    }
                }
                resultVm.CourseName = course.CourseName;
                 resultVm.OrganizationName = examAttendVm.OrganizationName;
                result.Add(resultVm);
               
            }


            return View("Result", result);
        }
      



        public List<SelectListItem> GetCourseListItem()
        {
            var courseList = examManager.GetCourse();
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

        public List<SelectListItem> GetParticipantsListItem()
        {
            var participantsList = examManager.GetParticipants();
            List<SelectListItem> participantsStItems = new List<SelectListItem>();
            foreach (var students in participantsList)
            {
                var osli = new SelectListItem();
                osli.Text = students.Name;
                osli.Value = students.Id.ToString();
                participantsStItems.Add(osli);
            }
            return participantsStItems;
        }
        public List<SelectListItem> GetOrganizationListItem()
        {
            var organizationList = examManager.GetOrganization();
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
        public JsonResult GetCourseByOrganizationId(int id)
        {
            var courses = new List<Course>();
            var dataList = examManager.GetOrganizationById(id);

            foreach (var organization in dataList)
            {
                courses.AddRange(organization.Courses);
            }
            return Json(courses.Select(c=> new {c.Id,c.CourseName }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentExamByCourseId(int id)
        {
            var data = examManager.GetStudentExamById(id);

            return Json(data.Examses.Select(ce=>new{ce.Id,ce.ExamCode,StudentData=data.Students.Select(cs=>new{cs.Id,cs.Name})}),JsonRequestBehavior.AllowGet);
   }

       

     
        public JsonResult GetQuestion()
        {
            var data = examManager.GetQuestionWithOption();


            return Json(data.Select(q=> new{q.Id,q.QuestionOrder,q.Marks,q.QuestionText,QuestionData=q.QuestionAnswers.Select(qa=>new{qa.IsAnswer,qa.OptionText})}), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOptionByQuestionId(int id)
        {
            var data = examManager.GetOption(id);


            return Json(data.Select(q => new { q.OptionText,q.OptionOder,q.IsAnswer }), JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetExamCodeByCourseId(int id)
        {
            
            var dataList = examManager.GetExamCodeById(id);

            return Json(dataList.Select(c=> new {c.Id,c.ExamCode}), JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult EvaluateAnswers(List<Question> questions,int StudentId,int CourseId)
        {
            ResultVm resultVm = new ResultVm();
            var Marks = 0;
            foreach (var question in questions)
            {
                resultVm.ExamsId = question.ExamsId;
                foreach (var questionAnswer in question.QuestionAnswers)
                {     
                var data = examManager.GetQuestionbyOrder(question);
                 //var answer = examManager.GetQuestionAnswer(data);

                    foreach (var dataAnswers in data.QuestionAnswers)
                    {
                        if (questionAnswer.OptionText == dataAnswers.OptionText && dataAnswers.IsAnswer)
                        {

                            
                            Marks = Marks + Convert.ToInt32(data.Marks);
                           
                        }
                    }
                  
                }
            }
            
            resultVm.StudentId = StudentId;
            resultVm.CourseId = CourseId;
            var result = Mapper.Map<Result>(resultVm);
            result.Students.Add(examManager.GetStudentById(StudentId));
            result.Courses.Add(examManager.GetCourseById(CourseId));
            result.ObtainedMarks = Marks;
            bool isSaved = examManager.SaveResult(result);
            return Json(JsonRequestBehavior.AllowGet);

            
        }



    }
}