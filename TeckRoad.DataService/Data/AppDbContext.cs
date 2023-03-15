using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TeckRoad;Integrated Security=True;");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Content> Content { get; set; }
    }
}
