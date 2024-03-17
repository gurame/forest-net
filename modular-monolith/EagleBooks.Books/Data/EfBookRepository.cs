using Microsoft.EntityFrameworkCore;

namespace EagleBooks.Books.Data;

internal class EfBookRepository : IBookRepository
{
  private readonly BooksDbContext _dbContext;
  public EfBookRepository(BooksDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<Book?> GetByIdAsync(Guid id)
  {
    return await _dbContext.Books.FindAsync(id);
  }

  public async Task<List<Book>> ListAsync()
  {
    return await _dbContext.Books.ToListAsync();
  }

  public Task AddAsync(Book book)
  {
    _dbContext.Add(book);
    return Task.CompletedTask;
  }

  public Task DeleteAsync(Book book)
  {
    _dbContext.Remove(book);
    return Task.CompletedTask;
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
