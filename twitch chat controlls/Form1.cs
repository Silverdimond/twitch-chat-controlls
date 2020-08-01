using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twitch_chat_controlls
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        int a = 0, b = 0, c = 0, d = 0;
        List<string> up = new List<string>();
        List<string> down = new List<string>();
        List<string> left = new List<string>();
        List<string> right = new List<string>();
        public Form1()
        {
           // See: https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            int FirstHotKeyKey = (int)Keys.NumPad8;
            // Register the "8" hotkey
            Boolean F9Registered = RegisterHotKey(
                this.Handle, 1, 0x0000, FirstHotKeyKey
            );
            int FirstHotKeyKeya = (int)Keys.NumPad4;
            // Register the "4" hotkey
            Boolean F9Registereda = RegisterHotKey(
                this.Handle, 2, 0x0000, FirstHotKeyKeya
            );
            int FirstHotKeyKeyab = (int)Keys.NumPad6;
            // Register the "6" hotkey
            Boolean F9Registeredab = RegisterHotKey(
                this.Handle, 3, 0x0000, FirstHotKeyKeyab
            );
            int FirstHotKeyKeyabc = (int)Keys.NumPad2;
            // Register the "2" hotkey
            Boolean F9Registeredabc = RegisterHotKey(
                this.Handle, 4, 0x0000, FirstHotKeyKeyabc
            );
            InitializeComponent();
            loadconf();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadconf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory + @"\config\");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void loadconf()
        {
            up.Clear();
            down.Clear();
            left.Clear();
            right.Clear();
            try
            {
                using (StreamReader upc = new StreamReader(Environment.CurrentDirectory+@"\config\up.txt"))
                {
                    while (!upc.EndOfStream)
                    {
                       
                       up.Add(upc.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {


                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show("ERROR:"+e.ToString(), "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }

            }
            if (up.Count==0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(@"ERROR: FILE `config\up.txt` IS EMPTY", "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }
            }
            try
            {
                using (StreamReader upc = new StreamReader(Environment.CurrentDirectory + @"\config\down.txt"))
                {
                    while (!upc.EndOfStream)
                    {

                        down.Add(upc.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {


                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show("ERROR:" + e.ToString(), "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }

            }
            if (down.Count == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(@"ERROR: FILE `config\down.txt` IS EMPTY", "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }
            }
            try
            {
                using (StreamReader upc = new StreamReader(Environment.CurrentDirectory + @"\config\left.txt"))
                {
                    while (!upc.EndOfStream)
                    {

                        left.Add(upc.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {


                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show("ERROR:" + e.ToString(), "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }

            }
            if (left.Count == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(@"ERROR: FILE `config\left.txt` IS EMPTY", "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }
            }
            try
            {
                using (StreamReader upc = new StreamReader(Environment.CurrentDirectory + @"\config\right.txt"))
                {
                    while (!upc.EndOfStream)
                    {

                       right.Add(upc.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {


                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show("ERROR:" + e.ToString(), "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }

            }
            if (right.Count == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(@"ERROR: FILE `config\right.txt` IS EMPTY", "Error", buttons);
                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    loadconf();
                    return;
                }
            }
            return;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 1:
                        if(a!=up.Count-1)
                        {
                            SendKeys.Send(up[a]);
                            a++;
                        }
                      else
                        {
                        
                            SendKeys.Send(up[a]);
                            a = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;
                    case 2:

                        if (b != left.Count-1 )
                        {
                            SendKeys.Send(left[b]);
                            b++;
                        }
                        else
                        {
                         
                            SendKeys.Send(left[b]); 
                            b = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;
                    case 3:
                        if (c != right.Count-1 )
                        {
                            SendKeys.Send(right[c]);
                            c++;
                        }
                        else
                        {
                          
                            SendKeys.Send(right[c]);
                            c = 0;
                        }

                        SendKeys.Send("{ENTER}");
                        break;
                    case 4:
                        if (d != down.Count -1)
                        {
                            SendKeys.Send(down[d]);
                            d++;
                        }
                        else
                        {
                         
                            SendKeys.Send(down[d]);
                            d = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;

                }
            }

            base.WndProc(ref m);
        }

    }
}
