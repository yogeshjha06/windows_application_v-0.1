using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace eye_opd
{
    public partial class declaration : Form
    {
        public declaration()
        {
            InitializeComponent();
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
                textBox4.Text = reader.GetValue(4).ToString();//address
                textBox5.Text = reader.GetValue(5).ToString();//mobile
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
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 60, 10);

            e.Graphics.DrawString("\t\t\t\t    " + label7.Text, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, new Point(60, 120));

            e.Graphics.DrawString(label3.Text + "\t " + textBox1.Text + " \t\t\t\t  " + label2.Text + " : " + dateTimePicker1.Value, new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, new Point(60, 200));

            e.Graphics.DrawString("मैं \t " + textBox2.Text + " \t पिता " + textBox3.Text + "\t पता \t" + textBox4.Text, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, new Point(60, 300));

            e.Graphics.DrawString("रहने वाला हूँ| मेरा मोतियाबिंद का ऑपरेशन श्री गणेश आई हॉस्पिटल में हुआ है। मेरे द्वारा दिया गया \n\nमोबईल नम्बर" + textBox5.Text + "जो मेरा खुद का है / परिवार में " + textBox6.Text + "है,/ मेरे गाँव \n\nमुखिया / सरपंच / सहीया / वार्ड सदस्य का है एवं ऑपरेशन के लिए मुझसे किसी भी प्रकार को कोई भी \n\nराशी नही ली गई है। ", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, new Point(60, 350));


            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\t______________________", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 920));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t            " + label6.Text, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, new Point(60, 940));
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Print.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
