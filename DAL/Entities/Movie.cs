namespace DAL.Entities;

public partial class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public decimal? Rating { get; set; }
}
