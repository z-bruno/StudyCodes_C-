using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCombinate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(@"C:\Users\Administrator\Desktop\Equal_Difference\1.jpg");
            Image img2 = Image.FromFile(@"C:\Users\Administrator\Desktop\Equal_Difference\1.jpg");
            Image img3 = Image.FromFile(@"C:\Users\Administrator\Desktop\Equal_Difference\1.jpg");

            int width = img1.Width + img2.Width + img3.Width;
            int h = Math.Max(img1.Height, img2.Height);
            int height = Math.Max(h, img3.Height);
            Bitmap bitmap = new Bitmap(width, height);
            //Graphics g = this.CreateGraphics();
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            //            g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
            g.DrawImage(img1, 0, 0, img1.Width, img1.Height);
            g.DrawImage(img2, img1.Width, 0, img2.Width, img2.Height);
            g.DrawImage(img3, img1.Width + img2.Width, 0, img3.Width, img3.Height);
            Image img = bitmap;
            pictureBox1.Image = img1;
            pictureBox2.Image = img2;
            pictureBox3.Image = img3;
            pictureBox4.Image = img;
            img.Save(@"C:\Users\Administrator\Desktop\Equal_Difference\B.jpg");
        }

    }
}
