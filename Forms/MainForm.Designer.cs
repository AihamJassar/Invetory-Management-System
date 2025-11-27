using System;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnCustomers;
        private Button btnReports;
        private Button btnLogout;


        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
        private void InitializeComponent()
        {
            this.lblWelcome = new Label();
            this.btnProducts = new Button();
            this.btnSuppliers = new Button();
            this.btnCustomers = new Button();
            this.btnReports = new Button();
            this.btnLogout = new Button();

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Text = "Smart Inventory - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            // lblWelcome
            this.lblWelcome.Text = "Welcome, User";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.AutoSize = true;

            // btnProducts
            this.btnProducts.Text = "Products";
            this.btnProducts.Size = new System.Drawing.Size(120, 40);
            this.btnProducts.Location = new System.Drawing.Point(50, 80);
            this.btnProducts.Click += new EventHandler(this.btnProducts_Click);

            // btnSuppliers
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(120, 40);
            this.btnSuppliers.Location = new System.Drawing.Point(200, 80);
            this.btnSuppliers.Click += new EventHandler(this.btnSuppliers_Click);

            // btnCustomers
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.Size = new System.Drawing.Size(120, 40);
            this.btnCustomers.Location = new System.Drawing.Point(350, 80);
            this.btnCustomers.Click += new EventHandler(this.btnCustomers_Click);

            // btnReports
            this.btnReports.Text = "Reports";
            this.btnReports.Size = new System.Drawing.Size(120, 40);
            this.btnReports.Location = new System.Drawing.Point(50, 140);
            this.btnReports.Click += new EventHandler(this.btnReports_Click);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.Location = new System.Drawing.Point(200, 140);
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // Add Controls
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnLogout);
        }
    }
}