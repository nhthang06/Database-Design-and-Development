using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thang
{
    public partial class frmLogin : Form
    {
        string connectionString =
            @"Data Source=DESKTOP-HDVM1QA;Initial Catalog=RiceStoreDB;Integrated Security=True";

        public frmLogin()
        {
            InitializeComponent();
        }

        // Placeholder User
        private void txtUser_GotFocus(object sender, EventArgs e)
        {
            if (txtUser.Text == "Username")
            {
                txtUser.Text = "";
            }
        }

        private void txtUser_LostFocus(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Username";
            }
        }

        // Placeholder Password
        private void txtPass_GotFocus(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.PasswordChar = '•';
            }
        }

        private void txtPass_LostFocus(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.PasswordChar = '\0';
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked && txtPass.Text != "Password")
            {
                txtPass.PasswordChar = '\0';
            }
            else if (!chkShow.Checked && txtPass.Text != "Password")
            {
                txtPass.PasswordChar = '•';
            }
        }

        // LOGIN BUTTON
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (txtUser.Text == "Username" || txtPass.Text == "Password")
            {
                lblError.Text = "Please enter username and password.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        @"SELECT Username, Role 
                          FROM Account 
                          WHERE Username = @u AND Password = @p";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", txtUser.Text);
                    cmd.Parameters.AddWithValue("@p", txtPass.Text);

                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        string user = rd["Username"].ToString();
                        string role = rd["Role"].ToString();

                        MessageBox.Show("Login successful", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        mainFrom f = new mainFrom(user);
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Incorrect username or password!";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
