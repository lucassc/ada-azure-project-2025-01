using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using application.spd.Models;
using application.spd.Data;
using Microsoft.EntityFrameworkCore;

namespace application.spd.Controllers;

public class HomeController(ILogger<HomeController> logger, AppDbContext appDbContext) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly AppDbContext _appDbContext = appDbContext;

    public IActionResult Index()
    {
        // The mogration will never be here, but for the sake of the example, let's put it here to return the error message
        _appDbContext.Database.Migrate();

        var keyVaultUri = Environment.GetEnvironmentVariable("SPD_KEY_VAULT_URI") ?? "Not Set";

        var projeto = _appDbContext.ProjetoEntregas.First(projeto => projeto.Id == 1);
        ViewData["KeyVaultUri"] = keyVaultUri;
        ViewData["NomeDoAluno"] = projeto.NomeDoAluno;
        ViewData["UrlDoRepositorio"] = projeto.UrlDoRepositorio;
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
