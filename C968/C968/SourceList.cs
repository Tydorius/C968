// Components in use.
using System;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    // Create our object class
    public class SourceList
    {
        // Add our object variables.
        public int partid;
        // 0 for in-house, 1 for outsourced.
        public bool inhouse;
        public int machineid;
        public string companyname;

        public SourceList()
        {
        }
    }
}