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
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        DataTable dt = new DataTable();

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


            DataTable newDt = new DataTable();
            newDt = dt;
            string searchValue = textBox1.Text; // 텍스트박스에 입력된 값
            
            if(comboBox1.SelectedItem.ToString() == "제품명")
            {
                newDt.DefaultView.RowFilter = String.Format("Name = '{0}'", searchValue);
                dataGridView1.DataSource = newDt;
            }
            else
            {
                newDt.DefaultView.RowFilter = String.Format("ItemID = '{0}'", searchValue);
                dataGridView1.DataSource = newDt;
            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            sqlQuery = $"SELECT * FROM `Items` ORDER BY `Count` ASC";

            // 콤보 박스
            string[] comboData = {"제품명", "제품코드"};
            comboBox1.Items.AddRange(comboData);
            comboBox1.SelectedIndex = 0; // 첫 번째 값 디폴트 선택

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

                // DataTable 열 이름 변경
                dt.Columns[0].ColumnName = "제품코드";
                dt.Columns[1].ColumnName = "제품명";
                dt.Columns[2].ColumnName = "가격";
                dt.Columns[3].ColumnName = "수량";

                // DataGridView 열 색상 변경
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                // 중복 선택 불가
                dataGridView1.MultiSelect = false;

                // 행 단위로 클릭
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // DataGridView에 dt 출력  
                dataGridView1.DataSource = dt;

                // DataGridView 첫 번째 열 출력하지 않기
                dataGridView1.RowHeadersVisible = false;

                // 목록과 DataGridView 크기 맞추기
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        }
    }
}
