using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

// this class represent the rich domain, that has entities and business rules.
public class CarsFactory
{
    // here we have the car itens representation.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    [Required]
    [Column(TypeName = "NVARCHAR(50)")]
    public string CarModel { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "DECIMAL(18,2)")]
    public decimal CarPrice { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string Carcolor { get; set; } = string.Empty;
    [Column(TypeName = "BIT")]
    public bool IsSold { get; set; }
    
    
}