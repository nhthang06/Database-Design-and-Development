using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmStaff : Form
    {
        string connectionString = @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";
        string imagePath = "";
        int selectedID = 0;

        public frmStaff()
        {
            InitializeComponent();
            LoadStaff();
            txtID.Enabled = false;
        }

        // Load Staff List
        void LoadStaff()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Staff", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStaff.DataSource = dt;
            }
        }

        // Clear form
        void ClearForm()
        {
            selectedID = 0;
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtPosition.Clear();
            cboGender.SelectedIndex = -1;
            picStaff.Image = null;
            imagePath = "";
        }

        // Browse Image
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStaff.Image = Image.FromFile(ofd.FileName);
                imagePath = ofd.FileName;
            }
        }

        // Click Row
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedID = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["StaffID"].Value);

                txtID.Text = selectedID.ToString();
                txtName.Text = dgvStaff.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                cboGender.Text = dgvStaff.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                txtPhone.Text = dgvStaff.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtPosition.Text = dgvStaff.Rows[e.RowIndex].Cells["Position"].Value.ToString();

                string img = dgvStaff.Rows[e.RowIndex].Cells["ImagePath"].Value.ToString();

                if (File.Exists(img))
                {
                    picStaff.Image = Image.FromFile(img);
                    imagePath = img;
                }
                else
                {
                    picStaff.Image = null;
                    imagePath = "";
                }
            }
        }

        // ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cboGender.Text == "")
            {
                MessageBox.Show("Please fill required fields");
                return;
            }

            string destPath = "";
            if (!string.IsNullOrEmpty(imagePath))
            {
                string folder = Application.StartupPath + "\\Images\\Staff\\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                destPath = folder + Path.GetFileName(imagePath);
                File.Copy(imagePath, destPath, true);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Staff(FullName, Gender, Phone, Position, ImagePath)
                      VALUES(@name, @gender, @phone, @pos, @img)", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cboGender.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                cmd.Parameters.AddWithValue("@img", destPath); // Lưu file mới

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Staff Added");
            LoadStaff();
            ClearForm();
        }

        // EDIT
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Select a staff to edit");
                return;
            }

            string destPath = imagePath;
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                string folder = Application.StartupPath + "\\Images\\Staff\\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                destPath = folder + Path.GetFileName(imagePath);
                File.Copy(imagePath, destPath, true);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Staff SET 
                        FullName=@name, 
                        Gender=@gender, 
                        Phone=@phone, 
                        Position=@pos,
                        ImagePath=@img
                      WHERE StaffID=@id", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cboGender.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                cmd.Parameters.AddWithValue("@img", destPath);
                cmd.Parameters.AddWithValue("@id", selectedID);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Updated Successfully");
            LoadStaff();
            ClearForm();
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Select a staff to delete");
                return;
            }

            if (MessageBox.Show("Delete this staff?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE StaffID=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Deleted");
            LoadStaff();
            ClearForm();
        }

        // SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Staff WHERE FullName LIKE @name", conn);
                da.SelectCommand.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStaff.DataSource = dt;
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
