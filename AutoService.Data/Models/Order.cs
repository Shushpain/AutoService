using System.ComponentModel.DataAnnotations;

namespace AutoService.Data.Models;

public class Order
{
    public int Id { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; } = null!;

    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Укажите виды работ")]
    [MaxLength(1000)]
    public string WorkDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите мастера")]
    [MaxLength(200)]
    public string MasterName { get; set; } = string.Empty;

    [Range(0, 9999999, ErrorMessage = "Стоимость не может быть отрицательной")]
    public decimal WorkCost { get; set; }

    [Range(0, 9999999, ErrorMessage = "Стоимость не может быть отрицательной")]
    public decimal PartsCost { get; set; }

    public decimal TotalCost { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Принят";
}
