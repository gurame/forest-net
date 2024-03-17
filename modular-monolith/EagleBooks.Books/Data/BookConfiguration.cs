using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleBooks.Books.Data;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(p => p.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleBookData());
  }
  private static IEnumerable<Book> GetSampleBookData()
  {
    const string tolkien = "J.R.R Tolkien";
    yield return new Book(Guid.NewGuid(), "The Fellowship of the Ring", tolkien, 10.99m);
    yield return new Book(Guid.NewGuid(), "The Two Towers", tolkien, 11.99m);
    yield return new Book(Guid.NewGuid(), "The Return of the Ring", tolkien, 12.99m);
  }
}

