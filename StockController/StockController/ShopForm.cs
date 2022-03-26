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
    public partial class ShopForm : Form
    {
        public int UserID { get; set; } // to hold the user's UserID
        public string FormMode { get; set; }    // to set the mode of the form
        public string ShopRef { get; set; } // to hold the first column of the selected grid

        public ShopForm()
        {
            InitializeComponent();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            // Setup the form 
            // new = blank form loaded and ready to add new record
            // old = filled out form and ready to update old record
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";    // change the text based on the mode of the form
                Text = "New Shop";  // change form title to reflect mode of form
            }
            else
            {
                CmdOK.Text = "OK";
                LoadData(); // Gets data from database and load's into form.
            }
        }

        private void TxtShopRef_Leave(object sender, EventArgs e)
        {
            TxtShopRef.Text = Utility.ChangeCase(TxtShopRef.Text, 1);
        }

        private void TxtShopName_Leave(object sender, EventArgs e)
        {
            TxtShopName.Text = Utility.ChangeCase(TxtShopName.Text, 0);
        }

        private void TxtContactName_Leave(object sender, EventArgs e)
        {
            TxtContactName.Text = Utility.ChangeCase(TxtContactName.Text, 0);
        }

        private void TxtAddress1_Leave(object sender, EventArgs e)
        {
            TxtAddress1.Text = Utility.ChangeCase(TxtAddress1.Text, 0);
        }

        private void TxtAddress2_Leave(object sender, EventArgs e)
        {
            TxtAddress2.Text = Utility.ChangeCase(TxtAddress2.Text, 0);
        }

        private void TxtAddress3_Leave(object sender, EventArgs e)
        {
            TxtAddress3.Text = Utility.ChangeCase(TxtAddress3.Text, 0);
        }

        private void TxtAddress4_Leave(object sender, EventArgs e)
        {
            TxtAddress4.Text = Utility.ChangeCase(TxtAddress4.Text, 0);
        }

        private void TxtPostCode_Leave(object sender, EventArgs e)
        {
            TxtPostCode.Text = Utility.ChangeCase(TxtPostCode.Text, 1);
        }

        private void TxteMail_Leave(object sender, EventArgs e)
        {
            // check the email address to see if correct format
            if (TxteMail.TextLength != 0)
            {
                if (Utility.IsValidEmail(TxteMail.Text))
                    TxteMail.Text = Utility.ChangeCase(TxteMail.Text, 2);
                else
                { TxteMail.Text = "Please Try Again"; }
            }
            else
            {
                // do nothing if email address has not been supplied.
            }
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (TxteMail.Text != "Please Try Again")
            {
                Shop shops = new Shop
                {
                    ShopRef = TxtShopRef.Text.TrimEnd(),
                    ShopName = TxtShopName.Text.TrimEnd(),
                    AddressLine1 = TxtAddress1.Text.TrimEnd(),
                    AddressLine2 = TxtAddress2.Text.TrimEnd(),
                    AddressLine3 = TxtAddress3.Text.TrimEnd(),
                    AddressLine4 = TxtAddress4.Text.TrimEnd(),
                    PostCode = TxtPostCode.Text.TrimEnd(),
                    ShopType = cboWType.Text.TrimEnd(),
                    Telephone = TxtTelephone.Text.TrimEnd(),
                    Fax = TxtFax.Text.TrimEnd(),
                    eMail = TxteMail.Text.TrimEnd(),
                    ContactName = TxtContactName.Text.TrimEnd(),
                    Memo = TxtMemo.Text.TrimEnd(),
                    UserID = UserID
                };
                if (FormMode == "New")
                    shops.SaveShopRecordToDB();
                else
                    shops.UpdateShopRecordInDB();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid email address!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxteMail.SelectAll();
            }
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);   // Clearing all the text from the text boxes on the form
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }
        // to clear all the textboxes
        private void ClearTextBoxes(Control control)
        {
            // Code from https://stackoverflow.com/questions/4811229/how-to-clear-the-text-of-all-textboxes-in-the-form
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }

            }
        }
        private void LoadData()
        {
            // properties for loading data
            int QtyInStock = 0;
            decimal ValueInStock = 0.0m;
            // get the record for the selected shop
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable dtk = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShops Where ShopRef = @ShopRef";
                    SelectCmd.Parameters.AddWithValue("@ShopRef", TxtShopRef.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dtk);
                }
                TxtShopRef.Text = dtk.Rows[0][0].ToString();
                TxtShopName.Text = dtk.Rows[0][1].ToString();
                TxtContactName.Text = dtk.Rows[0][12].ToString();
                TxtAddress1.Text = dtk.Rows[0][2].ToString();
                TxtAddress2.Text = dtk.Rows[0][3].ToString();
                TxtAddress3.Text = dtk.Rows[0][4].ToString();
                TxtAddress4.Text = dtk.Rows[0][5].ToString();
                TxtPostCode.Text = dtk.Rows[0][6].ToString();
                TxtTelephone.Text = dtk.Rows[0][7].ToString();
                TxtFax.Text = dtk.Rows[0][8].ToString();
                TxteMail.Text = dtk.Rows[0][9].ToString();
                TxtMemo.Text = dtk.Rows[0][11].ToString();
                cboWType.Text = dtk.Rows[0][10].ToString();
                this.Text = "Shop Details for [" + TxtShopRef.Text.TrimEnd() + "] " + TxtShopName.Text.TrimEnd();
            }
            // get the stock levels for the selected shop
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode, QtyHangers, Value From QryShopStock Where LocationRef = @LocationRef AND QtyHangers <> '0' ORDER BY StockCode";
                    SelectCmd.Parameters.AddWithValue("@LocationRef", TxtShopRef.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dt);
                }
                gridStocks.DataSource = dt;
                gridStocks.AutoGenerateColumns = true;
                gridStocks.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gridStocks.BackgroundColor = Color.LightCoral;
                gridStocks.DefaultCellStyle.SelectionBackColor = Color.Red;
                gridStocks.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                gridStocks.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gridStocks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridStocks.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridStocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridStocks.AllowUserToResizeColumns = false;
                gridStocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridStocks.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                gridStocks.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                gridStocks.Columns[0].HeaderText = "Stock Code";
                gridStocks.Columns[1].HeaderText = "Qty";
                gridStocks.Columns[2].HeaderText = "Value";
                gridStocks.Columns[2].DefaultCellStyle.Format = "C2";
            }
            // get all the transactions for the selected shop
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Utility.GetConnString(1);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode, MovementType, MovementQtyHangers, MovementDate, MovementReference from tblStockMovements where LocationRef = @LocationRef And LocationType = 2 Order By MovementDate";
                    SelectCmd.Parameters.AddWithValue("@LocationRef", TxtShopRef.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dt);
                }
                gridTrans.DataSource = dt;
                gridTrans.AutoGenerateColumns = true;
                gridTrans.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gridTrans.BackgroundColor = Color.LightCoral;
                gridTrans.DefaultCellStyle.SelectionBackColor = Color.Plum;
                gridTrans.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                gridTrans.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gridTrans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridTrans.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridTrans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridTrans.AllowUserToResizeColumns = false;
                gridTrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridTrans.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                gridTrans.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                gridTrans.Columns[0].HeaderText = "Stock Code";
                gridTrans.Columns[1].HeaderText = "Type";
                gridTrans.Columns[2].HeaderText = "Qty";
                gridTrans.Columns[3].HeaderText = "Date";
            }
            for (int i = 0; i < gridStocks.Rows.Count; i++)
            {
                QtyInStock += Convert.ToInt32(gridStocks.Rows[i].Cells[1].Value);
                ValueInStock += Convert.ToDecimal(gridStocks.Rows[i].Cells[2].Value);
            }
            TxtTotalItems.Text = QtyInStock.ToString();
            TxtTotalValue.Text = ValueInStock.ToString("C2");
        }
    }
}
