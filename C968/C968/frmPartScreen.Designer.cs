namespace C968
{
    partial class frmPartScreen
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
            this.radInHouse = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radOutsourced = new System.Windows.Forms.RadioButton();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblPriceCost = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMachineID = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.txtbxInventory = new System.Windows.Forms.TextBox();
            this.txtbxPriceCost = new System.Windows.Forms.TextBox();
            this.txtbxMax = new System.Windows.Forms.TextBox();
            this.txtbxMachineIDCompanyName = new System.Windows.Forms.TextBox();
            this.txtbxMin = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radInHouse
            // 
            this.radInHouse.AutoSize = true;
            this.radInHouse.Location = new System.Drawing.Point(140, 5);
            this.radInHouse.Name = "radInHouse";
            this.radInHouse.Size = new System.Drawing.Size(68, 17);
            this.radInHouse.TabIndex = 0;
            this.radInHouse.TabStop = true;
            this.radInHouse.Text = "In-House";
            this.radInHouse.UseVisualStyleBackColor = true;
            this.radInHouse.CheckedChanged += new System.EventHandler(this.radInHouse_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 20);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Add Part";
            // 
            // txtbxID
            // 
            this.txtbxID.Location = new System.Drawing.Point(135, 50);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.ReadOnly = true;
            this.txtbxID.Size = new System.Drawing.Size(160, 20);
            this.txtbxID.TabIndex = 5;
            this.txtbxID.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 20);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radOutsourced
            // 
            this.radOutsourced.AutoSize = true;
            this.radOutsourced.Location = new System.Drawing.Point(220, 5);
            this.radOutsourced.Name = "radOutsourced";
            this.radOutsourced.Size = new System.Drawing.Size(80, 17);
            this.radOutsourced.TabIndex = 1;
            this.radOutsourced.TabStop = true;
            this.radOutsourced.Text = "Outsourced";
            this.radOutsourced.UseVisualStyleBackColor = true;
            this.radOutsourced.CheckedChanged += new System.EventHandler(this.radOutsourced_CheckedChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(100, 50);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 20);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(75, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(50, 100);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(83, 20);
            this.lblInventory.TabIndex = 6;
            this.lblInventory.Text = "Inventory";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPriceCost
            // 
            this.lblPriceCost.AutoSize = true;
            this.lblPriceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceCost.Location = new System.Drawing.Point(32, 125);
            this.lblPriceCost.Name = "lblPriceCost";
            this.lblPriceCost.Size = new System.Drawing.Size(101, 20);
            this.lblPriceCost.TabIndex = 6;
            this.lblPriceCost.Text = "Price / Cost";
            this.lblPriceCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(90, 150);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(41, 20);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(195, 150);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(37, 20);
            this.lblMin.TabIndex = 6;
            this.lblMin.Text = "Min";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMachineID
            // 
            this.lblMachineID.AutoSize = true;
            this.lblMachineID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineID.Location = new System.Drawing.Point(30, 175);
            this.lblMachineID.Name = "lblMachineID";
            this.lblMachineID.Size = new System.Drawing.Size(100, 20);
            this.lblMachineID.TabIndex = 6;
            this.lblMachineID.Text = "Machine ID";
            this.lblMachineID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(135, 75);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(160, 20);
            this.txtbxName.TabIndex = 2;
            this.txtbxName.TextChanged += new System.EventHandler(this.txtbxName_TextChanged);
            // 
            // txtbxInventory
            // 
            this.txtbxInventory.Location = new System.Drawing.Point(135, 100);
            this.txtbxInventory.Name = "txtbxInventory";
            this.txtbxInventory.Size = new System.Drawing.Size(160, 20);
            this.txtbxInventory.TabIndex = 3;
            this.txtbxInventory.TextChanged += new System.EventHandler(this.txtbxInventory_TextChanged);
            // 
            // txtbxPriceCost
            // 
            this.txtbxPriceCost.Location = new System.Drawing.Point(135, 125);
            this.txtbxPriceCost.Name = "txtbxPriceCost";
            this.txtbxPriceCost.Size = new System.Drawing.Size(160, 20);
            this.txtbxPriceCost.TabIndex = 4;
            this.txtbxPriceCost.TextChanged += new System.EventHandler(this.txtbxPriceCost_TextChanged);
            // 
            // txtbxMax
            // 
            this.txtbxMax.Location = new System.Drawing.Point(135, 150);
            this.txtbxMax.Name = "txtbxMax";
            this.txtbxMax.Size = new System.Drawing.Size(60, 20);
            this.txtbxMax.TabIndex = 5;
            this.txtbxMax.TextChanged += new System.EventHandler(this.txtbxMax_TextChanged);
            // 
            // txtbxMachineIDCompanyName
            // 
            this.txtbxMachineIDCompanyName.Location = new System.Drawing.Point(135, 173);
            this.txtbxMachineIDCompanyName.Name = "txtbxMachineIDCompanyName";
            this.txtbxMachineIDCompanyName.Size = new System.Drawing.Size(160, 20);
            this.txtbxMachineIDCompanyName.TabIndex = 7;
            this.txtbxMachineIDCompanyName.TextChanged += new System.EventHandler(this.txtbxMachineIDCompanyName_TextChanged);
            // 
            // txtbxMin
            // 
            this.txtbxMin.Location = new System.Drawing.Point(235, 150);
            this.txtbxMin.Name = "txtbxMin";
            this.txtbxMin.Size = new System.Drawing.Size(60, 20);
            this.txtbxMin.TabIndex = 6;
            this.txtbxMin.TextChanged += new System.EventHandler(this.txtbxMin_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(185, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 20);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(-2, 175);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(134, 20);
            this.lblCompanyName.TabIndex = 7;
            this.lblCompanyName.Text = "Company Name";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCompanyName.Visible = false;
            // 
            // frmPartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 236);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblMachineID);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblPriceCost);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtbxMachineIDCompanyName);
            this.Controls.Add(this.txtbxMin);
            this.Controls.Add(this.txtbxMax);
            this.Controls.Add(this.txtbxPriceCost);
            this.Controls.Add(this.txtbxInventory);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radOutsourced);
            this.Controls.Add(this.radInHouse);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 275);
            this.MinimumSize = new System.Drawing.Size(325, 275);
            this.Name = "frmPartScreen";
            this.Text = "Part";
            this.Load += new System.EventHandler(this.frmPartScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radInHouse;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radOutsourced;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblPriceCost;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMachineID;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.TextBox txtbxInventory;
        private System.Windows.Forms.TextBox txtbxPriceCost;
        private System.Windows.Forms.TextBox txtbxMax;
        private System.Windows.Forms.TextBox txtbxMachineIDCompanyName;
        private System.Windows.Forms.TextBox txtbxMin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCompanyName;
    }
}