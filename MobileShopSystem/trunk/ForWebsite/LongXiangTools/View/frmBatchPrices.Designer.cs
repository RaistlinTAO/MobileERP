namespace LongXiangTools.View
{
    partial class frmBatchPrices
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
            this.tcPrices = new System.Windows.Forms.TabControl();
            this.lblExit = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tcPrices
            // 
            this.tcPrices.Location = new System.Drawing.Point(12, 12);
            this.tcPrices.Name = "tcPrices";
            this.tcPrices.SelectedIndex = 0;
            this.tcPrices.Size = new System.Drawing.Size(705, 512);
            this.tcPrices.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcPrices.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Location = new System.Drawing.Point(717, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(11, 12);
            this.lblExit.TabIndex = 1;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdate.Location = new System.Drawing.Point(628, 530);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(89, 23);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "更新";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // frmBatchPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::LongXiangTools.Properties.Resources._123;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(729, 560);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.tcPrices);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Honeydew;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatchPrices";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBatchPrices";
            this.Load += new System.EventHandler(this.frmBatchPrices_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBatchPrices_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcPrices;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Button cmdUpdate;
    }
}