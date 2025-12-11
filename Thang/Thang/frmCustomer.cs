using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmCustomer : Form
    {
        string connectionString =
            @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";

        string imagePath = "";
        bool isAdd = false;
        bool isEdit = false;

        public frmCustomer()
        {
            InitializeComponent();
            LoadCustomer();
            LockForm();
        }

        // LOAD GRID
        private void LoadCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;

                dgvCustomer.Columns["CustomerID"].Width = 70;
                dgvCustomer.Columns["FullName"].Width = 150;
                dgvCustomer.Columns["Phone"].Width = 100;
                dgvCustomer.Columns["Gender"].Width = 80;
            }
        }

        // LOCK / UNLOCK FORM
        private void LockForm()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            cboGender.Enabled = false;
            btnBrowse.Enabled = false;
            btnSave.Enabled = false;
            btnExit.Enabled = false;
        }

        private void UnlockForm()
        {
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            cboGender.Enabled = true;
            btnBrowse.Enabled = true;
            btnSave.Enabled = true;
            btnExit.Enabled = true;
        }

        private void ClearForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cboGender.SelectedIndex = -1;
            picCustomer.Image = null;
            imagePath = "";
        }

        // CLICK GRID → LOAD DATA
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtID.Text = dgvCustomer.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
            txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            cboGender.Text = dgvCustomer.Rows[e.RowIndex].Cells["Gender"].Value.ToString();

            string img = dgvCustomer.Rows[e.RowIndex].Cells["ImagePath"].Value.ToString();
            imagePath = img;

            if (File.Exists(img))
                picCustomer.Image = Image.FromFile(img);
            else
                picCustomer.Image = null;
        }

        // ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            isEdit = false;
            UnlockForm();
            ClearForm();
        }

        // EDIT
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select customer!");
                return;
            }

            isAdd = false;
            isEdit = true;
            UnlockForm();
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select customer!");
                return;
            }

            if (MessageBox.Show("Delete customer?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Customer WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCustomer();
            ClearForm();
        }

        // BROWSE IMAGE
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.jpg;*.png;*.jpeg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagePath = dlg.FileName;
                picCustomer.Image = Image.FromFile(imagePath);
            }
        }

        // SAVE (ADD + EDIT)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cboGender.Text == "")
            {
                MessageBox.Show("Enter name + gender!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (isAdd)
                {
                    string sql = "INSERT INTO Customer (FullName, Gender, Phone, Address, ImagePath) " +
                                 "VALUES (@n, @g, @p, @a, @img)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@g", cboGender.Text);
                    cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@img", imagePath);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added!");
                }
                else if (isEdit)
                {
                    string sql = "UPDATE Customer SET FullName=@n, Gender=@g, Phone=@p, Address=@a, ImagePath=@img " +
                                 "WHERE CustomerID=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@g", cboGender.Text);
                    cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@img", imagePath);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated!");
                }
            }

            LoadCustomer();
            LockForm();
            ClearForm();
        }



        // SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Customer WHERE FullName LIKE @s";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@s", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
