using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProductCat.Models
{
	public class ProductCategory
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int ProductCategoryID { get; set; }

		[Required, NotNull]
		[StringLength(50, MinimumLength = 4)]
		public string Name { get; set; }

		public ICollection<Product> Products { get; set; } = [];
	}
}