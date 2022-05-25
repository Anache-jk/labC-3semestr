using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab9CrossPlatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int checker = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }
       void FunSin(object mit)
        {
            Random rnd = new Random();
            Chart michart = mit as Chart;
            double x, y;
            int r = rnd.Next(0, 255), identifier = rnd.Next(100, 10000000);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
           int start = rnd.Next(-10, 10);
            int end = rnd.Next(20, 30);
            double step = rnd.Next(1, 9) / 10.0;
            michart.Series.Add("Identifier - " + identifier);
            michart.Series["Identifier - " + identifier].ChartType = SeriesChartType.Line;
            michart.Series["Identifier - " + identifier].Color = Color.FromArgb(255, r, g, b);
            x = start;
            while (x <= end) {
                y = Math.Sin(x);
                michart.Series["Identifier - " + identifier].Points.AddXY(x, y);
                x += step;
                Thread.Sleep(200);
               }
        }

        void FunTan(object mit)
        {
            Random rnd = new Random();
            Chart michart = mit as Chart;
            double x, y;
            int r = rnd.Next(0, 255), identifier = rnd.Next(100, 10000000);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int start = rnd.Next(-10, 10);
            int end = rnd.Next(20, 30);
            double step = rnd.Next(1, 9) / 10.0;
            michart.Series.Add("Identifier - " + identifier);
            michart.Series["Identifier - " + identifier].ChartType = SeriesChartType.Line;
            michart.Series["Identifier - " + identifier].Color = Color.FromArgb(255, r, g, b);
            x = start;
            while (x <= end)
            {
                y = Math.Tan(x);
                if (y > 40 || y < -40)
                {
                    y = 0;
                }
                michart.Series["Identifier - " + identifier].Points.AddXY(x, y);
                x += step;
                Thread.Sleep(200);
            }
        }

        void FunCTan(object mit)
        {
            Random rnd = new Random();
            Chart michart = mit as Chart;
            double x, y;
            int r = rnd.Next(0, 255), identifier = rnd.Next(100, 10000000);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int start = rnd.Next(-10, 10);
            int end = rnd.Next(20, 30);
            double step = rnd.Next(1, 9) / 10.0;
            michart.Series.Add("Identifier - " + identifier);
            michart.Series["Identifier - " + identifier].ChartType = SeriesChartType.Line;
            michart.Series["Identifier - " + identifier].Color = Color.FromArgb(255, r, g, b);
            x = start;
            while (x <= end)
            {
                y = 1.0/ Math.Tan(x);
                if (y > 40 || y < -40)
                {
                    y = 0;
                }
                michart.Series["Identifier - " + identifier].Points.AddXY(x, y);
                x += step;
                Thread.Sleep(200);
            }
        }



        void FunCos(object mit)
        {
            Random rnd = new Random();
            Chart michart = mit as Chart;
            double x, y;
            int r = rnd.Next(0, 255), identifier = rnd.Next(100, 10000000);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int start = rnd.Next(-10, 10);
            int end = rnd.Next(20, 30);
            double step = rnd.Next(1, 9) / 10.0;
            michart.Series.Add("Identifier - " + identifier);
            michart.Series["Identifier - " + identifier].ChartType = SeriesChartType.Line;
            michart.Series["Identifier - " + identifier].Color = Color.FromArgb(255, r, g, b);
            y = start;
            while (y <= end)
            {
                x = Math.Cos(y);
                michart.Series["Identifier - " + identifier].Points.AddXY(x, y);
                y += step;
                Thread.Sleep(200);
            }
        }
    
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread mysin = new Thread(FunSin);
            mysin.Name = $"Threading {checker}";
            mysin.IsBackground = true;
            mysin.Start(chart1);
            checker++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread mycos = new Thread(FunCos);
            mycos.Name = $"Threading {checker}";
            mycos.IsBackground = true;
            mycos.Start(chart1);
            checker++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread myctn = new Thread(FunCTan);
            myctn.Name = $"Threading {checker}";
            myctn.IsBackground = true;
            myctn.Start(chart1);
            checker++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread mytan = new Thread(FunTan);
            mytan.Name = $"Threading {checker}";
            mytan.IsBackground = true;
            mytan.Start(chart1);
            checker++;
        }

       
    }
}
