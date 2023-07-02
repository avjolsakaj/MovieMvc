using DAL.Entities;

namespace DAL.Interface;

public interface IMovieRepository
{
    Task<List<Movie>?> GetAll (string search, string genre);

    Task<Movie?> Get (int id);

    Task<int> SaveChanges ();

    Movie Add (Movie movie);

    void Delete (Movie movie);

    Task<List<string>> GetListOfGenres ();
}
