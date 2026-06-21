namespace AutoService.Forms.Forms;

partial class OrderListForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtSearch;
    private ComboBox cmbStatusFilter;
    private DataGridView dataGridView1;
    private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    private Label lblCount, lblStatusFilter;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        txtSearch = new TextBox(); cmbStatusFilter = new ComboBox();
        dataGridView1 = new DataGridView();
        btnAdd = new Button(); btnEdit = new Button(); btnDelete = new Button(); btnRefresh = new Button();
        lblCount = new Label(); lblStatusFilter = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        txtSearch.Location = new Point(12, 12); txtSearch.Size = new Size(500, 23);
        txtSearch.PlaceholderText = "Поиск по авто, мастеру, работам...";
        txtSearch.TextChanged += txtSearch_TextChanged;

        lblStatusFilter.Text = "Статус:"; lblStatusFilter.Location = new Point(522, 16); lblStatusFilter.AutoSize = true;
        cmbStatusFilter.Location = new Point(575, 12); cmbStatusFilter.Size = new Size(150, 23);
        cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatusFilter.Items.AddRange(new object[] { "Все", "Принят", "В работе", "Готов", "Выдан" });
        cmbStatusFilter.SelectedIndex = 0;
        cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;

        btnAdd.Text = "Добавить"; btnAdd.Location = new Point(12, 45); btnAdd.Size = new Size(100, 30); btnAdd.Click += btnAdd_Click;
        btnEdit.Text = "Изменить"; btnEdit.Location = new Point(118, 45); btnEdit.Size = new Size(100, 30); btnEdit.Enabled = false; btnEdit.Click += btnEdit_Click;
        btnDelete.Text = "Удалить"; btnDelete.Location = new Point(224, 45); btnDelete.Size = new Size(100, 30); btnDelete.Enabled = false; btnDelete.Click += btnDelete_Click;
        btnRefresh.Text = "Обновить"; btnRefresh.Location = new Point(330, 45); btnRefresh.Size = new Size(100, 30); btnRefresh.Click += btnRefresh_Click;

        lblCount.AutoSize = true; lblCount.Location = new Point(12, 565);

        dataGridView1.Location = new Point(12, 82); dataGridView1.Size = new Size(1150, 475);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1174, 591); StartPosition = FormStartPosition.CenterParent;
        Text = "Заказы"; Name = "OrderListForm";
        Controls.AddRange(new Control[] { txtSearch, lblStatusFilter, cmbStatusFilter, btnAdd, btnEdit, btnDelete, btnRefresh, dataGridView1, lblCount });
        Load += OrderListForm_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
