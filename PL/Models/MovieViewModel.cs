using System.ComponentModel.DataAnnotations;

namespace PL.Models;

public class MovieViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Release Date is required")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [StringLength(20, MinimumLength = 1)]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Range(1, 10)]
    public decimal? Rating { get; set; }
}