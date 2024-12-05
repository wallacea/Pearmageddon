using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;
using Pearmageddon.Models;

namespace Pearmageddon.Controllers;
[Route("")]
[Route("Home")]
[ApiExplorerSettings(IgnoreApi = true)]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    [Route("Index")]
    [HttpGet]
    [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
    [OutputCache(PolicyName = "ShortExpiration")]
    public IActionResult Index()
    {
        
        
        return View();
    }

    [HttpGet("Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("Error")]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
