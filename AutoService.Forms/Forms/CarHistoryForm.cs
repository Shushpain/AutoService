using AutoService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class CarHistoryForm : Form
{
    private void CarHistoryForm_Load(object s, EventArgs e)
    {
        using var db = new AppDbContext();
        var cars = db.Cars.Include(c => c.Client).OrderBy(c => c.Brand).ToList();
        cmbCar.DataSource = cars;
        cmbCar.DisplayMember = "DisplayName";
        cmbCar.ValueMember = "Id";
    }

    public CarHistoryForm() => InitializeComponent();

    private void btnShow_Click(object s, EventArgs e)
    {
        if (cmbCar.SelectedValue == null) return;
        int carId = (int)cmbCar.SelectedValue;

        using var db = new AppDbContext();
        var history = db.Orders
            .Where(o => o.CarId == carId)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new
            {
                Дата = o.OrderDate.ToString("dd.MM.yyyy"),
                Работы = o.WorkDescription,
                o.MasterName,
                Стоимость = o.TotalCost,
                o.Status
            })
            .ToList();

        dataGridView1.DataSource = history;

        var totals = db.Orders.Where(o => o.CarId == carId).ToList();
        lblSummary.Text = $"Заказов: {totals.Count}  |  Общие расходы: {totals.Sum(o => o.TotalCost):N2} руб.";
    }
}
