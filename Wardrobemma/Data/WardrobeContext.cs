using Microsoft.EntityFrameworkCore;
using Wardrobemma.Models;


namespace Wardrobemma.Data
{
    public class WardrobeContext :DbContext
    {
        

        public WardrobeContext(DbContextOptions<WardrobeContext> options) : base(options)
        {

        }

        public DbSet<Garment> Garments { get; set; }
        public DbSet<GarmentGenericType> GarmentGenericTypes { get; set; }
        public DbSet<GarmentType> GarmentTypes { get; set; }
        public DbSet<GarmentStyle> GarmentStyles { get; set; }
        public DbSet<GarmentColour> GarmentColours { get; set; }
        public DbSet<GarmentMaterial> GarmentMaterials { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Rename Tables
            modelBuilder.Entity<Garment>().ToTable("Garment");
            modelBuilder.Entity<GarmentGenericType>().ToTable("GarmentGenericType");
            modelBuilder.Entity<GarmentType>().ToTable("GarmentType");
            modelBuilder.Entity<GarmentStyle>().ToTable("GarmentStyle");
            modelBuilder.Entity<GarmentColour>().ToTable("GarmentColour");
            modelBuilder.Entity<GarmentMaterial>().ToTable("GarmentMaterial");

            //ensure dependent foreign key does not get deleted - one to many scenario
            //
            //



        }
    }
}
