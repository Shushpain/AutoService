using AutoService.Data.Context;
using AutoService.Data.Helpers;
using AutoService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class OrderEditForm : Form
{
    private readonly int _id;

    public OrderEditForm(int id)
    {
        InitializeComponent();
        _id = id;
        Text = id == 0 ? "Новый заказ" : "Редактирование заказа";
    }

    private void OrderEditForm_Load(object s, EventArgs e)
    {
        using var db = new AppDbContext();

        var cars = db.Cars.Include(c => c.Client).OrderBy(c => c.Brand).ToList();
        cmbCar.DataSource = cars;
        cmbCar.DisplayMember = "DisplayName";
        cmbCar.ValueMember = "Id";

        cmbMaster.Items.AddRange(new object[] { "Коваль А.В.", "Мороз В.С.", "Семёнов И.П.", "Литвин Е.Д." });
        cmbStatus.Items.AddRange(new object[] { "Принят", "В работе", "Готов", "Выдан" });

        if (_id == 0)
        {
            dtpDate.Value = DateTime.Now;
            cmbStatus.SelectedItem = "Принят";
            RecalcTotal(this, EventArgs.Empty);
            return;
        }

        var order = db.Orders.Find(_id);
        if (order == null) return;
        cmbCar.SelectedValue = order.CarId;
        dtpDate.Value = order.OrderDate;
        txtWorkDesc.Text = order.WorkDescription;
        cmbMaster.Text = order.MasterName;
        nudWorkCost.Value = order.WorkCost;
        nudPartsCost.Value = order.PartsCost;
        cmbStatus.SelectedItem = order.Status;
        RecalcTotal(this, EventArgs.Empty);
    }

    private void RecalcTotal(object? s, EventArgs e)
    {
        var total = CostCalculator.CalcTotal(nudWorkCost.Value, nudPartsCost.Value);
        lblTotal.Text = $"Итого: {total:N2} руб.";
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        txtWorkDesc.BackColor = SystemColors.Window;
        bool hasErrors = false;

        if (string.IsNullOrWhiteSpace(txtWorkDesc.Text)) { txtWorkDesc.BackColor = Color.LightPink; hasErrors = true; }
        if (cmbCar.SelectedValue == null) { MessageBox.Show("Выберите автомобиль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); hasErrors = true; }
        if (string.IsNullOrWhiteSpace(cmbMaster.Text)) { MessageBox.Show("Выберите мастера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); hasErrors = true; }
        if (cmbStatus.SelectedItem == null) { MessageBox.Show("Выберите статус", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); hasErrors = true; }
        if (hasErrors) return;

        try
        {
            using var db = new AppDbContext();
            Order order;
            if (_id == 0) { order = new Order(); db.Orders.Add(order); }
            else          { order = db.Orders.Find(_id)!; }

            order.CarId = (int)cmbCar.SelectedValue!;
            order.OrderDate = dtpDate.Value;
            order.WorkDescription = txtWorkDesc.Text.Trim();
            order.MasterName = cmbMaster.Text;
            order.WorkCost = nudWorkCost.Value;
            order.PartsCost = nudPartsCost.Value;
            order.TotalCost = CostCalculator.CalcTotal(order.WorkCost, order.PartsCost);
            order.Status = cmbStatus.Text;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object s, EventArgs e) => DialogResult = DialogResult.Cancel;
}
