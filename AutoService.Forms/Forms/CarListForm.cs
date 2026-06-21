using AutoService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class CarListForm : Form
{
    private readonly AppDbContext _db = new();
    private System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };

    public CarListForm()
    {
        InitializeComponent();
        _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); LoadCars(txtSearch.Text); };
    }

    private void CarListForm_Load(object s, EventArgs e) => LoadCars();

    private void LoadCars(string filter = "")
    {
        var query = _db.Cars.Include(c => c.Client).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(c =>
                c.Brand.Contains(filter) ||
                c.Model.Contains(filter) ||
                c.LicensePlate.Contains(filter) ||
                c.VIN.Contains(filter) ||
                c.Client.LastName.Contains(filter));

        dataGridView1.DataSource = query.OrderBy(c => c.Brand).ThenBy(c => c.Model)
            .Select(c => new
            {
                c.Id,
                Клиент = c.Client.FullName,
                c.Brand,
                c.Model,
                c.Year,
                ГосНомер = c.LicensePlate,
                c.VIN
            }).ToList();

        lblCount.Text = $"Автомобилей: {dataGridView1.RowCount}";
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        bool has = dataGridView1.CurrentRow != null;
        btnEdit.Enabled = has; btnDelete.Enabled = has;
    }

    private int GetSelectedId()
    {
        if (dataGridView1.CurrentRow == null) throw new InvalidOperationException("Выберите автомобиль");
        return (int)dataGridView1.CurrentRow.Cells["Id"].Value;
    }

    private void txtSearch_TextChanged(object s, EventArgs e) { _searchTimer.Stop(); _searchTimer.Start(); }
    private void dataGridView1_SelectionChanged(object s, EventArgs e) => UpdateButtons();

    private void btnAdd_Click(object s, EventArgs e) { if (new CarEditForm(0).ShowDialog() == DialogResult.OK) LoadCars(txtSearch.Text); }
    private void btnEdit_Click(object s, EventArgs e)
    {
        try { if (new CarEditForm(GetSelectedId()).ShowDialog() == DialogResult.OK) LoadCars(txtSearch.Text); }
        catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void btnDelete_Click(object s, EventArgs e)
    {
        try
        {
            int id = GetSelectedId();
            var car = _db.Cars.Find(id);
            if (car == null) return;
            if (MessageBox.Show($"Удалить автомобиль '{car.Brand} {car.Model} ({car.LicensePlate})'?\nЭто действие нельзя отменить.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _db.Cars.Remove(car);
            _db.SaveChanges();
            LoadCars(txtSearch.Text);
        }
        catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        catch { MessageBox.Show("Нельзя удалить автомобиль: у него есть заказы в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
    private void btnRefresh_Click(object s, EventArgs e) => LoadCars(txtSearch.Text);
    protected override void OnFormClosed(FormClosedEventArgs e) { _db.Dispose(); base.OnFormClosed(e); }
}
