using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar() 
        {
            ViewBag.imageUrl = context.About.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSocialMedia()
        {
            return PartialView();
        }
        public ActionResult DownloadCV()
        {
            // Dosya yolunu kontrol edin
            var filePath = Server.MapPath("~/Content/images/AHMETBATUHANAVCIOGLURESUME.pdf");

            // Eğer dosya yoksa bir hata döndür
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "AHMETBATUHANAVCIOGLURESUME.pdf";
            var contentType = "image/jpeg/pdf";

            // Dosya indirilebilir olarak döndür
            return File(filePath, contentType, fileName);
        }
    }
}