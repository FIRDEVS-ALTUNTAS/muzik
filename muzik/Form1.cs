using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string[] paths, files;
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //for(int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
            //{
            //    listBox1.Items.Add(openFileDialog1.SafeFileNames[i].ToString());
            //    listBox2.Items.Add(openFileDialog1.FileName[i].ToString());
            //}

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;

            }
            for (int i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume += 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume -= 10;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        int blink1;
        int blink2;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(111,30,81) ;
            blink1++;
            if (blink1==2)
            {
                timer2.Start();
                timer1.Stop();
                blink1 = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(131,52,113) ;
            blink2++;
            timer1.Start();
            timer2.Stop();
            blink2 = 0;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                paths = paths.Where((path, index) => index != listBox1.SelectedIndex).ToArray();
            }
            else
            {
                MessageBox.Show("Please select the song that you want to delete from the list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.SelectedIndex = listBox1.SelectedIndex;
            //axWindowsMediaPlayer1.URL = listBox2.SelectedItem.ToString();
            //axWindowsMediaPlayer1.Ctlcontrols.play();

           // axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < paths.Length)
            {
                axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
                axWindowsMediaPlayer1.Ctlcontrols.play(); // Şarkı çalmaya başla
            }
        }
    }
}
