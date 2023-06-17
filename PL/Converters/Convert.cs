using DAL.Entities;
using PL.Models;

namespace PL.Converters;

public static class Convert
{
    public static MovieViewModel Map (this Movie model)
    {
        return new MovieViewModel
        {
            Id = model.Id,
            Title = model.Title,
            ReleaseDate = model.ReleaseDate,
            Genre = model.Genre,
            Price = model.Price,
            Rating = model.Rating
        };
    }
}
