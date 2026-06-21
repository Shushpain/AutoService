using System.ComponentModel.DataAnnotations;

namespace AutoService.Data.Models;

public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите фамилию")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите имя")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Car> Cars { get; set; } = new List<Car>();

    public string FullName => $"{LastName} {FirstName}";
}
