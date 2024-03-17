namespace EagleBooks.Books;

internal interface IBookService
{
  Task<List<BookDto>> ListBooksAsync();
  Task<BookDto> getBookByIdAsync(Guid id);
  Task CreateBookAsync(BookDto newBook);
  Task DeleteBookAsync(Guid id);
  Task UpdateBookPriceAsync(Guid bookId, decimal newPrice);
}

