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
            this.btnCC.Size = new System.Drawing.Size(153, 23);
            this.btnCC.TabIndex = 2;
            this.btnCC.Text = "Pull CC Payment Details";
            this.btnCC.UseVisualStyleBackColor = true;
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnPaypal
            // 
            this.btnPaypal.Location = new System.Drawing.Point(12, 303);
            this.btnPaypal.Name = "btnPaypal";
            this.btnPaypal.Size = new System.Drawing.Size(153, 23);
            this.btnPaypal.TabIndex = 3;
            this.btnPaypal.Text = "Pull Paypal Payment Details";
            this.btnPaypal.UseVisualStyleBackColor = true;
            this.btnPaypal.Click += new System.EventHandler(this.btnPaypal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::client.Properties.Resources.o78k5fogx5g3hdy6peai;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(450, 338);
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
    }
}

