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


        //물품 출고시 데이터 그리드뷰에 선택된 값을 자동으로 인식하여 물품 명에 제품이름 출력
        public Form4(string target_item, int Count)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            tg_item = textBox1.Text = target_item;
            tg_Count = Count;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            string query = "select Name from Company;";
            try
            {
                DataSet dataset = dB_Connect.GetData(query);
                DataTable datatable = dataset.Tables[0];
                DataRowCollection datarow = datatable.Rows;
                foreach (DataRow row in datarow)
                {
                    if (row["Name"] != null || row["Name"] != DBNull.Value)
                    {
                        comboBox1.Items.Add(row["Name"].ToString());
                    }
                }
                dB_Connect.Close();
            }
            catch(Exception q)
            {
                MessageBox.Show(q.Message);
            }
        }

        //물품명을 받아오기때문에 해당 제품의 보유수량이 0인지 판별 후 동작필요
        private void button1_Click(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            if ( (tg_Count - int.Parse(textBox3.Text)) < 0)
            {
                MessageBox.Show("보유 수량보다 많은 값을 입력했습니다!");
            }
            else
            {
                dB_Connect.ProceDureSQLQuey("itemhistory",comboBox1.Text,textBox1.Text,textBox3.Text,"출고");
                dB_Connect.Close();
                MessageBox.Show($"{textBox1.Text}을(를) {comboBox1.Text}에게 {textBox3.Text}개를 출고하였습니다.");
                this.Close();
            }
        }

        
    }
}
