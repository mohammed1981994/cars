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
    public partial class car : Form
    {
        public car()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection connection = new connection();
            int status=connection.insert_car(textBox1.Text, textBox2.Text, textBox3.Text);
            if (status == 1)
            {
                MessageBox.Show("تمت الاضافة");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                get_car();

            }
            else
            {
                MessageBox.Show("حدثت مشكلة في الاضافة");

            }




        }

        private void car_Load(object sender, EventArgs e)
        {
            get_car();

        }
        public void get_car(string s="")
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_car(textBox4.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string car_name = dataGridView1.Rows[x].Cells[1].Value.ToString();
            string car_num= dataGridView1.Rows[x].Cells[2].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("هل تريد حذف السيارة "+car_name+" المرقمة "+car_num, "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                connection connection = new connection();

                connection.delete_car(Convert.ToInt32(id));
                get_car();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            string yss = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox1.Text= dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox2.Text=dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();

            int y = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string car_name = textBox1.Text;
            string car_num = textBox2.Text;
            string car_desc= textBox3.Text;
            if (DialogResult.Yes == MessageBox.Show("هل تريد تعديل السيارة " , "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                connection connection = new connection();

             int xx=   connection.update_car(Convert.ToInt32(id), car_name, car_num, car_desc);
                get_car();
            }
        }
    }
}
