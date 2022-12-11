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
    public partial class Form5 : Form
    {
        DB_connect dB_Connect;
        string today;
        public Form5()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // 콤보 박스
            string[] comboData = { "입고", "출고" };
            comboBox1.Items.AddRange(comboData);
            comboBox1.SelectedIndex = 0; // 첫 번째 값 디폴트 선택
            dB_Connect = new DB_connect();
            today = dateTimePicker1.Text;
            LoadList("입고");
        }
        public void LoadList(string record)
        {
            
            dB_Connect.Open();
            string query;
            if(record == "입고")
            {
                query = "select SalesRecord.ItemID,Items.Name,Company.Name,SalesRecord.Count,toDate,Record from SalesRecord,Items,Company " +
                    "where Items.ItemID = SalesRecord.ItemID " +
                    $"and SalesRecord.Record = '입고' " +
                    $"and DATE_FORMAT(toDate, '%Y-%m-%d') = DATE_FORMAT('{today}','%Y-%m-%d')" +
                    " group by Items.Name;";
            }
            else
            {
                query = $"select SalesRecord.ItemID,Items.Name,Company.Name,SalesRecord.Count,toDate,Record from SalesRecord,Items,Company " +
                    $"where Items.ItemID = SalesRecord.ItemID and Company.CompanyID = SalesRecord.CompanyID " +
                    $"and DATE_FORMAT(toDate, '%Y-%m-%d')=DATE_FORMAT('{today}','%Y-%m-%d')" +
                    $"and SalesRecord.Record = '출고';";
            }
            try
            {
                DataTable table = dB_Connect.readSQL(query);
                table.Columns[0].ColumnName = "제품코드";
                table.Columns[1].ColumnName = "제품명";
                table.Columns[2].ColumnName = "회사명";
                table.Columns[3].ColumnName = "수량";
                table.Columns[4].ColumnName = "판매날짜";
                table.Columns[5].ColumnName = "판매내역";


                // DataGridView 열 색상 변경
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                // 중복 선택 불가
                dataGridView1.MultiSelect = false;

                // 행 단위로 클릭
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // DataGridView 첫 번째 열 출력하지 않기 
                dataGridView1.RowHeadersVisible = false;

                // 목록과 DataGridView 크기 맞추기 
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // DataGridView에 dt 출력  
                dataGridView1.DataSource = table;
                
                dB_Connect.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadList(comboBox1.Text.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            today = dateTimePicker1.Text;
        }
    }
}
