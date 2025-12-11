using System;
using System.Windows.Forms;

namespace Thang
{
    public partial class mainFrom : Form
    {
        private Form activeForm = null;

        public string LoggedUser = "";

        public mainFrom()
        {
            InitializeComponent();
        }
        public mainFrom(string username)
        {
            InitializeComponent();
            LoggedUser = username;
            lblTitle.Text = "Welcome, " + username;
        }

        // Hàm dùng để mở Form con trong panelMain
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close(); // đóng form trước

            activeForm = childForm;
            childForm.TopLevel = false;                // biến form con thành control
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;           // full panel

            panelMain.Controls.Clear();                // xoá control cũ
            panelMain.Controls.Add(childForm);         // add form mới
            panelMain.Tag = childForm;

            childForm.Show();                          // hiển thị
        }

        // Nút mở Rice Storage
        private void btnStorage_Click(object sender, EventArgs e)
        {
            frmRice f = new frmRice();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        // Nút mở Invoice
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice  f = new frmInvoice
                ();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        // Nút mở Customer
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer f = new frmCustomer
                ();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        // Nút mở Supplier
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier  f = new frmSupplier 
               ();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        // Nút mở Staff Management
        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff f = new frmStaff
                ();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        // Logout về Login form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            f.Show();
        }
    }
}
