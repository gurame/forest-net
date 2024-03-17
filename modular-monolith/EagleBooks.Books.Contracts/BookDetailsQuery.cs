using Ardalis.Result;
using MediatR;

namespace EagleBooks.Books.Contracts;

public record BookDetailsQuery(Guid BookId) : IRequest<Result<BookDetailsResponse>>;
