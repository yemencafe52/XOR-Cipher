using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XorEnoUI1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult res = sfd.ShowDialog();

            if (res == DialogResult.OK)
            {

                string dst = sfd.FileName;

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Focus();
                    return;
                }

                button2.Enabled = false;
                button1.Enabled = false;
                textBox2.Enabled = false;

                try
                {
                    FileStream fs = File.Open(textBox1.Text, FileMode.Open);

                    int bufferSize = 1024 * 1024 * 10;

                    while (fs.Position < fs.Length)
                    {
                        byte[] buffer = null;

                        if ((fs.Length - fs.Position) > bufferSize)
                        {
                            buffer = new byte[bufferSize];
                        }
                        else
                        {
                            int lastBuffer = (int)(fs.Length - fs.Position);
                            buffer = new byte[lastBuffer];
                        }

                        fs.Read(buffer, 0, buffer.Length);
                        byte[] enc = Xor.XorM(buffer, Encoding.UTF8.GetBytes(textBox2.Text));

                        FileStream fs2 = File.Open(dst, FileMode.Append);
                        fs2.Write(enc, 0, enc.Length);
                        fs2.Close();

                        double p = ((double)fs.Position / (double)fs.Length);
                        label3.Text = p.ToString("%#0.#0");

                        Application.DoEvents();


                    }
                }
                catch
                {
                    MessageBox.Show("OOPS, SOMETHING WENT WRONG :(");
                }


                button2.Enabled = true;
                button1.Enabled = true;
                textBox2.Enabled = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult res = ofd.ShowDialog();

            if(res == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
    }
}
