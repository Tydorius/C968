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
    public partial class frmPartScreen : Form
    {
        public frmPartScreen()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
