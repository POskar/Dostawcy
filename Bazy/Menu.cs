using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bazy
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void manage_Click(object sender, EventArgs e)
        {
            Form1 zarzadzaj = new Form1();
            zarzadzaj.Show();
        }

        private void create_order_Click(object sender, EventArgs e)
        {
            Order zamawiaj = new Order();
            zamawiaj.Show();
        }
    }
}
