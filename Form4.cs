using Google.Protobuf.WellKnownTypes;
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
        string sqlQuery;
        DB_connect dB_Connect;
        DataTable dB_dt;
        DataTable dt_item;
        DataTable dt_com;
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


        //물품명을 받아오기때문에 해당 제품의 보유수량이 0인지 판별 후 동작필요
        private void button1_Click(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            while( (tg_Count - int.Parse(textBox3.Text)) < 0)
            {
                MessageBox.Show("보유 수량보다 많은 값을 입력했습니다!");

            }

            //선택 물품 출고작업
            sqlQuery = $"UPDATE Items SET Count = Count - {textBox3.Text} WHERE Name ='{textBox1.Text}';";
            dB_Connect.SQLQuery(sqlQuery);

            MessageBox.Show("itme_count_update good");
 



            /*dt_item = dB_Connect.Copy_DT(dt_item, "Items");
            dt_com = dB_Connect.Copy_DT(dt_com, "Company");

            DataRow[] dt_it = dt_item.Select($"{tg_item}");
            DataRow[] dt_co = dt_com.Select($"{textBox2.Text}");
            */

            //Num ItemID  CompanyID Count  Date

            //판매기록 데이터 테이블에 기록 추가
            sqlQuery = $"INSERT INTO SalesRecord values({123/*Num*/},{tg_Count - int.Parse(textBox3.Text)/*Count*/},{ DateTime.Now /*Date*/});";
            dB_Connect.SQLQuery(sqlQuery);

            dB_Connect.Close();
            this.Close();
        }
    }
}
