using AutoService.Data.Context;
using AutoService.Data.Models;

namespace AutoService.Forms.Forms;

public partial class ClientEditForm : Form
{
    private readonly int _id;

    public ClientEditForm(int id)
    {
        InitializeComponent();
        _id = id;
        Text = id == 0 ? "Новый клиент" : "Редактирование клиента";
    }

    private void ClientEditForm_Load(object s, EventArgs e)
    {
        if (_id == 0) return;
        using var db = new AppDbContext();
        var c = db.Clients.Find(_id);
        if (c == null) return;
        txtLastName.Text  = c.LastName;
        txtFirstName.Text = c.FirstName;
        txtPhone.Text     = c.Phone;
        txtEmail.Text     = c.Email;
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        txtLastName.BackColor = txtFirstName.BackColor = SystemColors.Window;
        bool hasErrors = false;

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
            { txtLastName.BackColor = Color.LightPink; hasErrors = true; }
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            { txtFirstName.BackColor = Color.LightPink; hasErrors = true; }
        if (hasErrors) return;

        try
        {
            using var db = new AppDbContext();
            Client client;
            if (_id == 0) { client = new Client(); db.Clients.Add(client); }
            else          { client = db.Clients.Find(_id)!; }

            client.LastName  = txtLastName.Text.Trim();
            client.FirstName = txtFirstName.Text.Trim();
            client.Phone     = txtPhone.Text.Trim();
            client.Email     = txtEmail.Text.Trim();
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
