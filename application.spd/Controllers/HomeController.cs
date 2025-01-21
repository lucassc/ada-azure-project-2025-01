using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using application.spd.Models;

namespace application.spd.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var keyVaultUri = Environment.GetEnvironmentVariable("SPD_KEY_VAULT_URI") ?? "Not Set";
        ViewData["KeyVaultUri"] = keyVaultUri;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
