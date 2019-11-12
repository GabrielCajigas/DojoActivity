using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Belt.Models;

namespace Belt.Models
{
    public class ElContext : DbContext
    {
        public ElContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<TheFiesta> Fiesta { get; set; }
        public DbSet<FiestaAndPlanner> FiestaAndPlanner { get; set; }
    }
}