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
    public partial class Form11 : Form
    {
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열
        Form10 frm10;
        DataTable dt;
        public Form11(Form10 form10)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            frm10 = form10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 입력된 회사 ID => textBox1.Text 
            // 입력된 회사명 => textBox2.Text 
            // 입력된 회사번호 => textBox3.Text 

            dB_Connect = new DB_connect();
            dB_Connect.Open();

            string sqlQuery = "SELECT CompanyID,Name FROM Company;";
            dt = dB_Connect.readSQL(sqlQuery);

            string Check = $"C{textBox1.Text}";
            string Check2 = $"{textBox2.Text}";

            bool contains = dt.AsEnumerable().Any(row => Check == row.Field<String>("CompanyID"));
            bool contains2 = dt.AsEnumerable().Any(row => Check2 == row.Field<String>("Name"));

            string companyNum = $"{comboBox1.Text}-{textBox4.Text}-{textBox3.Text}";


            if (contains == true || contains2 == true)
            {
                if (contains2 == true)
                {
                    MessageBox.Show("같은 이름의 업체가 있습니다.\n다시시도 하십시요!", "알림창", MessageBoxButtons.OK);
                    frm10.Update_DB();
                    dB_Connect.Close();
                    this.Close();
                }
                if(contains == true)
                {
                    MessageBox.Show("이미 등록된 업체입니다.\n다시시도 하십시요!", "알림창", MessageBoxButtons.OK);
                    frm10.Update_DB();
                    dB_Connect.Close();
                    this.Close();
                }
                
            }
            else
            {
                //sqlQuery = "SELECT * FROM `Company`";
                //(CompanyID, Name, PhoneNumber) -> Company 테이블 컬럼
                sqlQuery = $"INSERT INTO Company values ( '{Check}', '{textBox2.Text}', '{companyNum}');";
                try
                {
                    dB_Connect.SQLQuery(sqlQuery);
                    MessageBox.Show("회사 정보 저장!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    frm10.Update_DB();
                    dB_Connect.Close();
                    this.Close();
                }

            }
        }
        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm10.Update();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 수량의 경우 숫자가 아니면 입력 불가
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 수량의 경우 숫자가 아니면 입력 불가
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 수량의 경우 숫자가 아니면 입력 불가
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();

            if (comboBox1.Text == "051")
            {
                textBox4.MaxLength = 3;
            }
            else
            {
                textBox4.MaxLength = 4;
            }
        }
    }
}
