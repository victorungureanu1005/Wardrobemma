using Microsoft.EntityFrameworkCore;

namespace Wardrobemma.Data
{
    public class WardrobeContext :DbContext
    {
        

        public WardrobeContext(DbContextOptions<WardrobeContext> options) : base(options)
        {

        }

        //public DbSet<> x {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
