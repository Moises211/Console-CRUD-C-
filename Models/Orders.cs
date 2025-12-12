using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Orders
{
    [Key]
    public int OrderID { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [ForeignKey("Users")]
    public int? UserID { get; set; }
    public Users? User { get; set; }
    
}