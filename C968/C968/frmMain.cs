// Components in use.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{    
    public partial class frmMain : Form
    {

        // Create binding sources.
        BindingSource partsSource = new BindingSource();
        BindingSource productsSource = new BindingSource();

        // Initialize the form.
        public frmMain()
        {
            InitializeComponent();
        }

        // Load the form.
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Ensuring same start position each time.
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Attach sources
            partsSource.DataSource = MainInventory.inv.dtblParts;
            productsSource.DataSource = MainInventory.inv.dtblProducts;

            // Attach our inventory tables.
            dgvParts.DataSource = partsSource;
            dgvProducts.DataSource = productsSource;

            // Ensure we save our inventory on form closing.
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }
        // Load the Add Part form.
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            var frmParts = new frmPartScreen(-1);
            frmParts.ShowDialog();
        }
        // Exit the form.
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Save our inventory.
            MainInventory.inv.saveInventory();

            // Exit.
            Environment.Exit(0);
        }
        // Load the Add Product form.
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var frmProducts = new frmProductScreen(-1);
            frmProducts.ShowDialog();
        }
        // Load the Add Part form with a part loaded.
        private void btnModifyPart_Click(object sender, EventArgs e)
        {
            // Get our selected part and part ID.
            int selectedRowCount = dgvParts.CurrentCell.RowIndex;
            int selectedPartID = Convert.ToInt32(dgvParts.Rows[selectedRowCount].Cells[0].Value);

            // Pass it to the form.
            var frmParts = new frmPartScreen(selectedPartID);
            frmParts.ShowDialog();
        }
        // Load the Add Product form with a product loaded.
        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            // Get our selected product and product ID.
            int selectedRowCount = dgvProducts.CurrentCell.RowIndex;
            int selectedProductID = Convert.ToInt32(dgvProducts.Rows[selectedRowCount].Cells[0].Value);

            // Pass it to the form.
            var frmProducts = new frmProductScreen(selectedProductID);
            frmProducts.ShowDialog();
        }

        // Take our selected part, and delete it.
        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgvParts.CurrentCell.RowIndex;

            string selectedPartID = Convert.ToString(dgvParts.Rows[selectedRowCount].Cells[0].Value);

            string selectedPartName = Convert.ToString(dgvParts.Rows[selectedRowCount].Cells[1].Value);

            string msg = "Are you sure you wish to delete Part # " + selectedPartID + ", " + selectedPartName;

            DialogResult = MessageBox.Show(msg, "Confirm Delete Part", MessageBoxButtons.YesNo);

            // If message box response confirms ....
            if (DialogResult == DialogResult.Yes) 
            {
                // Delete the row from the table object.                
                // Create a temporary product.
                Product tmpProduct = new Product();
                // Delete the item.
                bool deleted = tmpProduct.deletePart(tmpProduct.lookupPart(Convert.ToInt32(selectedPartID)));
                if (deleted == false)
                {
                    MessageBox.Show("Error, part is affiliated with products. Remove associations and try again.");
                }

            }

            // Else ...
            else if (DialogResult == DialogResult.No)
            {
                //Do nothing
            }
        }

        // Take our selected product, and delete it.
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgvProducts.CurrentCell.RowIndex;

            string selectedPartID = Convert.ToString(dgvProducts.Rows[selectedRowCount].Cells[0].Value);

            string selectedPartName = Convert.ToString(dgvProducts.Rows[selectedRowCount].Cells[1].Value);

            string msg = "Are you sure you wish to delete Part # " + selectedPartID + ", " + selectedPartName;

            DialogResult = MessageBox.Show(msg, "Confirm Delete Part", MessageBoxButtons.YesNo);

            // If message box response confirms ....
            if (DialogResult == DialogResult.Yes)
            {
                // Delete the row from the table object.                
                // Create a temporary product.
                Product tmpProduct = new Product();
                // Delete the item.
                bool deleted = tmpProduct.deletePart(tmpProduct.lookupProduct(Convert.ToInt32(selectedPartID)));
            }

            // Else ...
            else if (DialogResult == DialogResult.No)
            {
                //Do nothing
            }
        }

        // Action on form close.
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save our inventory file.
            MainInventory.inv.saveInventory();
        }
        // UI feature to double click and modify a row.
        private void dgvParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get our selected part and part ID.
            int selectedRowCount = dgvParts.CurrentCell.RowIndex;
            int selectedPartID = Convert.ToInt32(dgvParts.Rows[selectedRowCount].Cells[0].Value);

            // Pass it to the form.
            var frmParts = new frmPartScreen(selectedPartID);
            frmParts.ShowDialog();
        }

        // Clear our search filters.
        private void txtbxPartSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtbxPartSearch.Text == null || txtbxPartSearch.Text == "")
            {
                partsSource.Filter = null;
            }
        }
        // Clear our search filters.
        private void txtbxProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtbxProductSearch.Text == null || txtbxProductSearch.Text == "")
            {
                productsSource.Filter = null;
            }
        }

        private void btnPartSearch_Click(object sender, EventArgs e)
        {
            // Initial filter that always runs.
            partsSource.Filter = string.Format("Name LIKE '%{0}%'", txtbxPartSearch.Text);

            // If the box is only a number and as such could be matched to the ID column ...
            int parsedValue;
            if (int.TryParse(txtbxPartSearch.Text, out parsedValue))
            {
                // Add the ability to search by ID.                
                partsSource.Filter = string.Format("convert([Part ID], 'System.String') Like '%{0}%' OR Name LIKE '%{0}%'", txtbxPartSearch.Text);
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            // Initial filter that always runs.
            productsSource.Filter = string.Format("Name LIKE '%{0}%'", txtbxProductSearch.Text);

            // If the box is only a number and as such could be matched to the ID column ...
            int parsedValue;
            if (int.TryParse(txtbxProductSearch.Text, out parsedValue))
            {
                // Add the ability to search by ID.                
                productsSource.Filter = string.Format("convert([Product ID], 'System.String') Like '%{0}%' OR Name LIKE '%{0}%'", txtbxProductSearch.Text);
            }

        }
    }
}
