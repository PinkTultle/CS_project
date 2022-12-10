using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMP_cs
{
    public partial class Form9 : Form
    {
        string sqlQuery;
        DB_connect dB_Connect;
        string original_count;
        public Form9(string itemName, int itemCount)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            label2.Text = itemName;
            original_count = label4.Text = itemCount.ToString();
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e) // 입고 버튼 클릭 시
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            sqlQuery = $"UPDATE Items SET Count='{textBox1.Text}' WHERE Count='{original_count}'";
            dB_Connect.SQLQuery(sqlQuery);

            MessageBox.Show($"'{label2.Text}'이(가) '{textBox1.Text}'개 입고되었습니다.", "입고 완료");

            dB_Connect.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) // 트랙바의 값을 텍스트박스에 출력
        {
            textBox1.Text = trackBar1.Value.ToString();
        }
    }
}
