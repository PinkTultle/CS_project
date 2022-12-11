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

            //sqlQuery = "SELECT * FROM `Company`";
            //(CompanyID, Name, PhoneNumber) -> Company 테이블 컬럼
            sqlQuery = $"INSERT INTO Company values ( '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}');";
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

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm10.Update();


        }
    }
}
