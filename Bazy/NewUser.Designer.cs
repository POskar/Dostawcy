namespace Bazy
{
    partial class NewUser
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
            this.button_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_telefon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_adres = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(77, 155);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 0;
            this.button_create.Text = "Gotowe !";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj swój numer telefonu:";
            // 
            // textBox_telefon
            // 
            this.textBox_telefon.Location = new System.Drawing.Point(27, 39);
            this.textBox_telefon.MaxLength = 9;
            this.textBox_telefon.Name = "textBox_telefon";
            this.textBox_telefon.Size = new System.Drawing.Size(125, 20);
            this.textBox_telefon.TabIndex = 2;
            this.textBox_telefon.TextChanged += new System.EventHandler(this.textBox_telefon_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Podaj adres pod który chcesz, aby Twoje zamówienie było dostarczone:";
            // 
            // textBox_adres
            // 
            this.textBox_adres.Location = new System.Drawing.Point(27, 117);
            this.textBox_adres.Name = "textBox_adres";
            this.textBox_adres.Size = new System.Drawing.Size(180, 20);
            this.textBox_adres.TabIndex = 4;
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 202);
            this.Controls.Add(this.textBox_adres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_telefon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_create);
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_telefon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_adres;
    }
}