using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMP_cs
{
    public partial class Form4 : Form
    {
        DB_connect dB_Connect;
        string tg_item;
        int tg_Count;
        //데이터 그리드뷰 새로고침위해 필요
        //폼2의 새로고침 매서드 실행위해 필요
        Form2 frm2;


        //물품 출고시 데이터 그리드뷰에 선택된 값을 자동으로 인식하여 물품 명에 제품이름 출력
        public Form4(string target_item, int Count, Form2 form2)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            tg_item = textBox1.Text = target_item;
            tg_Count = Count;
            this.frm2 = form2;
        }
        private void Form4_Load(object sender, EventArgs e) 
        {
            textBox2.Text = "선택하세요";
        }

        //물품명을 받아오기때문에 해당 제품의 보유수량이 0인지 판별 후 동작필요
        private void button1_Click(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            if(textBox3.Text == "") // 수량을 빈칸으로 비워두는 경우
            {
                MessageBox.Show("출고할 수량을 정확하게 입력해주세요.");
            }
            else
            {
                if ((tg_Count - int.Parse(textBox3.Text)) < 0)
                {
                    MessageBox.Show("보유 수량보다 많은 값을 입력했습니다!");
                }
                else
                {
                    dB_Connect.ProceDureSQLQuey("itemhistory", textBox2.Text, textBox1.Text, textBox3.Text, "출고");
                    dB_Connect.Close();
                    MessageBox.Show($"{textBox1.Text}을(를) {textBox2.Text}에게 {textBox3.Text}개를 출고하였습니다.");

                    frm2.Update_DB();

                    this.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(this);
            form10.ShowDialog();
        }

        public void change_textBox2(string val)
        {
            textBox2.Text = val;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 수량의 경우 숫자가 아니면 입력 불가
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar  == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
