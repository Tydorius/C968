// Components in use.
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;


// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // Create our object class
    public class Inventory : Part
    {
        // Initialize a parts list.
        public BindingList<Part> lstAllParts = new BindingList<Part>();

        // Initialize our data tables for use in the data grid views.
        public DataTable dtblParts = new DataTable();
        public DataTable dtblProducts = new DataTable();
        public string[] tblParts = null;

        public Inventory(bool mainInventory)
        {
            // Initial inventory load. This is suboptimal, but I've gone this route due to the class structure restrictions.
            loadInventory(mainInventory);
        }
        
        // Creating an action to reload the parts table.
        public void loadInventory(bool mainInventory)
        {
            // Add columns to data tables.
            dtblParts.Columns.Add("Part ID");
            dtblParts.Columns.Add("Name");
            dtblParts.Columns.Add("Inventory");
            dtblParts.Columns.Add("Price");
            dtblParts.Columns.Add("Min");
            dtblParts.Columns.Add("Max");

            dtblProducts.Columns.Add("Product ID");
            dtblProducts.Columns.Add("Name");
            dtblProducts.Columns.Add("Inventory");
            dtblProducts.Columns.Add("Price");
            dtblProducts.Columns.Add("Min");
            dtblProducts.Columns.Add("Max");
            
            // If the parts CSV file does not exist ...
            if (File.Exists(FileTree.strInventoryFile) != true)
            {
                // ... Create a new file.
                using (FileStream fs = File.Create(FileTree.strInventoryFile))
                {
                    //Add our headers
                    Byte[] headers = new UTF8Encoding(true).GetBytes("Type,ProductID,PartID,Name,Inventory,Price,In Stock,Min,Max,MachineID,Company Name,Components");
                    fs.Write(headers, 0, headers.Length);
                }

                // There's no reason to run additiona logic, because it's an empty inventory.
                return;
            }

            // Read the contents of the parts CSV file into an array.
            tblParts = System.IO.File.ReadAllLines(FileTree.strInventoryFile);
            
            // If our file is empty (i.e. header only) from a previous generation, it's also considered a blank inventory and we can skip logic.
            if (tblParts.Length == 1) { return; }

            // Skip the first row.
            tblParts = tblParts.Skip(1).ToArray();

            // Populate the parts list
            foreach (string line in tblParts)
            {
                // Split our row on commas.
                string[] row = line.Split(',');

                // Create our object.
                string strType = Convert.ToString(row[0]);
                
                // If type is InHouse ...
                if(strType == "InHouse")
                {
                    // Create an InHouse object
                    InHouse objPart = new InHouse();

                    // Part properties:
                    objPart.Name = row[3];
                    objPart.Price = Convert.ToDecimal(row[4]);
                    objPart.InStock = Convert.ToInt32(row[5]);
                    objPart.Min = Convert.ToInt32(row[6]);
                    objPart.Max = Convert.ToInt32(row[7]);
                    objPart.PartID = Convert.ToInt32(row[2]);
                    objPart.MachineID = Convert.ToInt32(row[8]);

                    // Add our object to the list.
                    lstAllParts.Add(objPart);
                }

                // OutSourced Type:
                if (strType == "Outsourced")
                {
                    // Create an OutSourced object
                    Outsourced objPart = new Outsourced();

                    // Part properties:
                    objPart.Name = row[3];
                    objPart.Price = Convert.ToDecimal(row[4]);
                    objPart.InStock = Convert.ToInt32(row[5]);
                    objPart.Min = Convert.ToInt32(row[6]);
                    objPart.Max = Convert.ToInt32(row[7]);
                    objPart.PartID = Convert.ToInt32(row[2]);
                    objPart.CompanyName = Convert.ToString(row[9]);

                    // Add our object to the list.
                    lstAllParts.Add(objPart);
                    
                }

                // Product Type:
                if (strType == "Product")
                {
                    // Create an OutSourced object
                    Product objPart = new Product();

                    // Product ID
                    objPart.ProductID = Convert.ToInt32(row[1]);

                    // Part properties:
                    objPart.Name = row[3];
                    objPart.Price = Convert.ToDecimal(row[4]);
                    objPart.InStock = Convert.ToInt32(row[5]);
                    objPart.Min = Convert.ToInt32(row[6]);
                    objPart.Max = Convert.ToInt32(row[7]);
                    // We do not touch associated parts until we actually need them, because inventory must be loaded first.

                    // Add our object to the list.
                    lstAllParts.Add(objPart);
                }

            }

            // We only care about data tables and product associated parts for our main form's inventory.
            // Because the lookupPart method uses Inventory objects, we want to ensure it does not cause a recursion issue.
            // However, we want to use the same code, so this was a simple solution.
            // If this is our first run ...
            if (mainInventory == true)
            {
                // Populate our data tables.
                // For each Part object ...
                foreach (Part objLine in lstAllParts)
                {
                    // If the type is InHouse or Outsourced, we know it is a part going into our parts table.
                    if ((objLine is InHouse) || (objLine is Outsourced))
                    {
                        dtblParts.Rows.Add(objLine.PartID, objLine.Name, objLine.InStock, objLine.Price, objLine.Min, objLine.Max);
                        // Continue, skip next logic.
                        continue;
                    }
                    // If we make it here, it's a product.
                }
                // Now that we are done with the loading, we need to build out our AssociatedParts binding lists.
                // For each Part in our list ...
                int i = 0;
                while (i < lstAllParts.Count)
                {
                    // If the Part is a Product ...
                    if (lstAllParts[i] is Product)
                    {
                        // Get the full product with parts. We will return it to the lstAllParts list.
                        lstAllParts[i] = lookupAssociatedPart(((Product)lstAllParts[i]).ProductID);

                        // If it is a Product, we know it's a product going into our products table.
                        dtblProducts.Rows.Add(((Product)lstAllParts[i]).ProductID, lstAllParts[i].Name, lstAllParts[i].InStock, lstAllParts[i].Price, lstAllParts[i].Min, lstAllParts[i].Max);
                    }
                    i++;
                }
            }
        }
        
        // Lookup associated part.
        public Part lookupAssociatedPart(int partID)
        {
            // Create the part that we will be returning.
            Product productObj = new Product();

            // Find our product first.
            int i = 0;
            while (i < lstAllParts.Count)
            {
                // If the Part is a Product ...
                if (lstAllParts[i] is Product && ((Product)lstAllParts[i]).ProductID == partID)
                {
                    productObj = ((Product)lstAllParts[i]);
                    break;
                }
                i++;
            }

            // Create an array for our components
            string strComponents = null;
            // For each row in our tblParts list
            foreach (string line in tblParts)
            {
                // Split our string with commas.
                string[] row = line.Split(',');
                // Only if the ProductID matches - Note that we ignore Type because only Products have ProductIDs.
                // This saves us one round of logic.
                // If the product ID matches the object's PartID ...
                if (row[1] == Convert.ToString(productObj.ProductID))
                {
                    // If the 10th cell of the row is not null ...
                    if (row[10] != null)
                    {
                        // Populate our components list by splitting the row on '|'
                        strComponents = row[10];
                    }
                    // Break the loop.
                    break;
                }
            }

            // If null, don't waste computing power.
            if (strComponents == null) { return productObj; }

            // Split our list.
            string[] lstComponents = strComponents.Split('|');
            
            // If our strComponents is empty, return Product with no associated parts.
            if (lstComponents == null || lstComponents.Length == 0) { return productObj; }

            // Create a new binding list.
            BindingList<Part> lstAssociatedComponents = new BindingList<Part>();

            // For each component in our list ...
            foreach (string strComponent in lstComponents)
            {
                // Make an int.
                int intComponent = Convert.ToInt32(strComponent);
                // Bool to continue our inner loop.
                bool found = false;

                // For each part in all parts ...
                foreach (Part tempPart in lstAllParts)
                {
                    // If we found our part already just continue.
                    if (found == true) { continue; }

                    // If it's not a product ...
                    if(!(tempPart is Product))
                    {
                        // If it matches the ID ...
                        if(tempPart.PartID == intComponent)
                        {
                            // Add the part.
                            lstAssociatedComponents.Add(tempPart);
                            // Set found to true.
                            found = true;
                        }
                    }
                }
            }

            // Assign our list.
            productObj.AssociatedParts = lstAssociatedComponents;

            //Return our completed product part.
            return productObj;
        }

        // It makes no sense to have this. By this point we already have our product made, why not just update it?
        public void addAssociatedPart(Product objProduct)
        {
            // I'm doing just that.
            objProduct.updatePart(objProduct.PartID, objProduct);
        }

        // Go through all Products and remove this part, intended for post part deletion.
        public bool removeAssociatedPart(int partToRemove)
        {
            // I'm not sure on the logic on returning a boolean, but we'll return one if we delete one or more instance.
            bool deleted = false;
            // For each part in our inventory ...
            foreach (Part lineObj in lstAllParts)
            {
                // If it's a product ...
                if(lineObj is Product)
                {
                    // Go through its associated parts
                    foreach (Part partObj in ((Product)lineObj).AssociatedParts)
                    {
                        // If we find our part ...
                        if(partObj.PartID == partToRemove)
                        {
                            // Delete it.
                            ((Product)lineObj).AssociatedParts.Remove(partObj);
                            // Update our flag.
                            deleted = true;
                        }
                    }
                }
            }
            // Return our boolean.
            return deleted;
        }

        // Creating an action for saving and exporting our inventory.
        public void saveInventory()
        {
            // Empty array with our headers
            List<string> csvExport = new List<string>();
            csvExport.Add("Type,ProductID,PartID,Name,Price,In Stock,Min,Max,MachineID,Company Name,Components");
            // ForEach Part ...
            foreach (Part objPart in lstAllParts)
            {
                // Create our empty string.
                string strLine = null;
                // If it's an InHouse part ...
                if (objPart is InHouse)
                {
                    // Build our line:
                    // Type,ProductID,PartID,Name,Price,In Stock,Min,Max,MachineID,Company Name,Components
                    strLine = "InHouse,," + objPart.PartID + "," + objPart.Name + "," + objPart.Price + "," + objPart.InStock + "," + objPart.Min + "," + objPart.Max + "," + ((InHouse)objPart).MachineID + ",,";
                }
                // If it's an Outsourced part ...
                if (objPart is Outsourced)
                {
                    // Build our line:
                    // Type,ProductID,PartID,Name,Price,In Stock,Min,Max,MachineID,Company Name,Components
                    strLine = "Outsourced,," + objPart.PartID + "," + objPart.Name + "," + objPart.Price + "," + objPart.InStock + "," + objPart.Min + "," + objPart.Max + ",," + ((Outsourced)objPart).CompanyName + ",";
                }
                // If it's a Product ...
                if (objPart is Product)
                {
                    // We have additional work to do for products.
                    // Initialize our component string.
                    string strComponents = null;
                    foreach(Part componentPart in ((Product)objPart).AssociatedParts)
                    {
                        // If the string is not null, we need to add a separator.
                        if(strComponents != null)
                        {
                            strComponents += "|";
                        }
                        // Get our part ID:
                        strComponents += Convert.ToString(componentPart.PartID);
                    }
                    // Build our line:
                    // Type,ProductID,PartID,Name,Price,In Stock,Min,Max,MachineID,Company Name,Components
                    strLine = "Product," + objPart.PartID + ",," + objPart.Name + "," + objPart.Price + "," + objPart.InStock + "," + objPart.Min + "," + objPart.Max + ",,," + strComponents;
                }
                // Add our line to our export list.
                csvExport.Add(strLine);
            }
            // Export our updated file.
            // System.IO.File.WriteAllLines(FileTree.strInventoryFile, csvExport);
        }
}
}