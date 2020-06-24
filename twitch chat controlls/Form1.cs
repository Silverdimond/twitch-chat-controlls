using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }


   
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 1:
                        if(a!=1)
                        {
                            SendKeys.Send("du");
                            a = 1;
                        }
                      else
                        {
                            SendKeys.Send("draw up");
                            a = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;
                    case 2:
                       
                        if (b != 1)
                        {
                            SendKeys.Send("dl");
                            b = 1;
                        }
                       else
                        {
                            SendKeys.Send("draw left");
                            b = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;
                    case 3:
                        if (c != 1)
                        {
                            SendKeys.Send("dr");
                            c = 1;
                        }
                        else
                        {
                            SendKeys.Send("draw right");
                            c = 0;
                        }
                      
                        SendKeys.Send("{ENTER}");
                        break;
                    case 4:
                        if (b != 1)
                        {
                            SendKeys.Send("dd");
                            b = 1;
                        }
                        else
                        {
                            SendKeys.Send("draw down");
                            b = 0;
                        }
                        SendKeys.Send("{ENTER}");
                        break;

                }
            }

            base.WndProc(ref m);
        }

    }
}
