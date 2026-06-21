using AutoService.Data.Context;
using AutoService.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class OrderStatusForm : Form
{
    private readonly AppDbContext _db = new();

    public OrderStatusForm() => InitializeComponent();

    private void OrderStatusForm_Load(object s, EventArgs e) => LoadOrders();

    private void LoadOrders()
    {
        dataGridView1.DataSource = _db.Orders
            .Include(o => o.Car).ThenInclude(c => c.Client)
            .Where(o => o.Status != "Выдан")
            .OrderBy(o => o.OrderDate)
            .Select(o => new
            {
                o.Id,
                Автомобиль = o.Car.Brand + " " + o.Car.Model,
                Клиент = o.Car.Client.FullName,
                Дата = o.OrderDate.ToString("dd.MM.yyyy"),
                Работы = o.WorkDescription,
                o.MasterName,
                Итого = o.TotalCost,
                o.Status
            }).ToList();

        lblCount.Text = $"Незавершённых заказов: {dataGridView1.RowCount}";
    }

    private void btnAdvance_Click(object s, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null)
        {
            MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

        try
        {
            var order = _db.Orders.Find(id)!;

            if (!CostCalculator.CanAdvance(order.Status))
            {
                MessageBox.Show("Заказ уже выдан клиенту.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string prevStatus = order.Status;
            order.Status = CostCalculator.NextStatus(order.Status);
            _db.SaveChanges();

            MessageBox.Show($"Статус изменён: {prevStatus} → {order.Status}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrders();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e) { _db.Dispose(); base.OnFormClosed(e); }
}
