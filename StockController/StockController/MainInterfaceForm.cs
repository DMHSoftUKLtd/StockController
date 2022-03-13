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
    public partial class MainInterfaceForm : Form
    {
        public Form RefToLoginForm { get; set; }
        public int UserID { get; set; }
        public MainInterfaceForm()
        {
            InitializeComponent();
        }

        private void MainInterfaceForm_Load(object sender, EventArgs e)
        {

        }

        private void WarehousesTSMItem_Click(object sender, EventArgs e)
        {
            // To load Warehouses records from the database
            //Function 1
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 1,
                Text = "Warehouses",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void SuppliersTSMItem_Click(object sender, EventArgs e)
        {
            // To load Supplier records from the database
            //Function 2
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 2,
                Text = "Suppliers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopsTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop records from the database
            //Function 3
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 3,
                Text = "Shops",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void SeasonsTSMItem_Click(object sender, EventArgs e)
        {
            // To load Season records from the database
            //Function 6
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 6,
                Text = "Seasons",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void CurrentStockTSMItem_Click(object sender, EventArgs e)
        {
            // To load Current Stock records from the database
            //Function 4
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 4,
                Text = "Current Stock",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void AllStockTSMItem_Click(object sender, EventArgs e)
        {
            // To load All Stock records from the database
            //Function 5
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 5,
                Text = "All Stock",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void PrchaseOrdersTSMItem_Click(object sender, EventArgs e)
        {
            // To load Purchase Order records from the database
            //Function 7
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 7,
                Text = "Purchase Orders",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void WarehouseAdjustmentTSMItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Adjustment records from the database
            //Function 8
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 8,
                Text = "Warehouse Adjustments",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void WarehouseTransferTSMItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Transfer records from the database
            //Function 9
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 9,
                Text = "Warehouse Transfers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void WarehouseReturnTSMItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Return records from the database
            //Function 10
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 10,
                Text = "Warehouse Returns",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopDeliveryTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop Delivery records from the database
            //Function 11
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 11,
                Text = "Shop Delivery",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopAdjustmentTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop Adjustment records from the database
            //Function 12
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 12,
                Text = "Shop Adjustments",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopTransferTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop Transfer records from the database
            //Function 13
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 13,
                Text = "Shop Transfers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopSaleTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop Sales records from the database
            //Function 14
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 14,
                Text = "Shop Sales",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void ShopReturnTSMItem_Click(object sender, EventArgs e)
        {
            // To load Shop Return records from the database
            //Function 15
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 15,
                Text = "Shop Return",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void TotalValuationTSMItem_Click(object sender, EventArgs e)
        {
            // To load Total Value records from the database
            //Function 16
            DataGridForm objGrid = new DataGridForm
            {
                FunctionID = 16,
                Text = "Company Valuation",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void SettingsTSMItem_Click(object sender, EventArgs e)
        {
            Setting oSettings = new Setting();
            oSettings.LoadSettings();
        }

        private void ExitTSMItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }
    }
}
