using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WareHouseManager.Razor.Models;

namespace BlazorApp.WareHouse.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Production>? Productions { get; set; }

        public DbSet<Store>? Stores { get; set; }

        //public DbSet<StoreHistory> storeHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraci�n de la tabla Production
            modelBuilder.Entity<Production>(entity =>
            {
                // Relaci�n con AspNetUsers - UserIdCreation
                entity.HasOne(p => p.UserCreation)
                    .WithMany()
                    .HasForeignKey(p => p.UserIdCreation)
                    .OnDelete(DeleteBehavior.NoAction); // ON DELETE NO ACTION

                // Relaci�n con AspNetUsers - UserIdModification
                entity.HasOne(p => p.UserModification)
                    .WithMany()
                    .HasForeignKey(p => p.UserIdModification)
                    .OnDelete(DeleteBehavior.NoAction); // ON DELETE NO ACTION

                // Relaci�n con Stores
                entity.HasOne(p => p.Store)
                    .WithMany()
                    .HasForeignKey(p => p.StoreId)
                    .OnDelete(DeleteBehavior.NoAction); // ON DELETE NO ACTION
            });
        }

    }

    

}
