using Microsoft.EntityFrameworkCore;
using WholenessAPI.Entities;

namespace WholenessAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sucursal> Sucursales { get; set; }
    }
}
