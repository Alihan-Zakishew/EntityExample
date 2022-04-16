using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "localDbDataSet.City". При необходимости она может быть перемещена или удалена.
            this.cityTableAdapter.Fill(this.localDbDataSet.City);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            City city = new City();
            city.name = textBox1.Text;
            city.population = textBox2.Text;
            city.country = textBox3.Text;

           localDbEntities _db = new localDbEntities();
            _db.City.Add(city);
            _db.SaveChanges();
            List<City> cityList = new List<City>();
            cityList = _db.City.ToList();
            dataGridView1.DataSource = cityList;

        }
    }
}
