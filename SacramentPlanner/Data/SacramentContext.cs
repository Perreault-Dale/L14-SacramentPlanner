using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace SacramentPlanner.Data
{
    public class SacramentContext : DbContext
    {
        public SacramentContext(DbContextOptions<SacramentContext> options) : base(options)
        {
        }

        public DbSet<Hymn> Hymns { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Prayer> Prayers { get; set; }
        public DbSet<Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
            modelBuilder.Entity<Talk>().ToTable("Talk");
            modelBuilder.Entity<Prayer>().ToTable("Prayer");
            modelBuilder.Entity<Program>().ToTable("Program");
        }
    }
}
