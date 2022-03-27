﻿using System;
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
            LoadWarehouseIntoForm();
            LoadSupplierIntoForm();
            if (FormMode == "New")
            {
                cmdOK.Text = "Save";
                this.Text = "New Warehouse Return";
                DtpDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                cmdOK.Text = "OK";
                LoadData();
            }
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            int rownum;
            rownum = (int)DgvRecords.Rows.Add();
            DgvRecords.Rows[rownum].Cells[0].Value = txtStockCode.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[1].Value = txtTransferQty.Text.TrimEnd();
            Totals();
            txtTransferQty.Clear();
            txtCurrentQty.Clear();
            txtStockCode.Clear();
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
            WarehouseReturn returnHead = new WarehouseReturn();
            WarehouseReturn returnLine = new WarehouseReturn();
            Log logs = new Log();
            int SavedID = 0;
            // Header of both adjustments and log file
            returnHead.WarehouseRef = txtWarehouseRef.Text.TrimEnd();
            returnHead.Reference = txtReference.Text.TrimEnd();
            returnHead.SupplierRef = txtSupplierRef.Text.TrimEnd();
            returnHead.TotalItems = Convert.ToInt32(txtTotalItems.Text.TrimEnd());
            returnHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            logs.MovementDate = returnHead.MovementDate;
            returnHead.UserID = UserID;
            logs.UserID = returnHead.UserID;
            if (FormMode == "New")
            {
                returnHead.SaveWarehouseReturnHead();
                SavedID = returnHead.GetLastWarehouseReturnHead();
            }
            else
            {
                Log Dlogs = new Log();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(txtReturnID.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 9;
                Dlogs.DeleteFromStockMovemmentsTable();
                returnHead.WarehouseReturnID = Convert.ToInt32(txtReturnID.Text.TrimEnd());
                returnHead.UpdateWarehouseReturnHead();
            }
            logs.TransferReference = SavedID;
            returnLine.WarehouseReturnID = SavedID;
            logs.LocationType = 1;
            logs.MovementType = 9;
            logs.Reference = "Warehouse Return";
            logs.StringMovementType = "Warehouse Return Item";
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                logs.LocationRef = returnHead.WarehouseRef;
                returnLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                returnLine.ReturnQty = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value);
                if (FormMode == "New")
                {
                    logs.LocationRef = returnHead.WarehouseRef;
                    logs.StockCode = returnLine.StockCode;
                    logs.SupplierRef = "N/A";
                    logs.Qty = returnLine.ReturnQty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    returnLine.SaveWarehouseReturnLine();
                    logs.LocationRef = returnHead.SupplierRef;
                    logs.Qty = returnLine.ReturnQty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
                else
                {
                    logs.LocationRef = returnHead.WarehouseRef;
                    logs.Qty = returnLine.ReturnQty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    returnLine.UpdateWarehouseReturnLine();
                    logs.LocationRef = returnHead.SupplierRef;
                    logs.Qty = returnLine.ReturnQty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
            }
            this.Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            txtTotalItems.Clear();
            txtStockCode.Clear();
            DgvRecords.Rows.Clear();
            txtSupplierRef.Clear();
            txtSupplierName.Clear();
            txtWarehouseRef.Clear();
            txtWarehouseName.Clear();
            txtReference.Clear();
            DtpDate.Value = Utility.GetSundayDate(DateTime.Now, 1);
        }

        private void TxtWarehouseRef_Leave(object sender, EventArgs e)
        {
            LoadStockIntoForm();
            txtWarehouseRef.Text = Warehouse.ChangeCase(txtWarehouseRef.Text, 1);
            Warehouse warehouse = new Warehouse()
            {
                WarehouseRef = txtWarehouseRef.Text.TrimEnd()
            };
            txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            txtStockCode.Text = Utility.ChangeCase(txtStockCode.Text, 1);
            Stock stock = new Stock();
            stock.StockCode = txtStockCode.Text.TrimEnd();
            stock.WarehouseRef = txtWarehouseRef.Text.TrimEnd();
            txtCurrentQty.Text = stock.GetWarehouseStockQty().ToString();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            DtpDate.Value = Utility.GetSundayDate(DtpDate.Value, 1);
        }

        private void TxtSupplierRef_Leave(object sender, EventArgs e)
        {
            txtSupplierRef.Text = Supplier.ChangeCase(txtSupplierRef.Text, 1);
            Supplier warehouse = new Supplier()
            {
                SupplierRef = txtSupplierRef.Text.TrimEnd()
            };
            txtSupplierName.Text = warehouse.GetSupplierNameFromDB();
        }

        private void DgvRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadSupplierIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT SupplierRef from tblSuppliers", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            txtSupplierRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSupplierRef.AutoCompleteCustomSource = ACSC;
            txtSupplierRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            txtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtWarehouseRef.AutoCompleteCustomSource = ACSC;
            txtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text);
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStockCode.AutoCompleteCustomSource = ACSC;
            txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
        private void LoadData()
        {
            int WarehouseReturnID = Convert.ToInt32(txtReturnID.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable WarehouseReturnHead = new DataTable();
                SqlDataAdapter WarehouseReturnDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblWarehouseReturns WHERE WarehouseReturnsID = @WarehouseReturnsID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseReturnsID", WarehouseReturnID);
                    WarehouseReturnDataAdapter.SelectCommand = SelectCmd;
                    WarehouseReturnDataAdapter.Fill(WarehouseReturnHead);
                }
                txtWarehouseRef.Text = WarehouseReturnHead.Rows[0][1].ToString();
                Warehouse warehouse = new Warehouse();
                warehouse.WarehouseRef = txtWarehouseRef.Text;
                txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                txtSupplierRef.Text = WarehouseReturnHead.Rows[0][2].ToString();
                Supplier supplier = new Supplier();
                supplier.SupplierRef = txtSupplierRef.Text.TrimEnd();
                txtSupplierName.Text = supplier.GetSupplierNameFromDB();
                txtReference.Text = WarehouseReturnHead.Rows[0][3].ToString();
                txtTotalItems.Text = WarehouseReturnHead.Rows[0][4].ToString();
                DtpDate.Value = Convert.ToDateTime(WarehouseReturnHead.Rows[0][5]);
                OldDate = DtpDate.Value;
            }
            DgvRecords.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable WarehouseReturnLine = new DataTable();
                SqlDataAdapter WarehouseReturnLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,Qty from tblWarehouseReturnLines WHERE WarehouseReturnID = @WarehouseReturnID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseReturnID", WarehouseReturnID);
                    WarehouseReturnLineDataAdapter.SelectCommand = SelectCmd;
                    WarehouseReturnLineDataAdapter.Fill(WarehouseReturnLine);
                    DgvRecords.DataSource = WarehouseReturnLine;
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
    }
}
