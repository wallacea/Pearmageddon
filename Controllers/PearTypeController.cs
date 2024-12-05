using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pearmageddon.ExtensionMethods;
using Pearmageddon.Models;
using Pearmageddon.Objects;
using Pearmageddon.Repositories;

namespace Pearmageddon.Controllers
{
    [Route("PearType")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PearTypeController : Controller
    {
        private readonly IPearTypeRepository _PearTypeRepo;
        private readonly IConfiguration _Config;
        public PearTypeController(IConfiguration config, IPearTypeRepository pearTypeRepo) 
        { 
            _Config = config;
            
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
        [Authorize]

        public IActionResult New()
        {
            return View();
        }
        [HttpPost("New")]
        [Authorize]

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
        [Authorize]

        public IActionResult Edit(int id)
        {
            PearType pearType = _PearTypeRepo.Get(id);
            return View(pearType?.ToModel());
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
