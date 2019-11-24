using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSaver
{
    public partial class Form1 : Form
    {
        bool active = true;
        int DeafultDelay = 60000;
        int HardDelay;
        public Form1()
        {
            InitializeComponent();
            RunAutoSaver();
        }

        private async void RunAutoSaver()
        {
            while(active)
            {
                
                await Task.Delay(GetDelay());
                SendKeys.SendWait("^(s)");
                label3.Text = "Last Saved: " + DateTime.Now;
            }
        }

        private int GetDelay()
        {
            if (HardDelay > 0)
                return HardDelay;

            String val = textBox1.Text;
            int i;
            if (!Int32.TryParse(val, out i))
            {
                i = -1;
            }
            if(i<=0)
            {
                return DeafultDelay;
            }
            else
            {
                return i * 1000;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="STOP")
            {
                active = false;
                button1.Text = "START";
                button1.BackColor = System.Drawing.Color.Lime;
                label1.Text = " Auto Saver is stopped.";
                HardDelay = 21000000;
            }
            else
            {
                active = true;
                HardDelay = 0;
                button1.Text = "STOP";
                button1.BackColor = System.Drawing.Color.Brown;
                label1.Text = " Auto Saver is running...";
                RunAutoSaver();
            }
        }
    }
}
