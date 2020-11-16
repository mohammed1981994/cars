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
    public partial class jam_report : Form
    {
        public jam_report()
        {
            InitializeComponent();
        }

        private void jam_report_Load(object sender, EventArgs e)
        {
            get_jam(textBox2.Text,dateTimePicker1.Value,dateTimePicker2.Value);
        }
        public void get_jam(string s , DateTime dt11 , DateTime dt12)
        {

            connection connection = new connection();
            // dataGridView1.Columns.Add("car_name", "اسم السيارة");
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = connection.get_jams(s,dt11,dt12);
            //     dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["car_id"].Visible = false;
            dataGridView1.Columns["jam.id"].Visible = false;
            dataGridView1.Columns["cars.id"].Visible = false;
            //dataGridView1.Columns["jam.id"].Visible = false;
            dataGridView1.Columns["car_name"].HeaderText = "اسم السيارة";
            dataGridView1.Columns["car_number"].HeaderText = "رقم السيارة";
            dataGridView1.Columns["car_desc"].HeaderText = "تفاصيل السيارة";
            dataGridView1.Columns["jam_desc"].HeaderText = "تفاصيل العطل";
            dataGridView1.Columns["jam_date"].HeaderText = "تاريخ العطل";
            dataGridView1.Columns["jam_money"].HeaderText = "مبلغ التكلفة";
            dataGridView1.Columns["jam_ect"].HeaderText = "ملاحظات";

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 15);

            dataGridView1.Refresh();
           // textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_jam(textBox2.Text, dateTimePicker1.Value, dateTimePicker2.Value);

        }
    }
}
