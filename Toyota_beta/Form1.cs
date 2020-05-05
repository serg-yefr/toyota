using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;


namespace Toyota_beta
{
    public partial class Form1 : Form
    {
        internal static Properties.Settings set = Properties.Settings.Default;
        FileStream fs;
        XmlSerializer xs;

        public int f;
        public Form1()
        {
            InitializeComponent();
        }
        public int i;
        public static List<Models> listM = new List<Models>();
        public static List<Cars> listC;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Модели.xml"))
            {
                
                fs = new FileStream("Модели.xml", FileMode.Open);
                xs = new XmlSerializer(typeof(List<Models>));
                listM = (List<Models>)xs.Deserialize(fs);
                fs.Close();
            }
            else
            {
                //Yaris---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Yaris L", 2020, "Manual", "FWD", "Fuel", 106, 15650));
                listC.Add(new Cars("Yaris XLE", 2020, "Automatic", "FWD", "Fuel", 106, 18750));

                listM.Add(new Models("Yaris ", "Sedan", "2020", "from 15,650$", listC));

                //Yaris Hatchback---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Yaris LE Hatchback", 2020, "Automatic", "FWD", "Fuel", 106, 17750));


                listM.Add(new Models("Yaris Hatchback", "Hatchback", "2020", "from 17,750$", listC));

                //Corolla---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Corolla L", 2020, "Automatic", "FWD", "Fuel", 139, 19600));
                listC.Add(new Cars("Corolla LE", 2020, "Automatic", "FWD", "Fuel", 139, 20050));
                listC.Add(new Cars("Corolla Hybrid LE", 2020, "Automatic", "FWD", "Fuel", 169, 23100));

                listM.Add(new Models("Cororlla", "Sedan", "2020", "from 19,600$", listC));

                //Corolla Hatchback---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Corolla SE", 2020, "Automatic", "FWD", "Fuel", 168, 20290));


                listM.Add(new Models("Cororlla Hatchback", "Hatchback", "2020", "from 20,290$", listC));

                //Camry---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Camry L", 2020, "Automatic", "FWD", "Fuel", 203, 24425));
                listC.Add(new Cars("Camry LE", 2020, "Automatic", "AWD", "Fuel", 202, 26370));
                listC.Add(new Cars("Camry TRD", 2020, "Automatic", "AWD", "Fuel", 301, 31170));
                listC.Add(new Cars("Camry XLE", 2020, "Automatic", "AWD", "Fuel", 301, 34580));
                listC.Add(new Cars("Camry Hybrid LE", 2020, "Automatic", "FWD", "Hybrid", 169, 28430));

                listM.Add(new Models("Camry", "Sedan", "2020", "from 24,425$", listC));

                //Prius---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Prius L - Eco", 2020, "Automatic", "FWD", "Hybrid", 96, 24325));
                listC.Add(new Cars("Prius LE", 2020, "Automatic", "FWD", "Hybrid", 96, 25535));
                listC.Add(new Cars("Corolla XLE", 2020, "Automatic", "AWD", "Hybrid", 96, 29375));

                listM.Add(new Models("Prius", "Hatchback", "2019", "from 24,325$", listC));

                //Avalon---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Avalon XLE", 2020, "Automatic", "FWD", "Fuel", 301, 35875));
                listC.Add(new Cars("Avalon XSE", 2020, "Automatic", "FWD", "Fuel", 301, 38375));
                listC.Add(new Cars("Avalon TRD", 2020, "Automatic", "FWD", "Fuel", 301, 42375));
                listC.Add(new Cars("Avalon Touring", 2020, "Automatic", "FWD", "Fuel", 301, 42575));
                listC.Add(new Cars("Avalon Hybrid XLE", 2020, "Automatic", "AWD", "Hybrid", 176, 37000));


                listM.Add(new Models("Avalon", "Sedan", "2020", "from 35,875$", listC));

                //Mirai---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Mirai", 2019, "Automatic", "FWD", "Electric", 151, 58500));


                listM.Add(new Models("Mirai", "Sedan", "2019", "from 58,500$", listC));

                //86---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("86", 2020, "Automatic", "FWD", "Fuel", 205, 27060));
                listC.Add(new Cars("86 GT", 2020, "Automatic", "FWD", "Fuel", 205, 30190));
                listC.Add(new Cars("86 HE", 2020, "Automatic", "FWD", "Fuel", 205, 29870));

                listM.Add(new Models("86", "Coupe", "2020", "from 27,060$", listC));

                //Supra---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Supra 3.0", 2020, "Automatic", "RWD", "Fuel", 335, 49990));
                listC.Add(new Cars("Supra 3.0 Premium", 2020, "Automatic", "RWD", "Fuel", 335, 53990));
                listC.Add(new Cars("Supra 3.0 LE", 2020, "Automatic", "RWD", "Fuel", 335, 55250));

                listM.Add(new Models("Supra", "Coupe", "2020", "from 49,990$", listC));

                //Tacoma---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Tacoma SR", 2020, "Automatic", "RWD", "Fuel", 159, 26050));
                listC.Add(new Cars("Tacoma SR5", 2020, "Automatic", "RWD", "Fuel", 278, 30970));
                listC.Add(new Cars("Tacoma TRD Sport", 2020, "Automatic", "AWD", "Fuel", 278, 36030));

                listM.Add(new Models("Tacoma", "Pickup", "2020", "from 26,050$", listC));

                //Tundra---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Tundra SR", 2020, "Automatic", "RWD", "Fuel", 381, 33575));
                listC.Add(new Cars("Tundra SR5", 2020, "Automatic", "RWD", "Fuel", 381, 38625));
                listC.Add(new Cars("Tundra TRD Pro", 2020, "Automatic", "AWD", "Fuel", 381, 48655));
                listC.Add(new Cars("Tundra Platinum", 2020, "Automatic", "AWD", "Fuel", 381, 51825));

                listM.Add(new Models("Tundra", "Pickup", "2020", "from 33,575$", listC));

                //Sienna---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Sienna L", 2020, "Automatic", "FWD", "Fuel", 296, 31640));
                listC.Add(new Cars("Sienna SE", 2020, "Automatic", "FWD", "Fuel", 296, 37790));
                listC.Add(new Cars("Sienna XLE", 2020, "Automatic", "FWD", "Fuel", 296, 37790));

                listM.Add(new Models("Sienna", "Van", "2020", "from 31,640$", listC));

                //C-HR---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("C-HR LE", 2020, "Manual", "FWD", "Fuel", 144, 21295));
                listC.Add(new Cars("C-HR XLE", 2020, "Automatic", "FWD", "Fuel", 144, 23330));

                listM.Add(new Models("C-HR", "Crossover", "2020", "from 21,295$", listC));

                //RAV4---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("RAV4 LE", 2020, "Automatic", "FWD", "Fuel", 203, 25950));
                listC.Add(new Cars("RAV4 XLE", 2020, "Automatic", "FWD", "Fuel", 203, 27245));
                listC.Add(new Cars("RAV4 TRD", 2020, "Automatic", "AWD", "Fuel", 203, 35280));
                listC.Add(new Cars("RAV4 XLE Hybrid", 2020, "Automatic", "AWD", "Hybrid", 219, 29645));
                listC.Add(new Cars("RAV4 XSE Hybrid", 2020, "Automatic", "AWD", "Hybrid", 219, 34300));


                listM.Add(new Models("RAV4", "Crossover", "2020", "from 25,950$", listC));

                //Highlander---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Highlander L", 2020, "Automatic", "FWD", "Fuel", 295, 34600));
                listC.Add(new Cars("Highlander LE", 2020, "Automatic", "FWD", "Fuel", 295, 36800));
                listC.Add(new Cars("Highlander XLE", 2020, "Automatic", "AWD", "Fuel", 295, 41200));
                listC.Add(new Cars("Highlander LE Hybrid", 2020, "Automatic", "AWD", "Hybrid", 243, 39800));
                listC.Add(new Cars("Highlander XLE Hybrid", 2020, "Automatic", "AWD", "Hybrid", 243, 42600));
                listC.Add(new Cars("Highlander Platinum", 2020, "Automatic", "AWD", "Fuel", 295, 48800));
                listC.Add(new Cars("Highlander Platinum Hybrid", 2020, "Automatic", "AWD", "Hybrid", 243, 50200));


                listM.Add(new Models("Highlander", "Crossover", "2020", "from 34,600$", listC));

                //4Runner---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("4Runner SR5", 2019, "Automatic", "RWD", "Fuel", 270, 36120));
                listC.Add(new Cars("4Runner TRD", 2019, "Automatic", "AWD", "Fuel", 270, 39840));
                listC.Add(new Cars("4Runner TRD Pro", 2019, "Automatic", "AWD", "Fuel", 270, 49865));

                listM.Add(new Models("4Runner", "SUV", "2019", "from 36,120$", listC));

                //Sequoia---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Sequoia SR5", 2020, "Automatic", "RWD", "Fuel", 381, 49980));
                listC.Add(new Cars("Sequoia TRD Sport", 2020, "Automatic", "AWD", "Fuel", 381, 55920));
                listC.Add(new Cars("Sequoia TRD Pro", 2020, "Automatic", "AWD", "Fuel", 381, 64105));
                listC.Add(new Cars("Sequoia Platinum", 2020, "Automatic", "AWD", "Fuel", 381, 69245));

                listM.Add(new Models("Sequoia", "SUV", "2020", "from 49,980$", listC));

                //Land Cruiser---------------------------------------------------------------------------------------------
                listC = new List<Cars>();
                listC.Add(new Cars("Land Cruiser", 2020, "Automatic", "AWD", "Fuel", 381, 85415));
                listC.Add(new Cars("Land Cruiser HE", 2020, "Automatic", "AWD", "Fuel", 381, 87745));

                listM.Add(new Models("Land Cruiser", "SUV", "2020", "from 85,415$", listC));


            }
            modelsBindingSource.DataSource = listM;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил студент группы ПИ18-4, Ефремов Сергей.");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index == dataGridView1.RowCount - 1)
                return;

