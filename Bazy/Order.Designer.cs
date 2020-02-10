namespace Bazy
{
    partial class Order
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
            this.label_tel = new System.Windows.Forms.Label();
            this.create_account = new System.Windows.Forms.Button();
            this.label_adres = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.comboBox_id = new System.Windows.Forms.ComboBox();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.textBox_adres = new System.Windows.Forms.TextBox();
            this.label_restauracja = new System.Windows.Forms.Label();
            this.comboBox_restauracje = new System.Windows.Forms.ComboBox();
            this.label_ilosc = new System.Windows.Forms.Label();
            this.comboBox_ilosc = new System.Windows.Forms.ComboBox();
            this.button_zamow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_platnosc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(23, 73);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(79, 13);
            this.label_tel.TabIndex = 0;
            this.label_tel.Text = "Numer telefonu";
            // 
            // create_account
            // 
            this.create_account.Location = new System.Drawing.Point(23, 318);
            this.create_account.Name = "create_account";
            this.create_account.Size = new System.Drawing.Size(91, 23);
            this.create_account.TabIndex = 1;
            this.create_account.Text = "Stwórz konto";
            this.create_account.UseVisualStyleBackColor = true;
            this.create_account.Click += new System.EventHandler(this.create_account_Click);
            // 
            // label_adres
            // 
            this.label_adres.AutoSize = true;
            this.label_adres.Location = new System.Drawing.Point(163, 73);
            this.label_adres.Name = "label_adres";
            this.label_adres.Size = new System.Drawing.Size(100, 13);
            this.label_adres.TabIndex = 2;
            this.label_adres.Text = "Adres zamieszkania";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(23, 22);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(76, 13);
            this.label_id.TabIndex = 3;
            this.label_id.Text = "Twój numer ID";
            // 
            // comboBox_id
            // 
            this.comboBox_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_id.FormattingEnabled = true;
            this.comboBox_id.Location = new System.Drawing.Point(23, 38);
            this.comboBox_id.Name = "comboBox_id";
            this.comboBox_id.Size = new System.Drawing.Size(121, 21);
            this.comboBox_id.TabIndex = 4;
            this.comboBox_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_id_SelectedIndexChanged);
            // 
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(23, 89);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.ReadOnly = true;
            this.textBox_tel.Size = new System.Drawing.Size(100, 20);
            this.textBox_tel.TabIndex = 5;
            // 
            // textBox_adres
            // 
            this.textBox_adres.Location = new System.Drawing.Point(166, 89);
            this.textBox_adres.Name = "textBox_adres";
            this.textBox_adres.ReadOnly = true;
            this.textBox_adres.Size = new System.Drawing.Size(100, 20);
            this.textBox_adres.TabIndex = 6;
            // 
            // label_restauracja
            // 
            this.label_restauracja.AutoSize = true;
            this.label_restauracja.Location = new System.Drawing.Point(20, 166);
            this.label_restauracja.Name = "label_restauracja";
            this.label_restauracja.Size = new System.Drawing.Size(103, 13);
            this.label_restauracja.TabIndex = 7;
            this.label_restauracja.Text = "Wybierz restaurację:";
            // 
            // comboBox_restauracje
            // 
            this.comboBox_restauracje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_restauracje.FormattingEnabled = true;
            this.comboBox_restauracje.Location = new System.Drawing.Point(129, 163);
            this.comboBox_restauracje.Name = "comboBox_restauracje";
            this.comboBox_restauracje.Size = new System.Drawing.Size(151, 21);
            this.comboBox_restauracje.TabIndex = 9;
            // 
            // label_ilosc
            // 
            this.label_ilosc.AutoSize = true;
            this.label_ilosc.Location = new System.Drawing.Point(20, 210);
            this.label_ilosc.Name = "label_ilosc";
            this.label_ilosc.Size = new System.Drawing.Size(222, 13);
            this.label_ilosc.TabIndex = 10;
            this.label_ilosc.Text = "Ile porcji dania specjalnego chcesz zamówić?";
            // 
            // comboBox_ilosc
            // 
            this.comboBox_ilosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ilosc.FormattingEnabled = true;
            this.comboBox_ilosc.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox_ilosc.Location = new System.Drawing.Point(249, 207);
            this.comboBox_ilosc.Name = "comboBox_ilosc";
            this.comboBox_ilosc.Size = new System.Drawing.Size(57, 21);
            this.comboBox_ilosc.TabIndex = 11;
            // 
            // button_zamow
            // 
            this.button_zamow.Location = new System.Drawing.Point(166, 318);
            this.button_zamow.Name = "button_zamow";
            this.button_zamow.Size = new System.Drawing.Size(91, 23);
            this.button_zamow.TabIndex = 12;
            this.button_zamow.Text = "Zamów !";
            this.button_zamow.UseVisualStyleBackColor = true;
            this.button_zamow.Click += new System.EventHandler(this.button_zamow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jak chcesz zapłacić?";
            // 
            // comboBox_platnosc
            // 
            this.comboBox_platnosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_platnosc.FormattingEnabled = true;
            this.comboBox_platnosc.Items.AddRange(new object[] {
            "Gotówka",
            "Karta",
            "BLIK"});
            this.comboBox_platnosc.Location = new System.Drawing.Point(136, 247);
            this.comboBox_platnosc.Name = "comboBox_platnosc";
            this.comboBox_platnosc.Size = new System.Drawing.Size(121, 21);
            this.comboBox_platnosc.TabIndex = 14;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 353);
            this.Controls.Add(this.comboBox_platnosc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_zamow);
            this.Controls.Add(this.comboBox_ilosc);
            this.Controls.Add(this.label_ilosc);
            this.Controls.Add(this.comboBox_restauracje);
            this.Controls.Add(this.label_restauracja);
            this.Controls.Add(this.textBox_adres);
            this.Controls.Add(this.textBox_tel);
            this.Controls.Add(this.comboBox_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_adres);
            this.Controls.Add(this.create_account);
            this.Controls.Add(this.label_tel);
            this.Name = "Order";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.Button create_account;
        private System.Windows.Forms.Label label_adres;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.ComboBox comboBox_id;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.TextBox textBox_adres;
        private System.Windows.Forms.Label label_restauracja;
        private System.Windows.Forms.ComboBox comboBox_restauracje;
        private System.Windows.Forms.Label label_ilosc;
        private System.Windows.Forms.ComboBox comboBox_ilosc;
        private System.Windows.Forms.Button button_zamow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_platnosc;
    }
}