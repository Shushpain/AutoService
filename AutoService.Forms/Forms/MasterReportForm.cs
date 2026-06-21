using AutoService.Data.Context;

namespace AutoService.Forms.Forms;

public partial class MasterReportForm : Form
{
    public MasterReportForm() => InitializeComponent();

    private void MasterReportForm_Load(object s, EventArgs e)
    {
        dtpFrom.Value = DateTime.Now.AddMonths(-1);
        dtpTo.Value = DateTime.Now;
    }

    private void btnApply_Click(object s, EventArgs e)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to = dtpTo.Value.Date.AddDays(1);

        using var db = new AppDbContext();

        // Сначала загружаем нужные заказы в память (ToList),
        // т.к. SQLite не умеет агрегировать decimal на стороне базы
        var orders = db.Orders
            .Where(o => o.OrderDate >= from && o.OrderDate < to)
            .ToList();

        var report = orders
            .GroupBy(o => o.MasterName)
            .Select(g => new
            {
                Мастер = g.Key,
                КолВоЗаказов = g.Count(),
                ВыручкаИтого = g.Sum(o => o.TotalCost),
                СредЧек = g.Average(o => o.TotalCost),
                ДоляМастера = g.Sum(o => o.TotalCost) * 0.30m
            })
            .OrderByDescending(x => x.ВыручкаИтого)
            .ToList();

        dataGridView1.DataSource = report;

        lblTotalOrders.Text = $"Всего заказов: {report.Sum(r => r.КолВоЗаказов)}";
        lblTotalRevenue.Text = $"Общая выручка: {report.Sum(r => r.ВыручкаИтого):N2} руб.";
    }
}