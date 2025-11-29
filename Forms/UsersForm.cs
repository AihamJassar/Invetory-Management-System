using Invetory_Management_System.Models;
using Invetory_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        UserService userService = new UserService();
        DataTable dt = new DataTable();

        private void UsersForm_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("المعرف");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("الصلاحيه");
            dgvUsers.DataSource = dt;

            List<User> users = new List<User>();
            users = userService.GetAll();
            foreach (User user in users)
            {
                dt.Rows.Add(user.Id, user.Username, user.Role);
                dgvUsers.DataSource = dt;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = userService.Register(txtUsername.Text, txtPassword.Text, cmbRole.Text);
                if (user.Id == 0)
                {
                    MessageBox.Show("Failed to add user.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dt.Rows.Add(user.Id, user.Username, user.Role);
                dgvUsers.DataSource = dt;

                // تنظيف الحقول
                ClearFields();

                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdite_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());

            User updatedUser = updatedUser = new User
                {
                    Id = id,
                    Username = txtUsername.Text,
                    Role = cmbRole.Text,
                    PasswordHash = txtPassword.Text
                };
            

            try
            {
                userService.Update(updatedUser);
                
                dgvUsers.CurrentRow.Cells[1].Value = txtUsername.Text;
                dgvUsers.CurrentRow.Cells[2].Value = cmbRole.Text;
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
                int id = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
                int index = dgvUsers.CurrentCell.RowIndex;
                userService.Delete(id);
                dgvUsers.Rows.RemoveAt(index);
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
            txtUsername.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            cmbRole.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
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
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.Text = "user";
            txtUsername.Focus();
        }

    }
}
