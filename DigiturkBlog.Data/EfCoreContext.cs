using DigiturkBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiturkBlog.Data
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public EfCoreContext(
            DbContextOptions<EfCoreContext> options)
            : base(options) { }

        public EfCoreContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-FOMOG3D; Database = DigiturkBlogDB; Integrated Security = SSPI;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Tag>().HasKey(x => x.Id);
            modelBuilder.Entity<Article>().HasKey(x => x.Id);

            modelBuilder.Entity<ArticleTag>()
                .HasKey(x => new { x.TagId, x.ArticleId });

            modelBuilder.Entity<Article>()
               .HasOne(p => p.Author)
               .WithMany(a => a.Articles)
               .HasForeignKey(x => x.AuthorId);


            modelBuilder.Entity<Author>().HasData(new Author { About = "DummyAbout", Email = "xxx@vvv.com", FirstName = "Misaki", LastName = "Taro", Id = 2, IsActive = true });
            modelBuilder.Entity<Author>().HasData(new Author { About = "DummyAbout", Email = "xxx@vvv.com", FirstName = "Tsubasa", LastName = "Ozora", Id = 1, IsActive = true });
            modelBuilder.Entity<Author>().HasData(new Author { About = "DummyAbout", Email = "xxx@vvv.com", FirstName = "Jun", LastName = "Misugi", Id = 3, IsActive = true });

            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Fiction" });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 2, Name = "Technology" });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 3, Name = "Art" });

            modelBuilder.Entity<Article>().HasData(new Article { Id = 1, Title = "What is Art-Fiction", Content = "Lorem ipsum dolor sit amed.", AuthorId = 1, PublishedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true });
            modelBuilder.Entity<Article>().HasData(new Article { Id = 2, Title = "C# Movie", Content = "Lorem ipsum dolor sit amed.", AuthorId = 2, PublishedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true });
            modelBuilder.Entity<Article>().HasData(new Article { Id = 3, Title = "Terminator", Content = "Lorem ipsum dolor sit amed.", AuthorId = 3, PublishedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true });

            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 1, TagId = 1 });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 1, TagId = 3 });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 2, TagId = 2 });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 2, TagId = 3 });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 3, TagId = 3 });
            modelBuilder.Entity<ArticleTag>().HasData(new ArticleTag { ArticleId = 3, TagId = 2 });
        }

    }
}
