using AutoService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class OrderListForm : Form
{
    private readonly AppDbContext _db = new();
    private System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };

    public OrderListForm()
    {
        InitializeComponent();
        _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); LoadOrders(txtSearch.Text); };
    }

    private void OrderListForm_Load(object s, EventArgs e) => LoadOrders();

    private void LoadOrders(string filter = "")
    {
        var query = _db.Orders.Include(o => o.Car).ThenInclude(c => c.Client).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(o =>
                o.Car.Brand.Contains(filter) ||
                o.Car.Model.Contains(filter) ||
                o.MasterName.Contains(filter) ||
                o.WorkDescription.Contains(filter) ||
                o.Status.Contains(filter));

        if (cmbStatusFilter.SelectedIndex > 0)
            query = query.Where(o => o.Status == cmbStatusFilter.Text);

        dataGridView1.DataSource = query.OrderByDescending(o => o.OrderDate)
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

        lblCount.Text = $"Заказов: {dataGridView1.RowCount}";
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        bool has = dataGridView1.CurrentRow != null;
        btnEdit.Enabled = has; btnDelete.Enabled = has;
    }

    private int GetSelectedId()
    {
        if (dataGridView1.CurrentRow == null) throw new InvalidOperationException("Выберите заказ");
        return (int)dataGridView1.CurrentRow.Cells["Id"].Value;
    }

    private void txtSearch_TextChanged(object s, EventArgs e) { _searchTimer.Stop(); _searchTimer.Start(); }
    private void cmbStatusFilter_SelectedIndexChanged(object s, EventArgs e) => LoadOrders(txtSearch.Text);
    private void dataGridView1_SelectionChanged(object s, EventArgs e) => UpdateButtons();

    private void btnAdd_Click(object s, EventArgs e) { if (new OrderEditForm(0).ShowDialog() == DialogResult.OK) LoadOrders(txtSearch.Text); }
    private void btnEdit_Click(object s, EventArgs e)
    {
        try { if (new OrderEditForm(GetSelectedId()).ShowDialog() == DialogResult.OK) LoadOrders(txtSearch.Text); }
        catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnDelete_Click(object s, EventArgs e)
    {
        try
        {
            int id = GetSelectedId();
            var order = _db.Orders.Find(id);
            if (order == null) return;
            if (MessageBox.Show($"Удалить заказ №{order.Id}?\nЭто действие нельзя отменить.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _db.Orders.Remove(order);
            _db.SaveChanges();
            LoadOrders(txtSearch.Text);
        }
        catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        catch (Exception ex) { MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
    private void btnRefresh_Click(object s, EventArgs e) => LoadOrders(txtSearch.Text);
    protected override void OnFormClosed(FormClosedEventArgs e) { _db.Dispose(); base.OnFormClosed(e); }
}
