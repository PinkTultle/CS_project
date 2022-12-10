<<<<<<< HEAD
﻿using System;
=======
﻿using MySql.Data.MySqlClient;
using System;
>>>>>>> master
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
>>>>>>> master

namespace SMP_cs
{
    public partial class Form6 : Form
    {
<<<<<<< HEAD
=======
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        DataTable dt = new DataTable();

>>>>>>> master
        public Form6()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
    }
}
=======



        private void Form6_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            sqlQuery = $"SELECT * FROM `Items` ORDER BY `Count` ASC";
            Daychart();
            Pricechart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                chart1.BringToFront();

            else if (comboBox1.SelectedIndex == 1)
                chart2.BringToFront();
            else if (comboBox1.SelectedIndex == 2)
                chart3.BringToFront();
        }

        private void Daychart()
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
            try
            {
                MySqlCommand cmd = dB_Connect.conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM `Items` ORDER BY `Count` ASC";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart1.Series["Series1"].Points.Clear();
                chart1.Series[0].LegendText = "수량";
                while (reader.Read())
                {
                    chart1.Series["Series1"].Points.AddXY(reader.GetString("name"), reader.GetInt32("count"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Pricechart()
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            chart2.ChartAreas["ChartArea2"].AxisX.LabelStyle.Interval = 1;
            try
            {
                MySqlCommand cmd = dB_Connect.conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM `Items` ORDER BY `Count` ASC";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart2.Series["Series2"].Points.Clear();
                chart2.Series[0].LegendText = "가격";
                while (reader.Read())
                {
                    chart2.Series["Series2"].Points.AddXY(reader.GetString("name"), reader.GetInt32("price"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

}
>>>>>>> master
