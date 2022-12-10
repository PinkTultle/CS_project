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
        DB_connect dB_Connect = new DB_connect();
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
            dB_Connect.Open();
            LoadList("입고");
        }
        public void LoadList(string record)
        {
            string query;
            if(record == "입고")
            {
                query = "select SalesRecord.ItemID,Items.Name,Company.Name,SalesRecord.Count,toDate,Record from SalesRecord,Items,Company " +
                    "where Items.ItemID = SalesRecord.ItemID  " +
                    "and SalesRecord.Record = '입고'" +
                    "group by Items.Name;";
            }
            else
            {
                query = $"select SalesRecord.ItemID,Items.Name,Company.Name,SalesRecord.Count,toDate,Record from SalesRecord,Items,Company " +
                    $"where Items.ItemID = SalesRecord.ItemID and Company.CompanyID = SalesRecord.CompanyID " +
                    $"and SalesRecord.Record = '{record}';";
            }
            try
            {
                DataTable table = dB_Connect.readSQL(query);
                dataGridView1.DataSource = table;
                dB_Connect.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.Text.ToString();
            LoadList(s);
        }
    }
}
