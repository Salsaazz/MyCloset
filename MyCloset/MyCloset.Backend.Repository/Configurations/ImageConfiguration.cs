using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id)
                .IsUnique();

            builder.Property(i => i.FileName)
                .IsRequired();

            builder.Property(i => i.Data)
                .IsRequired();

            builder.HasOne(i => i.Clothing)
                .WithMany(c => c.Images)
                .HasForeignKey(i => i.ClothingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
