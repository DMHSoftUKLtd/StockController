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
    public partial class ShopAdjustmentForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public ShopAdjustmentForm()
        {
            InitializeComponent();
        }

        private void ShopAdjustmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
