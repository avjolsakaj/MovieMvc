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

    public async Task<List<Movie>?> GetAll ()
    {
        var movies = await _context.Movies.ToListAsync();

        return movies;
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
}
