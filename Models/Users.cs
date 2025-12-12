using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Users
{
    [Key]
    public int? UserID { get; set; }

    [Required]
    [StringLength(100)]
    public string? UserName { get; set; }

    [Required]    
    [StringLength(100)]
    public string? UserEmail { get; set; }    
}