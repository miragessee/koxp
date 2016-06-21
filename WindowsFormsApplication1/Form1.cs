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
using DWORD = System.UInt32;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string sClass, string sWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            IntPtr find = (IntPtr)FindWindow(null, str);

            DWORD pid = 0;

            GetWindowThreadProcessId(find, out pid);

            if ((int)find > 0)
            {
                MessageBox.Show("Bulundu: " + pid);
            }
            else
            {
                MessageBox.Show("Bulunamadı");
            }
        }
    }
}
