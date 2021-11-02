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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "수강신청";

            dataGridView1.DataSource = DataManager.Subs;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Sub subs = dataGridView1.CurrentRow.DataBoundItem as Sub;
                textBox1.Text = subs.subName;
                textBox2.Text = subs.day;
                textBox3.Text = subs.time;
                textBox4.Text = subs.maxNum.ToString();
                textBox5.Text = subs.curNum.ToString();
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stud stud = DataManager.Studs.Single(x => x.Id.ToString() == Form1.textBox1.Text);
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("강의가 선택되지 않았습니다.");
            }
            else if(textBox4.Text == textBox5.Text)
            {
                MessageBox.Show("신청이 마감되었습니다.");
            }
            else if(stud.Sub1 == "")
            {
                try
                {
                    stud.Sub1 = textBox1.Text;
                    stud.Sub1Day = textBox2.Text;
                    stud.Sub1Time = textBox3.Text;

                    //Sub sub = DataManager.Subs.Single(x => x.subName == textBox1.Text);
                    //sub.curNum++;
                    DataManager.Save();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Subs;
                    DataManager.Save();
                    MessageBox.Show("수강신청이 완료되었습니다.");
                }
                catch(Exception ex) { MessageBox.Show("강의 및 ID를 확인해주세요."); }
            }
            else if(stud.Sub1!="" && stud.Sub2=="")
            {
                try
                {
                    if(textBox1.Text == stud.Sub1)
                    {
                        MessageBox.Show("이미 신청한 과목입니다.");
                    }
                    else
                    {
                        if(textBox2.Text == stud.Sub1Day && textBox3.Text == stud.Sub1Time)
                        {
                            MessageBox.Show("같은 시간대에 이미 다른 과목이 있습니다.");
                        }
                        else
                        {
                            stud.Sub2 = textBox1.Text;
                            stud.Sub2Day = textBox2.Text;
                            stud.Sub2Time = textBox3.Text;
                            DataManager.Save();
                            MessageBox.Show("수강신청이 완료되었습니다.");
                        }
                    }
                }catch(Exception ex) { MessageBox.Show("강의 및 ID를 확인해주세요."); }
            }
            else if(stud.Sub1!="" && stud.Sub2!=""&&stud.Sub3=="")
            {
                try
                {
                    if (textBox1.Text == stud.Sub1 || textBox1.Text == stud.Sub2)
                    {
                        MessageBox.Show("이미 신청한 과목입니다.");
                    }
                    else
                    {
                        if ((textBox2.Text == stud.Sub1Day && textBox3.Text == stud.Sub1Time)|| (textBox2.Text == stud.Sub2Day && textBox3.Text == stud.Sub2Time))
                        {
                            MessageBox.Show("같은 시간대에 이미 다른 과목이 있습니다.");
                        }
                        else
                        {
                            stud.Sub3 = textBox1.Text;
                            stud.Sub3Day = textBox2.Text;
                            stud.Sub3Time = textBox3.Text;
                            DataManager.Save();
                            MessageBox.Show("수강신청이 완료되었습니다.");
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("강의 및 ID를 확인해주세요."); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stud stud = DataManager.Studs.Single(x => x.Id.ToString() == Form1.textBox1.Text);
            try
            {
                if ((textBox1.Text == stud.Sub1 && textBox2.Text == stud.Sub1Day && textBox3.Text == stud.Sub1Time))
                {
                    stud.Sub1 = "";
                    stud.Sub1Day = "";
                    stud.Sub1Time = "";

                    DataManager.Save();
                    MessageBox.Show("신청이 취소되었습니다.");
                }
                else if ((textBox1.Text == stud.Sub2 && textBox2.Text == stud.Sub2Day && textBox3.Text == stud.Sub2Time))
                {
                    stud.Sub2 = "";
                    stud.Sub2Day = "";
                    stud.Sub2Time = "";

                    DataManager.Save();
                    MessageBox.Show("신청이 취소되었습니다.");
                }
                else if ((textBox1.Text == stud.Sub3 && textBox2.Text == stud.Sub3Day && textBox3.Text == stud.Sub3Time))
                {
                    stud.Sub3 = "";
                    stud.Sub3Day = "";
                    stud.Sub3Time = "";

                    DataManager.Save();
                    MessageBox.Show("신청이 취소되었습니다.");
                }
                else
                    MessageBox.Show("해당 과목의 신청 기록이 없습니다. 다시 확인해주세요.");
            }catch(Exception ex) { }
        }

        private void 시간표확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}