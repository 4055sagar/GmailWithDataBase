using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GmailWithDataBase.DataAccessLayer_Ef;
namespace GmailWithDataBase.Controllers
{
    public class EmployeeInfoController : Controller
    {
        DataAccessLayer_EF _dataAccessLayer_EF;
        public EmployeeInfoController(DataAccessLayer_EF dataAccessLayer_EF)
        {
            _dataAccessLayer_EF = dataAccessLayer_EF;
        }

        public IActionResult ShowAll()
        {
            var ar = _dataAccessLayer_EF.Employee.ToList();
            return View(ar);
        }

        public IActionResult DisplayAll() 
        {
            var ar = _dataAccessLayer_EF.Employee.ToList();
            return View(ar);
        }
       
        public IActionResult Details(int id) 
        {
            var ar1 = _dataAccessLayer_EF.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            return View(ar1);
        }
        public IActionResult Delete(int id)
        {
            var ar1 = _dataAccessLayer_EF.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            return View(ar1);
    }
        public IActionResult Edit(int id)
        {
            var ar1 = _dataAccessLayer_EF.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            return View(ar1);
        }
        public IActionResult SearchByName(string name) 
        {
            var forname= _dataAccessLayer_EF.Employee.Where(x => x.EmployeeName == name).FirstOrDefault();
            return View(forname);
        }

        public IActionResult SearchByBoth(string name,int id)
        {
            var forname = _dataAccessLayer_EF.Employee.Where(x => x.EmployeeName == name).FirstOrDefault();
            return View(forname);
        }
    }
}
