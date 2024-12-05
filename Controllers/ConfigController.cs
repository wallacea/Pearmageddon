using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Pearmageddon.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Admins")]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class ConfigController(IConfiguration config, IOptionsSnapshot<PearmageddonConfig> pearTypeOptions, RoleManager<IdentityRole> roleManager) : Controller
    {
        
        
        [Route("Index")]
        [HttpGet]
        [Authorize(Roles = "Students")]
        public IActionResult Index()
        {
            List<string> roleNames = roleManager.Roles.ToList().Select(role => role.Name).ToList();
               
            //ViewBag.SecretKey = config["SuperSecretKey"];
            //ViewBag.FavoritePear = config["PearmageddonConfig:FavoritePear"];

            //return View(config.GetSection("PearmageddonConfig").Get<PearmageddonConfig>());
            return View(roleNames);
        }
        [Route("AddRole")]
        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }
        [Route("AddRole")]
        [HttpPost]
        public IActionResult AddRole(string roleName)
        {
            roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
            return RedirectToAction("Index");
        }
    }
}