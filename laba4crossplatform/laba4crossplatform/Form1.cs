using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4crossplatform
{
    public partial class Form1 : Form
    {
        public bool checker;
        public int numidex, numview;
        public double element;
        GenericAscSortedList lis = new GenericAscSortedList();
        public class GenericAscSortedList : IComparable<GenericAscSortedList>
        {
            public List<double> lists = new List<double>();
            public int max;
            public int counts;

            public string COUNT
            {
                get
                {
                    return Convert.ToString(lists.Count);
                }
            }

            public string Add(int num, double val)
            {
                try
                {
                    if (lists.Count == num - 1)
                    {
                        lists.Add(val);
                        return "Элемент успешно вставлен";
                    }
                    else if (lists.Count > num - 1)
                    {
                        lists.Insert(num-1, val);
                        return "Элемент успешно вставлен";
                    }
                    else
                    {
                        return "Невозможно вставить элемент";
                    }
                }
                catch
                {
                    return "ошибка добавления элемента";
                }
                
            }

            public int CompareTo(GenericAscSortedList other)
            {
                if (other.lists[counts] > this.lists[max])
                {
                    return 1;
                }
                else if (other.lists[counts] < this.lists[max])
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            public string Max()
            {
                try
                {
                    max = 0;
                    counts = 0;
                    foreach (var item in lists)
                    {
                        if (item.CompareTo(item) == 1 || item.CompareTo(item) == 0)
                        {
                            max = counts;
                        }
                        counts++;
                    }
                    return Convert.ToString(lists.Max());
                }
                catch
                {
                    return "Список пуст или мал";
                }
            }
            public string Min()
            {
                try
                {
                    counts = 0;
                    foreach (var item in lists)
                    {
                        if (item.CompareTo(item) == -1 || item.CompareTo(item) == 0)
                        {
                            max = counts;
                        }
                        counts++;
                    }
                    return Convert.ToString(lists.Min());
                }
                catch
                {
                    return "Список пуст или мал";
                }
            }
            public string Get(int num)
            {
                try
                {
                    if (lists.Count > num || lists.Count == num)
                    {
                        return Convert.ToString(lists[num - 1]);
                    }
                    else
                    {
                        return "ошибка нахождения элемента";
                    }
                }
                catch
                {
                    return "Список слишком мал для такого индекса";
                }
            }
            public void add10()
            {
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    lists.Add(rnd.Next(0, 100));
                }
            }
            public string view()
            {
                string elements = "";
                for(int i = 0; i < lists.Count; i++)
                {
                    elements = elements + Convert.ToString(lists[i]) + " | ";
                }
                return elements;
            }
            public string sortreverse()
            {
                List<double> secondlists = new List<double>(lists);
                secondlists.Sort();
                secondlists.Reverse();
                string elements = "";
                for (int i = 0; i < secondlists.Count; i++)
                {
                    elements = elements + Convert.ToString(secondlists[i]) + " | ";
                }
                return elements;
            }
        }
        public Form1()
        {
            InitializeComponent();
            
        }
        async void choose()
        {
            while (checker)
            {
                try
                {
                    numidex = Convert.ToInt32(textBox1.Text);
                    numview = Convert.ToInt32(textBox4.Text);
                    element = Convert.ToDouble(textBox7.Text);
                    button2.Enabled = true;
                }
                catch
                {
                    button2.Enabled = false;
                }
                await Task.Delay(100);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            checker = true;
            choose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lis.Add(numidex, element));
            textBox5.Text = lis.Get(numview);
            textBox2.Text = lis.Max();
            textBox3.Text = lis.Min();
            textBox6.Text = lis.COUNT;
            textBox8.Text = lis.view();
            textBox9.Text = lis.sortreverse();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lis.add10();
            button3.Enabled = false;
        }
    }
}
