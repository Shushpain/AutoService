using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    LicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    VIN = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkDescription = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    MasterName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    WorkCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    PartsCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "ivanov@mail.ru", "Алексей", "Иванов", "+79001234567" },
                    { 2, "petrov@mail.ru", "Дмитрий", "Петров", "+79012345678" },
                    { 3, "sidorov@mail.ru", "Игорь", "Сидоров", "+79023456789" },
                    { 4, "kozlova@mail.ru", "Мария", "Козлова", "+79034567890" },
                    { 5, "novikov@mail.ru", "Андрей", "Новиков", "+79045678901" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "ClientId", "LicensePlate", "Model", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 1, "А001АА92", "Camry", "JT2BF22K1W0069329", 2018 },
                    { 2, "BMW", 2, "В002ВВ92", "320i", "WBA8E5G5XHNU12345", 2020 },
                    { 3, "Lada", 3, "Е003ЕЕ92", "Vesta", "XTA21190051234567", 2021 },
                    { 4, "Hyundai", 4, "К004КК92", "Solaris", "Z94CB41BAER123456", 2019 },
                    { 5, "Kia", 5, "М005ММ92", "Rio", "KNAE251ABHA123456", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "MasterName", "OrderDate", "PartsCost", "Status", "TotalCost", "WorkCost", "WorkDescription" },
                values: new object[,]
                {
                    { 1, 1, "Коваль А.В.", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800m, "Выдан", 6300m, 3500m, "ТО-60000" },
                    { 2, 2, "Мороз В.С.", new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3200m, "Готов", 4700m, 1500m, "Замена тормозных колодок" },
                    { 3, 3, "Коваль А.В.", new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m, "В работе", 2000m, 800m, "Замена масла, фильтров" },
                    { 4, 4, "Семёнов И.П.", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Принят", 2000m, 2000m, "Диагностика двигателя" },
                    { 5, 5, "Мороз В.С.", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8000m, "Принят", 23000m, 15000m, "Кузовной ремонт" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientId",
                table: "Cars",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VIN",
                table: "Cars",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
