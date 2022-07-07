using Microsoft.EntityFrameworkCore;
using GeneralStoreAPI.Models;
public class GeneralStoreDbContext : DbContext
{
    public GeneralStoreDbContext(DbContextOptions<GeneralStoreDbContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
}