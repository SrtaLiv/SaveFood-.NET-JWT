using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Bd
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        //dbset es para representación de una tabla
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Image> Images { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; } = string.Empty;
        public List<Post> Posts { get; set; } = new();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }


}
