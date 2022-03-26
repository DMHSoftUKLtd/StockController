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
    public partial class ShopReturnForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public ShopReturnForm()
        {
            InitializeComponent();
        }

        private void ShopReturnForm_Load(object sender, EventArgs e)
        {
            LoadShopsIntoForm();
            LoadWarehouseIntoForm();
            if (FormMode == "New")
            {
                cmdAdd.Text = "Save";
                this.Text = "New Shop Return";
            }
            else
            {
                cmdAdd.Text = "OK";
                LoadData();
            }
        }

        private void TxtShopRef_Leave(object sender, EventArgs e)
        {
            LoadStockIntoForm();
            TxtShopRef.Text = Utility.ChangeCase(TxtShopRef.Text, 1);
            Shop Shop = new Shop()
            {
                ShopRef = TxtShopRef.Text.TrimEnd()
            };
            txtShopName.Text = Shop.GetShopNameFromDB();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            TxtStockCode.Text = Utility.ChangeCase(TxtStockCode.Text, 1);
            Stock stock = new Stock();
            stock.StockCode = TxtStockCode.Text.TrimEnd();
            stock.ShopRef = TxtShopRef.Text.TrimEnd();
            txtCurrentQty.Text = stock.GetShopStockQty().ToString();
        }

        private void TxtWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtWarehouseRef.Text = Utility.ChangeCase(TxtWarehouseRef.Text, 1);
            Warehouse warehouse = new Warehouse()
            {
                WarehouseRef = TxtWarehouseRef.Text.TrimEnd()
            };
            txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            DtpDate.Value = Utility.GetSundayDate(DtpDate.Value, 1);
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            int rownum;
            rownum = (int)DgvRecords.Rows.Add();
            DgvRecords.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[1].Value = txtTransferQty.Text.TrimEnd();
            Totals();
            txtTransferQty.Clear();
            txtCurrentQty.Clear();
            TxtStockCode.Clear();
        }

        private void CmdClearGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRecords.SelectedRows)
            {
                DgvRecords.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ShopReturn returnHead = new ShopReturn();
            ShopReturn returnLine = new ShopReturn();
            Log logs = new Log();
            int SavedID = 0;
            // Header of both adjustments and log file
            returnHead.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
            returnHead.Reference = txtReference.Text.TrimEnd();
            returnHead.ShopRef = TxtShopRef.Text.TrimEnd();
            returnHead.TotalItems = Convert.ToInt32(txtTotalItems.Text.TrimEnd());
            returnHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            returnHead.UserID = UserID;
            if (FormMode == "New")
            {
                returnHead.SaveShopReturnHead();
                SavedID = returnHead.GetLastShopReturnHead();
            }
            else
            {
                Log Dlogs = new Log();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(txtReturnID.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 9;
                Dlogs.DeleteFromStockMovemmentsTable();
                returnHead.ShopReturnID = Convert.ToInt32(txtReturnID.Text.TrimEnd());
                returnHead.UpdateShopReturnHead();
            }
            logs.TransferReference = SavedID;
            returnLine.ShopReturnID = SavedID;
            logs.MovementDate = returnHead.MovementDate;
            logs.UserID = returnHead.UserID;
            logs.MovementType = 8;
            logs.StringMovementType = "Shop Return Item";
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                logs.LocationRef = returnHead.WarehouseRef;
                returnLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                returnLine.Qty = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value);
                logs.StockCode = returnLine.StockCode;
                logs.Reference = logs.StringMovementType;
                logs.SupplierRef = "N/A";
                if (FormMode == "New")
                {
                    logs.LocationType = 2;
                    logs.LocationRef = returnHead.ShopRef;
                    logs.Qty = returnLine.Qty * -1;
                    logs.DeliveredQtyHangers = returnLine.Qty * -1;
                    logs.SaveToStockMovementsTable();
                    returnLine.SaveShopReturnLine();
                    logs.LocationRef = returnHead.WarehouseRef;
                    logs.LocationType = 1;
                    logs.Qty = returnLine.Qty;
                    logs.DeliveredQtyHangers = returnLine.Qty;
                    logs.SaveToStockMovementsTable();
                }
                else
                {
                    logs.LocationRef = returnHead.ShopRef;
                    logs.Qty = returnLine.Qty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    returnLine.UpdateShopReturnLine();
                    logs.LocationRef = returnHead.WarehouseRef;
                    logs.Qty = returnLine.Qty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
            }
            Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            txtTotalItems.Clear();
            TxtStockCode.Clear();
            DgvRecords.Rows.Clear();
            TxtWarehouseRef.Clear();
            txtWarehouseName.Clear();
            TxtShopRef.Clear();
            txtShopName.Clear();
            txtReference.Clear();
            DtpDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            int ShopReturnID = Convert.ToInt32(txtReturnID.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable ShopReturnHead = new DataTable();
                SqlDataAdapter ShopReturnDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShopReturns WHERE ShopReturnsID = @ShopReturnsID";
                    SelectCmd.Parameters.AddWithValue("@ShopReturnsID", ShopReturnID);
                    ShopReturnDataAdapter.SelectCommand = SelectCmd;
                    ShopReturnDataAdapter.Fill(ShopReturnHead);
                }
                TxtShopRef.Text = ShopReturnHead.Rows[0][1].ToString();
                Shop Shop = new Shop
                {
                    ShopRef = TxtShopRef.Text
                };
                txtShopName.Text = Shop.GetShopNameFromDB();
                TxtWarehouseRef.Text = ShopReturnHead.Rows[0][2].ToString();
                Warehouse warehouse = new Warehouse
                {
                    WarehouseRef = TxtWarehouseRef.Text.TrimEnd()
                };
                txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                txtReference.Text = ShopReturnHead.Rows[0][3].ToString();
                txtTotalItems.Text = ShopReturnHead.Rows[0][4].ToString();
                DtpDate.Value = Convert.ToDateTime(ShopReturnHead.Rows[0][5]);
                OldDate = DtpDate.Value;
            }
            DgvRecords.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable ShopReturnLine = new DataTable();
                SqlDataAdapter ShopReturnLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,Qty from tblShopReturnLines WHERE ShopReturnID = @ShopReturnID";
                    SelectCmd.Parameters.AddWithValue("@ShopReturnID", ShopReturnID);
                    ShopReturnLineDataAdapter.SelectCommand = SelectCmd;
                    ShopReturnLineDataAdapter.Fill(ShopReturnLine);
                    DgvRecords.DataSource = ShopReturnLine;
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
                    DgvRecords.Columns[1].HeaderText = "Qty";
                }
                Totals();
            }
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
                adp.SelectCommand = new SqlCommand("SELECT StockCode from qryShopStock WHERE LocationRef = @LocationRef", conn);
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", TxtShopRef.Text);
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
            txtTotalItems.Text = lngqtyhangers.ToString();
        }
    }
}
