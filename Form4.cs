using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Form4()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();
            sqlQuery = $"UPDATE Items SET Count = Count - {textBox3.Text} WHERE Name ='{textBox1.Text}';";
      
            dB_Connect.SQLQuery(sqlQuery);
            dB_Connect.Close();
            this.Close();
        }
    }
}
