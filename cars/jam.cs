using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cars
{
    public partial class jam : Form
    {
        public jam()
        {
            InitializeComponent();
        }

        private void jam_Load(object sender, EventArgs e)
        {
            get_car();

        }
        public void get_car(string s = "")
        {
            connection connection = new connection();
            // dataGridView1.Columns.Add("car_name", "اسم السيارة");
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = connection.get_cars(s);
            dataGridView1.Columns["car_name"].HeaderText = "اسم السيارة";
            dataGridView1.Columns["car_number"].HeaderText = "رقم السيارة";
            dataGridView1.Columns["car_desc"].HeaderText = "تفاصيل السيارة";
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 15);

            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            string yss = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();

            int y = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            string car_id = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string jam_desc = textBox5.Text;
            DateTime dt = dateTimePicker1.Value;
            string jam_money = textBox7.Text;
            string jam_ect = textBox8.Text;
            connection connection = new connection();
            connection.insert_jam(Convert.ToInt32(car_id), jam_desc, dt, jam_money, jam_ect);
            MessageBox.Show("تمت الاضافة");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jam_report j = new jam_report();
            j.Show();
        }
    }
}
