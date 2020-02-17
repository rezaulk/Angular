using angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angular.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
 
        public ActionResult GetAllUser()
        {
            string role = (string)Session["logged"];
            List<User> idLists = (List<User>)Session["user"];
            List<User> idLists1 = new List<User>(); ;

            if (role == "Manager")
            {
                idLists1  = idLists.FindAll(x => x.type == "Assistant Manager");
            }
            else
            {
                idLists1 = idLists;
            }
           
            return Json(idLists1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Login(User k)
        {   
            string role = "";
            if(k.username == "Admin" && k.password == "Admin")
            {
                role = "Admin";
                Session["logged"] = "Admin";
            }
            else
            {
                List<User> idLists = (List<User>)Session["user"];
                if (idLists != null)
                {
                    User result = idLists.Find(x => x.username == k.username && x.password == k.password);

                    if(result.type == "Manager")
                    {
                        Session["logged"] = result.type;
                        role = result.type;
                    }
                    else
                    {
                        role = result.type;
                    }
                }
            } 
            return Json(role, JsonRequestBehavior.AllowGet);
        }



       
        [HttpPost]
        public JsonResult Adduser(User user)
        {
            List<User> idLists = (List<User>)Session["user"];

            if(idLists == null )
            {
                 idLists = new List<User>();
            } 

            idLists.Add(user);
            Session["user"] = idLists;
            
            string res = string.Empty;
            try
            {
                
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        } 
       
    }
}