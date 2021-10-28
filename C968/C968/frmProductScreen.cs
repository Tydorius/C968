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

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // The form itself. Note that we're using a single form for both adding and modifying.
    public partial class frmProductScreen : Form
    {
        // Creating a candidate parts table and a current parts table.
        private DataTable candidateParts = new DataTable();
        private DataTable currentParts = new DataTable();

        // Creating a product so we can use its methods.
        private Product tmpProduct = new Product();

        // Create a list for our component IDs.
        List<int> componentIDs = new List<int>();

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
                        currentParts.Rows.Add(objLine.PartID, objLine.Name, objLine.InStock, objLine.Price, objLine.Min, objLine.Max);
                        componentIDs.Add(objLine.PartID);
                    }
                }
            }
            populateCandidates();
        }
        private void populateCandidates()
        {
            candidateParts.Clear();
            foreach (Part objLine in MainInventory.inv.lstAllParts)
            {
                // Ignore the line if it's a product.
                if (objLine is Product) { continue; }
                // Ignore the part if it's in the int list.
                if (componentIDs.Contains(objLine.PartID)) { continue; }
                // If we make it here, add the aprt.
                candidateParts.Rows.Add(objLine.PartID, objLine.Name, objLine.InStock, objLine.Price, objLine.Min, objLine.Max);
            }
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
            dgvAssociatedParts.DataSource = currentParts;
            dgvParts.DataSource = candidateParts;
        }
    }
}
