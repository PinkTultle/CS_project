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
    public partial class Form3 : Form
    {
        string sqlQuery = "";
        DB_connect dB_Connect;
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false; // 전체화면 비활성화
        }

        private void button1_Click(object sender, EventArgs e) // 입고 버튼
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            sqlQuery = $"INSERT INTO Items values('{textBox4.Text}','{textBox1.Text}',{textBox3.Text},{textBox2.Text});";
            dB_Connect.SQLQuery(sqlQuery);
            this.Close();

            // 텍스트 박스에 담긴 값 DB로 전송

        }
    }
}
