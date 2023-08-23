using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Entities
{
    public class StoreContext :DbContext
    {
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<ConfermCart> ConfermCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAZENAHMED;Database=Store;Trusted_Connection=True;Encrypt=False");
        }
    }
}
