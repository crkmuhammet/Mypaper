using System;
using Maypaper.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maypaper.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // PrimaryKey alanını tanımladık.
            builder.HasKey(c => c.Id);
            // Eklendikçe ID'yi 1 arttır.
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).IsRequired();

            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.ToTable("Categories");
        }
    }
}
