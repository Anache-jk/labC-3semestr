using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace lab8Crossplatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<News> newslist = new List<News>();
        int counts = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            choose();
        }



        class News
        {
            public string link, title, information, date;

            public News(string TITLE, string INFO, string LINK, string DATE)
            {
                link = LINK;
                title = TITLE;
                information = INFO;
                date = DATE;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            XElement xRoots = XElement.Load("http://news.yandex.ru/world.rss");
            XElement xRoot = xRoots.Element("channel");
            if (xRoot != null)
           {
                foreach(XElement ynews in xRoot.Elements("item"))
                {
                    XElement titles = ynews.Element("title");
                    XElement links = ynews.Element("link");
                    XElement info = ynews.Element("description");
                    XElement dates = ynews.Element("pubDate");

                    newslist.Add(new News(titles.Value, info.Value, links.Value, dates.Value));
                    counts++;
                    comboBox1.Items.Add(counts);
                }
            }
            counts = 0;
            button1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.SelectedIndex = counts;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label5.Text = newslist[counts].title;
            label6.Visible = true;
            label6.Text = newslist[counts].information;
            label7.Visible = true;
            label7.Text = newslist[counts].link;
            label8.Visible = true;
            label8.Text = newslist[counts].date;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label11.Text = Convert.ToString(counts + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = newslist[comboBox1.SelectedIndex].title;
            label6.Text = newslist[comboBox1.SelectedIndex].information;
            label7.Text = newslist[comboBox1.SelectedIndex].link;
            label8.Text = newslist[comboBox1.SelectedIndex].date;
            counts = comboBox1.SelectedIndex;
            label11.Text = Convert.ToString(counts + 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            counts++;
            label5.Text = newslist[counts].title;
            label6.Text = newslist[counts].information;
            label7.Text = newslist[counts].link;
            label8.Text = newslist[counts].date;
            comboBox1.SelectedIndex = counts;
            label11.Text = Convert.ToString(counts + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            counts--;
            label5.Text = newslist[counts].title;
            label6.Text = newslist[counts].information;
            label7.Text = newslist[counts].link;
            label8.Text = newslist[counts].date;
            comboBox1.SelectedIndex = counts;
            label11.Text = Convert.ToString(counts + 1);
        }
        async void choose()
        {
            while (true)
            {
                if (counts > 0)
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
                if (counts < newslist.Count - 1)
                {
                    button4.Enabled = true;
                }
                else
                {
                    button4.Enabled = false;
                }
                await Task.Delay(100);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
