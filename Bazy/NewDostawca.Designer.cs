namespace Bazy
{
    partial class NewDostawca
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
            this.textBox_nazwisko = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_imie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_typ_pojazdu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(124, 179);
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
            this.label1.Location = new System.Drawing.Point(34, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj imię:";
            // 
            // textBox_nazwisko
            // 
            this.textBox_nazwisko.Location = new System.Drawing.Point(124, 32);
            this.textBox_nazwisko.Name = "textBox_nazwisko";
            this.textBox_nazwisko.Size = new System.Drawing.Size(177, 20);
            this.textBox_nazwisko.TabIndex = 2;
            this.textBox_nazwisko.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nazwisko_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Podaj nazwisko:";
            // 
            // textBox_imie
            // 
            this.textBox_imie.Location = new System.Drawing.Point(124, 69);
            this.textBox_imie.Name = "textBox_imie";
            this.textBox_imie.Size = new System.Drawing.Size(177, 20);
            this.textBox_imie.TabIndex = 4;
            this.textBox_imie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_imie_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jakim pojazdem będziesz dowozić?";
            // 
            // comboBox_typ_pojazdu
            // 
            this.comboBox_typ_pojazdu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_typ_pojazdu.FormattingEnabled = true;
            this.comboBox_typ_pojazdu.Items.AddRange(new object[] {
            "Rower",
            "Samochód osobowy",
            "Dostawczy"});
            this.comboBox_typ_pojazdu.Location = new System.Drawing.Point(79, 130);
            this.comboBox_typ_pojazdu.Name = "comboBox_typ_pojazdu";
            this.comboBox_typ_pojazdu.Size = new System.Drawing.Size(171, 21);
            this.comboBox_typ_pojazdu.TabIndex = 6;
            // 
            // NewDostawca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 237);
            this.Controls.Add(this.comboBox_typ_pojazdu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_imie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nazwisko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_create);
            this.Name = "NewDostawca";
            this.Text = "NewDostawca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nazwisko;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_imie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_typ_pojazdu;
    }
}