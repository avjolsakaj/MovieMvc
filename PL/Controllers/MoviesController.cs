using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Converters;

namespace PL.Controllers;

public class MoviesController : Controller
{
    private readonly MovieMVCContext _context;

    public MoviesController (MovieMVCContext context)
    {
        _context = context;
    }

    // GET: MoviesController
    public async Task<IActionResult> Index ()
    {
        var movies = await _context.Movies.ToListAsync();

        if (movies == null)
        {
            return Problem("Could not get movies from database!");
        }

        var result = movies.ConvertAll(x => x.Map());

        return View(result);
    }

    // GET: MoviesController/Details/5
    public async Task<IActionResult> Details (int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        var result = movie.Map();

        return View(result);
    }

    // GET: MoviesController/Create
    public ActionResult Create ()
    {
        return View();
    }

    // POST: MoviesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create (IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MoviesController/Edit/5
    public ActionResult Edit (int id)
    {
        return View();
    }

    // POST: MoviesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit (int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MoviesController/Delete/5
    public ActionResult Delete (int id)
    {
        return View();
    }

    // POST: MoviesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete (int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
