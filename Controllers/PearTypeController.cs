using Microsoft.AspNetCore.Mvc;
using Pearmageddon.ExtensionMethods;
using Pearmageddon.Models;
using Pearmageddon.Objects;
using Pearmageddon.Repositories;

namespace Pearmageddon.Controllers
{
    [Route("PearType")]
    public class PearTypeController : Controller
    {
        private readonly IPearTypeRepository _PearTypeRepo;
        public PearTypeController(IPearTypeRepository pearTypeRepo) 
        { 
            _PearTypeRepo = pearTypeRepo;
        }
        [HttpGet]
        [Route("Home")]
        public IActionResult Index()
        {
            IEnumerable<PearType> pearTypes = _PearTypeRepo.GetAll();
            return View(pearTypes);
        }
        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("New")]
        [ValidateAntiForgeryToken]
        public IActionResult New(PearTypeModel model)
        { 
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            _PearTypeRepo.Save(model.ToDataObject());
            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            PearType pearType = _PearTypeRepo.Get(id);
            return View(pearType);
        }
        [HttpPost("Edit/{ID}")]
        public IActionResult Edit(PearTypeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            _PearTypeRepo.Save(model.ToDataObject());
            return RedirectToAction("Index");
        }

    }
}
