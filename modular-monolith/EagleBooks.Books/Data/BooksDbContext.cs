using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EagleBooks.Books.Data;

internal class BooksDbContext : DbContext
{
  public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
  {
    
  }
  internal DbSet<Book> Books { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("Books");
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Properties<decimal>()
      .HavePrecision(18, 6);
  }
}
