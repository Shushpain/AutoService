namespace AutoService.Forms.Forms;

partial class ClientEditForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtLastName, txtFirstName, txtPhone, txtEmail;
    private Button btnSave, btnCancel;
    private Label label1, label2, label3, label4;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        txtLastName = new TextBox(); txtFirstName = new TextBox();
        txtPhone = new TextBox(); txtEmail = new TextBox();
        btnSave = new Button(); btnCancel = new Button();
        label1 = new Label(); label2 = new Label(); label3 = new Label(); label4 = new Label();
        SuspendLayout();

        label1.Text = "Фамилия *"; label1.Location = new Point(12, 20); label1.AutoSize = true;
        txtLastName.Location = new Point(130, 17); txtLastName.Size = new Size(250, 23); txtLastName.MaxLength = 100;

        label2.Text = "Имя *"; label2.Location = new Point(12, 55); label2.AutoSize = true;
        txtFirstName.Location = new Point(130, 52); txtFirstName.Size = new Size(250, 23); txtFirstName.MaxLength = 100;

        label3.Text = "Телефон"; label3.Location = new Point(12, 90); label3.AutoSize = true;
        txtPhone.Location = new Point(130, 87); txtPhone.Size = new Size(250, 23); txtPhone.MaxLength = 20;

        label4.Text = "Email"; label4.Location = new Point(12, 125); label4.AutoSize = true;
        txtEmail.Location = new Point(130, 122); txtEmail.Size = new Size(250, 23); txtEmail.MaxLength = 200;

        btnSave.Text = "Сохранить"; btnSave.Location = new Point(130, 165); btnSave.Size = new Size(110, 30);
        btnSave.BackColor = Color.SteelBlue; btnSave.ForeColor = Color.White; btnSave.Click += btnSave_Click;
        btnCancel.Text = "Отмена"; btnCancel.Location = new Point(250, 165); btnCancel.Size = new Size(110, 30); btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(410, 210); FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; StartPosition = FormStartPosition.CenterParent;
        Text = "Клиент"; Name = "ClientEditForm";
        Controls.AddRange(new Control[] { label1, txtLastName, label2, txtFirstName, label3, txtPhone, label4, txtEmail, btnSave, btnCancel });
        Load += ClientEditForm_Load;
        ResumeLayout(false); PerformLayout();
    }
}
