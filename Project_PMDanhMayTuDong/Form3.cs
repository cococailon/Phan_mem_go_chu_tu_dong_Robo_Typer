using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PMDanhMayTuDong
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = "I. Tổng quan về phần mềm:\n" +
                          "1. Phần mềm RoboTyper là gì ?\n" +
                          "- Phần mềm RoboTyper là một phần mềm gõ văn bản tự động.\n" +
                          "2. Công dụng:\n" +
                          "- Dựa vào văn bản do người dùng cung cấp, phần mềm sẽ gõ lại từng ký tự của đoạn" +
                          " văn bản đó vào bất cứ nơi nào có thể nhập văn bản vào được, và y như " +
                          "được gõ bởi người thật.\n" +
                          "- Khác với việc copy paste " +
                          "đơn thuần, phần mềm RoboTyper cung cấp cho người dùng cách thức copy" +
                          " paste chuyên nghiệp hơn, dù có Undo(Quay lại) thì văn bản vẫn sẽ " +
                          "quay lại từng chữ một, chứ không mất hẳn cả văn bản khi Undo như" +
                          " cách copy paste thông thường.\n" +
                          "3. Mục đích:\n" +
                          "- Tránh việc văn bản bị phát hiện là copy paste khi Undo hay Ctrl + Z.\n" +
                          "4. Các Chế độ (chức năng):\n" +
                          "a, Gõ chữ tự động (BlueRobo): Gõ với tốc độ nhanh và không tạm dừng, chỉ có thể " +
                          "dừng lại hẳn.\n" +
                          "b, Giả gõ chữ (RedRobo): Giả như đang gõ từng ký tự của văn bản nhưng thực chất " +
                          "thì không.\n" +
                          "ĐỂ BIẾT CÁCH SỬ DỤNG CÁC CHỨC NĂNG TRÊN, VUI LÒNG TRUY CẬP VÀO ĐƯỜNG LINK" +
                          " SAU ĐỂ XEM VIDEO HƯỚNG DẪN SỬ DỤNG.\n" +
                          "link...\n" +
                          "5. Nhà phát triển: Dấu tên.\n\n" +
                          "II. Tổng quan về version 1.0.0:\n" +
                          "- Những điều mà version 1.0.0 có thể làm được được thì chúng tôi đã " +
                          "liệt kê hết ở trên rồi. Vậy nên, ở phần này chúng tôi sẽ chỉ đề cập đến những mặt" +
                          " hạn chế của nó:\n" +
                          "1. Hiện chế độ \"Giả gõ chữ\" vẫn chưa được hỗ trợ cho Microsoft Word, " +
                          "nó vẫn có thể hoạt động nhưng sẽ phát sinh ra nhiều lỗi.\n" +
                          "2. Khi sử dụng chế độ \"Giả gõ chữ\", nếu nhấn phím quá nhanh thì sẽ khiến" +
                          " ký tự mà chương trình gõ vào bị sai lệch.\n" +
                          "(Trong tương lai, chúng tôi sẽ cố gắng khắc phục những mặt hạn chế của nó" +
                          " ở những version tiếp theo. Cảm ơn vì đã tin dùng.)";

            richTextBox2.Text = text;
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "Bạn gặp lỗi trong quá trình sử dụng ? Vui lòng liên hệ với chúng tôi" +
                "qua FanPage Facebook \"RoboTyper\" hoặc đường link sau:";
            pictureBox1.Visible = true;
            linkLabel1.Visible = true; 
            pictureBox2.Visible = false;
            linkLabel2.Visible = false;
        }
    }
}
