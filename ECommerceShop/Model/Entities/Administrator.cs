using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;
[Table("administrators")]
public class Administrator
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}