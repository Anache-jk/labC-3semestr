using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7Crossplatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool checker = true, checklist = false;
        double x1, x2, y1, y2, z1, z2, modul;

       

        class Vector
        {
            public double x1, x2, y1, y2, z1, z2;
            public double x, y, z;
            public double modulvec;
            public string xyz;

            public Vector(double X1, double X2, double Y1, double Y2, double Z1, double Z2)
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

                modulvec = Math.Round(Math.Sqrt(x * x + y * y + z * z), 7);

                xyz = "(" + x + ";" + y + ";" + z + ")";

            }
        }
        List<Vector> myvector = new List<Vector>();


        async void choosemain()
        {
            while (checker)
            {
                try
                {
                    x1 = Double.Parse(textBox1.Text);
                    x2 = Double.Parse(textBox2.Text);
                    y1 = Double.Parse(textBox3.Text);
                    y2 = Double.Parse(textBox4.Text);
                    z1 = Double.Parse(textBox5.Text);
                    z2 = Double.Parse(textBox6.Text);
                    button1.Enabled = true;
                }
                catch
                {
                    button1.Enabled = false;
                }
                await Task.Delay(100);
            }
        }
        async void choosesecond()
        {
            while (checker)
            {
                try
                {
                    if (checklist)
                    {
                       
                        button4.Enabled = true;
                        button3.Enabled = true;
                    }
                    modul = Double.Parse(textBox7.Text);
                    if (checklist)
                    {
                        button2.Enabled = true;
                    }
                }
                catch
                {
                    button2.Enabled = false;
                }
                await Task.Delay(100);
            }
        }

private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            richTextBox1.Text = null;
            richTextBox2.Text = null;
            richTextBox3.Text = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myvector.Clear();
            checklist = false;
            button4.Enabled = false;
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            choosemain();
            choosesecond();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myvector.Add(new Vector(x1, x2, y1, y2, z1, z2));
            checklist = true;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
            var selectedVector = from vec in myvector
                                 where vec.modulvec > modul
                                 select vec;
            if (selectedVector != null)
            {
                int col = 1;
                foreach (Vector v in selectedVector)
                {
                    richTextBox1.Text = richTextBox1.Text + Convert.ToString(col) + " : "+ v.xyz + " | his modul =  " + v.modulvec + Environment.NewLine;
                    col++;
                }
            }
            else
            {
                richTextBox1.Text = "Not Found";
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = null;
            var vectors = from vec in myvector
                            group vec by vec.x;

            foreach (var vec in vectors)
            {
                richTextBox2.Text = richTextBox2.Text + " X: " + vec.Key + ", has - " + Environment.NewLine + Environment.NewLine;

                int col = 1;

                foreach (var valuevec in vec)
                {
                    richTextBox2.Text = richTextBox2.Text + Convert.ToString(col) + " : " + valuevec.xyz + Environment.NewLine;
                    col++;
                }
                richTextBox2.Text = richTextBox2.Text + Environment.NewLine + Environment.NewLine;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = null;
            var orderedVectors = from v in myvector
                                 orderby v.modulvec ascending
                                 select v;
            int col = 1;
            foreach(var vec in orderedVectors)
            {
                richTextBox3.Text = richTextBox3.Text + Convert.ToString(col) + " : " + vec.xyz + ", modul = " + vec.modulvec + Environment.NewLine;
                col++;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
