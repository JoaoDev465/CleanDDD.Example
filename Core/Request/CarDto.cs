using System.ComponentModel.DataAnnotations;

namespace Core.Request;
// CarDto is a Data transfer object, is used to valid input in Uses&Case
public class CarDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "row Car Model can't null")]
    public string CarModel { get; set; } = string.Empty;
    [Required(ErrorMessage = "row Car Price can't null")]
    public decimal CarPrice { get; set; }
    [Required(ErrorMessage = "row Car Color can't be null")]
    public string Carcolor { get; set; } = string.Empty;

    public bool sold { get; set; }
}