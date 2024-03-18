using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCat.Models
{
	public class Product
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductID { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 4)]
		public string Name { get; set; }
		public string ProductNumber { get; set; }
		public string Color { get; set; }
		public DateTime? MFD { get; set; }
		public decimal StandardCost { get; set; }
		public decimal ListPrice { get; set; }
		public int Size { get; set; }
		public decimal Weight { get; set; }
		public int ProductCategoryID { get; set; }
		public bool Available { get; set; }
		
		public ProductCategory? ProductCategory { get; set; }

	}
}
