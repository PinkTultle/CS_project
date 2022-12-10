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
        }
    }
}
