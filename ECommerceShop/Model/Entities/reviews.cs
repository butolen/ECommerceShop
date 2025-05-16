using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;

[Table("reviews")]
public class reviews
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int reviewId { get; set; }
    
    [Required]
    public int rating { get; set; }
    
    [Required]
    [StringLength(50)]
    public string user { get; set; }
    //fertig
}