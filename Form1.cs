using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g; // Объявляем объект "g" класса Graphics
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            Image img = Image.FromFile("cat.jpg"); // запрещенный прием )))
            g.DrawImageUnscaled(img, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);
        }
                private void button1_Click(object sender, EventArgs e)
        {   int sx = 0, sy = 0, old_sx = 0, old_sy = 0; // координаты экрана
            double x = 0, y = 0;// переменные х у
            Pen axesPen = new Pen(Color.Black, 1);
            Pen graphicsPen = new Pen(Color.FromArgb( 255, 0, 0));
            pictureBox1.BackColor = Color.FromName("AliceBlue");
            pictureBox1.Refresh();
            g.DrawRectangle(axesPen, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            g.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0, (pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);//ось х
            g.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);//ось у
            g.PageUnit = GraphicsUnit.Pixel;// Стандарт страничного пространства в Pixel
            //график функции y=Sin(x)
            x = -Math.PI * 2;
            for (sx = 0; sx <= pictureBox1.Size.Width; sx++)
            {
                y = Math.Sin(x);
                sy = (pictureBox1.Size.Height - 1) - (Convert.ToInt16(y * 200) + 250); //каждый х считается у 
                if (sx != 0)
                {
                    g.DrawLine(graphicsPen, old_sx, old_sy, sx, sy);//РИСУЕМ
                }
                old_sx = sx; old_sy = sy;
                x = x + (Math.PI * 4) / (pictureBox1.Size.Width - 1);// /1000
            }
        }
            private void button2_Click(object sender, EventArgs e)
        {
            int sx = 0, sy = 0, old_sx = 0, old_sy = 0; //коорданаты экрана
            double x = 0, y = 0; // переменные х;у
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen axesPen = new Pen(Color.Black, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 0, 255), 0.1f);
            pictureBox1.BackColor = Color.FromName("AliceBlue");
            pictureBox1.Refresh();
            //Получаем ширину и высоту прямоугольника в миллиметрах
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 3) / g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 3) / g.DpiY * 25.4);
            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            x = -Math.PI * 2;
            for (sx = 0; sx <= WidthInMM; sx++)
            {
                y = Math.Sin(x);
                sy = HeightInMM - (Convert.ToInt16(y * Convert.ToSingle(200 / g.DpiX * 25.4)) + Convert.ToInt16(222 / g.DpiX * 25.4));
                if (sx != 0)
                {
                    g.DrawLine(graphicsPen, old_sx, old_sy, sx, sy);
                }
                old_sx = sx; old_sy = sy;
                x = x + (Math.PI * 4) / WidthInMM;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0;
            float x = 0, y = 0;
            float shag = 0;
            // Стандарт страничного пространства Inch
            g.PageUnit = GraphicsUnit.Inch;
            Pen axesPen = new Pen(Color.Black, 0.01f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 255, 0), 0.01f);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBox1.BackColor = Color.FromName("AliceBlue");
            pictureBox1.Refresh();
            // ширина и высоту прямоугольника в дюймах
            float WidthInInches = (pictureBox1.Size.Width - 1) / g.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / g.DpiY;
            // Рисуем прямоугольник:
            g.DrawRectangle(axesPen, 0, 0, WidthInInches, HeightInInches);
            // наносим оси
            g.DrawLine(axesPen, 0, HeightInInches / 2, WidthInInches,
            HeightInInches / 2);
            g.DrawLine(axesPen, WidthInInches / 2, 0, WidthInInches / 2,
            HeightInInches);
            // график функции y=Sin(x)
            x = -Convert.ToSingle(Math.PI * 2);
            ex = 0;
            shag = Convert.ToSingle(WidthInInches / 25.4);
            while (ex <= WidthInInches + shag)
            {
            y = Convert.ToSingle(Math.Sin(x));
            ey = Convert.ToSingle(-y) + HeightInInches / 2;
            if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
            old_ex = ex; old_ey = ey;
            ex = ex + shag;
            x = x + Convert.ToSingle((Math.PI * 4) / shag);
            }
        }
    }
}