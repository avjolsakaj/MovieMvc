using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Diagnostics;

namespace PL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController (ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index ()
    {
        var movies = new List<MovieViewModel>
        {
            new MovieViewModel
            {
                Id = 1,
                Name = "Fast X"
            },
            new MovieViewModel
            {
                Id = 2,
                Name = "The shining"
            }
        };

        ViewData["Movies"] = movies;

        ViewBag.Movies = movies;

        return View();
    }

    public string Hello ()
    {
        return "Word Word Word Word Word ";
    }

    public IActionResult Privacy ()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error ()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}