using Microsoft.EntityFrameworkCore;
using AutoService.Data.Models;

namespace AutoService.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=autoservice.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasIndex(c => c.VIN).IsUnique();

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Client)
            .WithMany(cl => cl.Cars)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Car)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Client>().HasData(
            new Client { Id = 1, LastName = "Иванов",  FirstName = "Алексей", Phone = "+79001234567", Email = "ivanov@mail.ru" },
            new Client { Id = 2, LastName = "Петров",  FirstName = "Дмитрий", Phone = "+79012345678", Email = "petrov@mail.ru" },
            new Client { Id = 3, LastName = "Сидоров", FirstName = "Игорь",   Phone = "+79023456789", Email = "sidorov@mail.ru" },
            new Client { Id = 4, LastName = "Козлова", FirstName = "Мария",   Phone = "+79034567890", Email = "kozlova@mail.ru" },
            new Client { Id = 5, LastName = "Новиков", FirstName = "Андрей",  Phone = "+79045678901", Email = "novikov@mail.ru" }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, ClientId = 1, Brand = "Toyota",  Model = "Camry",   Year = 2018, LicensePlate = "А001АА92", VIN = "JT2BF22K1W0069329" },
            new Car { Id = 2, ClientId = 2, Brand = "BMW",     Model = "320i",    Year = 2020, LicensePlate = "В002ВВ92", VIN = "WBA8E5G5XHNU12345" },
            new Car { Id = 3, ClientId = 3, Brand = "Lada",    Model = "Vesta",   Year = 2021, LicensePlate = "Е003ЕЕ92", VIN = "XTA21190051234567" },
            new Car { Id = 4, ClientId = 4, Brand = "Hyundai", Model = "Solaris", Year = 2019, LicensePlate = "К004КК92", VIN = "Z94CB41BAER123456" },
            new Car { Id = 5, ClientId = 5, Brand = "Kia",     Model = "Rio",     Year = 2022, LicensePlate = "М005ММ92", VIN = "KNAE251ABHA123456" }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CarId = 1, OrderDate = new DateTime(2025, 6, 1), WorkDescription = "ТО-60000",                  MasterName = "Коваль А.В.",  WorkCost = 3500m,  PartsCost = 2800m, TotalCost = 6300m,  Status = "Выдан"    },
            new Order { Id = 2, CarId = 2, OrderDate = new DateTime(2025, 6, 5), WorkDescription = "Замена тормозных колодок",  MasterName = "Мороз В.С.",  WorkCost = 1500m,  PartsCost = 3200m, TotalCost = 4700m,  Status = "Готов"    },
            new Order { Id = 3, CarId = 3, OrderDate = new DateTime(2025, 6, 8), WorkDescription = "Замена масла, фильтров",    MasterName = "Коваль А.В.", WorkCost = 800m,   PartsCost = 1200m, TotalCost = 2000m,  Status = "В работе" },
            new Order { Id = 4, CarId = 4, OrderDate = new DateTime(2025, 6,10), WorkDescription = "Диагностика двигателя",    MasterName = "Семёнов И.П.", WorkCost = 2000m,  PartsCost = 0m,    TotalCost = 2000m,  Status = "Принят"   },
            new Order { Id = 5, CarId = 5, OrderDate = new DateTime(2025, 6,12), WorkDescription = "Кузовной ремонт",           MasterName = "Мороз В.С.",  WorkCost = 15000m, PartsCost = 8000m, TotalCost = 23000m, Status = "Принят"   }
        );
    }
}
