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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {
            int TotalUsers;
            int PassResult;
            Employee oEmployee = new Employee();
            TotalUsers = oEmployee.GetAllUserTotal();
            PassResult = oEmployee.GetLoginUserID(TxtUserName.Text.TrimEnd(), TxtPassword.Text.TrimEnd());
            if (TotalUsers == 0)
            {
                DialogResult dialog = MessageBox.Show("Unknown User and do you wish to add new user?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialog == DialogResult.Yes)
                {
                    EmployeeForm frmEmployee = new EmployeeForm
                    {
                        FormMode = "New"
                    };                    
                    frmEmployee.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    TxtUserName.Clear();
                    TxtPassword.Clear();
                    TxtUserName.Select();
                }
            }
            else
            {
                if (PassResult != 0)
                {
                    MainInterfaceForm frmMain = new MainInterfaceForm
                    {
                        RefToLoginForm = this,
                        UserID = PassResult
                    };
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    Application.Exit(); // unknown user need to keep system secure.
                }
            }
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();     // Exit the application
        }
    }
}
