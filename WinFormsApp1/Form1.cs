using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap resim = new Bitmap(300, 300);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                Graphics.FromImage(resim).DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x, y, red, green, blue;
            this.Refresh();
            if (resim!=null)
            {

            
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);

            Color color = resim.GetPixel(x, y);
            red   = color.R;
            green = color.G;
            blue  = color.B;

            textBox3.Text = Convert.ToString(red) + "-" + Convert.ToString(green) + "-" + Convert.ToString(blue) ;
                panel1.BackColor = color;
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            int red, green, blue;
            this.Refresh();
            if (resim != null)
            {
                Color color = resim.GetPixel(e.X, e.Y);
                red   = color.R;
                green = color.G;
                blue  = color.B;
                textBox3.Text = Convert.ToString(red) + "-" + Convert.ToString(green) + "-" + Convert.ToString(blue);
                textBox1.Text = Convert.ToString(e.X);
                textBox2.Text = Convert.ToString(e.Y);
                panel1.BackColor = color;
        }
    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // GrayScale
            listBox1.Items.Clear();
            int Red, Green, Blue;
            int ort;
            Color c;

            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    c = resim.GetPixel(i, j);
                    Red = c.R;
                    Green = c.G;
                    Blue = c.B;
                    ort = (Red + Green + Blue) / 3;
                    listBox1.Items.Add("x:" + i + "y:" + j + "->" + ort);
                    resim.SetPixel(i, j, Color.FromArgb(ort, ort, ort));
                }
            }
            pictureBox1.Image = resim;
            this.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Bitmap
            listBox1.Items.Clear();
            int Red, Green, Blue;
            int ort;
            Color c;

            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    c = resim.GetPixel(i, j);
                    Red = c.R;
                    Green = c.G;
                    Blue = c.B;
                    ort = (Red + Green + Blue) / 3; // ortalamayi buluyoruz

                    if (ort > 127)
                    {
                        resim.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        listBox1.Items.Add("x:" + i + "y:" + j + "->" + 255);
                    }
                    else
                    {
                        resim.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        listBox1.Items.Add("x:" + i + "y:" + j + "->" + 0);
                    }

                }
            }
            pictureBox1.Image = resim;
            this.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int r, g, b;
            r = Convert.ToInt32(textBox4.Text);
            g = Convert.ToInt32(textBox5.Text);
            b = Convert.ToInt32(textBox6.Text);
            if (!(r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0))
            {
                panel1.BackColor = Color.FromArgb(r, g, b);
            }
            else
                MessageBox.Show("Hatali degerler girdiniz!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // renk isaretle 
            listBox1.Items.Clear(); 
            int Red, Green, Blue; int r, g, b;
            Color c;
            r = Convert.ToInt32(textBox4.Text);
            g = Convert.ToInt32(textBox5.Text);
            b = Convert.ToInt32(textBox6.Text);

            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    c = resim.GetPixel(i, j);
                    Red = c.R;
                    Green = c.G;
                    Blue = c.B;

                    if (Red == r && Green == g && Blue == b)
                    {
                        listBox1.Items.Add(i + "-" + j);
                        resim.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = resim;
             this.Refresh();
        }
    }
}
