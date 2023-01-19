using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Produs> Produse { get; set; }

        public DbSet<Brand> Branduri { get; set; }

        public DbSet<Material> Materiale { get; set; }

        public DbSet<Producator> Producatori { get; set; }
    }
}