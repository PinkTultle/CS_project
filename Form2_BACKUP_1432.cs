﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMP_cs
{
    public partial class Form2 : Form
    {
<<<<<<< HEAD
=======
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        DataTable dt = new DataTable();

>>>>>>> upstream/master
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false; // 전체화면 비활성화
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, EventArgs e) // 검색 버튼
        {

            /*Company company = new Company("name", "phone", "ID");
            company.Connect_check();

            connection.Open();
            string sql = "SELECT * FROM Items";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();*/

            
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            sqlQuery = $"SELECT * FROM `Items` ORDER BY `Count` ASC";

            DataPrint();
        }

        // DataGridView에 데이터 출력하는 함수
        private void DataPrint()
        {
            try
            {
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand(sqlQuery, dB_Connect.conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                DataSet ds = new DataSet();

                myDataAdapter.Fill(dt);

                dataGridView1.DataSource = dt;

                dB_Connect.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) // 물품 정보 수정 버튼
        {

        }
        private void button5_Click(object sender, EventArgs e) // 물품입고 버튼
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // 물품출고 버튼
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //입출고내역 버튼
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }


        private void button4_Click(object sender, EventArgs e) // 그래프 버튼
        {
<<<<<<< HEAD
            
=======

>>>>>>> upstream/master
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
