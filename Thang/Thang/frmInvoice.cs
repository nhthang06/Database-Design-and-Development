using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmInvoice
        : Form
    {
        string connectionString = @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";

        int selectedInvoiceID = 0;

        public frmInvoice ()
        {
            InitializeComponent();
            LoadStaff();
            LoadCustomer();
            LoadRice();
            LoadInvoice();
        }

        // Load Staff vào combo
        void LoadStaff()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT StaffID, FullName FROM Staff", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboStaffID.DataSource = dt;
                cboStaffID.DisplayMember = "FullName";
                cboStaffID.ValueMember = "StaffID";
            }
        }

        // Load Customer vào combo
        void LoadCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, FullName FROM Customer", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboCustomerID.DataSource = dt;
                cboCustomerID.DisplayMember = "FullName";
                cboCustomerID.ValueMember = "CustomerID";
            }
        }

        // Load Rice vào combo
        void LoadRice()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT RiceID, RiceName, Price FROM Rice", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboRice.DataSource = dt;
                cboRice.DisplayMember = "RiceName";
                cboRice.ValueMember = "RiceID";
            }
        }

        // Load invoices
        void LoadInvoice()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT InvoiceID, InvoiceDate, StaffID, CustomerID, TotalAmount 
                      FROM Invoice ORDER BY InvoiceID DESC", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBill.DataSource = dt;
            }
        }

        // Load InvoiceDetail theo bill đã chọn
        void LoadInvoiceDetail(int invoiceID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT d.DetailID, r.RiceName, d.Price, d.Quantity, d.SubTotal
                      FROM InvoiceDetail d
                      JOIN Rice r ON d.RiceID = r.RiceID
                      WHERE d.InvoiceID = " + invoiceID, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBill.DataSource = dt;
            }
        }

        // Khi chọn 1 Invoice
        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedInvoiceID = Convert.ToInt32(dgvBill.Rows[e.RowIndex].Cells["InvoiceID"].Value);

                dtpDate.Value = Convert.ToDateTime(dgvBill.Rows[e.RowIndex].Cells["InvoiceDate"].Value);
                cboStaffID.SelectedValue = dgvBill.Rows[e.RowIndex].Cells["StaffID"].Value;
                cboCustomerID.SelectedValue = dgvBill.Rows[e.RowIndex].Cells["CustomerID"].Value;
                txtSubtotal.Text = dgvBill.Rows[e.RowIndex].Cells["TotalAmount"].Value.ToString();

                LoadInvoiceDetail(selectedInvoiceID);
            }
        }

        // Thêm hóa đơn
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Nhập số lượng");
                return;
            }

            int qty = int.Parse(txtQty.Text);

            // Lấy giá gạo từ combo
            DataRowView drv = cboRice.SelectedItem as DataRowView;
            decimal price = Convert.ToDecimal(drv["Price"]);
            decimal sub = qty * price;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Tạo Invoice
                SqlCommand cmdInvoice = new SqlCommand(
                    @"INSERT INTO Invoice(InvoiceDate, StaffID, CustomerID, TotalAmount)
                      VALUES(@date, @staff, @cus, 0);
                      SELECT SCOPE_IDENTITY();", conn);

                cmdInvoice.Parameters.AddWithValue("@date", dtpDate.Value);
                cmdInvoice.Parameters.AddWithValue("@staff", cboStaffID.SelectedValue);
                cmdInvoice.Parameters.AddWithValue("@cus", cboCustomerID.SelectedValue);

                int newInvoiceID = Convert.ToInt32(cmdInvoice.ExecuteScalar());

                // 2. Thêm InvoiceDetail
                SqlCommand cmdDetail = new SqlCommand(
                    @"INSERT INTO InvoiceDetail(InvoiceID, RiceID, Price, Quantity)
                      VALUES(@id, @rice, @price, @qty)", conn);

                cmdDetail.Parameters.AddWithValue("@id", newInvoiceID);
                cmdDetail.Parameters.AddWithValue("@rice", cboRice.SelectedValue);
                cmdDetail.Parameters.AddWithValue("@price", price);
                cmdDetail.Parameters.AddWithValue("@qty", qty);
                cmdDetail.ExecuteNonQuery();

                // 3. Cập nhật total
                SqlCommand cmdSum = new SqlCommand(
                    @"UPDATE Invoice SET TotalAmount = 
                      (SELECT SUM(SubTotal) FROM InvoiceDetail WHERE InvoiceID = @id)
                      WHERE InvoiceID = @id", conn);

                cmdSum.Parameters.AddWithValue("@id", newInvoiceID);
                cmdSum.ExecuteNonQuery();

                MessageBox.Show("Thêm hóa đơn thành công");
            }

            LoadInvoice();
        }

        // Xóa hóa đơn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedInvoiceID == 0)
            {
                MessageBox.Show("Chọn hóa đơn cần xóa");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa detail trước
                SqlCommand cmdDetail = new SqlCommand(
                    "DELETE FROM InvoiceDetail WHERE InvoiceID = @id", conn);
                cmdDetail.Parameters.AddWithValue("@id", selectedInvoiceID);
                cmdDetail.ExecuteNonQuery();

                // Xóa invoice
                SqlCommand cmdInvoice = new SqlCommand(
                    "DELETE FROM Invoice WHERE InvoiceID = @id", conn);
                cmdInvoice.Parameters.AddWithValue("@id", selectedInvoiceID);
                cmdInvoice.ExecuteNonQuery();
            }

            MessageBox.Show("Xóa hóa đơn thành công");
            LoadInvoice();
            dgvBill.DataSource = null;
        }

        // Làm mới form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            selectedInvoiceID = 0;
            txtQty.Clear();
            txtSubtotal.Clear();
            LoadInvoice();
            dgvBill.DataSource = null;
        }

        // Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
