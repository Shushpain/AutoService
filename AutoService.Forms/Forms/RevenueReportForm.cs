using AutoService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class RevenueReportForm : Form
{
    public RevenueReportForm() => InitializeComponent();

    private void RevenueReportForm_Load(object s, EventArgs e)
    {
        dtpFrom.Value = DateTime.Now.AddMonths(-1);
        dtpTo.Value = DateTime.Now;
    }

    private void btnApply_Click(object s, EventArgs e)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to = dtpTo.Value.Date.AddDays(1);

        using var db = new AppDbContext();

        var orders = db.Orders
            .Include(o => o.Car).ThenInclude(c => c.Client)
            .Where(o => o.OrderDate >= from && o.OrderDate < to)
            .OrderByDescending(o => o.OrderDate)
            .ToList(); // загружаем в память до агрегации

        dataGridView1.DataSource = orders.Select(o => new
        {
            o.Id,
            Дата = o.OrderDate.ToString("dd.MM.yyyy"),
            Автомобиль = $"{o.Car.Brand} {o.Car.Model}",
            Клиент = o.Car.Client.FullName,
            o.WorkDescription,
            o.MasterName,
            Работы = o.WorkCost,
            Запчасти = o.PartsCost,
            Итого = o.TotalCost,
            o.Status
        }).ToList();

        lblCount.Text = $"Заказов: {orders.Count}";
        lblWorkCost.Text = $"Работы: {orders.Sum(o => o.WorkCost):N2} руб.";
        lblParts.Text = $"Запчасти: {orders.Sum(o => o.PartsCost):N2} руб.";
        lblTotal.Text = $"Итого: {orders.Sum(o => o.TotalCost):N2} руб.";
    }
}
