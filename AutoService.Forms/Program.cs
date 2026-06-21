using AutoService.Data.Context;
using AutoService.Forms.Forms;
using Microsoft.EntityFrameworkCore;

// Автоматическое создание / обновление БД при запуске
using var db = new AppDbContext();
db.Database.Migrate();

Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
Application.Run(new MainForm());