using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1PI
{
    public partial class Form1 : Form
    {
        bool checker;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checker = true;
            choose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            comboBox5.Show();
            button5.Show();
            
        }
        async void choose()
        {
            while (checker)
            {
                if (comboBox4.SelectedIndex != 0)
                {
                    maskedTextBox1.Enabled = true;
                    maskedTextBox2.Enabled = true;
                    maskedTextBox1.Text = "0000";
                    maskedTextBox2.Text = "0000";
                }
                else
                {
                    maskedTextBox1.Enabled = false;
                    maskedTextBox2.Enabled = false;
                    maskedTextBox1.Text = "5000";
                    maskedTextBox2.Text = "5000";
                }
                await Task.Delay(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checker = false;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checker = false;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label12.Text = (string)comboBox5.SelectedItem;
            comboBox5.Hide();
            button5.Hide();
            button2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label13.Text = maskedTextBox7.Text;
            button3.Show();
            maskedTextBox7.Hide();
            button6.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();
            maskedTextBox7.Show();
            button6.Show();
        }
    }
}
