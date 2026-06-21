namespace AutoService.Forms.Forms;

partial class OrderEditForm
{
    private System.ComponentModel.IContainer components = null;
    private ComboBox cmbCar, cmbMaster, cmbStatus;
    private DateTimePicker dtpDate;
    private TextBox txtWorkDesc;
    private NumericUpDown nudWorkCost, nudPartsCost;
    private Label lblTotal;
    private Button btnSave, btnCancel;
    private Label label1, label2, label3, label4, label5, label6, label7;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        cmbCar = new ComboBox(); cmbMaster = new ComboBox(); cmbStatus = new ComboBox();
        dtpDate = new DateTimePicker();
        txtWorkDesc = new TextBox();
        nudWorkCost = new NumericUpDown(); nudPartsCost = new NumericUpDown();
        lblTotal = new Label();
        btnSave = new Button(); btnCancel = new Button();
        label1 = new Label(); label2 = new Label(); label3 = new Label();
        label4 = new Label(); label5 = new Label(); label6 = new Label(); label7 = new Label();
        ((System.ComponentModel.ISupportInitialize)nudWorkCost).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPartsCost).BeginInit();
        SuspendLayout();

        label1.Text = "Автомобиль *"; label1.Location = new Point(12, 20); label1.AutoSize = true;
        cmbCar.Location = new Point(160, 17); cmbCar.Size = new Size(320, 23); cmbCar.DropDownStyle = ComboBoxStyle.DropDownList;

        label2.Text = "Дата"; label2.Location = new Point(12, 55); label2.AutoSize = true;
        dtpDate.Location = new Point(160, 52); dtpDate.Size = new Size(200, 23); dtpDate.Format = DateTimePickerFormat.Custom;
        dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";

        label3.Text = "Виды работ *"; label3.Location = new Point(12, 90); label3.AutoSize = true;
        txtWorkDesc.Location = new Point(160, 87); txtWorkDesc.Size = new Size(320, 60);
        txtWorkDesc.Multiline = true; txtWorkDesc.MaxLength = 1000;

        label4.Text = "Мастер *"; label4.Location = new Point(12, 158); label4.AutoSize = true;
        cmbMaster.Location = new Point(160, 155); cmbMaster.Size = new Size(220, 23); cmbMaster.DropDownStyle = ComboBoxStyle.DropDown;

        label5.Text = "Стоимость работ"; label5.Location = new Point(12, 193); label5.AutoSize = true;
        nudWorkCost.Location = new Point(160, 190); nudWorkCost.Size = new Size(120, 23);
        nudWorkCost.Maximum = 9999999; nudWorkCost.DecimalPlaces = 2; nudWorkCost.ThousandsSeparator = true;
        nudWorkCost.ValueChanged += RecalcTotal;

        label6.Text = "Стоимость запчастей"; label6.Location = new Point(12, 228); label6.AutoSize = true;
        nudPartsCost.Location = new Point(160, 225); nudPartsCost.Size = new Size(120, 23);
        nudPartsCost.Maximum = 9999999; nudPartsCost.DecimalPlaces = 2; nudPartsCost.ThousandsSeparator = true;
        nudPartsCost.ValueChanged += RecalcTotal;

        lblTotal.Text = "Итого: 0,00 руб."; lblTotal.Location = new Point(160, 258);
        lblTotal.AutoSize = true; lblTotal.Font = new Font(lblTotal.Font, FontStyle.Bold);

        label7.Text = "Статус"; label7.Location = new Point(12, 293); label7.AutoSize = true;
        cmbStatus.Location = new Point(160, 290); cmbStatus.Size = new Size(150, 23); cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        btnSave.Text = "Сохранить"; btnSave.Location = new Point(160, 330); btnSave.Size = new Size(110, 30);
        btnSave.BackColor = Color.SteelBlue; btnSave.ForeColor = Color.White; btnSave.Click += btnSave_Click;
        btnCancel.Text = "Отмена"; btnCancel.Location = new Point(280, 330); btnCancel.Size = new Size(110, 30); btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(505, 375); FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; StartPosition = FormStartPosition.CenterParent;
        Text = "Заказ"; Name = "OrderEditForm";
        Controls.AddRange(new Control[] {
            label1, cmbCar, label2, dtpDate, label3, txtWorkDesc, label4, cmbMaster,
            label5, nudWorkCost, label6, nudPartsCost, lblTotal, label7, cmbStatus, btnSave, btnCancel });
        Load += OrderEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)nudWorkCost).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPartsCost).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
