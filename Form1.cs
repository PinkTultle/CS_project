﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;// 전체화면 비활성화
            
        }

        private void Form1_Click(object sender, EventArgs e) // 화면 클릭 경우
        {
            this.Hide(); // 로고 화면 숨김
            this.Close(); // 로고 화면 종료
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e) // 사진 클릭 경우
        {
            this.Hide(); // 로고 화면 숨김
            this.Close(); // 로고 화면 종료
        }
    }
}
