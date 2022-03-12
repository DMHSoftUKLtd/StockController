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
    public partial class ShopTransferForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public ShopTransferForm()
        {
            InitializeComponent();
        }

        private void ShopTransferForm_Load(object sender, EventArgs e)
        {

        }
    }
}
