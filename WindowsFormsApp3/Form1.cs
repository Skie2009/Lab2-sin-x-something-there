using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //дописасть private void drawRectangles (Graphics g);
        {                Graphics g = pictureBox1.CreateGraphics();

            g.PageUnit = GraphicsUnit.Pixel;
            g.PageUnit = GraphicsUnit.Inch;
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen p = new Pen(color.black, 3);
            g.DrawRectangle(p, 0.1f, 1.5f, 4f, 1f);

            int cx = pictureBox1.Width;
                int cy = pictureBox1.Height / 2;

                PointF[] ptf = new PointF[cx];

                // число волн
                int cw = Convert.ToInt32(textBox1.Text);

                // Очистим PictureBox
                g.Clear(pictureBox1.BackColor);

                for (int i = 0; i < cx; i++)
                {
                    ptf[i].X = i;
                    ptf[i].Y = (float)((cy / 2) * (1 - Math.Sin(i * cw * Math.PI / (cx - 1))));
                }
                g.DrawLines(Pens.Red, ptf);
                g.Dispose();
            
        }
    }
}
