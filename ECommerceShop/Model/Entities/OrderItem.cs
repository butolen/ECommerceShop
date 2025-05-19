using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("products_has_users")]
public class OrderItem
{
    [Column("product_id")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Column("user")]
    public string Username { get; set; }
    public User User { get; set; }

    [Column("quantity_ordered")]
    public int QuantityOrdered { get; set; }
}