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

namespace AutoLockFeature
{
    public partial class Form1 : Form
    {
        int timeToLock;

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [DllImport("user32.dll")]
        static extern int MessageBoxTimeout(IntPtr hwnd, String text, String title, uint type, Int16 wLanguageId, Int32 milliseconds);

        [DllImport("user32.dll")]
        static extern void LockWorkStation();

        static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;
            uint envTicks = (uint)Environment.TickCount;

            if( GetLastInputInfo( ref lastInputInfo ) )
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;

            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            timeToLock = int.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Leave(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uint elapsed = 0;
            elapsed = GetLastInputTime();
            textBox2.Text = elapsed.ToString();

            if (elapsed > timeToLock)
            {
                timer1.Enabled = false;
                int iRet = MessageBoxTimeout(this.Handle,"Your workstation is about to lock. Press Ok to lock it now or Cancel to skip","Autolocking soon",1,0,5000);
                if (iRet != 2)
                {
                    LockWorkStation();
                    timer1.Enabled = true;
                }
            } 
        }
    }

    [StructLayout( LayoutKind.Sequential )]
    struct LASTINPUTINFO
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwTime;
    }
}
