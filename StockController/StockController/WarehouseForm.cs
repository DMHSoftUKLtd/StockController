using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockController
{
    public partial class WarehouseForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }        
        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
