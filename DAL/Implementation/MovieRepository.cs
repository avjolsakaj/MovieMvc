using DAL.Context;
using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation;

public class MovieRepository : IMovieRepository
{
    private readonly MovieMVCContext _context;

    public MovieRepository (MovieMVCContext context)
    {
        _context = context;
    }

    public async Task<Movie?> Get (int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        return movie;
    }

    public async Task<List<Movie>?> GetAll (string search, string genre)
    {
        var moviesQuery = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            // Filter movie by this search string
            moviesQuery = moviesQuery
                .Where(x => x.Title.Contains(search));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            // Filter movie by this genre string
            moviesQuery = moviesQuery
                .Where(x => x.Genre != null && x.Genre.Contains(genre));
        }

        return await moviesQuery
            .OrderBy(x => x.Title)
            .ToListAsync();

        //if (!string.IsNullOrEmpty(search))
        //{
        //    // Filter movie by this search string
        //    return await _context.Movies
        //        .Where(x => x.Title.Contains(search)
        //                    || (x.Genre != null && x.Genre.Contains(search)))
        //        .OrderBy(x => x.Title)
        //        .ToListAsync();
        //}

        //return await _context.Movies
        //    .OrderBy(x => x.Title)
        //    .ToListAsync();
    }

    public async Task<int> SaveChanges ()
    {
        return await _context.SaveChangesAsync();
    }

    public Movie Add (Movie movie)
    {
        var result = _context.Movies.Add(movie);

        return result.Entity;
    }

    public void Delete (Movie movie)
    {
        _context.Movies.Remove(movie);
    }

    public async Task<List<string>> GetListOfGenres ()
    {
        // Unique list of genres
        return await _context.Movies
            .Select(x => x.Genre ?? string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .Distinct()
            .ToListAsync();
    }
}
