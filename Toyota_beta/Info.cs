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
    public partial class Info : Form

    {
        Properties.Settings set = Properties.Settings.Default;
        bool select = false;
        public int f;
        public int m, c;
        public Info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Show();
            groupBox3.Show();
            groupBox4.Show();
            groupBox5.Show();
            filter.Show();
            clear.Show();
            all.Show();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;

            editCar editCar = new editCar();
            editCar.f = f;       
            editCar.s = dataGridView2.CurrentRow.Index;  

            editCar.ShowDialog();

            if (editCar.flagEdit)
                carsBindingSource.ResetCurrentItem();

        }

        private void add_Click(object sender, EventArgs e)
        {
            addCar addCar = new addCar();
            addCar.f = f;               

            addCar.ShowDialog();

            if (addCar.flagEdit)
               carsBindingSource.ResetBindings(false);


        }

        private void del_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для удаления одной или нескольких комплектаций: выделите их, щелкнув их заголовки (слева), и нажмите клавишу Delete на клавиатуре");

        }

        

        
        private bool TestRow(int s)
        {
            Cars cars = Form1.listM[f].Cars[s];

            if (comboBox1.Text != "" &&
                !cars.Transmission.Contains(comboBox1.Text)) return false;

            if (comboBox2.Text != "" &&
                !cars.Drive.Contains(comboBox2.Text)) return false;

            if (comboBox3.Text != "" &&
                !cars.Engine.Contains(comboBox3.Text)) return false;


            int r1, r2;
            int.TryParse(textBox_from.Text, out r1);
            int.TryParse(textBox_to.Text, out r2);

            if (r2 == 0) r2 = 1000;

            if (cars.Hp < r1 || cars.Hp > r2) return false;

            int r3, r4;
            int.TryParse(textBox_from1.Text, out r3);
            int.TryParse(textBox_to1.Text, out r4);

            if (r4 == 0) r4 = 100000;

            if (cars.Price < r3 || cars.Price > r4) return false;

            return true;
        }

        private void all_Click(object sender, EventArgs e)
        {
            select = false;

            for (int i = 0; i < dataGridView2.RowCount; i++)
                dataGridView2.Rows[i].Visible = true;

        }

        private void filter_Click(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell = null;

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                if (TestRow(i))
                    dataGridView2.Rows[i].Visible = true;
                else
                {
                    dataGridView2.Rows[i].Visible = false;
                    select = true;
                }
            }


            
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                if (dataGridView2.Rows[i].Visible == true)
                {
                    
                    dataGridView2.CurrentCell = dataGridView2[1, i];
                    break;
                }
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) return;

            int d = checkBox1.Checked == true ? -1 : 1;   
            List<Cars> list = Form1.listM[f].Cars;

            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "model":
                    list.Sort((a1, a2) => d * a1.Model.CompareTo(a2.Model));
                    break;

                case "trans":
                    list.Sort((a1, a2) => d * a1.Transmission.CompareTo(a2.Transmission));
                    break;

                case "drive":
                    list.Sort((a1, a2) => d * a1.Drive.CompareTo(a2.Drive));
                    break;

                case "year":
                    list.Sort((a1, a2) => d * a1.Year.CompareTo(a2.Year));
                    break;

                case "hp":
                    list.Sort((a1, a2) => d * a1.Hp.CompareTo(a2.Hp));
                    break;

                case "engine":
                    list.Sort((a1, a2) => d * a1.Engine.CompareTo(a2.Engine));
                    break;

                case "price":
                    list.Sort((a1, a2) => d * a1.Price.CompareTo(a2.Price));
                    break;


                default: 
                    return;
            }

            carsBindingSource.ResetBindings(false);

            if (select) filter_Click(null, null);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox6.Show();
            groupBox7.Show();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox_from.Text = "";
            textBox_to.Text = "";
            textBox_from1.Text = "";
            textBox_to1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            List<Cars> list = Form1.listM[f].Cars;

            if (!checkBox2.Checked && !checkBox3.Checked)
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        list = (list.OrderBy(s => s.Model).ThenBy(s => s.Drive)).ToList();
                        break;
                    case 1:
                        list = (list.OrderBy(s => s.Model).ThenBy(s => s.Hp)).ToList();
                        break;
                    case 2:
                        list = (list.OrderBy(s => s.Model).ThenBy(s => s.Price)).ToList();
                        break;
                    case 3:
                        list = (list.OrderBy(s => s.Hp).ThenBy(s => s.Drive)).ToList();
                        break;
                    case 4:
                        list = (list.OrderBy(s => s.Hp).ThenBy(s => s.Model)).ToList();
                        break;
                }

            else if (!checkBox2.Checked && checkBox3.Checked)
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        list = (list.OrderBy(s => s.Model).ThenByDescending(
                                                                                   s => s.Drive)).ToList();
                        break;
                    case 1:
                        list = (list.OrderBy(s => s.Model).ThenByDescending(
                                                                                   s => s.Hp)).ToList();
                        break;
                    case 2:
                        list = (list.OrderBy(s => s.Model).ThenByDescending(
                                                                                  s => s.Price)).ToList();
                        break;
                    case 3:
                        list = (list.OrderBy(s => s.Hp).ThenByDescending(
                                                                                   s => s.Drive)).ToList();
                        break;
                    case 4:
                        list = (list.OrderBy(s => s.Hp).ThenByDescending(
                                                                                   s => s.Model)).ToList();
                        break;
                }

            else if (checkBox2.Checked && checkBox3.Checked)
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        list = (list.OrderByDescending(s => s.Model).ThenByDescending(
                                                                                      s => s.Drive)).ToList();
                        break;
                    case 1:
                        list = (list.OrderByDescending(s => s.Model).ThenByDescending(
                                                                                   s => s.Hp)).ToList();
                        break;
                    case 2:
                        list = (list.OrderByDescending(s => s.Model).ThenByDescending(
                                                                                         s => s.Price)).ToList();
                        break;
                    case 3:
                        list = (list.OrderByDescending(s => s.Hp).ThenByDescending(
                                                                                         s => s.Drive)).ToList();
                        break;
                    case 4:
                        list = (list.OrderByDescending(s => s.Hp).ThenByDescending(
                                                                                         s => s.Model)).ToList();
                        break;
                }

            else if (checkBox2.Checked && !checkBox3.Checked)
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        list = (list.OrderByDescending(s => s.Model).ThenBy(
                                                                                     s => s.Drive)).ToList();
                        break;
                    case 1:
                        list = (list.OrderByDescending(s => s.Model).ThenBy(
                                                                                    s => s.Hp)).ToList();
                        break;
                    case 2:
                        list = (list.OrderByDescending(s => s.Model).ThenBy(
                                                                                     s => s.Price)).ToList();
                        break;
                    case 3:
                        list = (list.OrderByDescending(s => s.Hp).ThenBy(
                                                                                      s => s.Drive)).ToList();
                        break;
                    case 4:
                        list = (list.OrderByDescending(s => s.Hp).ThenBy(
                                                                                      s => s.Model)).ToList();
                        break;
                }

            Form1.listM[f].Cars = list;
            carsBindingSource.DataSource = list;

            if (select) filter_Click(null, null);
        }

        private void Info_Load(object sender, EventArgs e)
        {
            this.Text += " " + Form1.listM[f].Model + ":";

        }

        


    }
}
