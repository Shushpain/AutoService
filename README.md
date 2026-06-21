
## Как запустить

### Требования
- **Windows 10/11** (WinForms работает только на Windows)
- **Visual Studio 2022 Community** (бесплатно: https://visualstudio.microsoft.com)
  - При установке отметить компонент **".NET desktop development"**

### Шаги

1. Скачайте и распакуйте архив.
2. Откройте файл **`AutoService.sln`** двойным щелчком — откроется Visual Studio.
3. Дождитесь восстановления NuGet-пакетов (происходит автоматически при первом открытии,
   нужен интернет).
4. Нажмите **F5** или кнопку ▶ **"AutoService.Forms"** — приложение запустится.
5. При первом запуске автоматически создастся файл базы данных `autoservice.db`
   рядом с .exe файлом, с 5 клиентами, 5 автомобилями и 5 заказами.

## Структура

```
AutoService.sln
├── AutoService.Forms/
│   ├── Forms/
│   │   ├── MainForm.cs / .Designer.cs        — главное окно с меню
│   │   ├── ClientListForm.cs / .Designer.cs  — список клиентов + поиск
│   │   ├── ClientEditForm.cs / .Designer.cs  — добавление/редактирование клиента
│   │   ├── CarListForm.cs / .Designer.cs     — список автомобилей + поиск
│   │   ├── CarEditForm.cs / .Designer.cs     — добавление/редактирование авто
│   │   ├── OrderListForm.cs / .Designer.cs   — список заказов + поиск + фильтр статуса
│   │   ├── OrderEditForm.cs / .Designer.cs   — создание/редактирование заказа
│   │   ├── OrderStatusForm.cs / .Designer.cs — смена статуса заказа
│   │   ├── CarHistoryForm.cs / .Designer.cs  — история обслуживания авто
│   │   ├── MasterReportForm.cs / .Designer.cs   — отчёт по мастеру
│   │   └── RevenueReportForm.cs / .Designer.cs  — отчёт по выручке
│   └── Program.cs
├── AutoService.Data/
│   ├── Models/ (Client.cs, Car.cs, Order.cs)
│   ├── Context/AppDbContext.cs
│   └── Helpers/CostCalculator.cs
└── AutoService.Tests/
    └── CostCalculatorTests.cs  (15 тестов)
```

