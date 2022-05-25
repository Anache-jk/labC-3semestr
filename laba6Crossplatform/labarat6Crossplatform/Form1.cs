using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace labarat6Crossplatform
{ 
    public partial class Form1 : Form
    {
        bool checker = true;
        int weight;
        public Form1()
        {
            InitializeComponent();
            
        }
        class PieChart
        {
            public int check = 0;

            public void myPieChart(Chart michart) {
                michart.Visible = true;
            }

            public void changechart(Chart michart, int poin, string col, int val)
            {
              //  michart.Series[0].Points[poin].SetValueY(val);
                michart.Series[0].Points[poin].SetValueXY(col, val);
                michart.Series[0].Points[poin].Color = Color.FromName(col);
            }
            public void baseadd(Chart michart, List<DataForChart> dat)
            {
                int[] yValues = { 2222, 2724, 2720, 3263, 2445 };
                string[] xValues = { "Red", "Green", "Blue", "Yellow", "Black" };
                michart.Series[0].Points.DataBindXY(xValues, yValues);
                for(int i =0; i < xValues.Length; i++)
                {
                    michart.Series[0].Points[i].Color = Color.FromName(xValues[i]);
                    dat.Add(new DataForChart(xValues[i], yValues[i]));
                    check++;
                }
            }
        }

        class DataForChart
        {
            public int value;
            public string Color;

            public DataForChart(string col, int val)
            {
                this.Color = col;
                this.value = val;

            }
        }
        PieChart chartobj = new PieChart();
        List<DataForChart> datachart = new List<DataForChart>();

        private void Form1_Load(object sender, EventArgs e)
        {
            chartobj.baseadd(chart1, datachart);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            choose();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        async void choose()
        {
            while (checker)
            {
                try
                {
                    weight = Int32.Parse(textBox1.Text);
                    button3.Enabled = true;
                }
                catch
                {
                    button3.Enabled = false;
                }
                await Task.Delay(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartobj.myPieChart(chart1);
            button1.Visible = false;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            datachart[Convert.ToInt32(comboBox1.SelectedIndex)].value = weight;
            datachart[Convert.ToInt32(comboBox1.SelectedIndex)].Color = Convert.ToString(comboBox2.SelectedItem);
            chartobj.changechart(chart1, Convert.ToInt32(comboBox1.SelectedIndex), Convert.ToString(comboBox2.SelectedItem), weight);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
