// Components in use.
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // Create our object class
    public class Product : Part
    {
        // Add our object variables.
        public int ProductID;
        public BindingList<Part> AssociatedParts;

        // Object initialization.
        public Product()
        {

        }

        public void addProduct(Product objProduct)
        {
            // Saving some code
            addPart(objProduct);
        }

        // Remove a product entirely.
        public bool removeProduct(int productID)
        {
            return false;
        }

        public Product lookupProduct(int productID)
        {
            for (int index = 0; index < MainInventory.inv.lstAllParts.Count; ++index)
            {
                // If it's not a product, we continue to the next one.
                if (!(MainInventory.inv.lstAllParts[index] is Product)) { continue; }
                // If it isn't and the PartID matches ...
                if (((Product)MainInventory.inv.lstAllParts[index]).ProductID == productID)
                {
                    return ((Product)MainInventory.inv.lstAllParts[index]);
                }
            }
            // Return null if we make it to this point, i.e. nothing else is found.
            // TODO: Throw exception on null.
            MessageBox.Show("Error. Product " + productID + " returned null using lookupProduct(int).", "Error");

            return null;
        }

        // This is simple enough.
        public void addPart(Part objPart)
        {
            // Whether it's a part or product we add it to our overall inventory.
            MainInventory.inv.lstAllParts.Add(objPart);

            // If the type is InHouse or Outsourced, we know it is a part going into our parts table.
            if ((objPart is InHouse) || (objPart is Outsourced))
            {
                MainInventory.inv.dtblParts.Rows.Add(objPart.PartID, objPart.Name, objPart.InStock, objPart.Price, objPart.Min, objPart.Max);
                // Continue, skip next logic.
                return;
            }
            if (objPart is Product)
            {
                MainInventory.inv.dtblProducts.Rows.Add(objPart.PartID, objPart.Name, objPart.InStock, objPart.Price, objPart.Min, objPart.Max);
                // Continue, skip next logic.
                return;
            }
            // If we didn't get sent a part, we should do something.
            // TODO Exception.
        }

        // Reusing a lot of code from the update method.
        public bool deletePart(Part objPart)
        {
            int partID = objPart.PartID;

            bool deleted = false;

            if (objPart is Product)
            {
                foreach (DataRow row in MainInventory.inv.dtblProducts.Rows)
                {
                    if (Convert.ToInt32(row["Part ID"]) == partID)
                    {
                        row.Delete();
                        deleted = true;
                    }
                }
            }
            else
            {
                foreach (DataRow row in MainInventory.inv.dtblParts.Rows)
                {
                    if (Convert.ToInt32(row["Part ID"]) == partID)
                    {
                        row.Delete();
                        deleted = true;
                    }
                }
            }

            // Outright remove the object.
            MainInventory.inv.lstAllParts.Remove(objPart);

            // TODO: Part not found in table exception.
            return deleted;
        }

        public Part lookupPart(int partID)
        {
            for (int index = 0; index < MainInventory.inv.lstAllParts.Count; ++index)
            {
                // If it's a product, we continue to the next one.
                if (MainInventory.inv.lstAllParts[index] is Product) { continue; }
                // If it isn't and the PartID matches ...
                if (MainInventory.inv.lstAllParts[index].PartID == partID)
                {
                    // Outright return the object.
                    return MainInventory.inv.lstAllParts[index];
                }
            }
            // Return null if we make it to this point, i.e. nothing else is found.
            // TODO: Throw exception on null.
            MessageBox.Show("Error. Part ID " + partID + " returns Null from lookupPart(int).", "Error");
            return null;
        }

        public void updatePart(int partID, Part objPart)
        {
            // This is important since we're updating two items.
            bool found = false;
            for (int index = 0; index < MainInventory.inv.lstAllParts.Count; ++index)
            {
                // If it's a product, we continue to the next one.
                if(MainInventory.inv.lstAllParts[index] is Product) { continue; }
                // If it isn't and the PartID matches ...
                if(MainInventory.inv.lstAllParts[index].PartID == partID)
                {
                    // Outright replace the object.
                    MainInventory.inv.lstAllParts[index] = objPart;
                    found = true;
                    //Drop our loop.
                    break;
                }
            }
            if(found != true)
            {
                //TODO: Part not found exception.
            }
            foreach(DataRow row in MainInventory.inv.dtblParts.Rows)
            {
                if(Convert.ToInt32(row["Part ID"]) == partID)
                {
                    row["Name"] = objPart.Name;
                    row["Inventory"] = objPart.InStock;
                    row["Price"] = objPart.Price;
                    row["Min"] = objPart.Min;
                    row["Max"] = objPart.Max;
                    return;
                }
            }
            // TODO: Part not found in table exception.
        }
    }
}