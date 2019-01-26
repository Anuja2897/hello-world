using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class StudRegisterController : Controller
    {
        // GET: StudRegister
        [HttpGet]
        public ActionResult Register(int? id=0)
        {
            collegeEntities1 db = new collegeEntities1();
            
            var result = db.course.ToList();
            List<SelectListItem> projectList = result.AsEnumerable()
                                      .Select(o => new SelectListItem
                                      {
                                          Text = o.cname,
                                          Value = Convert.ToString(o.cid)
                                      }).ToList();

            ViewBag.ProjectList = new SelectList(projectList, "Value", "Text");
           
            student1 st = new student1();
            return View(st);
        }

        [HttpPost]
        public ActionResult Register(student1 st)
        {
            using (collegeEntities1 ce = new collegeEntities1())
            {
                
                    ce.student1.Add(st);
                    ce.SaveChanges();
               
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Regsiteration Successful";
            return RedirectToAction("Index", "StudDetails");
        }

        public ActionResult Logout()
        {
            int uid= (int)Session["id"];
            Session.Abandon();
            return RedirectToAction("Login","Home");

        }
    }
}