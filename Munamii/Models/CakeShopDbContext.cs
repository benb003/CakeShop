using Microsoft.EntityFrameworkCore;

namespace Munamii.Models;

public class CakeShopDbContext: DbContext
{
    public CakeShopDbContext(DbContextOptions<CakeShopDbContext> options) : base(options)
    {
    }

    public DbSet<Cake> Cakes { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}