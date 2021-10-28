// Components in use.
using System;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // Create our object class
    public abstract class Part
    {
        // Add our object properties.
        public int PartID;
        public string Name;
        public decimal Price;
        public int InStock;
        public int Min;
        public int Max;

        public Part()
        {
        }
    }
}