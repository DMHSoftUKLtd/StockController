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
    public partial class SeasonForm : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        public int SeasonID;
      
        public SeasonForm()
        {
            InitializeComponent();
        }

        private void SeasonForm_Load(object sender, EventArgs e)
        {
            // setup the form
            if (FormMode == "New")
                CmdOK.Text = "Save";
            else
            {
                CmdOK.Text = "OK";
                LblSeasonID.Text = SeasonID.ToString();
                TxtSeasonName.Text = LoadData();
            }
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            // Saving the record to the database if the form is new mode
            // updating the record in the database if the form is old mode
            Season oSeason = new Season
            {
                SeasonName = TxtSeasonName.Text.TrimEnd()
            };
            if (FormMode == "New")
            {
                oSeason.SaveSeasonRecordToDB();
            }
            else
            {
                oSeason.SeasonID = Convert.ToInt32(LblSeasonID.Text);
                oSeason.UpdateSeasonRecordInDB();
            }
            this.Close();   // close the form
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // Close the form
        }
        private string LoadData()
        {
            // load the data from the database of the selected ID
            string SName = "";
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = Utility.GetConnString(1);
                    try
                    {
                        conn.Open();
                        using (SqlCommand SelectCmd = new SqlCommand())
                        {
                            SelectCmd.Connection = conn;
                            SelectCmd.CommandText = "SELECT SeasonName from tblSeasons WHERE SeasonID = @SeasonID";
                            SelectCmd.Parameters.AddWithValue("@SeasonID", SeasonID);
                            SName = (string)SelectCmd.ExecuteScalar();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        conn.Close();
                        conn.Dispose();
                        throw;
                    }
                }
            }
            finally
            {
                //SName = "Unable to Get Data";
            }
            return SName;
        }
    }
}
