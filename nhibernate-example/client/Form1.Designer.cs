namespace client
{
    partial class Form1
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCC = new System.Windows.Forms.Button();
            this.btnPaypal = new System.Windows.Forms.Button();
            this.btnPullAll = new System.Windows.Forms.Button();
            this.btnAddPayPal = new System.Windows.Forms.Button();
            this.btnAddCC = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDeleteCC = new System.Windows.Forms.Button();
            this.btnDeletePP = new System.Windows.Forms.Button();
            this.btnPullAllItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(363, 303);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "*Bear* with us while we (n)Hibernate";
            // 
            // btnCC
            // 
            this.btnCC.Location = new System.Drawing.Point(12, 274);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(110, 23);
            this.btnCC.TabIndex = 2;
            this.btnCC.Text = "Pull CC Details";
            this.btnCC.UseVisualStyleBackColor = true;
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnPaypal
            // 
            this.btnPaypal.Location = new System.Drawing.Point(12, 303);
            this.btnPaypal.Name = "btnPaypal";
            this.btnPaypal.Size = new System.Drawing.Size(110, 23);
            this.btnPaypal.TabIndex = 3;
            this.btnPaypal.Text = "Pull Paypal  Details";
            this.btnPaypal.UseVisualStyleBackColor = true;
            this.btnPaypal.Click += new System.EventHandler(this.btnPaypal_Click);
            // 
            // btnPullAll
            // 
            this.btnPullAll.Location = new System.Drawing.Point(311, 303);
            this.btnPullAll.Name = "btnPullAll";
            this.btnPullAll.Size = new System.Drawing.Size(46, 23);
            this.btnPullAll.TabIndex = 4;
            this.btnPullAll.Text = "Orders";
            this.btnPullAll.UseVisualStyleBackColor = true;
            this.btnPullAll.Click += new System.EventHandler(this.btnPullAll_Click);
            // 
            // btnAddPayPal
            // 
            this.btnAddPayPal.Location = new System.Drawing.Point(128, 303);
            this.btnAddPayPal.Name = "btnAddPayPal";
            this.btnAddPayPal.Size = new System.Drawing.Size(25, 23);
            this.btnAddPayPal.TabIndex = 5;
            this.btnAddPayPal.Text = "+";
            this.btnAddPayPal.UseVisualStyleBackColor = true;
            this.btnAddPayPal.Click += new System.EventHandler(this.btnAddPayPal_Click);
            // 
            // btnAddCC
            // 
            this.btnAddCC.Location = new System.Drawing.Point(128, 274);
            this.btnAddCC.Name = "btnAddCC";
            this.btnAddCC.Size = new System.Drawing.Size(25, 23);
            this.btnAddCC.TabIndex = 6;
            this.btnAddCC.Text = "+";
            this.btnAddCC.UseVisualStyleBackColor = true;
            this.btnAddCC.Click += new System.EventHandler(this.btnAddCC_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(265, 276);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(63, 20);
            this.txtOrderNumber.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(334, 274);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(104, 20);
            this.txtName.TabIndex = 8;
            // 
            // btnDeleteCC
            // 
            this.btnDeleteCC.Location = new System.Drawing.Point(159, 274);
            this.btnDeleteCC.Name = "btnDeleteCC";
            this.btnDeleteCC.Size = new System.Drawing.Size(25, 23);
            this.btnDeleteCC.TabIndex = 9;
            this.btnDeleteCC.Text = "-";
            this.btnDeleteCC.UseVisualStyleBackColor = true;
            this.btnDeleteCC.Click += new System.EventHandler(this.btnDeleteCC_Click);
            // 
            // btnDeletePP
            // 
            this.btnDeletePP.Location = new System.Drawing.Point(159, 303);
            this.btnDeletePP.Name = "btnDeletePP";
            this.btnDeletePP.Size = new System.Drawing.Size(25, 23);
            this.btnDeletePP.TabIndex = 10;
            this.btnDeletePP.Text = "-";
            this.btnDeletePP.UseVisualStyleBackColor = true;
            this.btnDeletePP.Click += new System.EventHandler(this.btnDeletePP_Click);
            // 
            // btnPullAllItems
            // 
            this.btnPullAllItems.Location = new System.Drawing.Point(265, 302);
            this.btnPullAllItems.Name = "btnPullAllItems";
            this.btnPullAllItems.Size = new System.Drawing.Size(46, 23);
            this.btnPullAllItems.TabIndex = 11;
            this.btnPullAllItems.Text = "Items";
            this.btnPullAllItems.UseVisualStyleBackColor = true;
            this.btnPullAllItems.Click += new System.EventHandler(this.btnPullAllItems_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::client.Properties.Resources.o78k5fogx5g3hdy6peai;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(450, 338);
            this.Controls.Add(this.btnPullAllItems);
            this.Controls.Add(this.btnDeletePP);
            this.Controls.Add(this.btnDeleteCC);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.btnAddCC);
            this.Controls.Add(this.btnAddPayPal);
            this.Controls.Add(this.btnPullAll);
            this.Controls.Add(this.btnPaypal);
            this.Controls.Add(this.btnCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCC;
        private System.Windows.Forms.Button btnPaypal;
        private System.Windows.Forms.Button btnPullAll;
        private System.Windows.Forms.Button btnAddPayPal;
        private System.Windows.Forms.Button btnAddCC;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDeleteCC;
        private System.Windows.Forms.Button btnDeletePP;
        private System.Windows.Forms.Button btnPullAllItems;
    }
}

