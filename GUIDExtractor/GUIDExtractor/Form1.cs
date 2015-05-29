using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIDExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (encryptedTextbox != null)
            {
                // {55F30695-900C-4BF3-9DB9-FF4645A10D48}
                // Get the hex characters
                var buf = new StringBuilder(32);
                foreach (char c in encryptedTextbox.Text)
                {
                    if (('0' <= c && c <= '9')
                        || ('a' <= c && c <= 'f')
                        || ('A' <= c && c <= 'F'))
                    {
                        buf.Append(c);
                    }
                }
                if (buf.Length != 32)
                {
                    throw new ArgumentException("Product code must be a valid GUID.");
                }
                Reverse(buf, 0, 8);
                Reverse(buf, 8, 4);
                Reverse(buf, 12, 4);
                Reverse(buf, 16, 2);
                Reverse(buf, 18, 2);
                Reverse(buf, 20, 2);
                Reverse(buf, 22, 2);
                Reverse(buf, 24, 2);
                Reverse(buf, 26, 2);
                Reverse(buf, 28, 2);
                Reverse(buf, 30, 2);
                unencryptedTextbox.Text = buf.ToString();
            }
        }

        private static void Reverse(StringBuilder buf, int index, int count)
        {
            for (int end = index + count - 1; end > index; end--, index++)
            {
                char temp = buf[index];
                buf[index] = buf[end];
                buf[end] = temp;
            }
        }
    }
}
