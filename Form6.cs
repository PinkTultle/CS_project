using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMP_cs
{
    public partial class Form6 : Form
    {
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        DataTable dt = new DataTable();
        DataTable dB_dt;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            Itemchart();
           
            Saleschart();
        }

        private void Itemchart()
        {

            chart1.Series[0].LegendText = "물품 종류";
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;

            try
            {
                MySqlCommand cmd = dB_Connect.conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM `Items` ORDER BY `Name` ASC";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart1.Series["Series1"].Points.Clear();
                chart1.Series[0].IsValueShownAsLabel = true;
                while (reader.Read())
                {
                    chart1.Series["Series1"].Points.AddXY(reader.GetString("name"), reader.GetInt32("count"));
                    chart1.Series[0].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
      

        private void Saleschart()
        {

            dB_Connect = new DB_connect();
            dB_Connect.Open();
            chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
            chart3.Series[0].LegendText = "회사 종류";
            try
            {
                sqlQuery = $"select SalesRecord.ItemID,Company.Name,SalesRecord.Count,toDate,Record from SalesRecord,Items,Company " +
                    $"where Items.ItemID = SalesRecord.ItemID and Company.CompanyID = SalesRecord.CompanyID ";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, dB_Connect.conn);//dB_Connect.conn.CreateCommand();
                                                                               // cmd.CommandText = $"Select * from SalesRecord";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart3.Series["Series1"].Points.Clear();
               

                while (reader.Read())
                {

                    chart3.Series["Series1"].Points.AddXY(reader.GetString("Name"), reader.GetInt32("Count"));
                    chart3.Series[0].IsValueShownAsLabel = true;
                  
                    chart3.Series[0].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                chart1.BringToFront();
                comboBox1.BringToFront();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                chart3.BringToFront();
                comboBox1.BringToFront();
            }
                
        }
    }
}
