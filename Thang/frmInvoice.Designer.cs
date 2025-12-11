namespace Thang
{
    partial class frmInvoice
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.cboStaffID = new System.Windows.Forms.ComboBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.cboCustomerID = new System.Windows.Forms.ComboBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.cboProductID = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSearchInvoice = new System.Windows.Forms.Label();
            this.cboSearchInvoice = new System.Windows.Forms.ComboBox();
            this.btnSearchInvoice = new System.Windows.Forms.Button();
            this.cboRice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(350, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sales Invoice Management";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.Location = new System.Drawing.Point(40, 60);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(100, 23);
            this.lblInvoiceID.TabIndex = 1;
            this.lblInvoiceID.Text = "Invoice ID";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(150, 58);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(180, 22);
            this.txtInvoiceID.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(40, 100);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(150, 98);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 22);
            this.dtpDate.TabIndex = 4;
            // 
            // lblStaffID
            // 
            this.lblStaffID.Location = new System.Drawing.Point(40, 140);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(100, 23);
            this.lblStaffID.TabIndex = 5;
            this.lblStaffID.Text = "Staff ID";
            // 
            // cboStaffID
            // 
            this.cboStaffID.Location = new System.Drawing.Point(150, 138);
            this.cboStaffID.Name = "cboStaffID";
            this.cboStaffID.Size = new System.Drawing.Size(180, 24);
            this.cboStaffID.TabIndex = 6;
            // 
            // lblStaffName
            // 
            this.lblStaffName.Location = new System.Drawing.Point(40, 180);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(100, 23);
            this.lblStaffName.TabIndex = 7;
            this.lblStaffName.Text = "Staff Name";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(150, 178);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(180, 22);
            this.txtStaffName.TabIndex = 8;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Location = new System.Drawing.Point(400, 60);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerID.TabIndex = 9;
            this.lblCustomerID.Text = "Customer ID";
            // 
            // cboCustomerID
            // 
            this.cboCustomerID.Location = new System.Drawing.Point(510, 58);
            this.cboCustomerID.Name = "cboCustomerID";
            this.cboCustomerID.Size = new System.Drawing.Size(180, 24);
            this.cboCustomerID.TabIndex = 10;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Location = new System.Drawing.Point(400, 100);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerName.TabIndex = 11;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(510, 98);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(180, 22);
            this.txtCustomerName.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(400, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(510, 138);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(180, 22);
            this.txtAddress.TabIndex = 14;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(400, 180);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 15;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(510, 178);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 22);
            this.txtPhone.TabIndex = 16;
            // 
            // lblProductID
            // 
            this.lblProductID.Location = new System.Drawing.Point(40, 240);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(100, 23);
            this.lblProductID.TabIndex = 17;
            this.lblProductID.Text = "Product ID";
            // 
            // cboProductID
            // 
            this.cboProductID.Location = new System.Drawing.Point(150, 238);
            this.cboProductID.Name = "cboProductID";
            this.cboProductID.Size = new System.Drawing.Size(180, 24);
            this.cboProductID.TabIndex = 18;
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(350, 240);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 23);
            this.lblProductName.TabIndex = 19;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(460, 238);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(160, 22);
            this.txtProductName.TabIndex = 20;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(630, 240);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 23);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "Price";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(40, 280);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblQuantity.TabIndex = 23;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(150, 278);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(180, 22);
            this.txtQty.TabIndex = 24;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(350, 280);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 23);
            this.lblSubtotal.TabIndex = 25;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(460, 278);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(160, 22);
            this.txtSubtotal.TabIndex = 26;
            // 
            // dgvBill
            // 
            this.dgvBill.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvBill.ColumnHeadersHeight = 29;
            this.dgvBill.Location = new System.Drawing.Point(40, 320);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.RowHeadersWidth = 51;
            this.dgvBill.Size = new System.Drawing.Size(790, 220);
            this.dgvBill.TabIndex = 27;
            this.dgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 560);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(460, 560);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 35);
            this.btnPrint.TabIndex = 31;
            this.btnPrint.Text = "Print";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(610, 560);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 35);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSearchInvoice
            // 
            this.lblSearchInvoice.Location = new System.Drawing.Point(40, 620);
            this.lblSearchInvoice.Name = "lblSearchInvoice";
            this.lblSearchInvoice.Size = new System.Drawing.Size(100, 23);
            this.lblSearchInvoice.TabIndex = 33;
            this.lblSearchInvoice.Text = "Invoice Search";
            // 
            // cboSearchInvoice
            // 
            this.cboSearchInvoice.Location = new System.Drawing.Point(150, 618);
            this.cboSearchInvoice.Name = "cboSearchInvoice";
            this.cboSearchInvoice.Size = new System.Drawing.Size(180, 24);
            this.cboSearchInvoice.TabIndex = 34;
            // 
            // btnSearchInvoice
            // 
            this.btnSearchInvoice.Location = new System.Drawing.Point(350, 615);
            this.btnSearchInvoice.Name = "btnSearchInvoice";
            this.btnSearchInvoice.Size = new System.Drawing.Size(120, 28);
            this.btnSearchInvoice.TabIndex = 35;
            this.btnSearchInvoice.Text = "Find Invoice";
            // 
            // cboRice
            // 
            this.cboRice.FormattingEnabled = true;
            this.cboRice.Location = new System.Drawing.Point(697, 240);
            this.cboRice.Name = "cboRice";
            this.cboRice.Size = new System.Drawing.Size(149, 24);
            this.cboRice.TabIndex = 36;
            // 
            // frmInvoice
            // 
            this.ClientSize = new System.Drawing.Size(873, 670);
            this.Controls.Add(this.cboRice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInvoiceID);
            this.Controls.Add(this.txtInvoiceID);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblStaffID);
            this.Controls.Add(this.cboStaffID);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.cboCustomerID);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.cboProductID);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.dgvBill);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblSearchInvoice);
            this.Controls.Add(this.cboSearchInvoice);
            this.Controls.Add(this.btnSearchInvoice);
            this.Name = "frmInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInvoiceID, lblDate, lblStaffID, lblStaffName, lblCustomerID, lblCustomerName, lblAddress, lblPhone;
        private System.Windows.Forms.Label lblProductID, lblProductName, lblPrice, lblQuantity, lblSubtotal, lblSearchInvoice;

        private System.Windows.Forms.TextBox txtInvoiceID, txtStaffName, txtCustomerName, txtAddress, txtPhone, txtProductName, txtQty, txtSubtotal;
        private System.Windows.Forms.ComboBox cboStaffID, cboCustomerID, cboProductID, cboSearchInvoice;
        private System.Windows.Forms.DateTimePicker dtpDate;

        private System.Windows.Forms.DataGridView dgvBill;

        private System.Windows.Forms.Button btnAdd, btnSave, btnCancel, btnPrint, btnExit, btnSearchInvoice;
        private System.Windows.Forms.ComboBox cboRice;
    }
}
