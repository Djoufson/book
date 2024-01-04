using Catalog.API.Models;
using Catalog.API.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Slug);
        builder
            .Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => new BookId(value)
            );

        builder
            .Property(a => a.AuthorId)
            .HasConversion(
                id => id.Value,
                value => new AuthorId(value)
            );

        builder.Navigation(b => b.Author).AutoInclude();
        builder.Navigation(b => b.Tags).AutoInclude();
    }
}
