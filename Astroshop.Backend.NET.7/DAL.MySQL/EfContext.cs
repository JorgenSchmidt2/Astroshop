using Astroshop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAL.MySQL
{
    public class EfContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserCartElement> UserCarts { get; set; }

        public EfContext(DbContextOptions options) : base(options) 
        { 
            
        }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            string Connection = "server=localhost;user=root;database=astroshop;port=3306;password=superadmin_0002;";
            options.UseMySql(Connection, new MySqlServerVersion(new Version(8, 0, 33)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(entity => entity.ID);
            modelBuilder.Entity<Product>().HasKey(entity => entity.ID);
            modelBuilder.Entity<UserCartElement>().HasKey(entity => entity.ID);

            modelBuilder.Entity<User>().HasMany(p => p.UserOrders);
            modelBuilder.Entity<Product>().HasMany(p => p.ProductOrders);
        }
    }
}