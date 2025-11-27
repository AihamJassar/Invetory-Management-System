using Invetory_Management_System.Models;
//using Invetory_Management_System.Services
using System;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    public partial class LoginForm : Form
    {
        private UserService userService = new UserService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = userService.Login(username, password);
            if (user != null)
            {
                MessageBox.Show($"Welcome {user.Username} ({user.Role})!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm main = new MainForm(user);
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
