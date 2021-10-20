namespace C968
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnProductSearch = new System.Windows.Forms.Button();
            this.txtbxProductSearch = new System.Windows.Forms.TextBox();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblParts = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.txtbxPartSearch = new System.Windows.Forms.TextBox();
            this.btnPartSearch = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnModifyPart = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProductSearch
            // 
            this.btnProductSearch.Location = new System.Drawing.Point(565, 50);
            this.btnProductSearch.Name = "btnProductSearch";
            this.btnProductSearch.Size = new System.Drawing.Size(50, 20);
            this.btnProductSearch.TabIndex = 0;
            this.btnProductSearch.Text = "Search";
            this.btnProductSearch.UseVisualStyleBackColor = true;
            // 
            // txtbxProductSearch
            // 
            this.txtbxProductSearch.Location = new System.Drawing.Point(620, 50);
            this.txtbxProductSearch.Name = "txtbxProductSearch";
            this.txtbxProductSearch.Size = new System.Drawing.Size(160, 20);
            this.txtbxProductSearch.TabIndex = 1;
            // 
            // dgvParts
            // 
            this.dgvParts.AutoGenerateColumns = false;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.DataSource = this.partBindingSource;
            this.dgvParts.Location = new System.Drawing.Point(5, 75);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.Size = new System.Drawing.Size(380, 200);
            this.dgvParts.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(335, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Inventory Management System";
            // 
            // lblParts
            // 
            this.lblParts.AutoSize = true;
            this.lblParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParts.Location = new System.Drawing.Point(5, 50);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(51, 20);
            this.lblParts.TabIndex = 3;
            this.lblParts.Text = "Parts";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(400, 50);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(80, 20);
            this.lblProducts.TabIndex = 3;
            this.lblProducts.Text = "Products";
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(225, 281);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(50, 20);
            this.btnAddPart.TabIndex = 0;
            this.btnAddPart.Text = "Add";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // txtbxPartSearch
            // 
            this.txtbxPartSearch.Location = new System.Drawing.Point(225, 50);
            this.txtbxPartSearch.Name = "txtbxPartSearch";
            this.txtbxPartSearch.Size = new System.Drawing.Size(160, 20);
            this.txtbxPartSearch.TabIndex = 1;
            // 
            // btnPartSearch
            // 
            this.btnPartSearch.Location = new System.Drawing.Point(170, 50);
            this.btnPartSearch.Name = "btnPartSearch";
            this.btnPartSearch.Size = new System.Drawing.Size(50, 20);
            this.btnPartSearch.TabIndex = 0;
            this.btnPartSearch.Text = "Search";
            this.btnPartSearch.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.DataSource = this.productBindingSource;
            this.dgvProducts.Location = new System.Drawing.Point(400, 75);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(380, 200);
            this.dgvProducts.TabIndex = 2;
            // 
            // btnModifyPart
            // 
            this.btnModifyPart.Location = new System.Drawing.Point(281, 281);
            this.btnModifyPart.Name = "btnModifyPart";
            this.btnModifyPart.Size = new System.Drawing.Size(50, 20);
            this.btnModifyPart.TabIndex = 0;
            this.btnModifyPart.Text = "Modify";
            this.btnModifyPart.UseVisualStyleBackColor = true;
            this.btnModifyPart.Click += new System.EventHandler(this.btnModifyPart_Click);
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(337, 281);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.Size = new System.Drawing.Size(50, 20);
            this.btnDeletePart.TabIndex = 0;
            this.btnDeletePart.Text = "Delete";
            this.btnDeletePart.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(732, 305);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 20);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(620, 281);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(50, 20);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Location = new System.Drawing.Point(676, 281);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(50, 20);
            this.btnModifyProduct.TabIndex = 0;
            this.btnModifyProduct.Text = "Modify";
            this.btnModifyProduct.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(732, 281);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(50, 20);
            this.btnDeleteProduct.TabIndex = 0;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(C968.Part);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(C968.Product);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblParts);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.txtbxPartSearch);
            this.Controls.Add(this.txtbxProductSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnDeletePart);
            this.Controls.Add(this.btnModifyProduct);
            this.Controls.Add(this.btnModifyPart);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.btnPartSearch);
            this.Controls.Add(this.btnProductSearch);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "frmMain";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProductSearch;
        private System.Windows.Forms.TextBox txtbxProductSearch;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.TextBox txtbxPartSearch;
        private System.Windows.Forms.Button btnPartSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnModifyPart;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnModifyProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.BindingSource partBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}

