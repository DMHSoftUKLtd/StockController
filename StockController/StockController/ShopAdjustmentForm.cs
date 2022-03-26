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
            LoadShopsIntoForm();
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
                this.Text = "New Shop Adjustment";
                DtpDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                CmdOK.Text = "OK";
                LoadData();
            }
        }

        private void TxtShopRef_Leave(object sender, EventArgs e)
        {
            txtShopRef.Text = Utility.ChangeCase(txtShopRef.Text, 1);
            Shop shop = new Shop()
            {
                ShopRef = txtShopRef.Text.TrimEnd()
            };
            txtShopName.Text = shop.GetShopNameFromDB();
            LoadStockIntoForm();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            TxtStockCode.Text = Utility.ChangeCase(TxtStockCode.Text, 1);
            Stock stock = new Stock();
            stock.StockCode = TxtStockCode.Text.TrimEnd();
            stock.ShopRef = txtShopRef.Text.TrimEnd();
            if (txtShopName.TextLength == 0)
                txtCurrentHangers.Text = "0";
            else
                txtCurrentHangers.Text = stock.GetShopStockQty().ToString();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CmdAddToGrid_Click(object sender, EventArgs e)
        {
            int rownum;
            Stock stock = new Stock();
            stock.ShopRef = txtShopRef.Text.TrimEnd();
            stock.StockCode = TxtStockCode.Text.TrimEnd();
            rownum = (int)DgvItems.Rows.Add();
            DgvItems.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[1].Value = cboType.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[2].Value = txtAdjustHangers.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[3].Value = stock.GetShopStockValue(Convert.ToDecimal(txtAdjustHangers.Text));
            Totals();
            txtAdjustHangers.Clear();
            txtCurrentHangers.Clear();
            TxtStockCode.Clear();
        }

        private void CmdDeleteFromGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvItems.SelectedRows)
            {
                DgvItems.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ShopAdjustment adjustmentHead = new ShopAdjustment();
            ShopAdjustment adjustmentLine = new ShopAdjustment();
            Log logs = new Log();
            // Header of both adjustments and log file
            adjustmentHead.ShopRef = txtShopRef.Text.TrimEnd();
            adjustmentHead.Reference = txtReference.Text.TrimEnd();
            adjustmentHead.TotalGainItems = Convert.ToInt32(txtTotalGain.Text.TrimEnd());
            adjustmentHead.TotalLossItems = Convert.ToInt32(txtTotalLoss.Text.TrimEnd());
            adjustmentHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            adjustmentHead.UserID = UserID;
            if (FormMode == "New")
            {
                adjustmentHead.SaveShopAdjustmentHead();
                adjustmentHead.ID = adjustmentHead.GetLastShopAdjustmentHead();
            }
            else
            {
                Log Dlogs = new Log();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(TxtSID.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 6;
                Dlogs.DeleteFromStockMovemmentsTable();
                Dlogs.MovementType = 7;
                Dlogs.DeleteFromStockMovemmentsTable();
                adjustmentHead.ID = Convert.ToInt32(TxtSID.Text.TrimEnd());

                adjustmentHead.UpdateShopAdjustmentHead();
            }
            logs.TransferReference = adjustmentHead.ID;
            adjustmentLine.ID = adjustmentHead.ID;
            logs.LocationRef = adjustmentHead.ShopRef;
            for (int index = 0; index < DgvItems.Rows.Count; index++)
            {
                // Saving details to tblWarehouseAdjustmentLines Table
                adjustmentLine.StockCode = DgvItems.Rows[index].Cells[0].Value.ToString();
                adjustmentLine.SMovementType = DgvItems.Rows[index].Cells[1].Value.ToString();
                adjustmentLine.Qty = Convert.ToInt32(DgvItems.Rows[index].Cells[2].Value);
                adjustmentLine.Value = Convert.ToDecimal(DgvItems.Rows[index].Cells[3].Value);
                // Saving details to tblStockMovements Table
                logs.StockCode = adjustmentLine.StockCode;
                logs.LocationRef = adjustmentHead.ShopRef;
                logs.LocationType = 2;
                logs.SupplierRef = "N/A";
                if (adjustmentLine.SMovementType == "Loss")
                    logs.DeliveredQtyHangers = Convert.ToInt32(DgvItems.Rows[index].Cells[2].Value) * -1;
                else
                    logs.DeliveredQtyHangers = Convert.ToInt32(DgvItems.Rows[index].Cells[2].Value);
                logs.DeliveredQtyGarments = 0;
                logs.DeliveredQtyBoxes = 0;
                if (adjustmentLine.SMovementType == "Loss")
                    logs.MovementType = 7;
                else
                    logs.MovementType = 6;
                logs.MovementDate = adjustmentHead.MovementDate;
                logs.MovementValue = adjustmentLine.Value;
                logs.Reference = adjustmentHead.Reference;
                logs.UserID = UserID;
                // Save to the relevent data tables on each itteration of the Datagridview control             
                logs.SaveToStockMovementsTable();
                if (FormMode == "New")
                    adjustmentLine.SaveShopAdjustmentLine();
                else
                    adjustmentLine.UpdateShopAdjustmentLine();
            }
            Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            txtAdjustHangers.Clear();
            txtCurrentHangers.Clear();
            TxtStockCode.Clear();
            txtTotalGain.Clear();
            txtTotalLoss.Clear();
            DgvItems.Rows.Clear();
            txtShopRef.Clear();
            txtShopName.Clear();
            txtReference.Clear();
            DtpDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
        }

        private void DgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Totals()
        {
            int lngqtyhangers = 0;
            int lqtyhangers = 0;
            for (int i = 0; i < DgvItems.Rows.Count; i++)
            {
                if (DgvItems.Rows[i].Cells[1].Value.ToString() == "Loss")
                    lqtyhangers += Convert.ToInt32(DgvItems.Rows[i].Cells[2].Value);
                else
                    lngqtyhangers += Convert.ToInt32(DgvItems.Rows[i].Cells[2].Value);
            }
            txtTotalGain.Text = lngqtyhangers.ToString();
            txtTotalLoss.Text = lqtyhangers.ToString();
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
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtShopRef.AutoCompleteCustomSource = ACSC;
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", txtShopRef.Text);
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
        private void LoadData()
        {
            int ShopAdjustID = Convert.ToInt32(TxtSID.Text);
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable ShopAdjustHead = new DataTable();
                SqlDataAdapter ShopAdjustDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShopAdjustments WHERE ShopAdjustmentID = @ShopAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@ShopAdjustmentID", ShopAdjustID);
                    ShopAdjustDataAdapter.SelectCommand = SelectCmd;
                    ShopAdjustDataAdapter.Fill(ShopAdjustHead);
                }
                txtShopRef.Text = ShopAdjustHead.Rows[0][1].ToString();
                Shop Shop = new Shop();
                Shop.ShopRef = txtShopRef.Text.TrimEnd();
                txtShopName.Text = Shop.GetShopNameFromDB();
                txtReference.Text = ShopAdjustHead.Rows[0][2].ToString();
                txtTotalGain.Text = ShopAdjustHead.Rows[0][4].ToString();
                txtTotalLoss.Text = ShopAdjustHead.Rows[0][3].ToString();
                DtpDate.Value = Convert.ToDateTime(ShopAdjustHead.Rows[0][5]);
                OldDate = DtpDate.Value;
            }
            DgvItems.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable ShopAdjustLine = new DataTable();
                SqlDataAdapter ShopAdjustLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,MovementType,Qty,Value from tblShopAdjustmentLines WHERE ShopAdjustmentID = @ShopAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@ShopAdjustmentID", ShopAdjustID);
                    ShopAdjustLineDataAdapter.SelectCommand = SelectCmd;
                    ShopAdjustLineDataAdapter.Fill(ShopAdjustLine);
                    DgvItems.DataSource = ShopAdjustLine;
                    DgvItems.AutoGenerateColumns = true;
                    DgvItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    DgvItems.BackgroundColor = Color.LightCoral;
                    DgvItems.DefaultCellStyle.SelectionBackColor = Color.Red;
                    DgvItems.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                    DgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    DgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    DgvItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DgvItems.AllowUserToResizeColumns = false;
                    DgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DgvItems.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                    DgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                    DgvItems.Columns[0].HeaderText = "Stock Code";
                    DgvItems.Columns[1].HeaderText = "Movement Type";
                    DgvItems.Columns[2].HeaderText = "Qty";
                    DgvItems.Columns[3].Visible = false;
                }
            }
        }
    }
}
