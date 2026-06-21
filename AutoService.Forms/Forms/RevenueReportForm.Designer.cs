namespace AutoService.Forms.Forms;

partial class RevenueReportForm
{
    private System.ComponentModel.IContainer components = null;
    private DateTimePicker dtpFrom, dtpTo;
    private Button btnApply;
    private DataGridView dataGridView1;
    private Label lblCount, lblWorkCost, lblParts, lblTotal, label1, label2;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        dtpFrom = new DateTimePicker(); dtpTo = new DateTimePicker();
        btnApply = new Button();
        dataGridView1 = new DataGridView();
        lblCount = new Label(); lblWorkCost = new Label(); lblParts = new Label(); lblTotal = new Label();
        label1 = new Label(); label2 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        label1.Text = "С:"; label1.Location = new Point(12, 18); label1.AutoSize = true;
        dtpFrom.Location = new Point(35, 14); dtpFrom.Size = new Size(120, 23); dtpFrom.Format = DateTimePickerFormat.Short;

        label2.Text = "По:"; label2.Location = new Point(165, 18); label2.AutoSize = true;
        dtpTo.Location = new Point(195, 14); dtpTo.Size = new Size(120, 23); dtpTo.Format = DateTimePickerFormat.Short;

        btnApply.Text = "Применить"; btnApply.Location = new Point(330, 13); btnApply.Size = new Size(110, 25);
        btnApply.BackColor = Color.SteelBlue; btnApply.ForeColor = Color.White; btnApply.Click += btnApply_Click;

        dataGridView1.Location = new Point(12, 50); dataGridView1.Size = new Size(1050, 420);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        lblCount.AutoSize = true; lblCount.Location = new Point(12, 480); lblCount.Font = new Font(lblCount.Font, FontStyle.Bold);
        lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblWorkCost.AutoSize = true; lblWorkCost.Location = new Point(160, 480); lblWorkCost.Font = new Font(lblWorkCost.Font, FontStyle.Bold);
        lblWorkCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblParts.AutoSize = true; lblParts.Location = new Point(380, 480); lblParts.Font = new Font(lblParts.Font, FontStyle.Bold);
        lblParts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTotal.AutoSize = true; lblTotal.Location = new Point(600, 480); lblTotal.Font = new Font(lblTotal.Font, FontStyle.Bold);
        lblTotal.ForeColor = Color.DarkGreen;
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1074, 515); StartPosition = FormStartPosition.CenterParent;
        Text = "Отчёт по выручке за период"; Name = "RevenueReportForm";
        Controls.AddRange(new Control[] { label1, dtpFrom, label2, dtpTo, btnApply, dataGridView1, lblCount, lblWorkCost, lblParts, lblTotal });
        Load += RevenueReportForm_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
