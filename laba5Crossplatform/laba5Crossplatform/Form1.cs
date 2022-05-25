using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace laba5Crossplatform
{
    public partial class Form1 : Form
    {
        public int counts;
        public bool checkerZed = true;
        public delegate void MoveZtrack();
        class Point2d
        {
            public double x, y;
          
            public Point2d(double x, double y)
            {
                this.x = x; this.y = y;
            }
        }
        class Zed : Panel
        {
            List<Point2d> points = new List<Point2d>();
            public event MoveZtrack onZed = null;
            public void CatchZed()
            {
                onZed.Invoke();
            }
            public void clearpoints()
            {
                points.Clear();
            }
            public void checkerZ(double x, double y)
            {
                points.Add(new Point2d(x, y));
            }
            public int checkerZ()
            {
                int check = 0, coord1 = 0, coord2 = 0,coord3 = 0,coord4 = 0;
                bool checkfirstcoord = false;
                double maxdx = 0, maxhx = 0, mindx = 10000, minhx = 10000;
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].x > maxdx)
                    {
                        maxdx = points[i].x;
                        coord1 = i;
                    }
                    if (points[i].x < mindx)
                    {
                        mindx = points[i].x;
                        coord3 = i;
                    }
                }
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].x > maxhx && (points[coord1].y > points[i].y || points[coord1].y < points[i].y))
                    {
                        maxhx = points[i].x;
                        coord2 = i;
                    }
                    if (points[i].x < minhx && (points[coord3].y > points[i].y || points[coord3].y < points[i].y))
                    {
                        minhx = points[i].x;
                        coord4 = i;
                    }

                }                
                if(points[coord1].y > points[coord2].y)
                {
                    int dop = 0;
                    dop = coord1;
                    coord1 = coord2;
                    coord2 = dop;
                }
                if(points[coord3].y > points[coord4].y)
                {
                    int dop = 0;
                    dop = coord3;
                    coord3 = coord4;
                    coord4 = dop;
                }
                for (int i = 0; i < points.Count; i++)
                {
                    if((((points[coord2].x-points[coord4].x)/2  - 50 >= points[i].x) ||((points[coord2].x - points[coord4].x) / 2 + 50 <= points[i].x))
                        && (points[coord2].y > points[i].y) 
                        && (points[coord1].y < points[i].y)
                        && (points[coord3].y != points[coord4].y)
                        && (points[coord1].y != points[coord2].y))
                    {
                        check++;
                     }
                    if(check >= 10)
                    {
                        checkfirstcoord = true;
                    }
                }
           
                if (checkfirstcoord)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }
      public static void Sub1()
      {
            MessageBox.Show("Вы провели по траектории Z, ура?");
      }
        

        Zed zobj = new Zed();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zobj.onZed += Sub1;
            zobj.Location = new Point(100, 50);
            zobj.Name = "Bruh";
            zobj.Size = new Size(200, 200);
            zobj.BackColor = Color.Black;
            Controls.Add(zobj);
        }
        async void choose()
        {
            while (checkerZed)
            {
                label2.Text = Convert.ToString(Control.MousePosition.X);
                label3.Text = Convert.ToString(Control.MousePosition.Y);
                zobj.checkerZ(Control.MousePosition.X, Control.MousePosition.Y);
                counts++;
                if (counts % 200 == 0)
                {
                    int result = zobj.checkerZ();
                    if(result != 1)
                    {
                       // MessageBox.Show(Convert.ToString(result));
                        checkerZed = false;
                        button1.Enabled = true;
                        zobj.BackColor = Color.Red;
                    }
                    else if (result == 1)
                    {
                        zobj.CatchZed();
                        checkerZed = false;
                        button1.Enabled = true;
                        zobj.BackColor = Color.Green;
                    }
                    
                    counts = 0; 
                    
                }
                await Task.Delay(10);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread.Sleep(2000);
            zobj.clearpoints();
            counts = 0;
            checkerZed = true;
            zobj.BackColor = Color.Black;
            choose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
