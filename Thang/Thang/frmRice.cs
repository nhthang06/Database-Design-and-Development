using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmRice : Form
    {
        private string connectionString =
            @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";

        private int selectedID = -1;

        // chế độ hiện tại: None Add Edit
        private enum FormMode { None, Add, Edit }
        private FormMode currentMode = FormMode.None;

        public frmRice()
        {
            InitializeComponent();
            LoadSuppliers();
            LoadRice();
            ClearInputs();
        }

        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT SupplierID, SupplierName FROM Supplier";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboSupplier.DataSource = dt;
                cboSupplier.DisplayMember = "SupplierName";
                cboSupplier.ValueMember = "SupplierID";
            }
        }

        private void LoadRice()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT RiceID, RiceName, Quantity, Price, SupplierID FROM Rice";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRice.Columns.Clear();
                dgvRice.DataSource = dt;
            }
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            if (cboSupplier.Items.Count > 0)
                cboSupplier.SelectedIndex = 0;

            selectedID = -1;
            currentMode = FormMode.None;
        }

        private void dgvRice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // click header = bỏ

            DataGridViewRow row = dgvRice.Rows[e.RowIndex];

            // Kiểm tra dòng trống (dòng new row)
            if (row.Cells["RiceID"].Value == null || row.Cells["RiceID"].Value == DBNull.Value)
            {
                ClearInputs();
                selectedID = -1;
                currentMode = FormMode.None;
                return; // Không xử lý tiếp
            }

            selectedID = Convert.ToInt32(row.Cells["RiceID"].Value);

            txtName.Text = row.Cells["RiceName"].Value?.ToString() ?? "";
            txtQty.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";

            if (row.Cells["SupplierID"].Value != DBNull.Value)
            {
                cboSupplier.SelectedValue = Convert.ToInt32(row.Cells["SupplierID"].Value);
            }

            currentMode = FormMode.None;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
            currentMode = FormMode.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a row to edit");
                return;
            }
            currentMode = FormMode.Edit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this rice record?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Rice WHERE RiceID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selectedID);
                cmd.ExecuteNonQuery();
            }

            LoadRice();
            ClearInputs();
            MessageBox.Show("Deleted successfully");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRice();
            ClearInputs();
        }

  
  

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMode == FormMode.None)
            {
                MessageBox.Show("Please click Add or Edit before saving");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtQty.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!int.TryParse(txtQty.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be an integer");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a number");
                return;
            }

            int supplierID = Convert.ToInt32(cboSupplier.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql;

                if (currentMode == FormMode.Add)
                {
                    sql = @"INSERT INTO Rice (RiceName, Quantity, Price, SupplierID)
                            VALUES (@name, @qty, @price, @sup)";
                }
                else // Edit
                {
                    sql = @"UPDATE Rice
                            SET RiceName = @name,
                                Quantity = @qty,
                                Price = @price,
                                SupplierID = @sup
                            WHERE RiceID = @id";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@sup", supplierID);

                if (currentMode == FormMode.Edit)
                    cmd.Parameters.AddWithValue("@id", selectedID);

                cmd.ExecuteNonQuery();
            }

            LoadRice();
            ClearInputs();
            MessageBox.Show("Saved successfully");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
