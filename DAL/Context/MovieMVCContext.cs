using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class MovieMVCContext : IdentityDbContext
{
    public MovieMVCContext ()
    {
    }

    public MovieMVCContext (DbContextOptions<MovieMVCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; } = null!;

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.Genre).HasMaxLength(20);

            entity.Property(e => e.Price).HasColumnType("money");

            entity.Property(e => e.Rating).HasColumnType("decimal(5, 2)");

            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        // Configure identity table by default
        base.OnModelCreating(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
}
