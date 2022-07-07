using GmailWithDataBase.DataAccessLayer_Ef;
using GmailWithDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace GmailWithDataBase.Controllers
{
    public class UserAccountController : Controller
    {
        DataAccessLayer_EF _DataAccessLayer_EF;

        public UserAccountController(DataAccessLayer_EF DataAccessLayer_EF)
        {
            _DataAccessLayer_EF = DataAccessLayer_EF;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserRegistration userRegistration)
        {
            UserRegistrationDB obj = new UserRegistrationDB();
            obj.EmailId = userRegistration.EmailId;
            obj.Phone = userRegistration.Phone;
            obj.Password = userRegistration.Password;
            obj.UserName = userRegistration.UserName;

            _DataAccessLayer_EF.UserRegistration.Add(obj);
            _DataAccessLayer_EF.SaveChanges();
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserRegistration userRegistration)
        {
            var ar = _DataAccessLayer_EF.UserRegistration.Where(x => x.EmailId == userRegistration.EmailId && x.Password == userRegistration.Password).FirstOrDefault();
            if (ar != null)
            {
                HttpContext.Session.SetString("UName",ar.UserName);
                return RedirectToAction("DashBoard");
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult DashBoard() 
        {
            if (HttpContext.Session.GetString("UName") != null)
            {
                ViewBag.user = HttpContext.Session.GetString("UName");
            }
            else 
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ShowAll()
        {
            List<UserRegistration> list = new List<UserRegistration>();
            var ar = _DataAccessLayer_EF.UserRegistration.ToList();
            foreach (var i in ar)
            {
                list.Add(new UserRegistration { UserID= i.UserID, EmailId = i.EmailId,Phone= i.Phone,UserName = i.UserName});
            }
            return View(list.ToList());
        }

        public IActionResult Edit( int id)
        {
            var ar = _DataAccessLayer_EF.UserRegistration.Where(x => x.UserID == id).FirstOrDefault();
            UserRegistration userRegistration = new UserRegistration() { UserName= ar.UserName,Phone = ar.Phone,EmailId= ar.EmailId,};

          
            
            return View(userRegistration);
        }
        [HttpPost]
        public IActionResult Edit(int id,UserRegistration userRegistration)
        {
            var ar = _DataAccessLayer_EF.UserRegistration.Where(x => x.UserID == id).FirstOrDefault();
            if (ar != null) 
            {
                ar.UserName = userRegistration.UserName;
                ar.EmailId = userRegistration.EmailId;
                ar.Phone = userRegistration.Phone;
                _DataAccessLayer_EF.SaveChanges();
                return RedirectToAction("ShowAll");
            }

            return View(ar);
            

        }





    }
}
