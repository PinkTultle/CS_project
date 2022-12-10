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
    public partial class Form8 : Form
    {
        string sqlQuery;
        DB_connect dB_Connect;
        DataTable dB_dt;
        DataTable dt_item;
        DataTable dt_com;
        string tg_item;
        string original_name;

        /*private void button2_Click(object sender, EventArgs e) // 물품출고 버튼
        {
            DataGridViewRow selecRow = dataGridView1.SelectedRows[0];
            string itemName = selecRow.Cells[1].Value.ToString();
            int itemCount = int.Parse(selecRow.Cells[3].Value.ToString());
            Form4 form4 = new Form4($"{itemName}", itemCount);  //그리드뷰 선택 이름과 수량 기입필요
            form4.ShowDialog();
        }*/

        public Form8(string itemID, string itemName, string itemCount)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            tg_item = textBox1.Text = itemID;
            original_name = textBox2.Text = itemName;
            textBox3.Text = itemCount;
        }

        private void button1_Click(object sender, EventArgs e) // 수정 버튼 클릭 시
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            
            if(textBox2.Text != "" && textBox3.Text != "")
            {
                sqlQuery = $"UPDATE Items SET Name='{textBox2.Text}' WHERE Name='{original_name}'";
                dB_Connect.SQLQuery(sqlQuery);

                dB_Connect.Close();
                this.Close();
            }
            else // 빈칸이 있는 경우
            {
                MessageBox.Show("누락된 정보가 있습니다. 입력칸을 채워주세요.");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 수량의 경우 숫자와 백스페이스가 아니면 입력 불가
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) 
            {
                e.Handled = true;
            }
        }
    }
}