            Info formC = new Info();


            formC.f = dataGridView1.CurrentRow.Index;
            formC.carsBindingSource.DataSource = listM[formC.f].Cars;

            formC.ShowDialog();
            modelsBindingSource.ResetCurrentItem();

        }

        private void add_Click(object sender, EventArgs e)
        {
            addModel addModel = new addModel();
            addModel.ShowDialog();
            if (addModel.flagEdit)
                modelsBindingSource.ResetBindings(false);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            
            editModel editModel = new editModel();

            editModel.i = dataGridView1.CurrentRow.Index;
            editModel.ShowDialog();
            

            if (editModel.flagEdit)
                modelsBindingSource.ResetCurrentItem();

        }

        private void del_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для удаления одной или нескольких моделей: выделите их, щелкнув их заголовки (слева), и нажмите клавишу Delete на клавиатуре");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }


        private void save_Click(object sender, EventArgs e)
        {
            set.Save();
            // Создание потока
            fs = new FileStream("Модели.xml", FileMode.Create);

            XmlSerializer xs = new XmlSerializer(typeof(List<Models>));

            // Сохраним объект в XML-файле
            xs.Serialize(fs, listM);

            fs.Close();
            Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.toyota.com/");
        }

        private void удалитьПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set.Reset();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!File.Exists("О программе.txt"))
                File.CreateText("О программе.txt");

            Process.Start("notepad.exe", "О программе.txt");

        }
    }
}