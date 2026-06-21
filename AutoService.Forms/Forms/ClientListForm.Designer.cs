namespace AutoService.Forms.Forms;

partial class ClientListForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtSearch;
    private DataGridView dataGridView1;
    private Button btnAdd, btnEdit, btnDelete, btnRefresh;
    private Label lblCount;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        txtSearch = new TextBox();
        dataGridView1 = new DataGridView();
        btnAdd = new Button(); btnEdit = new Button(); btnDelete = new Button(); btnRefresh = new Button();
        lblCount = new Label();

        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();

        // txtSearch
        txtSearch.Location = new Point(12, 12); txtSearch.Size = new Size(600, 23);
        txtSearch.PlaceholderText = "Введите для поиска (фамилия, имя, телефон)...";
        txtSearch.TextChanged += txtSearch_TextChanged;

        // buttons
        btnAdd.Text = "Добавить"; btnAdd.Location = new Point(12, 45); btnAdd.Size = new Size(100, 30); btnAdd.Click += btnAdd_Click;
        btnEdit.Text = "Изменить"; btnEdit.Location = new Point(118, 45); btnEdit.Size = new Size(100, 30); btnEdit.Enabled = false; btnEdit.Click += btnEdit_Click;
        btnDelete.Text = "Удалить"; btnDelete.Location = new Point(224, 45); btnDelete.Size = new Size(100, 30); btnDelete.Enabled = false; btnDelete.Click += btnDelete_Click;
        btnRefresh.Text = "Обновить"; btnRefresh.Location = new Point(330, 45); btnRefresh.Size = new Size(100, 30); btnRefresh.Click += btnRefresh_Click;

        // lblCount
        lblCount.AutoSize = true; lblCount.Location = new Point(12, 565); lblCount.Text = "Клиентов: 0";

        // dataGridView1
        dataGridView1.Location = new Point(12, 82); dataGridView1.Size = new Size(960, 475);
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.ReadOnly = true;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

        var colId    = new DataGridViewTextBoxColumn { Name = "colId",    DataPropertyName = "Id",        HeaderText = "ID",       Width = 50,  Visible = false };
        var colLast  = new DataGridViewTextBoxColumn { Name = "colLast",  DataPropertyName = "LastName",  HeaderText = "Фамилия",  Width = 160 };
        var colFirst = new DataGridViewTextBoxColumn { Name = "colFirst", DataPropertyName = "FirstName", HeaderText = "Имя",      Width = 130 };
        var colPhone = new DataGridViewTextBoxColumn { Name = "colPhone", DataPropertyName = "Phone",     HeaderText = "Телефон",  Width = 150 };
        var colEmail = new DataGridViewTextBoxColumn { Name = "colEmail", DataPropertyName = "Email",     HeaderText = "Email",    Width = 220 };
        dataGridView1.Columns.AddRange(colId, colLast, colFirst, colPhone, colEmail);

        // Form
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 591); StartPosition = FormStartPosition.CenterParent;
        Text = "Клиенты"; Name = "ClientListForm";
        Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete, btnRefresh, dataGridView1, lblCount });
        Load += ClientListForm_Load;

        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }
}
