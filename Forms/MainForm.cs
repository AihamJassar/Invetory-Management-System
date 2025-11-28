using Invetory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    public partial class MainForm : Form
    {
        private User loggedUser;
        public MainForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            lblWelcome.Text = $"Welcome, {loggedUser.Username} ({loggedUser.Role})";

            // إخفاء أزرار حسب الدور
            if (loggedUser.Role.ToLower() != "admin")
            {
                //btnUsers.Enabled = false; // مثال
            }
        }



        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm pf = new ProductsForm();
            pf.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm sf = new SuppliersForm();
            sf.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm cf = new CustomersForm();
            cf.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm rf = new ReportsForm();
            rf.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
