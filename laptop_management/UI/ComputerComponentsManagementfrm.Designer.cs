using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class ComputerComponentsManagementfrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnOrderdetail = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnComponent = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnManage = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblHeader.Location = new System.Drawing.Point(462, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(427, 54);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THUẬN PHÁT MOBLE";
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlOptions.Controls.Add(this.btnLogOut);
            this.pnlOptions.Controls.Add(this.btnOrderdetail);
            this.pnlOptions.Controls.Add(this.pictureBox1);
            this.pnlOptions.Controls.Add(this.btnComponent);
            this.pnlOptions.Controls.Add(this.btnEmployee);
            this.pnlOptions.Controls.Add(this.btnOrder);
            this.pnlOptions.Controls.Add(this.btnCustomer);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.pnlOptions.ForeColor = System.Drawing.Color.Azure;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(246, 680);
            this.pnlOptions.TabIndex = 1;
            // 
            // btnOrderdetail
            // 
            this.btnOrderdetail.BackColor = System.Drawing.Color.DimGray;
            this.btnOrderdetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderdetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrderdetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOrderdetail.Location = new System.Drawing.Point(12, 527);
            this.btnOrderdetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderdetail.Name = "btnOrderdetail";
            this.btnOrderdetail.Size = new System.Drawing.Size(223, 48);
            this.btnOrderdetail.TabIndex = 6;
            this.btnOrderdetail.Text = "CHI TIẾT HÓA ĐƠN";
            this.btnOrderdetail.UseVisualStyleBackColor = false;
            this.btnOrderdetail.Click += new System.EventHandler(this.btnOrderdetail_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources.OIG2_lPIHED;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(33, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 127);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnComponent
            // 
            this.btnComponent.BackColor = System.Drawing.Color.DimGray;
            this.btnComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnComponent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnComponent.Location = new System.Drawing.Point(12, 445);
            this.btnComponent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnComponent.Name = "btnComponent";
            this.btnComponent.Size = new System.Drawing.Size(223, 48);
            this.btnComponent.TabIndex = 3;
            this.btnComponent.Text = "SẢN PHẨM";
            this.btnComponent.UseVisualStyleBackColor = false;
            this.btnComponent.Click += new System.EventHandler(this.btnComponent_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.DimGray;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEmployee.Location = new System.Drawing.Point(12, 285);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(223, 48);
            this.btnEmployee.TabIndex = 4;
            this.btnEmployee.Text = "NHÂN VIÊN";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.DimGray;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOrder.Location = new System.Drawing.Point(12, 364);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(223, 48);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "HÓA ĐƠN";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.DimGray;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCustomer.Location = new System.Drawing.Point(12, 201);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(223, 48);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "KHÁCH HÀNG";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.guna2ControlBox1);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(246, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1250, 59);
            this.pnlHeader.TabIndex = 2;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Silver;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1193, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // pnManage
            // 
            this.pnManage.BackColor = System.Drawing.Color.Transparent;
            this.pnManage.BackgroundImage = global::UI.Properties.Resources.Untitled_design;
            this.pnManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnManage.ForeColor = System.Drawing.Color.Transparent;
            this.pnManage.Location = new System.Drawing.Point(246, 59);
            this.pnManage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnManage.Name = "pnManage";
            this.pnManage.Size = new System.Drawing.Size(1250, 621);
            this.pnManage.TabIndex = 3;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DimGray;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogOut.Location = new System.Drawing.Point(12, 606);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(223, 48);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "LOGOUT";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // ComputerComponentsManagementfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1496, 680);
            this.Controls.Add(this.pnManage);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlOptions);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComputerComponentsManagementfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Componets Management";
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Button btnEmployee;
        private Button btnComponent;
        private Button btnOrder;
        private Button btnCustomer;
        private Panel pnlHeader;
        private Panel pnlOptions;
        private Panel pnManage;
        private PictureBox pictureBox1;
        private Button btnOrderdetail;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Button btnLogOut;
    }
}