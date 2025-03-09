using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class HelloGreetingContext : DbContext
    {
        public HelloGreetingContext(DbContextOptions<HelloGreetingContext> options) : base(options) { }

        public DbSet<UserEntity> Greetings { get; set; }
        public DbSet<UserDetailsEntity> Users { get; set; }  // ✅ New Users Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Ensure Email is Unique for UserDetailsEntity
            modelBuilder.Entity<UserDetailsEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
