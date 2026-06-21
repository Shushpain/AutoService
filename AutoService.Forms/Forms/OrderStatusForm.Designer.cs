namespace AutoService.Forms.Forms;

partial class OrderStatusForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dataGridView1;
    private Button btnAdvance;
    private Label lblCount;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        dataGridView1 = new DataGridView();
        btnAdvance = new Button();
        lblCount = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        lblCount.AutoSize = true; lblCount.Location = new Point(12, 12);

        btnAdvance.Text = "Перевести на след. статус →";
        btnAdvance.Location = new Point(12, 40); btnAdvance.Size = new Size(220, 35);
        btnAdvance.BackColor = Color.SeaGreen; btnAdvance.ForeColor = Color.White;
        btnAdvance.Click += btnAdvance_Click;

        dataGridView1.Location = new Point(12, 85); dataGridView1.Size = new Size(1000, 450);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1024, 545); StartPosition = FormStartPosition.CenterParent;
        Text = "Смена статуса заказа"; Name = "OrderStatusForm";
        Controls.AddRange(new Control[] { lblCount, btnAdvance, dataGridView1 });
        Load += OrderStatusForm_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
