using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Jack
{
    public partial class Form1 : Form
    {
        int now_pos, source;
        bool Start = false;
        int[] pos;
        public Form1()
        {
            InitializeComponent();
        }
        Graphics graphics;
        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = this.CreateGraphics();
            pos = new int[4]{0,0,0,0};
            Rn = new Random();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (e.KeyData == Keys.Left)
                {
                        now_pos = 200;
                        if (pos[1] == 1|| pos[2]==1)
                        {
                            Over();
                        }
                        else
                        {
                            source++;
                        label1.Text = "Source :" + source;
                            CUT();
                            print();
                        }
                }
                if (e.KeyData == Keys.Right)
                {
                        now_pos = 380;
                        if (pos[1] == 2|| pos[2] == 2)
                        {
                            Over();
                        }
                        else {
                            source++;
                        label1.Text = "Source :" + source;
                        CUT();
                            print();
                        }
                }
            }
            else
            {
                pos = new int[4] { 0, 0, 0, 0 };
                source = 0;
                label1.Text = "Source :" + source;
                timer1.Enabled = true;
                now_pos = 380;
                CUT();
                print();
                label2.Text = "Time :" + T-- + "s";
            }
        }
        int temp,temp1; Random Rn;
        void print()
        {
            graphics.DrawImage(Jack.Properties.Resources.back, 0, 0);
            if (now_pos ==380)
            {
                graphics.DrawImage(Jack.Properties.Resources.jack_right_burned, now_pos, 200);
            }
            else
            {
                graphics.DrawImage(Jack.Properties.Resources.jack_left_burned, now_pos, 200);
            }
            for (int i = 0; i < 3; i++)
            {
                if(pos[i]!=0)
                if (pos[i]==1)
                    graphics.DrawImage(Jack.Properties.Resources.tree__burned, 177, 12 + (78 * i));
                else if(pos[i] == 2)
                    graphics.DrawImage(Jack.Properties.Resources.tree__, 353 , 12 + (78 * i));
            }
        }
        int T = 60;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Time :" + T--+"s";
            if (T < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Game Over\nSource:" + source);
            }
        }

        void CUT()
        {
again:            temp1 = Rn.Next(1, 4);
            if((pos[0]==1&&temp1==2)|| (pos[0] == 2 && temp1 == 1))
            {
                goto again;
            }
                temp = pos[1];
                pos[1]= pos[0];
                pos[2]= temp;
                pos[0] = temp1;
        }
        void Over()
        {
            MessageBox.Show("Game Over\nSource:"+source);
            timer1.Enabled = false;
        }

    }
}
