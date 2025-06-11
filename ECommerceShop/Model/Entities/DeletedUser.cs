using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("deleted_users")]
public class DeletedUser
{
    [Key]
    [Column("username", TypeName = "VARCHAR(50)")]
    [Required]
    public string Username { get; set; }

    [Column("email", TypeName = "VARCHAR(50)")]
    [Required]
    public string Email { get; set; }

  
    [Column("deleted_at")]
    public DateTime DeletedAt { get; set; } = DateTime.UtcNow;
}