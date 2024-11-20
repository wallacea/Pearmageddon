using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Pearmageddon.Controllers
{
    [Route("[controller]")]
    
    public class ConfigController(IConfiguration config, IOptionsSnapshot<PearmageddonConfig> pearTypeOptions) : Controller
    {
        
        
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SecretKey = config["SuperSecretKey"];
            //ViewBag.FavoritePear = config["PearmageddonConfig:FavoritePear"];

            //return View(config.GetSection("PearmageddonConfig").Get<PearmageddonConfig>());
            return View(pearTypeOptions.Value);
        }
    }
}