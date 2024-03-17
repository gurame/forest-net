namespace EagleBooks.Books;

internal interface IReadOnlyBookInterface
{
  Task<Book?> GetByIdAsync(Guid id);
  Task<List<Book>> ListAsync();
}
