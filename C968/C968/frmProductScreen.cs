// Components in use.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // The form itself. Note that we're using a single form for both adding and modifying.
    public partial class frmProductScreen : Form
    {
        // Validation and save tracking.
        private bool valid;
        private bool saved;
        public string validationErrors;

        // Creating a candidate parts table and a current parts table.
        private DataTable candidateParts = new DataTable();
        private DataTable currentParts = new DataTable();

        // Creating a product so we can use its methods.
        private Product tmpProduct = new Product();

        // Create a list for our component IDs.
        List<int> componentIDs = new List<int>();

        // Create binding sources.
        BindingSource candidateSource = new BindingSource();
        BindingSource currentSource = new BindingSource();

        public frmProductScreen(int productID)
        {
            InitializeComponent();

            // Create a new product.
            Product objProduct = new Product();

            // Add columns to data tables.
            candidateParts.Columns.Add("Part ID");
            candidateParts.Columns.Add("Name");
            candidateParts.Columns.Add("Inventory");
            candidateParts.Columns.Add("Price");
            candidateParts.Columns.Add("Min");
            candidateParts.Columns.Add("Max");

            currentParts.Columns.Add("Part ID");
            currentParts.Columns.Add("Name");
            currentParts.Columns.Add("Inventory");
            currentParts.Columns.Add("Price");
            currentParts.Columns.Add("Min");
            currentParts.Columns.Add("Max");

            // If we have been handed a product, we must populate everything.
            if (productID != -1)
            {
                txtbxID.Text = Convert.ToString(productID);
                objProduct = ((Product)tmpProduct.lookupProduct(productID));
                txtbxInventory.Text = Convert.ToString(objProduct.InStock);
                txtbxName.Text = objProduct.Name;
                txtbxMin.Text = Convert.ToString(objProduct.Min);
                txtbxMax.Text = Convert.ToString(objProduct.Max);
                txtbxPriceCost.Text = Convert.ToString(objProduct.Price);

                // Only do this if the list isnt null.
                if (objProduct.AssociatedParts != null)
                {
                    foreach (Part objLine in objProduct.AssociatedParts)
                    {
                        componentIDs.Add(objLine.PartID);
                    }
                }
            }
            populateCandidates();

            // Validate the form on load.
            valid = validateForm();
            saved = true;
        }
        private void populateCandidates()
        {
            // Clear current tables.
            // The project calls for us to not remove parts from the top list. Only removing current parts items.
            // candidateParts.Clear();
            currentParts.Clear();

            // For each ...
            foreach (Part objLine in MainInventory.inv.lstAllParts)
            {
                // Ignore the line if it's a product.
                if (objLine is Product) { continue; }
                // Add the part to the current parts list if it's in the int list.
                if (componentIDs.Contains(objLine.PartID))
                {
                    currentParts.Rows.Add(objLine.PartID, objLine.Name, objLine.InStock, objLine.Price, objLine.Min, objLine.Max);
                }
                // If we make it here, add the part.
                if (!(componentIDs.Contains(objLine.PartID)))
                {
                    // The project calls for us to not remove parts from the top list.
                    // candidateParts.Rows.Add(objLine.PartID, objLine.Name, objLine.InStock, objLine.Price, objLine.Min, objLine.Max);
                }
            }

            // Load sources
            candidateSource.ResetBindings(false);
            currentSource.ResetBindings(false);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductScreen_Load(object sender, EventArgs e)
        {
            // Ensuring same start position each time.
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Load sources
            // Replaced candidatep parts with MainInventory.inv.dtblParts
            candidateSource.DataSource = MainInventory.inv.dtblParts;
            currentSource.DataSource = currentParts;

            // Bind.
            dgvAssociatedParts.DataSource = currentSource;
            dgvParts.DataSource = candidateSource;

            // Ensure we check for saved status on close.
            this.FormClosing += new FormClosingEventHandler(frmProductScreen_FormClosing);
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            addPart();
        }

        private void dgvParts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addPart();
        }
        private void addPart()
        {
            // Determine our selected row.
            int selectedRowCount = dgvParts.CurrentCell.RowIndex;
            // Determine our selected row ID.
            int selectedPartID = Convert.ToInt32(dgvParts.Rows[selectedRowCount].Cells[0].Value);

            // Remove our list item.
            componentIDs.Add(selectedPartID);
            // Populate our candidates.
            populateCandidates();
        }
        private void removePart()
        {
            // Determine our selected row.
            int selectedRowCount = dgvAssociatedParts.CurrentCell.RowIndex;
            // Determine our selected row ID.
            int selectedPartID = Convert.ToInt32(dgvAssociatedParts.Rows[selectedRowCount].Cells[0].Value);

            // Remove our list item.
            componentIDs.RemoveAll(item => item == selectedPartID);
            // Populate our candidates.
            populateCandidates();

        }
        private void dgvAssociatedParts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowCount = dgvAssociatedParts.CurrentCell.RowIndex;

            string selectedPartID = Convert.ToString(dgvAssociatedParts.Rows[selectedRowCount].Cells[0].Value);

            string selectedPartName = Convert.ToString(dgvAssociatedParts.Rows[selectedRowCount].Cells[1].Value);

            string msg = "Are you sure you wish to delete Part # " + selectedPartID + ", " + selectedPartName + " from the associated parts list?";

            DialogResult result = MessageBox.Show(msg, "Confirm Delete Part", MessageBoxButtons.YesNo);

            // If no ...
            if (result == DialogResult.No)
            {
                //Do nothing
                return;
            }
            // If message box response confirms ....
            if (result == DialogResult.Yes)
            {
                // Delete the row from the table object.                
                removePart();
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgvAssociatedParts.CurrentCell.RowIndex;

            string selectedPartID = Convert.ToString(dgvAssociatedParts.Rows[selectedRowCount].Cells[0].Value);

            string selectedPartName = Convert.ToString(dgvAssociatedParts.Rows[selectedRowCount].Cells[1].Value);

            string msg = "Are you sure you wish to delete Part # " + selectedPartID + ", " + selectedPartName + " from the associated parts list?";

            DialogResult result = MessageBox.Show(msg, "Confirm Delete Part", MessageBoxButtons.YesNo);

            // If no ...
            if (result == DialogResult.No)
            {
                //Do nothing
                return;
            }
            // If message box response confirms ....
            if (result == DialogResult.Yes)
            {
                // Delete the row from the table object.                
                removePart();
            }
        }
        private bool validateForm()
        {
            // Set to valid, unless we find a problem.
            valid = true;
            // Reset error string.
            validationErrors = "";
            // Reset the colors.
            txtbxName.BackColor = Color.White;
            txtbxInventory.BackColor = Color.White;
            txtbxPriceCost.BackColor = Color.White;
            txtbxMax.BackColor = Color.White;
            txtbxMin.BackColor = Color.White;

            // Validation logic.
            // Name can't be blank and can't contain a comma.
            if (txtbxName.Text == "" || txtbxName.Text == null || txtbxName.Text.Contains("."))
            {

                validationErrors += Environment.NewLine;
                validationErrors += "Name can not be empty.";
                txtbxName.BackColor = Color.Salmon;
                valid = false;
            }
            // Inventory can't be blank and must be positive numeric or zero.
            if (txtbxInventory.Text == "" || txtbxInventory.Text == null || Regex.IsMatch(txtbxInventory.Text, "[^0-9]"))
            {
                validationErrors += Environment.NewLine;
                validationErrors += "Inventory can not be empty and must be a positive whole number or zero.";
                txtbxInventory.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate that cost isn't blank.
            if (txtbxPriceCost.Text == "" || txtbxPriceCost.Text == null)
            {
                validationErrors += Environment.NewLine;
                validationErrors += "Price can not be empty.";
                txtbxPriceCost.BackColor = Color.Salmon;
                valid = false;
            }
            // Validatioin if there's a decimal
            if (txtbxPriceCost.Text.Contains("."))
            {
                bool invalidAmt = false;
                // Look for a decimal.
                string[] tempSplit = txtbxPriceCost.Text.Split('.');
                // If there isn't a decimal, we should only have one. If there is, we should have two.
                // If there are too many decimals, we make it invalid.
                if (tempSplit.Length > 2)
                {
                    invalidAmt = true;
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
                // If we have the correct amount, we now need to validate both sides and ensure we only have two decimal places.
                if (tempSplit.Length == 2)
                {
                    // We want 1 or 2 decimal places. No more, no less.
                    if (tempSplit[1].Length == 0 || tempSplit[1].Length > 2)
                    {
                        invalidAmt = true;
                        txtbxPriceCost.BackColor = Color.Salmon;
                        valid = false;
                    }
                    // We want to ensure that the position after the decimal is only numeric.
                    // We are already invalid if we have a [2] or higher, so we only need to check [1].
                    if (Regex.IsMatch(tempSplit[1], "[^0-9]"))
                    {
                        invalidAmt = true;
                        txtbxPriceCost.BackColor = Color.Salmon;
                        valid = false;
                    }
                }
                // Finally, confirm that we only have integers not counting our decimal on the left.
                if (Regex.IsMatch(tempSplit[0], "[^0-9]") || invalidAmt == true)
                {
                    validationErrors += Environment.NewLine;
                    validationErrors += "Price must be valid and numeric, either whole number or a max of two decimal places.";
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
            }
            // Validation if there is not a decimal.
            if (!txtbxPriceCost.Text.Contains("."))
            {
                if (Regex.IsMatch(txtbxPriceCost.Text, "[^0-9]"))
                {
                    validationErrors += Environment.NewLine;
                    validationErrors += "Price must be valid and numeric, either whole number or a max of two decimal places.";
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
            }
            // Validate Max - Must not be null, must be only positive integers or 0, and must be greater than or equal to min.
            if (txtbxMax.Text == "" || txtbxMax.Text == null || Regex.IsMatch(txtbxMax.Text, "[^0-9]"))
            {
                validationErrors += Environment.NewLine;
                validationErrors += "Maximum inventory should be a positive whole number.";
                txtbxMax.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate Inventory - Must not be null, must be only positive integers or 0, and must be greater than or equal to min.
            if (!(txtbxMax.Text == "" || txtbxMax.Text == null || Regex.IsMatch(txtbxMax.Text, "[^0-9]")))
            {
                if (!(txtbxMin.Text == "" || txtbxMin.Text == null || Regex.IsMatch(txtbxMin.Text, "[^0-9]")))
                {
                    if (!(txtbxInventory.Text == "" || txtbxInventory.Text == null || Regex.IsMatch(txtbxInventory.Text, "[^0-9]")))
                    {
                        if (Convert.ToInt32(txtbxInventory.Text) <= Convert.ToInt32(txtbxMin.Text) || Convert.ToInt32(txtbxInventory.Text) >= Convert.ToInt32(txtbxMax.Text))
                        {
                            validationErrors += Environment.NewLine;
                            validationErrors += "Current inventory must be between the maximum and minimum values.";
                            txtbxInventory.BackColor = Color.Salmon;
                            valid = false;
                        }
                    }
                }
            }
            // Validate Min - Must not be null, must be only positive integers or 0, and must be less or equal to Max.
            if (txtbxMin.Text == "" || txtbxMin.Text == null || Regex.IsMatch(txtbxMin.Text, "[^0-9]"))
            {
                validationErrors += Environment.NewLine;
                validationErrors += "Minimum inventory should be a positive whole number or zero.";
                txtbxMin.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate that Max is > Min
            try
            {
                if (!(Convert.ToInt32(txtbxMax.Text) > Convert.ToInt32(txtbxMin.Text)))
                {
                    validationErrors += Environment.NewLine;
                    validationErrors += "Maximum inventory should be greater than the minimum.";
                    txtbxMin.BackColor = Color.Salmon;
                    valid = false;
                }
            }
            catch
            {
                // Do nothing. If we fail to convert, it's a string anyway and should already be invalid.
            }
            return valid;
        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        private void txtbxInventory_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        private void txtbxPriceCost_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        private void txtbxMax_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        private void txtbxMin_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        // Action on form close.
        private void frmProductScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel closing if there are unsaved changes.
            if (saved == false)
            {
                var window = MessageBox.Show("You have unsaved changes. Close anyway?", "Confirm", MessageBoxButtons.YesNo);
                e.Cancel = (window == DialogResult.No);
            }
        }
        private int newID()
        {
            // Create a temporary inventory.
            Inventory tmpInv = new Inventory(false);

            // Initialize our integer at 0, which is our lowest part ID number.
            int newID = 0;

            // Parse every object in our list.
            foreach (Part objPart in tmpInv.lstAllParts)
            {
                // If we have a part type, we compare the part ID.
                if (objPart is Product)
                {
                    // If it's equal to or greater ...
                    if (((Product)objPart).ProductID >= newID)
                    {
                        // We update our part ID to be +1.
                        newID = ((Product)objPart).ProductID + 1;
                    }
                }
            }

            // Return our new part ID.
            return newID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Run a fresh validation just in case.
            valid = validateForm();
            // If valid, save.
            if (valid == true)
            {
                savePart();
                saved = true;
                if (saved == true)
                {
                    this.Close();
                }
            }
            // Else, warning.
            if (valid == false)
            {
                string msg = "Please correct errors before saving." + validationErrors;
                MessageBox.Show(msg, "Error");
            }
        }

        // Save part.
        private void savePart()
        {
            // One last check to prevent type errors.
            if (valid == false) { return; }
            Product newPart = new Product();
            // If it's a new part, we need a part ID.
            // Doing it this way also means once a part ID is assigned, we don't have to run the newID logic again.
            newPart.Name = txtbxName.Text;
            newPart.Price = Convert.ToDecimal(txtbxPriceCost.Text);
            newPart.InStock = Convert.ToInt32(txtbxInventory.Text);
            newPart.Min = Convert.ToInt32(txtbxMin.Text);
            newPart.Max = Convert.ToInt32(txtbxMax.Text);
            // We need to populate the part list.
            BindingList<Part> AssociatedParts = new BindingList<Part>();

            if (componentIDs.Count > 0)
            {
                foreach (int tmpID in componentIDs)
                {
                    Part tmpPart = tmpProduct.lookupPart(tmpID);
                    AssociatedParts.Add(tmpPart);
                }
            }

            // Replace our parts list.
            newPart.AssociatedParts = AssociatedParts;

            // If it's a blank part ID, we need to treat it as a new part.
            if (txtbxID.Text == null || txtbxID.Text == "")
            {
                txtbxID.Text = Convert.ToString(newID());
                newPart.ProductID = Convert.ToInt32(txtbxID.Text);
                tmpProduct.addProduct(newPart);
                // Finish.
                return;
            }
            // If we make it here, we're updating an existing part.
            newPart.ProductID = Convert.ToInt32(txtbxID.Text);
            tmpProduct.updatePart(newPart.ProductID, newPart);
            // Finish.
            return;
        }
        private void btnPartSearch_Click(object sender, EventArgs e)
        {
            // Initial filter that always runs.
            candidateSource.Filter = string.Format("Name LIKE '%{0}%'", txtbxPartSearch.Text);

            // If the box is only a number and as such could be matched to the ID column ...
            int parsedValue;
            if (int.TryParse(txtbxPartSearch.Text, out parsedValue))
            {
                // Add the ability to search by ID.                
                candidateSource.Filter = string.Format("convert([Part ID], 'System.String') Like '%{0}%' OR Name LIKE '%{0}%'", txtbxPartSearch.Text);
            }
        }

        // Clear our filter if our text box is cleared.
        private void txtbxPartSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtbxPartSearch.Text == null || txtbxPartSearch.Text == "")
            {
                candidateSource.Filter = null;
            }
        }
    }
}
