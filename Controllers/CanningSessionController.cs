using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pearmageddon.ExtensionMethods;
using Pearmageddon.Objects;
using Pearmageddon.Repositories;

namespace Pearmageddon.Controllers
{
    [Route("CanningSession")]
    [Authorize]
    public class CanningSessionController(ICanningSessionRepository canningSessionRepo, IPearTypeRepository pearTypeRepo) : Controller
    {
        [Route("")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<CanningSession> canningSessions = canningSessionRepo.GetAll();
            return View(canningSessions);
        }
        
        [HttpGet("New")]
        
        public IActionResult New()
        {
            var pearTypes = pearTypeRepo.GetAll();
            List<SelectListItem> pearTypeItems = new List<SelectListItem>();
            pearTypes.ToList().ForEach(pearType => pearTypeItems.Add(new SelectListItem(pearType.Name, pearType.ID.ToString())));
            ViewBag.PearTypes = pearTypeItems;
            return View(new CanningSessionModel());
        }
        
        [HttpPost("New")]
        public IActionResult New(CanningSessionModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            canningSessionRepo.Save(model.ToDataObject());

            return RedirectToAction("Index");
        }
    }
}
