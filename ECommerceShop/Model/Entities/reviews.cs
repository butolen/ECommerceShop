using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Entities;
//reviews fertig   
[Table("reviews")]
public class reviews
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int reviewId { get; set; }
    
    [Required]
    public int rating { get; set; }
    
    public int productId { get; set; }
    
    public Product Product { get; set; }

    
    [Required]
    [StringLength(50)]
    public string user { get; set; }
     
}