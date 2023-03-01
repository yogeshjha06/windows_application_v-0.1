using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eye_opd
{
    public partial class ot : Form
    {

        public string injection;
        public ot()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox4.Text = reader.GetValue(2).ToString();//age
                textBox5.Text = reader.GetValue(3).ToString();//sex
                textBox3.Text = reader.GetValue(4).ToString();//address
                textBox6.Text = reader.GetValue(5).ToString();//mobile
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;

            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                /*Panel panel = new Panel();
                this.Controls.Add(panel);

                Graphics graphics = panel.CreateGraphics();
                Size size = this.ClientSize;
                bitmap = new Bitmap(size.Width, size.Height, graphics);
                graphics = Graphics.FromImage(bitmap);

                Point point = PointToScreen(panel.Location);
                graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);*/
                if (checkBox1.Checked)
                    injection = "Penbulbar Block";
                if (checkBox2.Checked)
                    injection = "Topical";

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Print.");
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 60, 10);
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 60, 10);

            e.Graphics.DrawString("\t\t\t OPERATIVE NOTE /O.T. RECORD", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, new Point(60, 120));
            e.Graphics.DrawString("MRD NUMBER :\t " + textBox1.Text + " \t\t NAME : " + textBox2.Text + "\t\t AGE : \t" + textBox3.Text + "\t\t SEX : \t" + textBox4.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawString("ADDRESS :\t " + textBox5.Text + " \t\t MOBILE : " + textBox6.Text + "\t\t DATE : \t" + dateTimePicker1.Value, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("\t\t\t\t Detailed O.T. Notes", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Red, new Point(60, 250));
            e.Graphics.DrawString("1. Details of Operation : \t" + richTextBox1.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 290));
            e.Graphics.DrawString("2. Complications : \t" + richTextBox2.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 370));
            e.Graphics.DrawString("3. O.T. Time In : \t" + textBox7.Text + "\t\t\t  4. O.T. Time Out : " + textBox8.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 420));
            e.Graphics.DrawString("5. Type of Anaesthesia : " + injection, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 460));
            e.Graphics.DrawString("6. Post Operative Advice Pad and Patch The Eye", new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 500));
            e.Graphics.DrawString("7. Doctor Name :  Dr. AMIT KUMAR JAYSWAL", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 530));
            e.Graphics.DrawString("IOL STICKER", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 800));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\t______________________", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 920));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\tSurgeon's Signature", new Font("Segoe UI", 9, FontStyle.Italic), Brushes.Black, new Point(60, 940));
            //
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save to ot record
            if (textBox1.Text != "")
            {
                try
                {

                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into ot (time_in, time_out, date, dop, comp, mrd_no) values (@time_in, @time_out, @date, @dop, @comp, @mrd_no)", con);
                    cmd.Parameters.AddWithValue("@time_in", textBox7.Text);
                    cmd.Parameters.AddWithValue("@time_out", textBox8.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@dop", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@comp", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@mrd_no", textBox1.Text);


                    cmd.ExecuteNonQuery();

                    con.Close();
                    //confermation message

                    MessageBox.Show("OT Application Saved Success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Data Request Denied! Please check the text filled and try again." + ex);
                }
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Save.");
            }
        }
    }
}
