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
using System.Xml.Linq;

namespace SMP_cs
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=Company;Uid=admin;Pwd=!#admin");

        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false; // 전체화면 비활성화
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

<<<<<<< HEAD
        private void button4_Click(object sender, EventArgs e) // 그래프 버튼
        {

        }

        private void button1_Click(object sender, EventArgs e) // 검색 버튼
        {

=======
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Company company = new Company("name", "phone", "ID");
            company.Connect_check();
            */
            connection.Open();
            string sql = "SELECT * FROM Items";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();

            listBox1.Items.Add(table);
            
>>>>>>> b281288602e75b06db633c3253db50367b0232dc
        }
    }
}
