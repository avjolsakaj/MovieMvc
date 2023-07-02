using DAL.Entities;
using PL.Converters;

namespace PL.Tests;

public class MovieMappersShould
{
    [Fact]
    public void Map_ToViewModel ()
    {
        var movie = new Movie { Id = 1 };
        var viewModel = MovieMapper.Map(movie);
        Assert.Equal(1, viewModel.Id);
    }
}