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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
