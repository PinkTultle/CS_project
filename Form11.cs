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
        public Form11()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string companyId = textBox1.Text; // 입력된 회사 ID
            string companyName = textBox2.Text; // 입력된 회사명
            string companyNum = textBox3.Text; // 입력된 회사번호

            dB_Connect = new DB_connect();
            dB_Connect.Open();

            //sqlQuery = "SELECT * FROM `Company`";

            sqlQuery = $"INSERT INTO Company (CompanyID, Name, PhoneNumber) VALUES ({companyId}, {companyName}, {companyNum})";
            dB_Connect.SQLQuery(sqlQuery);

            dB_Connect.Close();
            
        }
    }
}
