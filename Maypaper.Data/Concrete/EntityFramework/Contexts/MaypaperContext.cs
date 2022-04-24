using System;
using Maypaper.Data.Concrete.EntityFramework.Mappings;
using Maypaper.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Data.Concrete.EntityFramework.Contexts
{
    public class MaypaperContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=Maypaper;User Id=postgres;Password=ksnargup4a;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
