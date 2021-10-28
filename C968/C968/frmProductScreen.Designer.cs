namespace C968
{
    partial class frmProductScreen
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
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblPriceCost = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtbxMin = new System.Windows.Forms.TextBox();
            this.txtbxMax = new System.Windows.Forms.TextBox();
            this.txtbxPriceCost = new System.Windows.Forms.TextBox();
            this.txtbxInventory = new System.Windows.Forms.TextBox();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAllParts = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.txtbxPartSearch = new System.Windows.Forms.TextBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnPartSearch = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.dgvAssociatedParts = new System.Windows.Forms.DataGridView();
            this.lblAssociatedParts = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociatedParts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(170, 135);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(37, 20);
            this.lblMin.TabIndex = 13;
            this.lblMin.Text = "Min";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(65, 135);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(41, 20);
            this.lblMax.TabIndex = 14;
            this.lblMax.Text = "Max";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPriceCost
            // 
            this.lblPriceCost.AutoSize = true;
            this.lblPriceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceCost.Location = new System.Drawing.Point(7, 110);
            this.lblPriceCost.Name = "lblPriceCost";
            this.lblPriceCost.Size = new System.Drawing.Size(101, 20);
            this.lblPriceCost.TabIndex = 15;
            this.lblPriceCost.Text = "Price / Cost";
            this.lblPriceCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(25, 85);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(83, 20);
            this.lblInventory.TabIndex = 16;
            this.lblInventory.Text = "Inventory";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(50, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(75, 35);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 20);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtbxMin
            // 
            this.txtbxMin.Location = new System.Drawing.Point(210, 135);
            this.txtbxMin.Name = "txtbxMin";
            this.txtbxMin.Size = new System.Drawing.Size(60, 20);
            this.txtbxMin.TabIndex = 7;
            // 
            // txtbxMax
            // 
            this.txtbxMax.Location = new System.Drawing.Point(110, 135);
            this.txtbxMax.Name = "txtbxMax";
            this.txtbxMax.Size = new System.Drawing.Size(60, 20);
            this.txtbxMax.TabIndex = 8;
            // 
            // txtbxPriceCost
            // 
            this.txtbxPriceCost.Location = new System.Drawing.Point(110, 110);
            this.txtbxPriceCost.Name = "txtbxPriceCost";
            this.txtbxPriceCost.Size = new System.Drawing.Size(160, 20);
            this.txtbxPriceCost.TabIndex = 9;
            // 
            // txtbxInventory
            // 
            this.txtbxInventory.Location = new System.Drawing.Point(110, 85);
            this.txtbxInventory.Name = "txtbxInventory";
            this.txtbxInventory.Size = new System.Drawing.Size(160, 20);
            this.txtbxInventory.TabIndex = 10;
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(110, 60);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(160, 20);
            this.txtbxName.TabIndex = 11;
            // 
            // txtbxID
            // 
            this.txtbxID.Location = new System.Drawing.Point(110, 35);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.ReadOnly = true;
            this.txtbxID.Size = new System.Drawing.Size(160, 20);
            this.txtbxID.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 20);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Add Product";
            // 
            // lblAllParts
            // 
            this.lblAllParts.AutoSize = true;
            this.lblAllParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllParts.Location = new System.Drawing.Point(291, 35);
            this.lblAllParts.Name = "lblAllParts";
            this.lblAllParts.Size = new System.Drawing.Size(163, 20);
            this.lblAllParts.TabIndex = 24;
            this.lblAllParts.Text = "All Candidate Parts";
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.AllowUserToResizeRows = false;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(291, 60);
            this.dgvParts.MultiSelect = false;
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.ReadOnly = true;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParts.Size = new System.Drawing.Size(380, 100);
            this.dgvParts.TabIndex = 23;
            // 
            // txtbxPartSearch
            // 
            this.txtbxPartSearch.Location = new System.Drawing.Point(511, 35);
            this.txtbxPartSearch.Name = "txtbxPartSearch";
            this.txtbxPartSearch.Size = new System.Drawing.Size(160, 20);
            this.txtbxPartSearch.TabIndex = 22;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(621, 166);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(50, 20);
            this.btnAddPart.TabIndex = 20;
            this.btnAddPart.Text = "Add";
            this.btnAddPart.UseVisualStyleBackColor = true;
            // 
            // btnPartSearch
            // 
            this.btnPartSearch.Location = new System.Drawing.Point(456, 35);
            this.btnPartSearch.Name = "btnPartSearch";
            this.btnPartSearch.Size = new System.Drawing.Size(50, 20);
            this.btnPartSearch.TabIndex = 21;
            this.btnPartSearch.Text = "Search";
            this.btnPartSearch.UseVisualStyleBackColor = true;
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(621, 298);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.Size = new System.Drawing.Size(50, 20);
            this.btnDeletePart.TabIndex = 20;
            this.btnDeletePart.Text = "Delete";
            this.btnDeletePart.UseVisualStyleBackColor = true;
            // 
            // dgvAssociatedParts
            // 
            this.dgvAssociatedParts.AllowUserToAddRows = false;
            this.dgvAssociatedParts.AllowUserToDeleteRows = false;
            this.dgvAssociatedParts.AllowUserToResizeRows = false;
            this.dgvAssociatedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssociatedParts.Location = new System.Drawing.Point(291, 192);
            this.dgvAssociatedParts.MultiSelect = false;
            this.dgvAssociatedParts.Name = "dgvAssociatedParts";
            this.dgvAssociatedParts.ReadOnly = true;
            this.dgvAssociatedParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssociatedParts.Size = new System.Drawing.Size(380, 100);
            this.dgvAssociatedParts.TabIndex = 23;
            // 
            // lblAssociatedParts
            // 
            this.lblAssociatedParts.AutoSize = true;
            this.lblAssociatedParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssociatedParts.Location = new System.Drawing.Point(291, 167);
            this.lblAssociatedParts.Name = "lblAssociatedParts";
            this.lblAssociatedParts.Size = new System.Drawing.Size(283, 20);
            this.lblAssociatedParts.TabIndex = 24;
            this.lblAssociatedParts.Text = "Parts Associated with this Product";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(621, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 20);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 20);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmProductScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.lblAssociatedParts);
            this.Controls.Add(this.lblAllParts);
            this.Controls.Add(this.dgvAssociatedParts);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.txtbxPartSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeletePart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.btnPartSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblPriceCost);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtbxMin);
            this.Controls.Add(this.txtbxMax);
            this.Controls.Add(this.txtbxPriceCost);
            this.Controls.Add(this.txtbxInventory);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.txtbxID);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmProductScreen";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.frmProductScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociatedParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblPriceCost;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtbxMin;
        private System.Windows.Forms.TextBox txtbxMax;
        private System.Windows.Forms.TextBox txtbxPriceCost;
        private System.Windows.Forms.TextBox txtbxInventory;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAllParts;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.TextBox txtbxPartSearch;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnPartSearch;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.DataGridView dgvAssociatedParts;
        private System.Windows.Forms.Label lblAssociatedParts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}