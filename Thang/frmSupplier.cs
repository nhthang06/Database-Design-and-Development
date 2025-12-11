using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmSupplier : Form
    {
        string connectionString = @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";
        int selectedID = 0;

        public frmSupplier()
        {
            InitializeComponent();
            LoadSupplier();
            txtID.Enabled = false;
        }

        // Load Supplier List
        void LoadSupplier()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Supplier", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSupplier.DataSource = dt;
            }
        }

        // Clear Form
        void ClearForm()
        {
            selectedID = 0;
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }

        // CLICK ROW
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedID = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["SupplierID"].Value);

                txtID.Text = selectedID.ToString();
                txtName.Text = dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();
                txtPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value.ToString();

                // Email không có trong SQL – chỉ là chỗ nhập tạm
                txtEmail.Text = "";
            }
        }

        // ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter supplier name");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Supplier(SupplierName, Phone, Address)
                      VALUES(@name, @phone, @address)", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Supplier Added");
            LoadSupplier();
            ClearForm();
        }

        // EDIT
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Please select a supplier");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Supplier SET 
                        SupplierName=@name,
                        Phone=@phone,
                        Address=@address
                      WHERE SupplierID=@id", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@id", selectedID);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Updated Successfully");
            LoadSupplier();
            ClearForm();
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Select a supplier first");
                return;
            }

            if (MessageBox.Show("Do you want to delete this supplier?",
                "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Supplier WHERE SupplierID=@id", conn);

                cmd.Parameters.AddWithValue("@id", selectedID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Deleted Successfully");
            LoadSupplier();
            ClearForm();
        }

        // SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Supplier WHERE SupplierName LIKE @name", conn);
                da.SelectCommand.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSupplier.DataSource = dt;
            }
        }

        // SAVE (giống Edit)
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // EXIT
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
