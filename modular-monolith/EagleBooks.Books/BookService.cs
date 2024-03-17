namespace EagleBooks.Books;

internal class BookService : IBookService
{
  private readonly IBookRepository _bookRepository;
  public BookService(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }
  public async Task CreateBookAsync(BookDto newBook)
  {
    var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);

    await _bookRepository.AddAsync(book);
    await _bookRepository.SaveChangesAsync();
  }

  public async Task DeleteBookAsync(Guid id)
  {
    var bookToDelete = await _bookRepository.GetByIdAsync(id);
    if (bookToDelete is not null)
    {
      await _bookRepository.DeleteAsync(bookToDelete);
      await _bookRepository.SaveChangesAsync();
    }
  }

  public async Task<BookDto> getBookByIdAsync(Guid id)
  {
    var book = await _bookRepository.GetByIdAsync(id);
    return new BookDto(book!.Id, book.Title, book.Author, book.Price);
  }

  public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice)
  {
    // validate price
    var book = await _bookRepository.GetByIdAsync(bookId);
    book!.UpdatePrice(newPrice);

    await _bookRepository.SaveChangesAsync();
  }
  public async Task<List<BookDto>> ListBooksAsync()
  {
    return (await _bookRepository.ListAsync())
      .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
      .ToList();
  }
}

