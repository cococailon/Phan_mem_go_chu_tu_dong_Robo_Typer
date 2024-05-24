using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PMDanhMayTuDong
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private string text;
        private int i = 0;

        private bool isWroking;
        private bool isStopped;

        public Form2(string textTuF1, Form1 formChuyenTuF1)
        {
            InitializeComponent();
            text = textTuF1;
            TopMost = true;
            form1 = formChuyenTuF1;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = label1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            isStopped = false;
            isWroking = true;
            button1.Enabled = false;
            textBox1.Text = text[0].ToString();
            label1.Text = "";
            this.Text = "Chương trình đang chạy";
            this.ActiveControl = null;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            isWroking = true;
            this.Text = "Chương trình đang chạy";
            this.ActiveControl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isWroking = false;
            this.Text = "Chương trình đã được tạm dừng";
            this.ActiveControl = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Text = "Chương trình đã dừng";
            i = 0;
            isStopped = true;
            isWroking = false;
            button1.Enabled = true;
            textBox1.Text = "";
            label1.Text = "";
            this.ActiveControl = null;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (isWroking == true && i < text.Length - 1)
            {
                textBox1.Text = text[i + 1].ToString();
                label1.Text = "" + Math.Round((((i + 1) / (float)text.Length) * 100), 1) + "%";

                this.WindowState = FormWindowState.Minimized;

                if (text[i] == '(' || text[i] == ')' || text[i] == '{' || text[i] == '}' ||
                    text[i] == '~' || text[i] == '+' || text[i] == '%' || text[i] == '^')
                {
                    SendKeys.SendWait("{" + text[i].ToString() + "}");
                }
                else
                {
                    SendKeys.SendWait(text[i].ToString());
                }

                this.WindowState = FormWindowState.Normal;

                i++;
            }
            else if (isWroking == true && i == text.Length - 1)
            {
                textBox1.Text = text[i].ToString();
                label1.Text = "" + Math.Round((((i + 1) / (float)text.Length) * 100), 1) + "%";

                this.WindowState = FormWindowState.Minimized;

                if (text[i] == '(' || text[i] == ')' || text[i] == '{' || text[i] == '}' ||
                    text[i] == '~' || text[i] == '+' || text[i] == '%' || text[i] == '^')
                {
                    SendKeys.SendWait("{" + text[i].ToString() + "}");
                }
                else
                {
                    SendKeys.SendWait(text[i].ToString());
                }

                this.WindowState = FormWindowState.Normal;

                isWroking = false;
                button1.Enabled = true;
                textBox1.Text = "";
                i = 0;
                this.Text = "Chương trình đã hoàn thành";
            }
        }


        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = e.X;
                int y = e.Y;
                if (x > 240)
                {
                    x = 240;
                }

                if (y > 12)
                {
                    y = 12;
                }

                button5.Location = new Point(x, y);
                button7.Location = new Point(x, y + 21);
                button6.Location = new Point(x, y + 42);

                button5.Enabled = true;
                button5.Visible = true;
                button6.Enabled = true;
                button6.Visible = true;
                button7.Enabled = true;
                button7.Visible = true;
            }
            else if (e.Button == MouseButtons.Left)
            {
                button5.Enabled = false;
                button5.Visible = false;
                button6.Enabled = false;
                button6.Visible = false;
                button7.Enabled = false;
                button7.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = label1.Location.X + e.X;
                int y = label1.Location.Y + e.Y;
                button5.Location = new Point(x, y);
                button7.Location = new Point(x, y + 21);
                button6.Location = new Point(x, y + 42);

                button5.Enabled = true;
                button5.Visible = true;
                button6.Enabled = true;
                button6.Visible = true;
                button7.Enabled = true;
                button7.Visible = true;
            }
            else if (e.Button == MouseButtons.Left)
            {
                button5.Enabled = false;
                button5.Visible = false;
                button6.Enabled = false;
                button6.Visible = false; 
                button7.Enabled = false;
                button7.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button5.Visible = false;
            button6.Enabled = false;
            button6.Visible = false;
            button7.Enabled = false;
            button7.Visible = false;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = 240;
                int y = label2.Location.Y + e.Y;
                button5.Location = new Point(x, y);
                button7.Location = new Point(x, y + 21);
                button6.Location = new Point(x, y + 42);

                button5.Enabled = true;
                button5.Visible = true;
                button6.Enabled = true;
                button6.Visible = true;
                button7.Enabled = true;
                button7.Visible = true;
            }
            else if (e.Button == MouseButtons.Left)
            {
                button5.Enabled = false;
                button5.Visible = false;
                button6.Enabled = false;
                button6.Visible = false;
                button7.Enabled = false;
                button7.Visible = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            button5.Enabled = false;
            button5.Visible = false;
            button6.Enabled = false;
            button6.Visible = false;
            button7.Enabled = false;
            button7.Visible = false;
        }
    }
}
