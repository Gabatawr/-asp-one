using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;

namespace mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(b =>
            {
                b.Property(e => e.Codes).HasConversion(
                    set => set.Count < 1
                        ? string.Empty
                        : JsonSerializer.Serialize(set, null),
                    str => string.IsNullOrEmpty(str)
                        ? new HashSet<string>()
                        : JsonSerializer.Deserialize<HashSet<string>>(str, null)
                );
            });
        }
    }
}
