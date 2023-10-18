using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restauracja.Models;

namespace Restauracja.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Restauracja.Models.StolikiVM> StolikiVM { get; set; } = default!;
        public DbSet<Rezerwacja> Rezerwacje { get; set; } = default!;

    }
}