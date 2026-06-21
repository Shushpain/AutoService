namespace AutoService.Forms.Forms;

partial class CarEditForm
{
    private System.ComponentModel.IContainer components = null;
    private ComboBox cmbClient;
    private TextBox txtBrand, txtModel, txtPlate, txtVin;
    private NumericUpDown nudYear;
    private Button btnSave, btnCancel;
    private Label label1, label2, label3, label4, label5, label6;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        cmbClient = new ComboBox();
        txtBrand = new TextBox(); txtModel = new TextBox(); txtPlate = new TextBox(); txtVin = new TextBox();
        nudYear = new NumericUpDown();
        btnSave = new Button(); btnCancel = new Button();
        label1 = new Label(); label2 = new Label(); label3 = new Label();
        label4 = new Label(); label5 = new Label(); label6 = new Label();
        ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
        SuspendLayout();

        label1.Text = "Клиент *"; label1.Location = new Point(12, 20); label1.AutoSize = true;
        cmbClient.Location = new Point(140, 17); cmbClient.Size = new Size(260, 23); cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;

        label2.Text = "Марка *"; label2.Location = new Point(12, 55); label2.AutoSize = true;
        txtBrand.Location = new Point(140, 52); txtBrand.Size = new Size(260, 23); txtBrand.MaxLength = 100;

        label3.Text = "Модель *"; label3.Location = new Point(12, 90); label3.AutoSize = true;
        txtModel.Location = new Point(140, 87); txtModel.Size = new Size(260, 23); txtModel.MaxLength = 100;

        label4.Text = "Год"; label4.Location = new Point(12, 125); label4.AutoSize = true;
        nudYear.Location = new Point(140, 122); nudYear.Size = new Size(100, 23);
        nudYear.Minimum = 1900; nudYear.Maximum = 2100;

        label5.Text = "Гос. номер"; label5.Location = new Point(12, 160); label5.AutoSize = true;
        txtPlate.Location = new Point(140, 157); txtPlate.Size = new Size(260, 23); txtPlate.MaxLength = 20;

        label6.Text = "VIN"; label6.Location = new Point(12, 195); label6.AutoSize = true;
        txtVin.Location = new Point(140, 192); txtVin.Size = new Size(260, 23); txtVin.MaxLength = 20;

        btnSave.Text = "Сохранить"; btnSave.Location = new Point(140, 235); btnSave.Size = new Size(110, 30);
        btnSave.BackColor = Color.SteelBlue; btnSave.ForeColor = Color.White; btnSave.Click += btnSave_Click;
        btnCancel.Text = "Отмена"; btnCancel.Location = new Point(260, 235); btnCancel.Size = new Size(110, 30); btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 280); FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; StartPosition = FormStartPosition.CenterParent;
        Text = "Автомобиль"; Name = "CarEditForm";
        Controls.AddRange(new Control[] { label1, cmbClient, label2, txtBrand, label3, txtModel, label4, nudYear, label5, txtPlate, label6, txtVin, btnSave, btnCancel });
        Load += CarEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
