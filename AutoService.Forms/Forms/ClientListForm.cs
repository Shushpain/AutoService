using AutoService.Data.Context;
using AutoService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Forms.Forms;

public partial class ClientListForm : Form
{
    private readonly AppDbContext _db = new();
    private System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };

    public ClientListForm()
    {
        InitializeComponent();
        _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); LoadClients(txtSearch.Text); };
    }

    private void ClientListForm_Load(object s, EventArgs e) => LoadClients();

    private void LoadClients(string filter = "")
    {
        var query = _db.Clients.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(c =>
                c.LastName.Contains(filter) ||
                c.FirstName.Contains(filter) ||
                c.Phone.Contains(filter));

        dataGridView1.DataSource = query.OrderBy(c => c.LastName).ToList();
        lblCount.Text = $"Клиентов: {dataGridView1.RowCount}";
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        bool hasSelection = dataGridView1.CurrentRow != null;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
    }

    private int GetSelectedId()
    {
        if (dataGridView1.CurrentRow == null)
            throw new InvalidOperationException("Выберите клиента в списке");
        return (int)dataGridView1.CurrentRow.Cells["colId"].Value;
    }

    private void txtSearch_TextChanged(object s, EventArgs e) { _searchTimer.Stop(); _searchTimer.Start(); }
    private void dataGridView1_SelectionChanged(object s, EventArgs e) => UpdateButtons();

    private void btnAdd_Click(object s, EventArgs e)
    {
        if (new ClientEditForm(0).ShowDialog() == DialogResult.OK)
            LoadClients(txtSearch.Text);
    }

    private void btnEdit_Click(object s, EventArgs e)
    {
        try
        {
            if (new ClientEditForm(GetSelectedId()).ShowDialog() == DialogResult.OK)
                LoadClients(txtSearch.Text);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnDelete_Click(object s, EventArgs e)
    {
        try
        {
            int id = GetSelectedId();
            var client = _db.Clients.Find(id);
            if (client == null) return;
            var ans = MessageBox.Show(
                $"Удалить клиента '{client.FullName}'?\nЭто действие нельзя отменить.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans != DialogResult.Yes) return;
            _db.Clients.Remove(client);
            _db.SaveChanges();
            LoadClients(txtSearch.Text);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch
        {
            MessageBox.Show("Нельзя удалить клиента: у него есть автомобили в системе.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object s, EventArgs e) => LoadClients(txtSearch.Text);

    protected override void OnFormClosed(FormClosedEventArgs e) { _db.Dispose(); base.OnFormClosed(e); }
}
