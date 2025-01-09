using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        // GET: ContactController
        public ActionResult Index()
        {
            return View(_contactService.FindAll());
        }
        
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ContactModel model) { 
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            } else
            {
                return View(model);
            }
        }
        
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);

            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            return View(_contactService.FindById(id));
        }
        
        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Update(model);
            return RedirectToAction(nameof(System.Index));
        }
        
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }


    }
}
