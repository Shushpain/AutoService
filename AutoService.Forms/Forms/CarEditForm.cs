using AutoService.Data.Context;
using AutoService.Data.Models;

namespace AutoService.Forms.Forms;

public partial class CarEditForm : Form
{
    private readonly int _id;

    public CarEditForm(int id)
    {
        InitializeComponent();
        _id = id;
        Text = id == 0 ? "Новый автомобиль" : "Редактирование автомобиля";
    }

    private void CarEditForm_Load(object s, EventArgs e)
    {
        using var db = new AppDbContext();

        var clients = db.Clients.OrderBy(c => c.LastName).ToList();
        cmbClient.DataSource = clients;
        cmbClient.DisplayMember = "FullName";
        cmbClient.ValueMember = "Id";

        nudYear.Value = DateTime.Now.Year;

        if (_id == 0) return;

        var car = db.Cars.Find(_id);
        if (car == null) return;
        cmbClient.SelectedValue = car.ClientId;
        txtBrand.Text = car.Brand;
        txtModel.Text = car.Model;
        nudYear.Value = car.Year;
        txtPlate.Text = car.LicensePlate;
        txtVin.Text = car.VIN;
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        txtBrand.BackColor = txtModel.BackColor = SystemColors.Window;
        bool hasErrors = false;

        if (string.IsNullOrWhiteSpace(txtBrand.Text)) { txtBrand.BackColor = Color.LightPink; hasErrors = true; }
        if (string.IsNullOrWhiteSpace(txtModel.Text)) { txtModel.BackColor = Color.LightPink; hasErrors = true; }
        if (cmbClient.SelectedValue == null)
        {
            MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            hasErrors = true;
        }
        if (nudYear.Value < 1900 || nudYear.Value > 2100)
        {
            MessageBox.Show("Год должен быть от 1900 до 2100", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            hasErrors = true;
        }
        if (hasErrors) return;

        try
        {
            using var db = new AppDbContext();
            Car car;
            if (_id == 0) { car = new Car(); db.Cars.Add(car); }
            else          { car = db.Cars.Find(_id)!; }

            car.ClientId     = (int)cmbClient.SelectedValue!;
            car.Brand        = txtBrand.Text.Trim();
            car.Model        = txtModel.Text.Trim();
            car.Year         = (int)nudYear.Value;
            car.LicensePlate = txtPlate.Text.Trim();
            car.VIN          = txtVin.Text.Trim();

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при сохранении (возможно, VIN уже существует): " + ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object s, EventArgs e) => DialogResult = DialogResult.Cancel;
}
