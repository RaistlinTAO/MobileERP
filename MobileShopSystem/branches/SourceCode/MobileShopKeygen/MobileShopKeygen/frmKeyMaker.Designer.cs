namespace MobileShopKeygen
{
    partial class frmKeyMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeyMaker));
            this.txtKey = new System.Windows.Forms.TextBox();
            this.cmdMake = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(13, 13);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(365, 21);
            this.txtKey.TabIndex = 0;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdMake
            // 
            this.cmdMake.Location = new System.Drawing.Point(159, 64);
            this.cmdMake.Name = "cmdMake";
            this.cmdMake.Size = new System.Drawing.Size(75, 22);
            this.cmdMake.TabIndex = 1;
            this.cmdMake.Text = "Make";
            this.cmdMake.UseVisualStyleBackColor = true;
            this.cmdMake.Click += new System.EventHandler(this.cmdMake_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Length:";
            // 
            // txtLength
            // 
            this.txtLength.AutoSize = true;
            this.txtLength.Location = new System.Drawing.Point(66, 41);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(0, 12);
            this.txtLength.TabIndex = 3;
            // 
            // frmKeyMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 94);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdMake);
            this.Controls.Add(this.txtKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKeyMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button cmdMake;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtLength;
    }
}