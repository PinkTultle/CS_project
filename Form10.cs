﻿using System;
using System.Collections;
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
    public partial class Form10 : Form
    {
        DB_connect dB_Connect;
        string sqlQuery = ""; // sqlQuery문을 담을 문자열

        public Form10()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            dB_Connect = new DB_connect();
            dB_Connect.Open();

            sqlQuery = "SELECT * FROM `Company` ORDER BY `Name` DESC";

            try
            {
                DataTable table = dB_Connect.readSQL(sqlQuery);
                table.Columns[0].ColumnName = "회사ID";
                table.Columns[1].ColumnName = "회사명";
                table.Columns[2].ColumnName = "회사번호";

                dataGridView1.DataSource = table;

                // DataGridView 열 색상 변경
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                // 중복 선택 불가
                dataGridView1.MultiSelect = false;

                // 행 단위로 클릭
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // DataGridView 첫 번째 열 출력하지 않기 
                dataGridView1.RowHeadersVisible = false;

                // 목록과 DataGridView 크기 맞추기
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dB_Connect.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.ShowDialog();
        }
    }
}