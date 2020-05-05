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
    public partial class addModel : Form
    {
        public bool flagEdit = false;
        public addModel()
        {
            InitializeComponent();
        }

        private void addModel_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            List<Cars> listC = new List<Cars>();

            Form1.listM.Add(new Models(textBox1.Text, textBox2.Text,
                                                  textBox3.Text, textBox4.Text, listC));
            textBox1.Focus();
            flagEdit = true;

            MessageBox.Show("Модель добавлена."
                + "\n\nДобавьте следующую или закройте окно.");

        }
    }
}
