namespace AutoService.Forms.Forms;

partial class CarHistoryForm
{
    private System.ComponentModel.IContainer components = null;
    private ComboBox cmbCar;
    private Button btnShow;
    private DataGridView dataGridView1;
    private Label lblSummary, label1;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        cmbCar = new ComboBox(); btnShow = new Button();
        dataGridView1 = new DataGridView();
        lblSummary = new Label(); label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        label1.Text = "Автомобиль:"; label1.Location = new Point(12, 18); label1.AutoSize = true;
        cmbCar.Location = new Point(110, 14); cmbCar.Size = new Size(350, 23); cmbCar.DropDownStyle = ComboBoxStyle.DropDownList;

        btnShow.Text = "Показать"; btnShow.Location = new Point(470, 13); btnShow.Size = new Size(100, 25); btnShow.Click += btnShow_Click;

        lblSummary.AutoSize = true; lblSummary.Location = new Point(12, 50);
        lblSummary.Font = new Font(lblSummary.Font, FontStyle.Bold);

        dataGridView1.Location = new Point(12, 80); dataGridView1.Size = new Size(900, 420);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(924, 515); StartPosition = FormStartPosition.CenterParent;
        Text = "История обслуживания автомобиля"; Name = "CarHistoryForm";
        Controls.AddRange(new Control[] { label1, cmbCar, btnShow, lblSummary, dataGridView1 });
        Load += CarHistoryForm_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
