using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using OnlineExaminationSystem_Mvc.ViewModels;
using OnlineExaminationSystem_Mvc.ViewModels.Course;
using OnlineExaminationSystem_Mvc.ViewModels.Exam;
using OnlineExaminationSystem_Mvc.ViewModels.Student;
using OnlineExaminationSystem_Mvc.ViewModels.Trainer;

namespace OnlineExaminationSystem_Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(config =>
            {
                config.CreateMap<CourseEntryVm, Course>();
                config.CreateMap<Course, CourseEntryVm>();

                config.CreateMap<CourseUpdateVm, Course>();
                config.CreateMap<Course, CourseUpdateVm>();

                config.CreateMap<ExamEntryVm, Exams>();
                config.CreateMap<Exams, ExamEntryVm>();

                config.CreateMap<StudentEntryVm, Student>();
                config.CreateMap<Student, StudentEntryVm>();
                
                config.CreateMap<TrainerEntryVm, Trainer>();
                config.CreateMap<Trainer, TrainerEntryVm>();

                config.CreateMap<ExamAttendVm, Exams>();
                config.CreateMap<Exams, ExamAttendVm>();

                config.CreateMap<ResultVm, Result>();
                config.CreateMap<Result, ResultVm>();

            });
        }
    }
}
