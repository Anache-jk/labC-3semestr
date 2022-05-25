using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2Crossplatform
{
    public partial class Form1 : Form
    {
        public bool checker  = true;
        public double t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13;
        public class Vector
        {
            private double x1, y1, z1, x2,y2,z2;
            public double x, y, z;

            public Vector(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
            {
                x1 = X1;
                x2 = X2;
                y1 = Y1;
                y2 = Y2;
                z1 = Z1;
                z2 = Z2;
                x = x2 - x1;
                y = y2 - y1;
                z = z2 - z1;
            }

            public string SumVec(Vector v)
            {
                return "(" + (this.x + v.x) + ";" + (this.y + v.y) + ";" + (this.z + v.z) + ")";
            }
            public string SubtractVec(Vector v)
            {
                return "(" + (this.x - v.x) + ";" + (this.y - v.y) + ";" + (this.z - v.z) + ")";
            }
            public double ModulVec()
            {
                return Math.Round(Math.Sqrt(x * x + y * y + z * z),7);
            }
            public string MultiplicateVec(double scal)
            {
                return "(" + (this.x * scal) + ";" + (this.y * scal) + ";" + (this.z * scal) + ")";
            }
            public string DecartViewVec()
            {
                return "(" + (this.x) + ";" + (this.y) + ")";
            }
            public string SphereViewVec()
            {
                return "(" + (this.x) + ";" + (this.y) + ";" + (this.z) + ")";
            }

        }
        async void choose()
        {
            while (checker)
            {
                try
                {
                    t1 = Double.Parse(textBox1.Text);
                     t2 = Double.Parse(textBox2.Text);
                     t3 = Double.Parse(textBox3.Text);
                     t4 = Double.Parse(textBox4.Text);
                     t5 = Double.Parse(textBox5.Text);
                     t6 = Double.Parse(textBox6.Text);
                     t7 = Double.Parse(textBox7.Text);
                     t8 = Double.Parse(textBox8.Text);
                     t9 = Double.Parse(textBox9.Text);
                     t10 = Double.Parse(textBox10.Text);
                     t11 = Double.Parse(textBox11.Text);
                     t12 = Double.Parse(textBox12.Text);
                     t13 = Double.Parse(textBox13.Text);

                    button1.Enabled = true;
                }
                catch
                {
                    button1.Enabled = false;
                }
                await Task.Delay(100);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checker = true;
            choose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vector onevec = new Vector(t1,t2,t3,t6,t5,t4);
            Vector twovec = new Vector(t12,t11,t10,t9,t8,t7);

            //decartsystem
            textBox20.Text = onevec.DecartViewVec();
            textBox14.Text = twovec.DecartViewVec();
            //spheresystem
            textBox19.Text = onevec.SphereViewVec();
            textBox21.Text = twovec.SphereViewVec();
            //multiplicatescalyar
            textBox18.Text = onevec.MultiplicateVec(t13);
            textBox15.Text = twovec.MultiplicateVec(t13);
            //sumofvector
            textBox17.Text = onevec.SumVec(twovec);
            //subtractionofvector
            textBox16.Text = onevec.SubtractVec(twovec);
            //moduleofvector1
            textBox22.Text = Convert.ToString(onevec.ModulVec());
            //moduleofvector2
            textBox23.Text = Convert.ToString(twovec.ModulVec());

        }
    }
}
