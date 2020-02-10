namespace Bazy
{
    partial class Menu
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
            this.create_order = new System.Windows.Forms.Button();
            this.manage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create_order
            // 
            this.create_order.Location = new System.Drawing.Point(56, 96);
            this.create_order.Name = "create_order";
            this.create_order.Size = new System.Drawing.Size(104, 52);
            this.create_order.TabIndex = 0;
            this.create_order.Text = "Złóż zamówienie";
            this.create_order.UseVisualStyleBackColor = true;
            this.create_order.Click += new System.EventHandler(this.create_order_Click);
            // 
            // manage
            // 
            this.manage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.manage.Location = new System.Drawing.Point(213, 96);
            this.manage.Name = "manage";
            this.manage.Size = new System.Drawing.Size(104, 52);
            this.manage.TabIndex = 1;
            this.manage.Text = "Zarządzaj";
            this.manage.UseVisualStyleBackColor = true;
            this.manage.Click += new System.EventHandler(this.manage_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 263);
            this.Controls.Add(this.manage);
            this.Controls.Add(this.create_order);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button create_order;
        private System.Windows.Forms.Button manage;
    }
}