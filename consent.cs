using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eye_opd
{
    public partial class consent : Form
    {
        public consent()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from user_data where mrd_no=@mrd_no", con);
            cmd.Parameters.AddWithValue("@mrd_no", textBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox2.Text = reader.GetValue(1).ToString();//name
                textBox3.Text = reader.GetValue(2).ToString();//age
                textBox4.Text = reader.GetValue(3).ToString();//sex
                textBox5.Text = reader.GetValue(4).ToString();//address
                textBox6.Text = reader.GetValue(5).ToString();//mobile
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (checkBox1.Checked)
                {
                    /*Panel panel = new Panel();
                    this.Controls.Add(panel);

                    Graphics graphics = panel.CreateGraphics();
                    Size size = this.ClientSize;
                    bitmap = new Bitmap(size.Width, size.Height, graphics);
                    graphics = Graphics.FromImage(bitmap);

                    Point point = PointToScreen(panel.Location);
                    graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);*/

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Accept Terms & Conditions Before Proceeding To Print.");
                }
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Print.");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 60, 10);

            e.Graphics.DrawString("\t\t\tCONSENT SUMMARY", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, new Point(60, 120));
            e.Graphics.DrawString("MRD NUMBER:\t " + textBox1.Text + " \t\t NAME: " + textBox2.Text + "\t\t AGE: \t" + textBox3.Text + "\t\t SEX: \t" + textBox4.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawString("ADDRESS:\t " + textBox5.Text + " \t\t MOBILE: " + textBox6.Text + "\t\t DATE: \t" + dateTimePicker1.Value, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("ऑपरेशन के लिए सहमति", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, new Point(60, 260));
            e.Graphics.DrawString(textBox7.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 320));
        }
    }
}
