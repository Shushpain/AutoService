# Автосервис — ПП.01, Вариант 14

Десктопное приложение на C# / WinForms / Entity Framework Core / SQLite
для автоматизации работы автосервиса.

## Состав решения

| Проект | Тип | Описание |
|---|---|---|
| `AutoService.Forms` | WinForms .exe | Все формы приложения, точка входа |
| `AutoService.Data` | Class Library | Entity-классы, DbContext, расчётные методы |
| `AutoService.Tests` | NUnit Test Project | Юнит-тесты для CostCalculator |

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

### Если Visual Studio просит создать миграцию вручную

Если БД не создаётся автоматически, откройте **Package Manager Console**
(View → Other Windows → Package Manager Console), выберите Default project =
`AutoService.Data`, и выполните:

```
Add-Migration InitialCreate -StartupProject AutoService.Forms
Update-Database -StartupProject AutoService.Forms
```

Либо через обычный терминал в папке решения:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --project AutoService.Data --startup-project AutoService.Forms
dotnet ef database update --project AutoService.Data --startup-project AutoService.Forms
```

## Запуск тестов

В Visual Studio: **Test → Test Explorer → Run All Tests**.
Все 15 тестов в `CostCalculatorTests.cs` должны пройти (зелёные).

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

## Реализованный функционал (по заданию варианта 14)

- ✅ CRUD для всех 3 таблиц (Клиент, Автомобиль, Заказ)
- ✅ Поиск в реальном времени (Timer 300 мс)
- ✅ Создание заказа: выбор автомобиля, виды работ, мастер
- ✅ Автоматический расчёт итоговой стоимости (работы + запчасти)
- ✅ Смена статуса заказа: Принят → В работе → Готов → Выдан
- ✅ История обслуживания автомобиля
- ✅ Отчёт по мастеру (количество заказов, выручка, средний чек, доля)
- ✅ Отчёт по выручке за период
- ✅ Подтверждение перед удалением (MessageBox)
- ✅ Валидация с подсветкой полей и сообщениями на русском
- ✅ Автосоздание БД при первом запуске
- ✅ 15 юнит-тестов NUnit для расчётных методов

## Дальнейшие шаги для сдачи практики

1. Сделайте скриншот Test Explorer с зелёными тестами.
2. Заполните ручной тест-план (таблица в .docx с заданием) — пройдите все 16 кейсов.
3. Соберите Release-версию:
   ```bash
   dotnet publish AutoService.Forms/AutoService.Forms.csproj -c Release -r win-x64 --self-contained true -o ./publish
   ```
4. Сделайте финальный коммит с тегом:
   ```bash
   git init
   git add .
   git commit -m "final: v1.0.0"
   git tag v1.0.0
   git remote add origin <ваш-репозиторий>
   git push -u origin main --tags
   ```
