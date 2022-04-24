using System;
using Maypaper.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maypaper.Data.Concrete.EntityFramework.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // PrimaryKey alanını tanımladık.
            builder.HasKey(q => q.Id);
            // Eklendikçe ID'yi 1 arttır.
            builder.Property(q => q.Id).ValueGeneratedOnAdd();
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.Content).IsRequired();
            builder.Property(q => q.CreatedByName).IsRequired();
            builder.Property(q => q.ModifiedByName).IsRequired();
            builder.Property(q => q.CreatedDate).IsRequired();
            builder.Property(q => q.ModifiedDate).IsRequired();
            builder.Property(q => q.IsActive).IsRequired();
            builder.Property(q => q.IsDeleted).IsRequired();
            builder.HasOne<Article>(q => q.Article).WithMany(a => a.Questions).HasForeignKey(q => q.ArticleId);

            builder.ToTable("Questions");
        }
    }
}
