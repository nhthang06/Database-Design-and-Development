namespace Thang
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();

            // Panel Login
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.chkShow);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtPass);
            this.pnlLogin.Controls.Add(this.txtUser);
            this.pnlLogin.Controls.Add(this.lblTitle);
            this.pnlLogin.Location = new System.Drawing.Point(40, 40);
            this.pnlLogin.Size = new System.Drawing.Size(350, 300);

            // Title
            this.lblTitle.Text = "LOGIN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.AutoSize = true;

            // Username
            this.txtUser.Location = new System.Drawing.Point(50, 80);
            this.txtUser.Size = new System.Drawing.Size(250, 25);
            this.txtUser.Text = "Username";

            this.txtUser.GotFocus += new System.EventHandler(this.txtUser_GotFocus);
            this.txtUser.LostFocus += new System.EventHandler(this.txtUser_LostFocus);

            // Password
            this.txtPass.Location = new System.Drawing.Point(50, 120);
            this.txtPass.Size = new System.Drawing.Size(250, 25);
            this.txtPass.Text = "Password";

            this.txtPass.GotFocus += new System.EventHandler(this.txtPass_GotFocus);
            this.txtPass.LostFocus += new System.EventHandler(this.txtPass_LostFocus);

            // Show Password
            this.chkShow.Text = "Show password";
            this.chkShow.Location = new System.Drawing.Point(50, 150);
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);

            // Error Label
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(50, 180);
            this.lblError.Size = new System.Drawing.Size(250, 20);
            this.lblError.Visible = false;

            // Button Login
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(50, 210);
            this.btnLogin.Size = new System.Drawing.Size(250, 35);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // FORM
            this.ClientSize = new System.Drawing.Size(430, 380);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";

            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblError;
    }
}
