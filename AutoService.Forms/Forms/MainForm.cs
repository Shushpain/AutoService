using AutoService.Forms.Forms;

namespace AutoService.Forms.Forms;

public partial class MainForm : Form
{
    private System.Windows.Forms.Timer _clockTimer = new() { Interval = 1000, Enabled = true };

    public MainForm()
    {
        InitializeComponent();
        _clockTimer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    // Справочники
    private void menuClients_Click(object s, EventArgs e) => new ClientListForm().ShowDialog();
    private void menuCars_Click(object s, EventArgs e) => new CarListForm().ShowDialog();
    private void menuOrders_Click(object s, EventArgs e) => new OrderListForm().ShowDialog();

    // Операции
    private void menuNewOrder_Click(object s, EventArgs e) => new OrderEditForm(0).ShowDialog();
    private void menuChangeStatus_Click(object s, EventArgs e) => new OrderStatusForm().ShowDialog();
    private void menuCarHistory_Click(object s, EventArgs e) => new CarHistoryForm().ShowDialog();

    // Отчёты
    private void menuMasterReport_Click(object s, EventArgs e) => new MasterReportForm().ShowDialog();
    private void menuRevenueReport_Click(object s, EventArgs e) => new RevenueReportForm().ShowDialog();
}
