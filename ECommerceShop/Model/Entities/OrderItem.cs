using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("order_item")]
public class OrderItem
{
    [Column("product_id")]
    public int ProductProductId { get; set; }
    public Product Product { get; set; }
    [Column("user")]
    public string UsersUsername { get; set; }
    public User User { get; set; }
    [Column("quantity_ordered")]
    public int QuantityOrdered { get; set; }
}