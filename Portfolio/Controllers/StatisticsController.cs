using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            int messageCount=context.Message.Count();
            int messageCountIsWıthByTrue=context.Message.Where(x=>x.IsRead == true).Count();
            int messagaCountIsReadByFalse=context.Message.Where(x=>x.IsRead==false).Count();
            int skillCount=context.Skill.Count();
            var totalSkillValue=context.Skill.Sum(x=>x.Value);
            var averageSkillValue=context.Skill.Average(x=>x.Value);
            var getEmailFromProfile=context.Profile.Select(x=>x.Email).FirstOrDefault();
            var getLastCategoryId = context.Category.Max(x => x.CategoryId);
            var getLastCategoryName=context.Category.Where(x=>x.CategoryId==getLastCategoryId).Select(y=>y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsWıthByTrue = messageCountIsWıthByTrue;
            ViewBag.messagaCountIsReadByFalse = messagaCountIsReadByFalse;          
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.averageSkillValue = averageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName=getLastCategoryName;


            return View();
        }
    }
}