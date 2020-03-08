using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AUTOKEY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = this.input.Text.Trim();
            int enterCount = int.Parse(this.enterCount.Text.Trim());
            int InvertTime = int.Parse(this.InvertTime.Text.Trim());
            int IntiTime = int.Parse(this.IntiTime.Text.Trim());
            int Times = int.Parse(this.Times.Text.Trim());

            System.Threading.Thread.Sleep(IntiTime*1000);

            for (int i = 0; i < Times; i++)
            {
                SendKeys.SendWait(input);
                if (enterCount > 0)
                {
                    SendKeys.SendWait("{ENTER " + enterCount + "}");
                    System.Threading.Thread.Sleep(InvertTime);
                }
                else
                {
                    for (int k = 0; k < input.Length; k++)
                    {
                        SendKeys.SendWait(input.Substring(k,1));
                        System.Threading.Thread.Sleep(200);
                    }
                    System.Threading.Thread.Sleep(InvertTime * (i + 1));
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Point p = Control.MousePosition;
            int InvertTime = int.Parse(this.InvertTime.Text.Trim());
            int IntiTime = int.Parse(this.IntiTime.Text.Trim());
            int Times = int.Parse(this.Times.Text.Trim());
            
            System.Threading.Thread.Sleep(IntiTime * 1000);
            for (int i = 0; i < Times; i++)
            {
                mouse_right(p);
                System.Threading.Thread.Sleep(InvertTime); 
            }                        
        }

        [DllImport("user32.dll", EntryPoint = "mouse_event", SetLastError = true)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        const int MOUSEEVENTF_MOVE = 0x0001;  // 移动鼠标
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        const int MOUSEEVENTF_RIGHTUP = 0x0010;// 模拟鼠标右键抬起
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标
        static void mouse_right(System.Drawing.Point p)
        { 
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP,p.X,p.Y, 0, 0);
        }

        static void mouse_left(System.Drawing.Point p)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, p.X, p.Y, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String input = this.input.Text.Trim();
            int enterCount = int.Parse(this.enterCount.Text.Trim());
            int InvertTime = int.Parse(this.InvertTime.Text.Trim());
            int IntiTime = int.Parse(this.IntiTime.Text.Trim());
            int Times = int.Parse(this.Times.Text.Trim());

            System.Threading.Thread.Sleep(IntiTime * 1000);
            System.Drawing.Point p = Control.MousePosition;
            for (int i = 0; i < Times; i++)
            {
                SendKeys.Send(input);
                System.Threading.Thread.Sleep(InvertTime);
                mouse_left(p);
                System.Threading.Thread.Sleep(InvertTime);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String input = "show me the money";
            int enterCount = 2;
            int InvertTime = 200;
            int IntiTime = 5000;
            int Times = 100;

            System.Threading.Thread.Sleep(IntiTime);

            for (int i = 0; i < Times; i++)
            {
                SendKeys.SendWait(input);              
                SendKeys.SendWait("{ENTER " + enterCount + "}");
                System.Threading.Thread.Sleep(InvertTime);
                
            }
        }
    }
}
