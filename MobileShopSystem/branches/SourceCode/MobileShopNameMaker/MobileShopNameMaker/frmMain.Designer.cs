namespace MobileShopNameMaker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdMake = new System.Windows.Forms.Button();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.txtShopCNName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdMake
            // 
            this.cmdMake.Location = new System.Drawing.Point(213, 82);
            this.cmdMake.Name = "cmdMake";
            this.cmdMake.Size = new System.Drawing.Size(75, 23);
            this.cmdMake.TabIndex = 0;
            this.cmdMake.Text = "Make";
            this.cmdMake.UseVisualStyleBackColor = true;
            this.cmdMake.Click += new System.EventHandler(this.cmdMake_Click);
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(115, 12);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(173, 21);
            this.txtShopName.TabIndex = 1;
            // 
            // txtShopCNName
            // 
            this.txtShopCNName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtShopCNName.Location = new System.Drawing.Point(115, 39);
            this.txtShopCNName.Name = "txtShopCNName";
            this.txtShopCNName.Size = new System.Drawing.Size(173, 21);
            this.txtShopCNName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shop Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shop CN Name:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 116);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShopCNName);
            this.Controls.Add(this.txtShopName);
            this.Controls.Add(this.cmdMake);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Name Gen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMake;
        private System.Windows.Forms.TextBox txtShopName;
        private System.Windows.Forms.TextBox txtShopCNName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}