using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("name", TypeName = "VARCHAR(700)")]
    [Required]
    public string Name { get; set; }

    [Column("image", TypeName = "VARCHAR(700)")]
    [Required]
    public string Image { get; set; }

    [Column("description", TypeName = "VARCHAR(700)")]
    public string Description { get; set; }

    [Column("price", TypeName = "DECIMAL(10,2)")]
    [Required]
    public decimal Price { get; set; }

    [Column("instock")]
    [Required]
    public int InStock { get; set; }

    [Column("category", TypeName = "VARCHAR(700)")]
    [Required]
    public string Category { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}