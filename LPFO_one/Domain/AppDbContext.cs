using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LPFO_one.Domain
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);



        }
    }
}
