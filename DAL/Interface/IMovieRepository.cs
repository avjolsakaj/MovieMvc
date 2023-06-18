using DAL.Entities;

namespace DAL.Interface;

public interface IMovieRepository
{
    Task<List<Movie>?> GetAll ();

    Task<Movie?> Get (int id);

    Task<int> SaveChanges ();

    Movie Add (Movie movie);

    void Delete (Movie movie);
}
