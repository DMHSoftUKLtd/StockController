using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockController
{
    public partial class ShopDeliveryForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public ShopDeliveryForm()
        {
            InitializeComponent();
        }

        private void ShopDeliveryForm_Load(object sender, EventArgs e)
        {
            LoadWarehouseIntoForm();
            LoadShopsIntoForm();
            if (FormMode == "New")
            {
                CmdAdd.Text = "Save";
                this.Text = "New Shop Delivery";
                DteDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                CmdAdd.Text = "OK";
                LoadData();
            }
        }

        private void TxtShopRef_Leave(object sender, EventArgs e)
        {
            TxtShopRef.Text = Shop.ChangeCase(TxtShopRef.Text, 1);
            Shop Shops = new Shop()
            {
                ShopRef = TxtShopRef.Text.TrimEnd()
            };
            txtShopName.Text = Shops.GetShopNameFromDB();
        }

        private void TxtWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtWarehouseRef.Text = Warehouse.ChangeCase(TxtWarehouseRef.Text, 1);
            Warehouse warehouses = new Warehouse()
            {
                WarehouseRef = TxtWarehouseRef.Text.TrimEnd()
            };
            txtWarehouseName.Text = warehouses.GetWarehouseNameFromDB();
            LoadStockIntoForm();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            if (TxtStockCode.TextLength != 0)
            {
                TxtStockCode.Text = Utility.ChangeCase(TxtStockCode.Text, 1);
                Stock stocks = new Stock();
                stocks.StockCode = TxtStockCode.Text.TrimEnd();
                stocks.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
                txtQty.Text = stocks.GetWarehouseStockQty().ToString();
            }
            else
            { }
        }

        private void CmdAddItem_Click(object sender, EventArgs e)
        {
            int rownum;
            rownum = (int)DgvRecords.Rows.Add();
            DgvRecords.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[1].Value = txtQtyHangers.Text.TrimEnd();
            Totals();
            txtQtyHangers.Clear();
            txtQty.Clear();
            TxtStockCode.Clear();
            TxtStockCode.Select();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRecords.SelectedRows)
            {
                DgvRecords.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            ShopDelivery deliveryHead = new ShopDelivery();
            ShopDelivery deliveryLine = new ShopDelivery();
            Log logs = new Log();
            // Header of both adjustments and log file
            deliveryHead.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
            deliveryHead.Reference = txtReference.Text.TrimEnd();
            deliveryHead.ShopRef = TxtShopRef.Text.TrimEnd();
            deliveryHead.TotalItems = Convert.ToInt32(txtTotalGarments.Text.TrimEnd());
            deliveryHead.MovementDate = Convert.ToDateTime(DteDate.Value.ToString());
            deliveryHead.UserID = UserID;
            if (FormMode == "New")
            {
                deliveryHead.SaveShopDeliveryHead();
                deliveryHead.ShopDelID = deliveryHead.GetLastShopDelivery();
            }
            else
            {
                Log Dlogs = new Log();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 3;
                Dlogs.DeleteFromStockMovemmentsTable();
                deliveryHead.ShopDelID = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
                deliveryHead.UpdateShopDeliveryHead();
            }
            logs.TransferReference = deliveryHead.ShopDelID;
            deliveryLine.ShopDelID = deliveryHead.ShopDelID;
            logs.MovementDate = deliveryHead.MovementDate;
            logs.Reference = "Shop Delivery";
            logs.UserID = UserID;
            logs.SupplierRef = "NULL";
            logs.StringMovementType = "Shop Return Item";
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                deliveryLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                logs.StockCode = deliveryLine.StockCode;
                deliveryLine.Qty = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value);
                if (FormMode == "New")
                {
                    logs.LocationRef = deliveryHead.WarehouseRef;
                    logs.LocationType = 1;
                    logs.MovementType = 3;
                    logs.Qty = deliveryLine.Qty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    deliveryLine.SaveShopDeliveryLine();
                    logs.LocationType = 2;
                    logs.MovementType = 3;
                    logs.LocationRef = deliveryHead.ShopRef;
                    logs.Qty = deliveryLine.Qty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
                else
                {
                    logs.LocationRef = deliveryHead.WarehouseRef;
                    logs.LocationType = 1;
                    logs.MovementType = 3;
                    logs.Qty = deliveryLine.Qty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    deliveryLine.UpdateShopDeliveryLine();
                    logs.LocationType = 2;
                    logs.MovementType = 3;
                    logs.LocationRef = deliveryHead.ShopRef;
                    logs.Qty = deliveryLine.Qty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
            }
            this.Close();
        }

        private void CmdClearForm_Click(object sender, EventArgs e)
        {
            txtDelNoteNumber.Clear();
            txtQty.Clear();
            txtQtyHangers.Clear();
            txtTotalGarments.Clear();
            TxtStockCode.Clear();
            DgvRecords.Rows.Clear();
            TxtWarehouseRef.Clear();
            txtWarehouseName.Clear();
            TxtShopRef.Clear();
            txtShopName.Clear();
            txtReference.Clear();
            DteDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void DgvRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadWarehouseIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT WarehouseRef from tblWarehouses", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtWarehouseRef.AutoCompleteCustomSource = ACSC;
            TxtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadShopsIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT ShopRef from tblShops", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtShopRef.AutoCompleteCustomSource = ACSC;
            TxtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadStockIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT StockCode from qryWarehouseStock WHERE LocationRef = @LocationRef", conn);
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", TxtWarehouseRef.Text);
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtStockCode.AutoCompleteCustomSource = ACSC;
            TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        public void Totals()
        {
            int lngqtyhangers = 0;

            for (int i = 0; i < DgvRecords.Rows.Count; i++)
            {
                lngqtyhangers += Convert.ToInt32(DgvRecords.Rows[i].Cells[1].Value);
            }
            txtTotalGarments.Text = lngqtyhangers.ToString();
            Deliverlabel.Text = DgvRecords.Rows.Count.ToString();

        }
        private void LoadData()
        {
            int SHDelID = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable ShopDeliveryHead = new DataTable();
                SqlDataAdapter ShopDeliveryDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShopDeliveries WHERE ShopDeliveryID = @ShopDeliveryID";
                    SelectCmd.Parameters.AddWithValue("@ShopDeliveryID", SHDelID);
                    ShopDeliveryDataAdapter.SelectCommand = SelectCmd;
                    ShopDeliveryDataAdapter.Fill(ShopDeliveryHead);
                }
                TxtShopRef.Text = ShopDeliveryHead.Rows[0][1].ToString();
                Shop shop = new Shop();
                shop.ShopRef = TxtShopRef.Text.TrimEnd();
                txtShopName.Text = shop.GetShopNameFromDB();
                Warehouse warehouses = new Warehouse();
                TxtWarehouseRef.Text = ShopDeliveryHead.Rows[0][2].ToString();
                warehouses.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
                txtWarehouseName.Text = warehouses.GetWarehouseNameFromDB();
                txtReference.Text = ShopDeliveryHead.Rows[0][3].ToString();
                txtTotalGarments.Text = ShopDeliveryHead.Rows[0][4].ToString();
                DteDate.Value = Convert.ToDateTime(ShopDeliveryHead.Rows[0][5]);
                OldDate = DteDate.Value;
            }
            DgvRecords.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable WarehouseAdjustLine = new DataTable();
                SqlDataAdapter WarehouseAdjustLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,DeliveredQty from tblShopDeliveryLines WHERE ShopDeliveryID = @ShopDeliveryID";
                    SelectCmd.Parameters.AddWithValue("@ShopDeliveryID", SHDelID);
                    WarehouseAdjustLineDataAdapter.SelectCommand = SelectCmd;
                    WarehouseAdjustLineDataAdapter.Fill(WarehouseAdjustLine);
                    DgvRecords.DataSource = WarehouseAdjustLine;
                    DgvRecords.AutoGenerateColumns = true;
                    DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    DgvRecords.BackgroundColor = Color.LightCoral;
                    DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red;
                    DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                    DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DgvRecords.AllowUserToResizeColumns = false;
                    DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                    DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                    DgvRecords.Columns[0].HeaderText = "Stock Code";
                    DgvRecords.Columns[1].HeaderText = "Delivered Qty";
                }
            }
        }
    }
}
