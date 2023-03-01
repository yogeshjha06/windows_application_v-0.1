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
    public partial class discharge : Form
    {
        public discharge()
        {
            InitializeComponent();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
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

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Print.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save discharge data to database discharge
            if (textBox1.Text != "")
            {
                try
                {

                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into discharge (date, iol, treat, mrd_no) values (@date, @iol, @treat, @mrd_no)", con);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker3.Value);
                    cmd.Parameters.AddWithValue("@iol", textBox9.Text);
                    cmd.Parameters.AddWithValue("@treat", textBox8.Text);
                    cmd.Parameters.AddWithValue("@mrd_no", textBox1.Text);


                    cmd.ExecuteNonQuery();

                    con.Close();
                    //confermation message

                    MessageBox.Show("Discharge Application Saved Success!");
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 60, 10);
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 60, 10);

            e.Graphics.DrawString("\t\t\t DISCHARGE SUMMARY", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, new Point(60, 120));
            e.Graphics.DrawString("MRD NUMBER :\t " + textBox1.Text + " \t\t NAME : " + textBox2.Text + "\t\t AGE : \t" + textBox3.Text + "\t\t SEX : \t" + textBox4.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawString("ADDRESS :\t " + textBox5.Text + " \t\t MOBILE : " + textBox6.Text + "\t\t DATE : \t" + dateTimePicker1.Value, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("DATE OF SURGERY : \t"+dateTimePicker2.Value+"\t\t\t DATE OF DISCHARGE: \t"+dateTimePicker3.Value, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 250));
            e.Graphics.DrawString("DIAGNOSIS : \t" +textBox7.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 290));
            e.Graphics.DrawString("TREATMENT GIVEN: \t" + textBox8.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 330));
            e.Graphics.DrawString("REMARK : \t" + textBox10.Text+"\t\t\tIOL POWER : "+textBox9.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 370));
            e.Graphics.DrawString("ADVICE : ", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Red, new Point(60, 410));
            e.Graphics.DrawString(label28.Text+"\n"+label29.Text+"\n"+label30.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 440));
            e.Graphics.DrawString(label31.Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 620));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\t______________________", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 900));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\tSurgeon's Signature", new Font("Segoe UI", 9, FontStyle.Italic), Brushes.Black, new Point(60, 920));
        }
    }
}
