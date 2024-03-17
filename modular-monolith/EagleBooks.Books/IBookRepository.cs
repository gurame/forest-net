namespace EagleBooks.Books;

internal interface IBookRepository : IReadOnlyBookInterface
{
  Task AddAsync(Book book);
  Task DeleteAsync(Book book);
  Task SaveChangesAsync();
}
