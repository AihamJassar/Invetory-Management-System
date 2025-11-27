using System;
using System.Windows.Forms;

namespace Invetory_Management_System.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReports;
        private Button btnExport;

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
            this.dgvReports = new DataGridView();
            this.btnExport = new Button();

            // ReportsForm
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Text = "Reports";
            this.StartPosition = FormStartPosition.CenterScreen;

            // dgvReports
            this.dgvReports.Location = new System.Drawing.Point(20, 20);
            this.dgvReports.Size = new System.Drawing.Size(650, 300);
            this.dgvReports.ReadOnly = true;
            this.dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // btnExport
            this.btnExport.Text = "Export";
            this.btnExport.Location = new System.Drawing.Point(20, 340);
            this.btnExport.Size = new System.Drawing.Size(120, 35);
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.btnExport);
        }

        #endregion
    }
}