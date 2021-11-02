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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Stud stud = DataManager.Studs.Single(x => x.Id.ToString() == Form1.textBox1.Text);
            textBox1.Text = stud.Sub1;
            textBox2.Text = stud.Sub1Day;
            textBox3.Text = stud.Sub1Time;
            textBox4.Text = stud.Sub2;
            textBox5.Text = stud.Sub2Day;
            textBox6.Text = stud.Sub2Time;
            textBox7.Text = stud.Sub3;
            textBox8.Text = stud.Sub3Day;
            textBox9.Text = stud.Sub3Time;
        }
    }
}
