
namespace StockController
{
    partial class ShopSaleForm
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
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.TxtStockCode = new System.Windows.Forms.TextBox();
            this.cmdDelToGrid = new System.Windows.Forms.Button();
            this.cmdAddToGrid = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.Label20 = new System.Windows.Forms.Label();
            this.txtSoldToDate = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.txtCurrentQty = new System.Windows.Forms.TextBox();
            this.txtDelivered = new System.Windows.Forms.TextBox();
            this.lblShopName = new System.Windows.Forms.Label();
            this.txtNetSale = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.DgvRecords = new System.Windows.Forms.DataGridView();
            this.DtpTransaction = new System.Windows.Forms.DateTimePicker();
            this.TxtTotalDelivered = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.TxtTotalSold = new System.Windows.Forms.TextBox();
            this.txtTotalCurrQty = new System.Windows.Forms.TextBox();
            this.TxtShopRef = new System.Windows.Forms.TextBox();
            this.txtTotalGarments = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtVATRate = new System.Windows.Forms.TextBox();
            this.TxtSalesID = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(108, 31);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(8);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(117, 17);
            this.CheckBox1.TabIndex = 163;
            this.CheckBox1.Text = "Enter A Zero Stock";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.Visible = false;
            // 
            // TxtStockCode
            // 
            this.TxtStockCode.Location = new System.Drawing.Point(308, 69);
            this.TxtStockCode.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtStockCode.Name = "TxtStockCode";
            this.TxtStockCode.Size = new System.Drawing.Size(165, 20);
            this.TxtStockCode.TabIndex = 125;
            this.TxtStockCode.Leave += new System.EventHandler(this.TxtStockCode_Leave);
            // 
            // cmdDelToGrid
            // 
            this.cmdDelToGrid.Location = new System.Drawing.Point(818, 100);
            this.cmdDelToGrid.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdDelToGrid.Name = "cmdDelToGrid";
            this.cmdDelToGrid.Size = new System.Drawing.Size(104, 29);
            this.cmdDelToGrid.TabIndex = 129;
            this.cmdDelToGrid.Text = "Delete";
            this.cmdDelToGrid.UseVisualStyleBackColor = true;
            this.cmdDelToGrid.Click += new System.EventHandler(this.CmdDelToGrid_Click);
            // 
            // cmdAddToGrid
            // 
            this.cmdAddToGrid.Location = new System.Drawing.Point(704, 100);
            this.cmdAddToGrid.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdAddToGrid.Name = "cmdAddToGrid";
            this.cmdAddToGrid.Size = new System.Drawing.Size(104, 29);
            this.cmdAddToGrid.TabIndex = 128;
            this.cmdAddToGrid.Text = "Add";
            this.cmdAddToGrid.UseVisualStyleBackColor = true;
            this.cmdAddToGrid.Click += new System.EventHandler(this.CmdAddToGrid_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(887, 417);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(104, 29);
            this.cmdCancel.TabIndex = 132;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(773, 417);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(104, 29);
            this.cmdOK.TabIndex = 131;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(575, 44);
            this.Label20.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(28, 13);
            this.Label20.TabIndex = 157;
            this.Label20.Text = "Sold";
            // 
            // txtSoldToDate
            // 
            this.txtSoldToDate.Location = new System.Drawing.Point(561, 70);
            this.txtSoldToDate.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtSoldToDate.Name = "txtSoldToDate";
            this.txtSoldToDate.Size = new System.Drawing.Size(66, 20);
            this.txtSoldToDate.TabIndex = 156;
            this.txtSoldToDate.TabStop = false;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(489, 44);
            this.Label19.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(52, 13);
            this.Label19.TabIndex = 159;
            this.Label19.Text = "Delivered";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(634, 44);
            this.Label18.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(60, 13);
            this.Label18.TabIndex = 154;
            this.Label18.Text = "Current Qty";
            // 
            // txtCurrentQty
            // 
            this.txtCurrentQty.Location = new System.Drawing.Point(637, 70);
            this.txtCurrentQty.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtCurrentQty.Name = "txtCurrentQty";
            this.txtCurrentQty.Size = new System.Drawing.Size(59, 20);
            this.txtCurrentQty.TabIndex = 155;
            this.txtCurrentQty.TabStop = false;
            // 
            // txtDelivered
            // 
            this.txtDelivered.Location = new System.Drawing.Point(479, 70);
            this.txtDelivered.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtDelivered.Name = "txtDelivered";
            this.txtDelivered.Size = new System.Drawing.Size(71, 20);
            this.txtDelivered.TabIndex = 158;
            this.txtDelivered.TabStop = false;
            // 
            // lblShopName
            // 
            this.lblShopName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShopName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblShopName.Location = new System.Drawing.Point(479, 9);
            this.lblShopName.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(363, 20);
            this.lblShopName.TabIndex = 162;
            // 
            // txtNetSale
            // 
            this.txtNetSale.Location = new System.Drawing.Point(787, 69);
            this.txtNetSale.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtNetSale.Name = "txtNetSale";
            this.txtNetSale.Size = new System.Drawing.Size(135, 20);
            this.txtNetSale.TabIndex = 127;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(704, 70);
            this.txtQty.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(63, 20);
            this.txtQty.TabIndex = 126;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(805, 44);
            this.Label14.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(51, 13);
            this.Label14.TabIndex = 152;
            this.Label14.Text = "Net Sale:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(701, 45);
            this.Label13.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(46, 13);
            this.Label13.TabIndex = 153;
            this.Label13.Text = "Quantity";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(286, 262);
            this.Label15.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(15, 13);
            this.Label15.TabIndex = 141;
            this.Label15.Text = "%";
            // 
            // DgvRecords
            // 
            this.DgvRecords.AllowUserToAddRows = false;
            this.DgvRecords.AllowUserToDeleteRows = false;
            this.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecords.Location = new System.Drawing.Point(356, 143);
            this.DgvRecords.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.DgvRecords.Name = "DgvRecords";
            this.DgvRecords.RowHeadersVisible = false;
            this.DgvRecords.RowHeadersWidth = 51;
            this.DgvRecords.Size = new System.Drawing.Size(635, 262);
            this.DgvRecords.TabIndex = 130;
            this.DgvRecords.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecords_CellEndEdit);
            // 
            // DtpTransaction
            // 
            this.DtpTransaction.Location = new System.Drawing.Point(108, 3);
            this.DtpTransaction.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.DtpTransaction.Name = "DtpTransaction";
            this.DtpTransaction.Size = new System.Drawing.Size(177, 20);
            this.DtpTransaction.TabIndex = 123;
            this.DtpTransaction.ValueChanged += new System.EventHandler(this.DtpTransaction_ValueChanged);
            // 
            // TxtTotalDelivered
            // 
            this.TxtTotalDelivered.Enabled = false;
            this.TxtTotalDelivered.Location = new System.Drawing.Point(479, 414);
            this.TxtTotalDelivered.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtTotalDelivered.Name = "TxtTotalDelivered";
            this.TxtTotalDelivered.Size = new System.Drawing.Size(62, 20);
            this.TxtTotalDelivered.TabIndex = 149;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(305, 44);
            this.Label12.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(66, 13);
            this.Label12.TabIndex = 160;
            this.Label12.Text = "Stock Code:";
            // 
            // TxtTotalSold
            // 
            this.TxtTotalSold.Enabled = false;
            this.TxtTotalSold.Location = new System.Drawing.Point(561, 414);
            this.TxtTotalSold.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtTotalSold.Name = "TxtTotalSold";
            this.TxtTotalSold.Size = new System.Drawing.Size(66, 20);
            this.TxtTotalSold.TabIndex = 151;
            // 
            // txtTotalCurrQty
            // 
            this.txtTotalCurrQty.Enabled = false;
            this.txtTotalCurrQty.Location = new System.Drawing.Point(637, 414);
            this.txtTotalCurrQty.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtTotalCurrQty.Name = "txtTotalCurrQty";
            this.txtTotalCurrQty.Size = new System.Drawing.Size(57, 20);
            this.txtTotalCurrQty.TabIndex = 150;
            // 
            // TxtShopRef
            // 
            this.TxtShopRef.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtShopRef.Location = new System.Drawing.Point(370, 6);
            this.TxtShopRef.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtShopRef.Name = "TxtShopRef";
            this.TxtShopRef.Size = new System.Drawing.Size(103, 20);
            this.TxtShopRef.TabIndex = 124;
            this.TxtShopRef.Leave += new System.EventHandler(this.TxtShopRef_Leave);
            // 
            // txtTotalGarments
            // 
            this.txtTotalGarments.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotalGarments.Location = new System.Drawing.Point(126, 385);
            this.txtTotalGarments.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtTotalGarments.Name = "txtTotalGarments";
            this.txtTotalGarments.Size = new System.Drawing.Size(210, 20);
            this.txtTotalGarments.TabIndex = 146;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(420, 417);
            this.Label11.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(39, 13);
            this.Label11.TabIndex = 148;
            this.Label11.Text = "Totals:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotal.Location = new System.Drawing.Point(126, 342);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(210, 20);
            this.txtTotal.TabIndex = 145;
            this.txtTotal.TabStop = false;
            // 
            // txtVAT
            // 
            this.txtVAT.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtVAT.Location = new System.Drawing.Point(126, 300);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(210, 20);
            this.txtVAT.TabIndex = 142;
            this.txtVAT.TabStop = false;
            // 
            // txtNet
            // 
            this.txtNet.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNet.Location = new System.Drawing.Point(126, 215);
            this.txtNet.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(210, 20);
            this.txtNet.TabIndex = 139;
            this.txtNet.TabStop = false;
            // 
            // txtVATRate
            // 
            this.txtVATRate.Location = new System.Drawing.Point(126, 258);
            this.txtVATRate.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.txtVATRate.Name = "txtVATRate";
            this.txtVATRate.Size = new System.Drawing.Size(130, 20);
            this.txtVATRate.TabIndex = 135;
            // 
            // TxtSalesID
            // 
            this.TxtSalesID.BackColor = System.Drawing.Color.White;
            this.TxtSalesID.Location = new System.Drawing.Point(900, 6);
            this.TxtSalesID.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.TxtSalesID.Name = "TxtSalesID";
            this.TxtSalesID.Size = new System.Drawing.Size(56, 20);
            this.TxtSalesID.TabIndex = 133;
            this.TxtSalesID.TabStop = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Fuchsia;
            this.Label10.Location = new System.Drawing.Point(305, 9);
            this.Label10.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(64, 13);
            this.Label10.TabIndex = 161;
            this.Label10.Text = "Shop Ref:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(23, 385);
            this.Label9.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(82, 13);
            this.Label9.TabIndex = 147;
            this.Label9.Text = "Total Garments:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(71, 342);
            this.Label8.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(34, 13);
            this.Label8.TabIndex = 144;
            this.Label8.Text = "Total:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(74, 300);
            this.Label7.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(31, 13);
            this.Label7.TabIndex = 143;
            this.Label7.Text = "VAT:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(78, 215);
            this.Label6.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(27, 13);
            this.Label6.TabIndex = 138;
            this.Label6.Text = "Net:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(88, 177);
            this.Label5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(113, 20);
            this.Label5.TabIndex = 137;
            this.Label5.Text = "Sales Totals:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(48, 258);
            this.Label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(57, 13);
            this.Label4.TabIndex = 140;
            this.Label4.Text = "VAT Rate:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(92, 13);
            this.Label2.TabIndex = 136;
            this.Label2.Text = "Transaction Date:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(843, 10);
            this.Label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 134;
            this.Label1.Text = "Sales ID:";
            // 
            // ShopSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 455);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.TxtStockCode);
            this.Controls.Add(this.cmdDelToGrid);
            this.Controls.Add(this.cmdAddToGrid);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.txtSoldToDate);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.txtCurrentQty);
            this.Controls.Add(this.txtDelivered);
            this.Controls.Add(this.lblShopName);
            this.Controls.Add(this.txtNetSale);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.DgvRecords);
            this.Controls.Add(this.DtpTransaction);
            this.Controls.Add(this.TxtTotalDelivered);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.TxtTotalSold);
            this.Controls.Add(this.txtTotalCurrQty);
            this.Controls.Add(this.TxtShopRef);
            this.Controls.Add(this.txtTotalGarments);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtNet);
            this.Controls.Add(this.txtVATRate);
            this.Controls.Add(this.TxtSalesID);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "ShopSaleForm";
            this.Text = "ShopSaleForm";
            this.Load += new System.EventHandler(this.ShopSaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.TextBox TxtStockCode;
        internal System.Windows.Forms.Button cmdDelToGrid;
        internal System.Windows.Forms.Button cmdAddToGrid;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.TextBox txtSoldToDate;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox txtCurrentQty;
        internal System.Windows.Forms.TextBox txtDelivered;
        internal System.Windows.Forms.Label lblShopName;
        internal System.Windows.Forms.TextBox txtNetSale;
        internal System.Windows.Forms.TextBox txtQty;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.DataGridView DgvRecords;
        internal System.Windows.Forms.DateTimePicker DtpTransaction;
        internal System.Windows.Forms.TextBox TxtTotalDelivered;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox TxtTotalSold;
        internal System.Windows.Forms.TextBox txtTotalCurrQty;
        internal System.Windows.Forms.TextBox TxtShopRef;
        internal System.Windows.Forms.TextBox txtTotalGarments;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.TextBox txtVAT;
        internal System.Windows.Forms.TextBox txtNet;
        internal System.Windows.Forms.TextBox txtVATRate;
        internal System.Windows.Forms.TextBox TxtSalesID;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}