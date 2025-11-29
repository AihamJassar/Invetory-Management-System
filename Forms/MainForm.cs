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

            // إخفاء أزرار حسب الدور
            if (loggedUser.Role.ToLower() != "admin")
            {
                btnUsers.Enabled = false;
            }
        }


        private void BtnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm pf = new ProductsForm();
            pf.ShowDialog();
        }
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            UsersForm pf = new UsersForm();
            pf.ShowDialog();
        }
        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm cf = new CustomersForm();
            cf.ShowDialog();
        }
        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm sf = new SuppliersForm();
            sf.ShowDialog();
        }
        private void BtnInvoices_Click(object sender, EventArgs e)
        {
            InvoicesForm fr = new InvoicesForm();
            fr.ShowDialog();
        }
        private void BtnReports_Click(object sender, EventArgs e)
        {
            ReportsForm rf = new ReportsForm();
            rf.ShowDialog();
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm fr = new LoginForm();
            fr.ShowDialog();
        }

    }
}
