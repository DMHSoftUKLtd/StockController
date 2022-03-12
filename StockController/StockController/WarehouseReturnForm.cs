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
    public partial class WarehouseReturnForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public WarehouseReturnForm()
        {
            InitializeComponent();
        }

        private void WarehouseReturnForm_Load(object sender, EventArgs e)
        {

        }
    }
}
