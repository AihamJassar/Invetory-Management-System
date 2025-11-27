using System;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

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
        private void InitializeComponent()
        {
            this.dgvProducts = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            // ProductsForm
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Text = "Products Management";
            this.StartPosition = FormStartPosition.CenterScreen;

            // dgvProducts
            this.dgvProducts.Location = new System.Drawing.Point(20, 20);
            this.dgvProducts.Size = new System.Drawing.Size(650, 250);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // btnAdd
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(20, 300);
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(140, 300);
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(260, 300);
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
        }

        #endregion
    }
}