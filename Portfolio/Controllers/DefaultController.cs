﻿using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values=(from x in context.Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.v=values;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.title=context.About.Select(x=>x.Title).FirstOrDefault();
            ViewBag.detail=context.About.Select(x=>x.Detail).FirstOrDefault();
            ViewBag.image=context.About.Select(x=>x.ImageUrl).FirstOrDefault();

            ViewBag.address=context.Profile.Select(x=>x.Address).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            ViewBag.github=context.Profile.Select(x=>x.Github).FirstOrDefault();
       
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.image = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            var value = context.Education.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialSkill()
        {
            var values= context.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial(Testimonial t)
        {
            ViewBag.name=context.Testimonial.Select(x=>x.Name).FirstOrDefault();
            ViewBag.title=context.Testimonial.Select(x=>x.Title).FirstOrDefault();
            ViewBag.comment=context.Testimonial.Select(x=>x.Comment).FirstOrDefault();
            ViewBag.ImageUrl=context.Testimonial.Select(x=>x.ImageUrl).FirstOrDefault();
            
            return PartialView();
        }

        public PartialViewResult PartialExperience()
        {
            ViewBag.companyName=context.Experience.Select(x=>x.CompanyName).FirstOrDefault();
            ViewBag.workDate=context.Experience.Select(x=>x.WorkDate).FirstOrDefault();
            ViewBag.title=context.Experience.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=context.Experience.Select(x=>x.Description).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialServices()
        {
            ViewBag.title=context.Service.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=context.Service.Select(x=>x.Description).FirstOrDefault();
            ViewBag.icon=context.Service.Select(x=>x.Icon).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            var values=context.Portfolio.ToList();
            return PartialView(values);
        }
        
    }
}