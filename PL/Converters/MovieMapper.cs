using DAL.Entities;
using PL.Models;
using Riok.Mapperly.Abstractions;

namespace PL.Converters;

[Mapper]
public static partial class MovieMapper
{
    public static partial MovieViewModel Map (this Movie movie);
}
