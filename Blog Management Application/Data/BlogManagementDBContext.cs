using Blog_Management_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Management_Application.Data
{
    public class BlogManagementDBContext: DbContext
    {
        public BlogManagementDBContext(DbContextOptions<BlogManagementDBContext> options) : base(options){}
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and constraints if needed
            modelBuilder.Entity<BlogPost>().HasIndex(b => b.Slug).IsUnique();
            modelBuilder.Entity<Comment>().HasOne(c => c.BlogPost)
                                          .WithMany(b =>b.Comments)
                                          .HasForeignKey(c => c.BlogPostId)
                                          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id =1,Name ="C#"},
                new Category { Id =2,Name ="ASP.NET Core"},
                new Category { Id =3,Name ="Entity Framework Core"},
                new Category { Id =4,Name ="Blazor"},
                new Category { Id =5,Name ="Azure" },
                new Category { Id =6,Name ="DevOps" },
                new Category { Id =7,Name ="Design Patterns" },
                new Category { Id =8,Name ="Microservices" },
                new Category { Id =9,Name ="Web Development" },
                new Category { Id =10,Name ="Mobile Development" }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Nilesh Nanavare", Email = "nilesh.nanavare@perfectiontech.com" },
                new Author { Id = 2, Name = "Pratiksha Nanavare", Email = "pratiksha.nanavare@perfectiontech.com" },
                new Author { Id = 3, Name = "Nikhil Nanavare", Email = "nikhil.nanavare@perfectiontech.com" },
                new Author { Id = 4, Name = "Vinayak Photography", Email = "vinayak@perfectiontech.com" },
                new Author { Id = 5, Name = "Nilesh Softtech", Email = "nilesh@perfectiontech.com" });
        }
    }
}
