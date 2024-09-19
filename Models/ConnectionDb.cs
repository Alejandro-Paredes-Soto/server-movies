using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace server_movies.Models
{
    public class ConnectionDb : DbContext
    {
        public ConnectionDb(DbContextOptions<ConnectionDb> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<ShoppingCar> ShoppingCar { get; set; }

        public DbSet<Sales> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Users>()
                .Property(u => u.Last_Name)
                .HasColumnName("last_name");

            modelBuilder.Entity<Users>()
                .Property(u => u.Date_Create)
                .HasColumnName("Date_Create"); 

            modelBuilder.Entity<ShoppingCar>().HasKey(u => u.IdMovie);
            modelBuilder.Entity<ShoppingCar>().HasKey(u => u.IdUser);

        }
        
    }
}
