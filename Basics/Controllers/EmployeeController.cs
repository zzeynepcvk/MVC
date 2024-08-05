using System;
using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index1() {
            string message = $"hello world. {DateTime.Now.ToString()}" ;
            return View("Index1",message) ;
            // View(viewname,nesne)
        }

        public ViewResult Index2()
        {
            var names = new string[]
            {
                "zeynep",
                "müberra",
                "zehra"
            };
            // string[] array
            return View(names);
        }
// view nesne dönen action, 
//burada sayfamız belli bir görünüme göre döner
        public IActionResult Index3()
        {
            var list = new List<Employee>() 
            {
                new Employee(){Id=1,FirstName ="zeynep", LastName = "cevik",Age=21},
                new Employee(){Id=2,FirstName ="müberra", LastName = "cevik",Age=48},
                new Employee(){Id=3,FirstName ="zehra", LastName = "cevik",Age=20},
            };
            return View("Index3", list);
        }

    }
}