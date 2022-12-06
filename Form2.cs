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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMP_cs
{
    public partial class Form2 : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=Company;Uid=admin;Pwd=!#admin");
        
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        
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


        private void button4_Click(object sender, EventArgs e) // 그래프 버튼
        {

        }

        private void button1_Click(object sender, EventArgs e) // 검색 버튼
        {
            /*
            Company company = new Company("name", "phone", "ID");
            company.Connect_check();
            */
            /*
            connection.Open();
            string sql = "SELECT * FROM Items";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            */
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            /*sqlQuery = $"SELECT * FROM `Items` ORDER BY `Count` ASC";
            MySqlCommand cmdDataBase = new MySqlCommand(sqlQuery, connection);*/

            // DataGridView의 열 추가
            dataGridView1.Columns.Add("ItemID", "제품번호");
            dataGridView1.Columns.Add("Name", "제품이름");
            dataGridView1.Columns.Add("Price", "가격");
            dataGridView1.Columns.Add("Count", "보유수량");

            //dataGridView1.DataSource = dB_Connect;

            // DataGridView 연동 예제 https://youtu.be/hbeyeHCPlOM
            /*try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                adapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                adapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // 에러 메시지 출력
            }*/
            DataSet ds = GetData();
            dataGridView1.DataSource = ds.Tables[0];

        }

        // 데이터를 가져오는 메소드
        private DataSet GetData()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

    }
}
