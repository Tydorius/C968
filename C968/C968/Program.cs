// Components in use.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

// The namespace is just an organizational wrapper to prevent conflicts.
namespace C968
{
    static class MainInventory
    {
        // Initialize our main inventory and making it globally available.
        public static Inventory inv = new Inventory(true);
    }
    // FileTree stores our static file names for the application. These are static global variables.
    static class FileTree
    {
        // Obtain the current directory.
        public static string strHomeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // Our inventory list CSV file.
        public static string strInventoryFile = strHomeDirectory + "\\inventory.csv";
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }

}
