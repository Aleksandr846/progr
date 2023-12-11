using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int height;
                if (int.TryParse(textBox1.Text, out height))
                {
                    int optimalWeight = height - 100;

                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        int actualWeight;
                        if (int.TryParse(textBox2.Text, out actualWeight))
                        {
                            if (actualWeight < optimalWeight)
                            {
                                MessageBox.Show("Рекомендуется поправиться");
                            }
                            else if (actualWeight > optimalWeight)
                            {
                                MessageBox.Show("Рекомендуется похудеть");
                            }
                            else
                            {
                                MessageBox.Show("Вес в норме");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректный вес");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите ваш текущий вес");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный рост");
                }
            }
            else
            {
                MessageBox.Show("Введите ваш рост");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
