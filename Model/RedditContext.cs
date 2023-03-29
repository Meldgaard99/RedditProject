using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RedditFullStack.Model;

namespace RedditFullStack.Model
{
public class RedditContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public string DbPath { get; }

    public RedditContext(DbContextOptions<RedditContext> options)
        : base(options)
    {
          DbPath = " bin/Reddit.db";
    }
//Grunden til DbPath er så lang, var jeg havde et "couldnt create taskcontext object". aka kunne ikke finde db path fordi den ikke var absolut og kun releativ 

      public RedditContext()
        {
          DbPath = " bin/Reddit.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");


        }
}
}
