using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Data;

namespace cars
{
    class connection
    {
        OleDbConnection conn;
        public connection()
        {
            conn = new OleDbConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            string path = Environment.CurrentDirectory + "\\db.accdb";
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data source=" + path;

            conn.Open();
            // Insert code to process data.



        }
        public int insert_car(string name, string number, string description)
        {
            string query = "insert into cars(`car_name`, `car_number`, `car_desc`) values('" + name + "','" + number + "','" + description + "')";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            int status = cmd.ExecuteNonQuery();
            conn.Close();
            return status;

        }
        public DataTable get_cars(string s)
        {
            string query = "";
            if (s != "")
                query = "select * from cars where car_name like'%" + s + "%' or car_number like '%" + s + "%' or car_desc like '%" + s + "%'";

            else
                query = "select * from cars";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            conn.Close();

            return scores;
        }
        public int delete_car(int num)
        {
            string query = "delete from cars where ID=" + num + "";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            return 1;
        }
    public int update_car(int id,string name,string num,string desc)

        {
            string query = "update  cars set car_name='"+name+"' , car_number='"+num+"' , car_desc='"+desc+"' where ID=" + id + "";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            return 1;

        }
        public int insert_jam(int car_id,string jam_desc,DateTime jam_date,string jam_money,string jam_ect)
        {
            string query = "insert into jam(`car_id`, `jam_desc`, `jam_date`,`jam_money`,`jam_ect`) values(" + car_id + ",'" + jam_desc + "','" + jam_date + "','"+jam_money+"','"+jam_ect+"')";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            int status = cmd.ExecuteNonQuery();
            conn.Close();
            return status;
        }
        public DataTable get_jams(string car_num,DateTime dt1,DateTime dt2)
        {
            string query = "";
            if (car_num != "")
            {
                query = "select * from cars inner join jam on(cars.id=jam.car_id) where  car_number like '%" + car_num + "%'";
                if (dt1.Date != dt2.Date)
                    query += " or jam_date>=" + dt1 + " and jam_date<=" + dt2;
            }
            else if(dt1.Date != dt2.Date)
                query += "select * from cars inner join jam on(cars.id=jam.car_id) where jam_date>=#" + dt1 + "# and jam_date<=#" + dt2+"#";
            else
                query = "select * from cars inner join jam on(cars.id=jam.car_id)";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            conn.Close();

            return scores;
        }
    }
}
