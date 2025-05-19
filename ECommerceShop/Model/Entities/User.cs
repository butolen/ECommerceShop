using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;
//users fertig   
[Table("users")]
public class User
{
    [Key]
    [Column("username" ,TypeName = "VARCHAR(50)")]
    [Required]
    public string Username { get; set; }
    [Column("email" ,TypeName = "VARCHAR(50)")]
    [Required]
    public string Email { get; set; }
    [Column("password" ,TypeName = "VARCHAR(15)")]
    [Required]
    public string Password { get; set; }
    [Required]
    [Column("address" ,TypeName = "VARCHAR(200)")]
    public string Address { get; set; }
}