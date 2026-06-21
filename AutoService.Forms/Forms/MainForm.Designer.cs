namespace AutoService.Forms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem справочникиToolStripMenuItem;
    private ToolStripMenuItem menuClients;
    private ToolStripMenuItem menuCars;
    private ToolStripMenuItem menuOrders;
    private ToolStripMenuItem операцииToolStripMenuItem;
    private ToolStripMenuItem menuNewOrder;
    private ToolStripMenuItem menuChangeStatus;
    private ToolStripMenuItem menuCarHistory;
    private ToolStripMenuItem отчётыToolStripMenuItem;
    private ToolStripMenuItem menuMasterReport;
    private ToolStripMenuItem menuRevenueReport;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
    private ToolStripStatusLabel lblTime;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        справочникиToolStripMenuItem = new ToolStripMenuItem();
        menuClients = new ToolStripMenuItem();
        menuCars = new ToolStripMenuItem();
        menuOrders = new ToolStripMenuItem();
        операцииToolStripMenuItem = new ToolStripMenuItem();
        menuNewOrder = new ToolStripMenuItem();
        menuChangeStatus = new ToolStripMenuItem();
        menuCarHistory = new ToolStripMenuItem();
        отчётыToolStripMenuItem = new ToolStripMenuItem();
        menuMasterReport = new ToolStripMenuItem();
        menuRevenueReport = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        lblTime = new ToolStripStatusLabel();

        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // menuStrip1
        menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, операцииToolStripMenuItem, отчётыToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(784, 24);

        // Справочники
        справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuClients, menuCars, menuOrders });
        справочникиToolStripMenuItem.Text = "Справочники";
        menuClients.Text = "Клиенты";
        menuClients.Click += menuClients_Click;
        menuCars.Text = "Автомобили";
        menuCars.Click += menuCars_Click;
        menuOrders.Text = "Заказы";
        menuOrders.Click += menuOrders_Click;

        // Операции
        операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuNewOrder, menuChangeStatus, menuCarHistory });
        операцииToolStripMenuItem.Text = "Операции";
        menuNewOrder.Text = "Создать заказ";
        menuNewOrder.Click += menuNewOrder_Click;
        menuChangeStatus.Text = "Сменить статус заказа";
        menuChangeStatus.Click += menuChangeStatus_Click;
        menuCarHistory.Text = "История автомобиля";
        menuCarHistory.Click += menuCarHistory_Click;

        // Отчёты
        отчётыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuMasterReport, menuRevenueReport });
        отчётыToolStripMenuItem.Text = "Отчёты";
        menuMasterReport.Text = "По мастеру";
        menuMasterReport.Click += menuMasterReport_Click;
        menuRevenueReport.Text = "Выручка за период";
        menuRevenueReport.Click += menuRevenueReport_Click;

        // StatusStrip
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblTime });
        statusStrip1.Location = new Point(0, 539);
        statusStrip1.Size = new Size(784, 22);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(670, 17);
        lblStatus.Spring = true;
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        lblStatus.Text = "Автосервис — система управления заказами";
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(99, 17);
        lblTime.Text = "00:00:00";

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 561);
        Controls.Add(menuStrip1);
        Controls.Add(statusStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Автосервис — Управление заказами";
        WindowState = FormWindowState.Maximized;

        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
