using AllUslugi.Services;
using Microsoft.AspNetCore.Mvc;
using AllUslugi.Models;

namespace AllUslugi.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IAppealRepository appealRepository;
        private static readonly string[] Titles = { "получение справки", "замена паспорта", "налоги" };
        private static readonly string[] Statuses = { "принято", "обрабатывается", "завершено", "отклонено" };

        public IActionResult Index()
        {
            return View(appealRepository.GetAll());
        }

        public ServiceController(IAppealRepository appealRepos)
        { appealRepository=appealRepos;
        }
       
        //poluchit
        [HttpGet("Service/AddService/{id?}")]
        public IActionResult AddService(int? id)
        {
            ViewBag.Titles = Titles;
            ViewBag.Statuses = Statuses;

            var appeal = id == null ? new Apeal() : appealRepository.GetById(id.Value);
            return View(appeal);
        }

        [HttpPost]
        public IActionResult AddService(Apeal appeal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Titles = Titles;
                ViewBag.Statuses = Statuses;
                return View(appeal);
            }

            if (appeal.Id == 0)
                appealRepository.Add(appeal);
            else
                appealRepository.Update(appeal);

            return RedirectToAction("Index");
        }
        
         [HttpPost]
         public IActionResult ChangeRating(int id)
         {
             appealRepository.ChangeRating(id);
             return RedirectToAction("Index");
         }

        
         [HttpPost]
         public IActionResult Delete(int id)
         {
             appealRepository.Delete(id);
             return RedirectToAction("Index");
         }
          
    }
}
