using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Converters;
using PL.Models;

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
        var movie = await _context.Movies.FindAsync(id);

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
    public async Task<IActionResult> Edit (int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        var result = movie.Map();

        return View(result);
    }

    // POST: MoviesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit (int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieViewModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        // Update movie
        movie.Title = request.Title;
        movie.ReleaseDate = request.ReleaseDate;
        movie.Genre = request.Genre;
        movie.Price = request.Price;
        movie.Rating = request.Rating;

        // Save database
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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
