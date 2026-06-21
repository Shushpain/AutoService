namespace AutoService.Forms.Forms;

partial class MasterReportForm
{
    private System.ComponentModel.IContainer components = null;
    private DateTimePicker dtpFrom, dtpTo;
    private Button btnApply;
    private DataGridView dataGridView1;
    private Label lblTotalOrders, lblTotalRevenue, label1, label2;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        dtpFrom = new DateTimePicker(); dtpTo = new DateTimePicker();
        btnApply = new Button();
        dataGridView1 = new DataGridView();
        lblTotalOrders = new Label(); lblTotalRevenue = new Label();
        label1 = new Label(); label2 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        label1.Text = "С:"; label1.Location = new Point(12, 18); label1.AutoSize = true;
        dtpFrom.Location = new Point(35, 14); dtpFrom.Size = new Size(120, 23); dtpFrom.Format = DateTimePickerFormat.Short;

        label2.Text = "По:"; label2.Location = new Point(165, 18); label2.AutoSize = true;
        dtpTo.Location = new Point(195, 14); dtpTo.Size = new Size(120, 23); dtpTo.Format = DateTimePickerFormat.Short;

        btnApply.Text = "Применить"; btnApply.Location = new Point(330, 13); btnApply.Size = new Size(110, 25);
        btnApply.BackColor = Color.SteelBlue; btnApply.ForeColor = Color.White; btnApply.Click += btnApply_Click;

        dataGridView1.Location = new Point(12, 50); dataGridView1.Size = new Size(800, 400);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        lblTotalOrders.AutoSize = true; lblTotalOrders.Location = new Point(12, 460);
        lblTotalOrders.Font = new Font(lblTotalOrders.Font, FontStyle.Bold);
        lblTotalOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        lblTotalRevenue.AutoSize = true; lblTotalRevenue.Location = new Point(220, 460);
        lblTotalRevenue.Font = new Font(lblTotalRevenue.Font, FontStyle.Bold);
        lblTotalRevenue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(824, 495); StartPosition = FormStartPosition.CenterParent;
        Text = "Отчёт по мастеру"; Name = "MasterReportForm";
        Controls.AddRange(new Control[] { label1, dtpFrom, label2, dtpTo, btnApply, dataGridView1, lblTotalOrders, lblTotalRevenue });
        Load += MasterReportForm_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
