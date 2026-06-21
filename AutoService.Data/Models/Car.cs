using System.ComponentModel.DataAnnotations;

namespace AutoService.Data.Models;

public class Car
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    [Required(ErrorMessage = "Введите марку")]
    [MaxLength(100)]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите модель")]
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2100, ErrorMessage = "Год от 1900 до 2100")]
    public int Year { get; set; }

    [MaxLength(20)]
    public string LicensePlate { get; set; } = string.Empty;

    [MaxLength(20)]
    public string VIN { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public string DisplayName => $"{Brand} {Model} ({LicensePlate})";
}
