
namespace StockController
{
    partial class SeasonForm
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
            this.CmdCancel = new System.Windows.Forms.Button();
            this.TxtSeasonName = new System.Windows.Forms.TextBox();
            this.LblSeasonID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(383, 78);
            this.CmdCancel.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(118, 46);
            this.CmdCancel.TabIndex = 23;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // TxtSeasonName
            // 
            this.TxtSeasonName.Location = new System.Drawing.Point(110, 46);
            this.TxtSeasonName.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.TxtSeasonName.Name = "TxtSeasonName";
            this.TxtSeasonName.Size = new System.Drawing.Size(391, 20);
            this.TxtSeasonName.TabIndex = 22;
            // 
            // LblSeasonID
            // 
            this.LblSeasonID.BackColor = System.Drawing.Color.MistyRose;
            this.LblSeasonID.Location = new System.Drawing.Point(110, 9);
            this.LblSeasonID.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LblSeasonID.Name = "LblSeasonID";
            this.LblSeasonID.Size = new System.Drawing.Size(159, 24);
            this.LblSeasonID.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Season Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Season ID:";
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(260, 78);
            this.CmdOK.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(118, 46);
            this.CmdOK.TabIndex = 18;
            this.CmdOK.Text = "OK";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // SeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 133);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.TxtSeasonName);
            this.Controls.Add(this.LblSeasonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdOK);
            this.Name = "SeasonForm";
            this.Text = "Season";
            this.Load += new System.EventHandler(this.SeasonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.TextBox TxtSeasonName;
        private System.Windows.Forms.Label LblSeasonID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdOK;
    }
}