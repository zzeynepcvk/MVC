using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi.Controllers
{
    public class CourseController : Controller 
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;

            return View (model);
        }
        public IActionResult Apply()
        {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate model)
        {
            if (Repository.Applications.Any(c=> c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("","Daha başvuru yaptınız.");
            }
            if (ModelState.IsValid)
            {
                Repository.Add(model);
            return View("FeedBack",model);
            }
            return View();
        }
    }
   
}