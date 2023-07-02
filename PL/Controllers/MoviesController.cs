using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Converters;
using PL.Models;

namespace PL.Controllers;

[Authorize]
public class MoviesController : Controller
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController (IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    // GET: MoviesController
    [AllowAnonymous]
    public async Task<IActionResult> Index (string searchString, string genreSearch)
    {
        var movies = await _movieRepository.GetAll(searchString, genreSearch);

        if (movies == null)
        {
            return Problem("Could not get movies from database!");
        }

        var result = movies.ConvertAll(x => x.Map());

        ViewBag.GenreList = await _movieRepository.GetListOfGenres();

        return View(result);
    }

    // GET: MoviesController/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Details (int id)
    {
        var movie = await _movieRepository.Get(id);

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
        var model = new MovieViewModel
        {
            ReleaseDate = DateTime.Now,
            Price = 0,
            Rating = 0
        };

        return View(model);
    }

    // POST: MoviesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create ([Bind("Title, ReleaseDate, Genre, Price, Rating")] MovieViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var movieToCreate = new DAL.Entities.Movie
        {
            Title = request.Title,
            ReleaseDate = request.ReleaseDate,
            Genre = request.Genre,
            Price = request.Price,
            Rating = request.Rating
        };

        _ = _movieRepository.Add(movieToCreate);

        _ = await _movieRepository.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // GET: MoviesController/Edit/5
    public async Task<IActionResult> Edit (int id)
    {
        var movie = await _movieRepository.Get(id);

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

        var movie = await _movieRepository.Get(id);

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
        _ = await _movieRepository.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // GET: MoviesController/Delete/5
    public async Task<IActionResult> Delete (int id)
    {
        var movie = await _movieRepository.Get(id);

        if (movie == null)
        {
            return NotFound();
        }

        var result = movie.Map();

        return View(result);
    }

    // POST: MoviesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete (int id, [Bind("Id")] MovieViewModel request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        var movie = await _movieRepository.Get(id);

        if (movie == null)
        {
            return RedirectToAction(nameof(Index));
        }

        _movieRepository.Delete(movie);

        _ = await _movieRepository.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
