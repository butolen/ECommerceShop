using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("reviews")]
public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("reviewid")]
    public int ReviewId { get; set; }

    [Required]
    [Column("rating")]
    public int Rating { get; set; }

    [Column("productid")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [StringLength(50)]
    [Column("text",TypeName = "VARCHAR(200)")]
    public string Text { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column("username")]
    public string Username { get; set; }
    public User User { get; set; }
}