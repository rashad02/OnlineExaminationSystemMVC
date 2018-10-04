using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class HomeController : Controller
    {
        HomeManager homeManager=new HomeManager();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminCredentials adminCredentials)
        {
            bool isAuthentic = homeManager.CheckAdmin(adminCredentials);
            if (isAuthentic)
            {
                return RedirectToAction("Entry","Course");
            }
            return View();
        }
	}
}