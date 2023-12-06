using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab5.Models;
using Microsoft.AspNetCore.Authorization;

namespace lab5.Controllers;

public class LabsController : Controller
{
    private readonly ILogger<LabsController> _logger;

    public LabsController(ILogger<LabsController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    public IActionResult Labs()
    {
        return View("LabsListMenu");
    }
    
    [Authorize]
    public IActionResult Lab1Page()
    {
        return View("Lab1");
    }
    
    [Authorize]
    public IActionResult Lab2Page()
    {
        return View("Lab2");
    }
    
    [Authorize]
    public IActionResult Lab3Page()
    {
        return View("Lab3");
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Lab1(string SA, string SB)
    {
        var result = labs_sources.Lab1.CalculateCyclicDistance(SA, SB);

        ViewBag.Result = result;
        return View();
    }
    
    public IActionResult Lab2(int K, int P)
    {
        var result = labs_sources.Lab2.CalculateEnts(K, P);

        ViewBag.Result = result;
        return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Lab3(int n, List<int[]> rectangles)
    {
        var result = labs_sources.Lab3.FindMaxArea(rectangles, n);

        ViewBag.Result = result;
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}