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
using System.Text.RegularExpressions;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // The form itself. Note that we're using a single form for both adding and modifying.
    public partial class frmPartScreen : Form
    {
        private bool valid;
        private bool saved;

        // Create a product solely so we can use lookupPart and addPart, which is mandatorily set as a part of the Product Class.
        Product tmpProduct = new Product();

        public frmPartScreen(int partID)
        {
            InitializeComponent();
            
            // If we have -1, we know that it's a blank screen. But if it's not, we need to set all of the component fields.
            if(partID != -1)
            {
                Part tmpPart = tmpProduct.lookupPart(partID);

                // Set our radio buttons and their relevant boxes.
                if(tmpPart is InHouse)
                {
                    radInHouse.Checked = true;
                    radOutsourced.Checked = false;
                    txtbxMachineIDCompanyName.Text = Convert.ToString(((InHouse)tmpPart).MachineID);
                    lblMachineID.Visible = true;
                }
                if(tmpPart is Outsourced)
                {
                    radInHouse.Checked = false;
                    radOutsourced.Checked = true;
                    txtbxMachineIDCompanyName.Text = ((Outsourced)tmpPart).CompanyName;
                    lblCompanyName.Visible = false;
                }

                txtbxID.Text = Convert.ToString(tmpPart.PartID);
                txtbxName.Text = tmpPart.Name;
                txtbxInventory.Text = Convert.ToString(tmpPart.InStock);
                txtbxPriceCost.Text = Convert.ToString(tmpPart.Price);
                txtbxMax.Text = Convert.ToString(tmpPart.Max);
                txtbxMin.Text = Convert.ToString(tmpPart.Min);
            }

            // Validate the form on load.
            valid = validateForm();
            saved = true;
        }

        // We've added some logic to determine if the form is saved. It triggers on form closing, so there's no logic here.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartScreen_Load(object sender, EventArgs e)
        {
            // Ensuring same start position each time.
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Ensure we check for saved status on close.
            this.FormClosing += new FormClosingEventHandler(frmPartScreen_FormClosing);
        }

        private void radInHouse_CheckedChanged(object sender, EventArgs e)
        {
            // Using a repeatable function to save a few lines.
            updateType();
            valid = validateForm();
        }

        private void radOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            // Using a repeatable function to save a few lines.
            updateType();
            valid = validateForm();
        }
        // Change our label visibility.
        private void updateType()
        {
            if(radInHouse.Checked == true)
            {
                lblMachineID.Visible = true;
                lblCompanyName.Visible = false;
            }
            if (radOutsourced.Checked == true)
            {
                lblMachineID.Visible = false;
                lblCompanyName.Visible = true;
            }
        }

        private bool validateForm()
        {
            // Set to valid, unless we find a problem.
            valid = true;
            // Reset the colors.
            txtbxName.BackColor = Color.White;
            txtbxInventory.BackColor = Color.White;
            txtbxPriceCost.BackColor = Color.White;
            txtbxMax.BackColor = Color.White;
            txtbxMin.BackColor = Color.White;
            txtbxMachineIDCompanyName.BackColor = Color.White;

            // Validation logic.
            // Name can't be blank and can't contain a comma.
            if (txtbxName.Text == "" || txtbxName.Text == null || txtbxName.Text.Contains("."))
            {
                txtbxName.BackColor = Color.Salmon;
                valid = false;
            }
            // Inventory can't be blank and must be positive numeric or zero.
            if (txtbxInventory.Text == "" || txtbxInventory.Text == null || Regex.IsMatch(txtbxInventory.Text, "[^0-9]"))
            {
                txtbxInventory.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate that cost isn't blank.
            if (txtbxPriceCost.Text == "" || txtbxPriceCost.Text == null)
            {
                txtbxPriceCost.BackColor = Color.Salmon;
                valid = false;
            }
            // Validatioin if there's a decimal
            if(txtbxPriceCost.Text.Contains("."))
            {
                // Look for a decimal.
                string[] tempSplit = txtbxPriceCost.Text.Split('.');
                // If there isn't a decimal, we should only have one. If there is, we should have two.
                // If there are too many decimals, we make it invalid.
                if (tempSplit.Length > 2)
                {
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
                // If we have the correct amount, we now need to validate both sides and ensure we only have two decimal places.
                if (tempSplit.Length == 2)
                {
                    // We want 1 or 2 decimal places. No more, no less.
                    if(tempSplit[1].Length == 0 || tempSplit[1].Length > 2)
                    {
                        txtbxPriceCost.BackColor = Color.Salmon;
                        valid = false;
                    }
                    // We want to ensure that the position after the decimal is only numeric.
                    // We are already invalid if we have a [2] or higher, so we only need to check [1].
                    if (Regex.IsMatch(tempSplit[1], "[^0-9]"))
                    {
                        txtbxPriceCost.BackColor = Color.Salmon;
                        valid = false;
                    }
                }
                // Finally, confirm that we only have integers not counting our decimal on the left.
                if (Regex.IsMatch(tempSplit[0], "[^0-9]"))
                {
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
            }
            // Validation if there is not a decimal.
            if(!txtbxPriceCost.Text.Contains("."))
            {
                if (Regex.IsMatch(txtbxPriceCost.Text, "[^0-9]"))
                {
                    txtbxPriceCost.BackColor = Color.Salmon;
                    valid = false;
                }
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
                            txtbxInventory.BackColor = Color.Salmon;
                            valid = false;
                        }
                    }
                }
            }
            // Validate Max - Must not be null, must be only positive integers or 0, and must be greater than or equal to min.
            if (txtbxMax.Text == "" || txtbxMax.Text == null || Regex.IsMatch(txtbxMax.Text, "[^0-9]"))
            {
                txtbxMax.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate Min - Must not be null, must be only positive integers or 0, and must be less or equal to Max.
            if (txtbxMin.Text == "" || txtbxMin.Text == null || Regex.IsMatch(txtbxMin.Text, "[^0-9]"))
            {
                txtbxMin.BackColor = Color.Salmon;
                valid = false;
            }
            // Validate that Max is >= Min
            try
            {
                if(!(Convert.ToInt32(txtbxMax.Text) >= Convert.ToInt32(txtbxMin.Text)))
                {
                    txtbxMin.BackColor = Color.Salmon;
                    valid = false;
                }
            }
            catch
            {
                // Do nothing. If we fail to convert, it's a string anyway and should already be invalid.
            }
            // Validate that the company name is not null and does not contain a comma.
            if (txtbxMachineIDCompanyName.Text == "" || txtbxMachineIDCompanyName.Text == null || txtbxMachineIDCompanyName.Text.Contains("."))
            {
                txtbxMachineIDCompanyName.BackColor = Color.Salmon;
                valid = false;
            }
            // Ensure our machine number is an integer using a simple integer parse.
            // Create int n.
            int n;
            // If inhouse is checked (i.e. we must have an integer machine ID) AND we fail (!int.TryParse), then we fail validation.
            if (radInHouse.Checked == true && !int.TryParse(txtbxMachineIDCompanyName.Text, out n) )
            {
                txtbxMachineIDCompanyName.BackColor = Color.Salmon;
                valid = false;
            }
            return valid;
        }

        // Check for validation before saving.
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
                MessageBox.Show("Please correct errors before saving.", "Error");
            }
        }
        // Save part.
        private void savePart()
        {
            // One last check to prevent type errors.
            if(valid == false) { return; }

            // Different Part depending upon our type.
            if(radInHouse.Checked == true)
            {
                InHouse newPart = new InHouse();
                // If it's a new part, we need a part ID.
                // Doing it this way also means once a part ID is assigned, we don't have to run the newID logic again.
                newPart.Name = txtbxName.Text;
                newPart.Price = Convert.ToDecimal(txtbxPriceCost.Text);
                newPart.InStock = Convert.ToInt32(txtbxInventory.Text);
                newPart.Min = Convert.ToInt32(txtbxMin.Text);
                newPart.Max = Convert.ToInt32(txtbxMax.Text);
                newPart.MachineID = Convert.ToInt32(txtbxMachineIDCompanyName.Text);
                // If it's a blank part ID, we need to treat it as a new part.
                if (txtbxID.Text == null || txtbxID.Text == "")
                {
                    txtbxID.Text = Convert.ToString(newID());
                    newPart.PartID = Convert.ToInt32(txtbxID.Text);
                    tmpProduct.addPart(newPart);
                    // Finish.
                    return;
                }
                // If we make it here, we're updating an existing part.
                newPart.PartID = Convert.ToInt32(txtbxID.Text);
                tmpProduct.updatePart(newPart.PartID, newPart);
                // Finish.
                return;
            }
            if(radOutsourced.Checked == true)
            {
                Outsourced newPart = new Outsourced();
                // If it's a new part, we need a part ID.
                // Doing it this way also means once a part ID is assigned, we don't have to run the newID logic again.
                newPart.Name = txtbxName.Text;
                newPart.Price = Convert.ToDecimal(txtbxPriceCost.Text);
                newPart.InStock = Convert.ToInt32(txtbxInventory.Text);
                newPart.Min = Convert.ToInt32(txtbxMin.Text);
                newPart.Max = Convert.ToInt32(txtbxMax.Text);
                newPart.CompanyName = txtbxMachineIDCompanyName.Text;
                // If it's a blank part ID, we need to treat it as a new part.
                if (txtbxID.Text == null || txtbxID.Text == "")
                {
                    txtbxID.Text = Convert.ToString(newID());
                    newPart.PartID = Convert.ToInt32(txtbxID.Text);
                    tmpProduct.addPart(newPart);
                    // Finish.
                    return;
                }
                // If we make it here, we're updating an existing part.
                newPart.PartID = Convert.ToInt32(txtbxID.Text);
                tmpProduct.updatePart(newPart.PartID, newPart);
                // Finish.
                return;
            }
        }

        private int newID()
        {
            // Create a temporary inventory.
            Inventory tmpInv = new Inventory(false);

            // Initialize our integer at 0, which is our lowest part ID number.
            int newID = 0;

            // Parse every object in our list.
            foreach(Part objPart in tmpInv.lstAllParts)
            {
                // If we have a part type, we compare the part ID.
                if(objPart is InHouse || objPart is Outsourced)
                {
                    // If it's equal to or greater ...
                    if(objPart.PartID >= newID)
                    {
                        // We update our part ID to be +1.
                        newID = objPart.PartID + 1;
                    }
                }
            }

            // Return our new part ID.
            return newID;
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

        private void txtbxMachineIDCompanyName_TextChanged(object sender, EventArgs e)
        {
            // Saved is now false, because something has changed.
            saved = false;
            // Validate form since something has changed.
            valid = validateForm();
        }

        // Action on form close.
        private void frmPartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel closing if there are unsaved changes.
            if (saved == false)
            {
                var window = MessageBox.Show("You have unsaved changes. Close anyway?", "Confirm", MessageBoxButtons.YesNo);
                e.Cancel = (window == DialogResult.No);
            }
        }
    }
}
