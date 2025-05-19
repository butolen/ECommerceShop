using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id", TypeName = "INT")]
    [Required]
    public int ProductId { get; set; }

    [Column("name", TypeName = "VARCHAR(50)")]
    [Required]
    public string Name { get; set; }

    [Column("image", TypeName = "VARCHAR(50)")]
    [Required]
    public string Image { get; set; }

    [Column("description", TypeName = "VARCHAR(700)")]
    [Required]
    public string Description { get; set; }

    [Column("price", TypeName = "DECIMAL(5,2)")]
    [Required]
    public decimal Price { get; set; }

    [Column("inStock", TypeName = "INT")]
    [Required]
    public int InStock { get; set; }

    [Column("category", TypeName = "VARCHAR(50)")]
    [Required]
    public string Category { get; set; }
}