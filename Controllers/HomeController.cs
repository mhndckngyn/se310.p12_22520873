using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using se310_th.Context;
using se310_th.Models;

namespace se310_th.Controllers;

public class HomeController : Controller
{
    private QlBanHangContext db = new QlBanHangContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var sanPhams = db.SanPhams.ToList();
        return View(sanPhams);
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