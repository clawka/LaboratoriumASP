using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        // GET: ContactController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_contactService.FindAll());
        }
        
        
        [HttpGet]
        public IActionResult Add()
        {
            
            ContactModel model = new ContactModel();
            model.Organizations =  _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ContactModel model) { 
            model.Organizations =  _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
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
            ContactModel model = _contactService.FindById(id);
            model.Organizations =  _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
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
