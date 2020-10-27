using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config
{
    public class BoardGameConfiguration : IEntityTypeConfiguration<BoardGame>
    {
        public void Configure(EntityTypeBuilder<BoardGame> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(b => b.Description)
                .IsRequired(true);

            builder.Property(b => b.MinPlayers)
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(b => b.MaxPlayers)
                .IsRequired(false);

            builder.Property(b => b.MinAge)
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(b => b.MaxAge)
                .IsRequired(false)
                .HasDefaultValue(99);

            builder.Property(b => b.Price)
                .IsRequired(false)
                .HasColumnType("decimal(5,2)");

            builder.HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId);
        }
    }
}
