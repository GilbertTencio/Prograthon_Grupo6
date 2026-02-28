using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        // Clase;
        // public DbSet<Persona> Persona { get; set; }
        // public DbSet<Cliente> Cliente { get; set; }
        // public DbSet<Inventario> Inventario { get; set; }

    }
}
