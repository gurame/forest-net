using FastEndpoints;

namespace EagleBooks.Books.Endpoints;

internal class List(IBookService bookService) : EndpointWithoutRequest<ListBooksReponse>
{
  private readonly IBookService _bookService = bookService;
  public override void Configure()
  {
    Get("/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    await SendAsync(new ListBooksReponse()
    {
      Books = await _bookService.ListBooksAsync()
    });
  }
}
