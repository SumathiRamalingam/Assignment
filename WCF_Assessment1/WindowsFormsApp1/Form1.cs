using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string operation = string.Empty;
        public int a;
        ServiceReference2.Service1Client csc = new ServiceReference2.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceRef.Service1Client sc = new ServiceRef.Service1Client("BasicHttpBinding_IService1");
            MessageBox.Show(sc.SayHello("Ram"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceRef.Service1Client tcpSc = new ServiceRef.Service1Client("NetTcpBinding_IService1");
            MessageBox.Show(tcpSc.TodayProgram("Ram"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client jsc = new ServiceReference1.Service1Client();
            var list = jsc.OpeningJobs();
            string results = string.Empty;

            foreach (var item in list)
            {
                string role = string.Empty;
                string job = string.Empty;
                role = role + item.role;
                job = string.Join(",", item.jobName);
                if (results.Length == 0)
                    results = role + ":   " + job;
                else
                    results = results + " ; " + role + ":   " + job;
            }
            MessageBox.Show(results);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = button4.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = button16.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = button15.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = button14.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = button13.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = button12.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = button11.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = button10.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = button5.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = button7.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            textBox1.Text = string.Empty;
            operation = button9.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            textBox1.Text = string.Empty;
            operation = button8.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int b = Convert.ToInt32(textBox1.Text);
            if (operation == "+")
                textBox1.Text = csc.add(a, b).ToString();
            else
                textBox1.Text = csc.Sub(a, b).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client jsc = new ServiceReference1.Service1Client();
            var list = jsc.OpeningJobsByRole("Manager");
            string results = string.Empty;
            string role = string.Empty;
            string job = string.Empty;
            if (list.Length > 0)
            {
                role = role + list[0].role;
                job = string.Join(",", list[0].jobName);
                if (results.Length == 0)
                    results = role + ":   " + job;
                else
                    results = results + " ; " + role + ":   " + job;
            }
            else
            {
                results = "No such Role is found";
            }
            MessageBox.Show(results);
        }
    }
}
