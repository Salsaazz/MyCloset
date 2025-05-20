using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Configurations
{
    public class ClothingConfiguration : IEntityTypeConfiguration<Clothing>
    {
        public void Configure(EntityTypeBuilder<Clothing> builder)
        {
            {
                builder.HasKey(c => c.Id);
                builder.HasIndex(c => c.Id)
                    .IsUnique();


                builder.Property(c => c.Name)
                    .HasMaxLength(128)
                    .IsRequired();

                builder.Property(c => c.Colors)
                    .IsRequired();

                builder.Property(c => c.Size)
                    .IsRequired();

                builder.Property(c => c.Season)
                    .IsRequired();

                builder.Property(c => c.Prize)
                    .IsRequired();

                builder.Property(c => c.Aesthetic)
                    .IsRequired();

                builder.Property(c => c.Type)
                    .IsRequired();

                builder.Navigation(c => c.Images)
                    .AutoInclude();
            }
        }
    }
}
