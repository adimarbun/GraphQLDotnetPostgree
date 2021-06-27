using GrapqlDotnetPostgree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrapqlDotnetPostgree.Data
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Platforms> Platforms { get; set; }
        public DbSet<Commands> Commands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=graphqldotnet;Username=postgres;Password=admin");
    }
}
