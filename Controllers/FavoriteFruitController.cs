using Microsoft.AspNetCore.Mvc;
using Pearmageddon.Models;

namespace Pearmageddon.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class FavoriteFruitController : Controller
    {
        [Route("Survey")]
        [HttpGet]
        public IActionResult Survey()
        {
            return View(GetFruitModels());
        }
        [Route("Survey")]
        [HttpPost]
        public IActionResult Survey(List<FruitModel> fruitModels)
        {
            if (!ModelState.IsValid)
            {
                return View(fruitModels);
            }
            return RedirectToAction("Index", "Home");
        }
        private IEnumerable<FruitModel> GetFruitModels()
        {
            return new List<FruitModel>
            {
                new AppleModel { ID = 1, Name = "Apple", Variety = "" },
                new FruitModel { ID = 2, Name = "Banana", Variety = "" },
                new FruitModel { ID = 3, Name = "Cherry", Variety = "" },
                new FruitModel { ID = 4, Name = "Date", Variety = "" }
            };
        }
    }
}