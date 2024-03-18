using Microsoft.EntityFrameworkCore;
using ProductCat.Models;

namespace BlazorApp1.Data
{
	public class ProductDb : DbContext
	{
		public DbSet<ProductCategory> ProductCategory { get; set; }
		public DbSet<Product> Product { get; set; } 
		public ProductDb(DbContextOptions options)
		   : base(options)
		{
		}
	}
}
