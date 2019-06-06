using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCShopWinFormAdmin
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboItemType.Text == "New")
            {
                frmItem form = new frmNewItem();
                form.Show();
            }
            else
            {
                frmItem form = new frmUsedItem();
                form.Show();
            }
            
        }
    }
}
