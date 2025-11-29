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
            this.btnEidte = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1441, 719);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEidte);
            this.Name = "ProductsForm";
            this.Text = "L";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(-1, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1441, 100);
            this.pnlHeader.TabIndex = 12;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(571, 23);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(272, 45);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = " إدارة المنتجات";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(1302, 185);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 24);
            this.lblName.TabIndex = 7;
            this.lblName.Text = ": الاسم";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(1019, 185);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(259, 22);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCategory.Location = new System.Drawing.Point(1302, 242);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 24);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = ": الفئة";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(1022, 242);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(257, 22);
            this.txtCategory.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantity.Location = new System.Drawing.Point(1286, 310);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(82, 24);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = ": الكمية";
            this.txtName.TabIndex = 4;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(1233, 310);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(45, 22);
            this.txtQuantity.TabIndex = 6;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrice.Location = new System.Drawing.Point(1072, 310);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(81, 24);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = ": السعر";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(1019, 310);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(45, 22);
            this.txtPrice.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1187, 378);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 51);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEidte
            // 
            this.btnEidte.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEidte.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEidte.ForeColor = System.Drawing.Color.White;
            this.btnEidte.Location = new System.Drawing.Point(1019, 435);
            this.btnEidte.Name = "btnEidte";
            this.btnEidte.Size = new System.Drawing.Size(158, 51);
            this.btnEidte.TabIndex = 0;
            this.btnEidte.Text = "تعديل";
            this.btnEidte.UseVisualStyleBackColor = false;
            this.btnEidte.Click += new System.EventHandler(this.BtnEdite_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1187, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 51);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Sienna;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1019, 378);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 51);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1022, 492);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(323, 51);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(33, 165);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 26;
            this.dgvProducts.Size = new System.Drawing.Size(866, 500);
            this.dgvProducts.TabIndex = 16;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellClick);
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.DgvProducts_SelectionChanged);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEidte;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvProducts;
        #endregion
    }
}