using Invetory_Management_System.Models;
using Invetory_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        ProductService productService = new ProductService();
        DataTable dt = new DataTable();

        private void ProductsForm_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("المعرف");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("الفئة");
            dt.Columns.Add("السعر", typeof(int));
            dt.Columns.Add("الكمية", typeof(int));
            dgvProducts.DataSource = dt;

            List<Product> products = new List<Product>();
            products = productService.GetAll();
            foreach (Product product in products)
            {
                dt.Rows.Add(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                dgvProducts.DataSource = dt;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // التحقق من أن الكمية والسعر أرقام
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = new Product
            {
                Name = txtName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Quantity = quantity,
                Price = price
            };

            try
            {
                product = productService.Add(product);
                if (product.Id == 0)
                {
                    MessageBox.Show("Failed to add product.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dt.Rows.Add(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                dgvProducts.DataSource = dt;

                // تنظيف الحقول
                ClearFields();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdite_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());

            Product updatedProduct = new Product
            {
                Id = id,
                Name = txtName.Text,
                Category = txtCategory.Text,
                Price = int.Parse(txtPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
            };

            try
            {
            productService.Update(updatedProduct);

            dgvProducts.CurrentRow.Cells[1].Value = txtName.Text;
            dgvProducts.CurrentRow.Cells[2].Value = txtCategory.Text;
            dgvProducts.CurrentRow.Cells[3].Value = txtPrice.Text;
            dgvProducts.CurrentRow.Cells[4].Value = txtQuantity.Text;
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
                int id = int.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());
                int index = dgvProducts.CurrentCell.RowIndex;
                productService.Delete(id);
                dgvProducts.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvProducts_SelectionChanged(null, null);
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtCategory.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtQuantity.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
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
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtName.Focus();
        }


    }
}
