namespace VIEW
{
    partial class HomeView
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
            this.client = new System.Windows.Forms.Button();
            this.category = new System.Windows.Forms.Button();
            this.articale = new System.Windows.Forms.Button();
            this.order = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // client
            // 
            this.client.BackColor = System.Drawing.Color.CornflowerBlue;
            this.client.Location = new System.Drawing.Point(18, 131);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(162, 145);
            this.client.TabIndex = 0;
            this.client.Text = "Client";
            this.client.UseVisualStyleBackColor = false;
            // 
            // category
            // 
            this.category.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.category.Location = new System.Drawing.Point(221, 131);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(162, 145);
            this.category.TabIndex = 1;
            this.category.Text = "Category";
            this.category.UseVisualStyleBackColor = false;
            // 
            // articale
            // 
            this.articale.BackColor = System.Drawing.SystemColors.Info;
            this.articale.Location = new System.Drawing.Point(410, 131);
            this.articale.Name = "articale";
            this.articale.Size = new System.Drawing.Size(161, 145);
            this.articale.TabIndex = 2;
            this.articale.Text = "Articale";
            this.articale.UseVisualStyleBackColor = false;
            this.articale.Click += new System.EventHandler(this.articale_Click);
            // 
            // order
            // 
            this.order.BackColor = System.Drawing.Color.OrangeRed;
            this.order.Location = new System.Drawing.Point(594, 131);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(161, 145);
            this.order.TabIndex = 3;
            this.order.Text = "Order";
            this.order.UseVisualStyleBackColor = false;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.order);
            this.Controls.Add(this.articale);
            this.Controls.Add(this.category);
            this.Controls.Add(this.client);
            this.Name = "HomeView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button client;
        private System.Windows.Forms.Button category;
        private System.Windows.Forms.Button articale;
        private System.Windows.Forms.Button order;
    }
}