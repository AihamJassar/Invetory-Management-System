using Invetory_Management_System.Models;
using Invetory_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Invetory_Management_System.Forms
{
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }

        SupplierService supplierService = new SupplierService();
        DataTable dt = new DataTable();

        private void SuppliersForm_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("المعرف");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("العنوان");
            dt.Columns.Add("الهاتف");
            dgvSuppliers.DataSource = dt;

            List<Supplier> suppliers = new List<Supplier>();
            suppliers = supplierService.GetAll();
            foreach (Supplier supplier in suppliers)
            {
                dt.Rows.Add(supplier.Id, supplier.Name, supplier.Address, supplier.Phone);
                dgvSuppliers.DataSource = dt;
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
                Supplier newSupplier = new Supplier
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                };

                Supplier supplier = supplierService.Add(newSupplier);
                if (supplier.Id == 0)
                {
                    MessageBox.Show("Failed to add supplier.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dt.Rows.Add(supplier.Id, supplier.Name, supplier.Address, supplier.Phone);
                dgvSuppliers.DataSource = dt;

                // تنظيف الحقول
                ClearFields();

                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            int id = int.Parse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString());

            Supplier updatedSupplier = updatedSupplier = new Supplier
            {
                Id = id,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };


            try
            {
                supplierService.Update(updatedSupplier);

                dgvSuppliers.CurrentRow.Cells[1].Value = txtName.Text;
                dgvSuppliers.CurrentRow.Cells[2].Value = txtAddress.Text;
                dgvSuppliers.CurrentRow.Cells[3].Value = txtPhone.Text;
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
                int id = int.Parse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString());
                int index = dgvSuppliers.CurrentCell.RowIndex;
                supplierService.Delete(id);
                dgvSuppliers.Rows.RemoveAt(index);
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
            txtName.Text = dgvSuppliers.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvSuppliers.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvSuppliers.CurrentRow.Cells[3].Value.ToString();
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
