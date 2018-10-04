using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace OnlineExaminationSystem_Mvc.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationManager organizationManager=new OrganizationManager();
        //
        // GET: /Organization/
        public ActionResult OrganizationEntry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrganizationEntry(Organization organization)
        {
            HttpPostedFileBase file = Request.Files["Image"];
            organization.Logo = ConvertToBytes(file); 
            bool isSaved = organizationManager.AddOrganization(organization);
            return View("OrganizationView",organization);
        }


        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }

        public ActionResult RetrieveImage(int id)
        {

            byte[] cover = organizationManager.GetImageFromDataBase(id);

            if (cover != null)
            {

                return File(cover, "image/jpg");

            }

            else
            {

                return null;

            }

        }
        public ActionResult OrganizationSearch()
        {
            return View();
        }

        public ActionResult OrganizationInformation()
        {
            var data = organizationManager.GetOrganization();
            return View("OrganizationInformation",data);
        }
        [HttpPost]
        public JsonResult OrganizationSearch(Organization organization)
        {
            var data = organizationManager.GetOrganizationBySearchCriteria(organization);
            return Json(data.Select(o => new { o.Name, o.Code, StudentData = o.Students.Count, TrainerData = o.Trainers.Count }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetOrganization()
        {
            var data = organizationManager.GetOrganization();
            return Json(data.Select(o => new { o.Name, o.Code, StudentData = o.Students.Count, TrainerData = o.Trainers.Count }), JsonRequestBehavior.AllowGet);
        }

	}
}