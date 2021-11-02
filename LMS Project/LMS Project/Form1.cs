using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "로그인";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stud stud = DataManager.Studs.Single(x => x.Id.ToString() == textBox1.Text);
            if (stud.Name == textBox2.Text)
            {
                new Form2().ShowDialog();
            }
            else
                MessageBox.Show("로그인 실패");
        }
    }
}
