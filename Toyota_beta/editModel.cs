using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toyota_beta
{
    public partial class editModel : Form
    {

        public editModel()
        {
            InitializeComponent();
        }

        public int i;                
        public bool flagEdit = false;


        private void edit_Click(object sender, EventArgs e)
        {
            Form1.listM[i].Model = textBox1.Text;
            Form1.listM[i].Year = textBox2.Text;
            Form1.listM[i].Type = textBox3.Text;
            Form1.listM[i].Price = textBox4.Text;
            flagEdit = true;

            Close();

        }

        private void editModel_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.listM[i].Model;
            textBox2.Text = Form1.listM[i].Year;
            textBox3.Text = Form1.listM[i].Type;
            textBox4.Text = Form1.listM[i].Price;

        }
    }
}
