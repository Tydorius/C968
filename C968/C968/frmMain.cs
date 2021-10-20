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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // If the parts CSV file does not exist ...
            if (File.Exists(FileTree.strPartsFile) != true)
            {
                // ... Create a new file.
                using (File.Create(FileTree.strPartsFile)) { }
            }
            // If the products CSV file does not exist ...
            if (File.Exists(FileTree.strProductsFile) != true)
            {
                // ... Create a new file.
                using (File.Create(FileTree.strProductsFile)) { }
            }

            // Read the contents of the parts CSV file into an array.
            string[] tblParts = System.IO.File.ReadAllLines(FileTree.strPartsFile);
            // Skip the first row.
            tblParts = tblParts.Skip(1).ToArray();
            // Read the contents of the products CSV file into an array.
            string[] tblProducts = System.IO.File.ReadAllLines(FileTree.strProductsFile);
            // Skip the first row.
            tblProducts = tblProducts.Skip(1).ToArray();
            // Initialize a parts list.
            List<Part> lstParts = new List<Part>();
            // Initialize a Products list.
            List<Product> lstProducts = new List<Product>();
            // Initialize a Components list.
            // This allows us to simplify the DataGridView later by not having to worry about the components column.
            List<ComponentList> lstComponents = new List<ComponentList>();

            // Populate the parts list
            foreach (string line in tblParts)
            {
                // Split our row on commas.
                string[] row = line.Split(',');

                // Create a new part object.
                Part objPart = new Part();

                // Set the values for our object.
                objPart.partid = Convert.ToInt32(row[0]);
                objPart.name = row[1];
                objPart.inventory = Convert.ToInt32(row[2]);
                objPart.price = Convert.ToDecimal(row[3]);
                objPart.min = Convert.ToInt32(row[4]);
                objPart.max = Convert.ToInt32(row[5]);
                
                // Add our object to the list.
                lstParts.Add(objPart);
            }

            // Populate the products array
            foreach (string line in tblProducts)
            {
                // Split our row on commas.
                string[] row = line.Split(',');

                // Create a new part object.
                Product objProduct = new Product();

                // Set the values for our object.
                objProduct.productid = Convert.ToInt32(row[0]);
                objProduct.name = row[1];
                objProduct.inventory = Convert.ToInt32(row[2]);
                objProduct.price = Convert.ToDecimal(row[3]);
                objProduct.min = Convert.ToInt32(row[4]);
                objProduct.max = Convert.ToInt32(row[5]);

                // Add our object to the list.
                lstProducts.Add(objProduct);

                // Create a new ComponentList object.
                ComponentList objComponent = new ComponentList();

                // Set the values for our object.
                objComponent.productid = Convert.ToInt32(row[0]);
                objComponent.components = row[6];

                // Add our object to the list.
                lstComponents.Add(objComponent);
            }

        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            var frmParts = new frmPartScreen();
            frmParts.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var frmProducts = new frmProductScreen();
            frmProducts.ShowDialog();
        }

        private void btnModifyPart_Click(object sender, EventArgs e)
        {
            var frmParts = new frmPartScreen();
            frmParts.ShowDialog();
        }
    }
}
