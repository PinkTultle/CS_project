using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false; // 전체화면 비활성화
        }

        private void button1_Click(object sender, EventArgs e) // 입고 버튼
        {
            this.Close();

            // 텍스트 박스에 담긴 값 DB로 전송

        }
    }
}
