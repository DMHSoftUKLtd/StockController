
namespace StockController
{
    partial class ShopReturnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReturnID = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.txtCurrentQty = new System.Windows.Forms.TextBox();
            this.TxtStockCode = new System.Windows.Forms.TextBox();
            this.TxtShopRef = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdClearGrid = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.txtTransferQty = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.TxtWarehouseRef = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.DgvRecords = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(469, 628);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 34);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(84, 60);
            this.txtReference.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtReference.MaxLength = 50;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(364, 20);
            this.txtReference.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(204, 92);
            this.Label5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(38, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Name:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 152);
            this.Label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Current Qty:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 118);
            this.Label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Stock Code:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 91);
            this.Label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(55, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Shop Ref:";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(258, 628);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(91, 34);
            this.cmdOK.TabIndex = 13;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtReturnID);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.DtpDate);
            this.GroupBox1.Controls.Add(this.txtShopName);
            this.GroupBox1.Controls.Add(this.txtCurrentQty);
            this.GroupBox1.Controls.Add(this.TxtStockCode);
            this.GroupBox1.Controls.Add(this.TxtShopRef);
            this.GroupBox1.Controls.Add(this.txtReference);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(10, 10);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.GroupBox1.Size = new System.Drawing.Size(547, 181);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Current";
            // 
            // txtReturnID
            // 
            this.txtReturnID.Enabled = false;
            this.txtReturnID.Location = new System.Drawing.Point(84, 23);
            this.txtReturnID.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtReturnID.Name = "txtReturnID";
            this.txtReturnID.Size = new System.Drawing.Size(160, 20);
            this.txtReturnID.TabIndex = 4;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(24, 26);
            this.Label11.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(50, 13);
            this.Label11.TabIndex = 9;
            this.Label11.Text = "ReturnID";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(264, 26);
            this.Label9.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(33, 13);
            this.Label9.TabIndex = 5;
            this.Label9.Text = "Date:";
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd-MM-yyyy";
            this.DtpDate.Location = new System.Drawing.Point(317, 23);
            this.DtpDate.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(199, 20);
            this.DtpDate.TabIndex = 0;
            this.DtpDate.Value = new System.DateTime(2016, 2, 7, 0, 0, 0, 0);
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(248, 88);
            this.txtShopName.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(282, 20);
            this.txtShopName.TabIndex = 7;
            this.txtShopName.TabStop = false;
            // 
            // txtCurrentQty
            // 
            this.txtCurrentQty.Location = new System.Drawing.Point(84, 152);
            this.txtCurrentQty.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtCurrentQty.Name = "txtCurrentQty";
            this.txtCurrentQty.Size = new System.Drawing.Size(108, 20);
            this.txtCurrentQty.TabIndex = 14;
            // 
            // TxtStockCode
            // 
            this.TxtStockCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtStockCode.Location = new System.Drawing.Point(84, 118);
            this.TxtStockCode.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtStockCode.MaxLength = 30;
            this.TxtStockCode.Name = "TxtStockCode";
            this.TxtStockCode.Size = new System.Drawing.Size(364, 20);
            this.TxtStockCode.TabIndex = 3;
            this.TxtStockCode.Leave += new System.EventHandler(this.TxtStockCode_Leave);
            // 
            // TxtShopRef
            // 
            this.TxtShopRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtShopRef.Location = new System.Drawing.Point(84, 88);
            this.TxtShopRef.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtShopRef.MaxLength = 8;
            this.TxtShopRef.Name = "TxtShopRef";
            this.TxtShopRef.Size = new System.Drawing.Size(108, 20);
            this.TxtShopRef.TabIndex = 2;
            this.TxtShopRef.Leave += new System.EventHandler(this.TxtShopRef_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 63);
            this.Label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Reference:";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(1215, 144);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(115, 17);
            this.CheckBox1.TabIndex = 11;
            this.CheckBox1.Text = "Return To Supplier";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.Visible = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(8, 25);
            this.Label6.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(85, 13);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Warehouse Ref:";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Value";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 125;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(360, 628);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(98, 34);
            this.cmdClear.TabIndex = 15;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            // 
            // cmdClearGrid
            // 
            this.cmdClearGrid.Location = new System.Drawing.Point(300, 78);
            this.cmdClearGrid.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdClearGrid.Name = "cmdClearGrid";
            this.cmdClearGrid.Size = new System.Drawing.Size(74, 34);
            this.cmdClearGrid.TabIndex = 3;
            this.cmdClearGrid.Text = "Delete All";
            this.cmdClearGrid.UseVisualStyleBackColor = true;
            this.cmdClearGrid.Click += new System.EventHandler(this.CmdClearGrid_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtTotalItems);
            this.GroupBox2.Controls.Add(this.cmdClearGrid);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.cmdAdd);
            this.GroupBox2.Controls.Add(this.txtTransferQty);
            this.GroupBox2.Controls.Add(this.txtWarehouseName);
            this.GroupBox2.Controls.Add(this.TxtWarehouseRef);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.DgvRecords);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Location = new System.Drawing.Point(10, 206);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.GroupBox2.Size = new System.Drawing.Size(547, 413);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Return To:";
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Location = new System.Drawing.Point(203, 378);
            this.txtTotalItems.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(94, 20);
            this.txtTotalItems.TabIndex = 10;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(55, 381);
            this.Label10.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(62, 13);
            this.Label10.TabIndex = 9;
            this.Label10.Text = "Total Items:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(212, 78);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(68, 30);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // txtTransferQty
            // 
            this.txtTransferQty.Location = new System.Drawing.Point(102, 84);
            this.txtTransferQty.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtTransferQty.Name = "txtTransferQty";
            this.txtTransferQty.Size = new System.Drawing.Size(90, 20);
            this.txtTransferQty.TabIndex = 1;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(102, 50);
            this.txtWarehouseName.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(283, 20);
            this.txtWarehouseName.TabIndex = 7;
            this.txtWarehouseName.TabStop = false;
            // 
            // TxtWarehouseRef
            // 
            this.TxtWarehouseRef.Location = new System.Drawing.Point(102, 22);
            this.TxtWarehouseRef.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtWarehouseRef.MaxLength = 8;
            this.TxtWarehouseRef.Name = "TxtWarehouseRef";
            this.TxtWarehouseRef.Size = new System.Drawing.Size(224, 20);
            this.TxtWarehouseRef.TabIndex = 0;
            this.TxtWarehouseRef.Leave += new System.EventHandler(this.TxtWarehouseRef_Leave);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(25, 87);
            this.Label8.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(68, 13);
            this.Label8.TabIndex = 6;
            this.Label8.Text = "Transfer Qty:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(55, 57);
            this.Label7.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(38, 13);
            this.Label7.TabIndex = 5;
            this.Label7.Text = "Name:";
            // 
            // DgvRecords
            // 
            this.DgvRecords.AllowUserToAddRows = false;
            this.DgvRecords.AllowUserToDeleteRows = false;
            this.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvRecords.Location = new System.Drawing.Point(9, 132);
            this.DgvRecords.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.DgvRecords.Name = "DgvRecords";
            this.DgvRecords.RowHeadersWidth = 51;
            this.DgvRecords.Size = new System.Drawing.Size(468, 237);
            this.DgvRecords.TabIndex = 8;
            this.DgvRecords.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecords_CellEndEdit);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Stock Code";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // ShopReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 673);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.GroupBox2);
            this.Name = "ShopReturnForm";
            this.Text = "Shop Return";
            this.Load += new System.EventHandler(this.ShopReturnForm_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtReference;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtReturnID;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.DateTimePicker DtpDate;
        internal System.Windows.Forms.TextBox txtShopName;
        internal System.Windows.Forms.TextBox txtCurrentQty;
        internal System.Windows.Forms.TextBox TxtStockCode;
        internal System.Windows.Forms.TextBox TxtShopRef;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdClearGrid;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtTotalItems;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.TextBox txtTransferQty;
        internal System.Windows.Forms.TextBox txtWarehouseName;
        internal System.Windows.Forms.TextBox TxtWarehouseRef;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridView DgvRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}