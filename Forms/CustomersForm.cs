using Invetory_Management_System.Models;
using Invetory_Management_System.Services;
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
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        CustomerService customerService = new CustomerService();
        DataTable dt = new DataTable();

        private void CustomersForm_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("المعرف");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("العنوان");
            dt.Columns.Add("الهاتف");
            dgvCustomers.DataSource = dt;

            List<Customer> customers = new List<Customer>();
            customers = customerService.GetAll();
            foreach (Customer customer in customers)
            {
                dt.Rows.Add(customer.Id, customer.Name, customer.Address, customer.Phone);
                dgvCustomers.DataSource = dt;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer newCustomer = new Customer
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                };

                Customer customer = customerService.Add(newCustomer);
                if (customer.Id == 0)
                {
                    MessageBox.Show("Failed to add customer.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dt.Rows.Add(customer.Id, customer.Name, customer.Address, customer.Phone);
                dgvCustomers.DataSource = dt;

                // تنظيف الحقول
                ClearFields();

                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdite_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());

            Customer updatedCustomer = updatedCustomer = new Customer
            {
                Id = id,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };


            try
            {
                customerService.Update(updatedCustomer);

                dgvCustomers.CurrentRow.Cells[1].Value = txtName.Text;
                dgvCustomers.CurrentRow.Cells[2].Value = txtAddress.Text;
                dgvCustomers.CurrentRow.Cells[3].Value = txtPhone.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                int index = dgvCustomers.CurrentCell.RowIndex;
                customerService.Delete(id);
                dgvCustomers.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvUsers_SelectionChanged(null, null);
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            txtName.Text = dgvCustomers.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvCustomers.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvCustomers.CurrentRow.Cells[3].Value.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Show();
            Close();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtName.Focus();
        }

    }
}
