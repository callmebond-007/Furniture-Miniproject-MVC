using Furniture_Management_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Furniture_Management_MVC.DBContext
{
    public class FurnitureDbContext: IdentityDbContext<IdentityUser>
    {
        public FurnitureDbContext(DbContextOptions<FurnitureDbContext> options) : base(options)
        {

        }
        public DbSet<Category> ItemCategory { get; set; }

        public DbSet<Furniture> Furnitures { get; set; }

    }
}
