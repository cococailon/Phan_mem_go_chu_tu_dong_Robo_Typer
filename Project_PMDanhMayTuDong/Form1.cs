using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PMDanhMayTuDong
{
    public partial class Form1 : Form
    {
        private bool isStopped;
        private Image img1;
        private Image img2;
        private Image helpGif;
        private Image helpImg;

        public Form1()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\imageBgRoboTyper.png");
            img1 = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\imageBgBlueRobo.png");
            img2 = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\imageBgRedRobo.png");
            helpGif = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\helpgif.gif");
            helpImg = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\helpimgok.png");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            this.Text = "RoboTyper 1.0.0 (BlueRobo)";
            button2.Enabled = false;
            button2.Visible = false;

            this.BackgroundImage = img1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button2.Visible = true;
            this.Text = "RoboTyper 1.0.0 (RedRobo)";
            button1.Enabled = false;
            button1.Visible = false;

            this.BackgroundImage = img2;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    //Đéo làm gì
                }
                else
                {
                    isStopped = true;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;

            if (text == "")
            {
                MessageBox.Show("Vui lòng nhập văn bản cần gõ vào ô trước khi chạy !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isStopped = false;

            string ms = "Lưu ý trước khi chạy:\n" +
                  "1. Tắt Unikey.\n" +
                  "2. Trên các phần mềm chuyên viết code, cần tắt các chức năng: " +
                  "tự động sinh dấu, tự động căn lề, gợi ý, và tất cả những cài đặt khác có khả năng" +
                  " can thiệp và làm thay đổi văn bản được gõ vào.\n" +
                  "3. Khi chương trình đang chạy ở chức năng \"Gõ chữ tự động\", nếu muốn dừng" +
                  " quá trình chạy lại, chỉ cần mở chương trình lên từ thanh taskbar.\n" +
                  "CHƯƠNG TRÌNH SẼ CHẠY SAU KHI BẠN NHẤN \"Yes\", BẠN ĐÃ SẴN SÀNG ?";
            DialogResult dlrs = MessageBox.Show(ms, "Thông báo", MessageBoxButtons.YesNoCancel);

            int dem = 0;
            if (dlrs == DialogResult.Yes)
            {
                this.WindowState = FormWindowState.Minimized;
                button1.Enabled = false;
                richTextBox1.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;

                await Task.Run(() =>
                {
                    string[] cacDong = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);

                    this.WindowState = FormWindowState.Minimized;
                    for (int i = 0; i < cacDong.Length; i++)
                    {
                        foreach (char dong in cacDong[i])
                        {
                            System.Threading.Thread.Sleep(1);
                            dem = 0;
                            if (isStopped == true)
                            {
                                MessageBox.Show("Đã dừng chương trình !!");
                                dem++;
                                return;
                            }

                            if (dong == '(' || dong == ')' || dong == '{' || dong == '}' ||
                                dong == '~' || dong == '+' || dong == '%' || dong == '^')
                            {
                                SendKeys.SendWait("{" + dong.ToString() + "}");
                            }
                            else
                            {
                                SendKeys.SendWait(dong.ToString());
                            }
                        }
                        SendKeys.SendWait("\r");
                    }
                });
            }
            else
            {
                return;
            }

            if (dem == 0)
            {
                this.WindowState = FormWindowState.Normal;
                MessageBox.Show("Chương trình đã hoàn thành !!");
            }

            button1.Enabled = true;
            richTextBox1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;

            if (text == "")
            {
                MessageBox.Show("Vui lòng nhập văn bản cần gõ vào ô trước khi bắt đầu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ms = "Lưu ý trước khi chạy:\n" +
                        "1. Tắt Unikey.\n" +
                        "2. Trên các phần mềm chuyên viết code, cần tắt các chức năng: " +
                        "tự động sinh dấu, tự động căn lề, gợi ý, và tất cả những cài đặt khác có khả năng" +
                        " can thiệp và làm thay đổi văn bản được gõ vào.\n" +
                        "3. Khi chương trình đang chạy ở chức năng \"Giả gõ chữ\", vui lòng không" +
                        " nhấn phím quá nhanh vì sẽ khiến ký tự gõ vào bị sai lệch.\n" +
                        "4. Hiện tại, chức năng \"Giả gõ chữ\" vẫn chưa được hỗ trợ cho trình soạn thảo Word, " +
                        "do đó, chương trình vẫn" +
                        " có thể hoạt động nhưng sẽ gây ra nhiều lỗi.\n" +
                        "CHƯƠNG TRÌNH SẼ BẮT ĐẦU SAU KHI BẠN NHẤN \"Yes\", BẠN ĐÃ SẴN SÀNG ?";
            DialogResult dlrs = MessageBox.Show(ms, "Thông báo", MessageBoxButtons.YesNoCancel);

            if (dlrs == DialogResult.Yes)
            {
                Form2 form2 = new Form2(richTextBox1.Text, this);
                form2.Show();
                Hide();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\gifBtBlueRobo.gif");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = null;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Image = Image.FromFile("C:\\C#3\\lab\\LabBaiLam\\PMDanhMayTuDong\\Project_PMDanhMayTuDong\\Resources\\gifBtRedRobo.gif");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = null;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            pictureBox1.Image = helpGif;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            pictureBox1.Image = helpImg;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}