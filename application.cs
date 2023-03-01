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
    public partial class application : Form
    {
        //PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        //PrintDocument pntdoc = new PrintDocument();
        public string eyelidL, eyelidR, conjL, conjR,corL, corR,iriL, iriR, lenseR, lenseL, odL, odR, mucL,musR, perL,perR;
        public application()
        {
            InitializeComponent();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

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
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox13.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;
            textBox17.Text = string.Empty;


            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
        }
        Bitmap bitmap;

        private void button1_Click(object sender, EventArgs e)
        {
            //Print the page
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

                //eyelid
                if (checkBox1.Checked)
                    eyelidR = "ok";
                else
                    eyelidR = "not ok";

                if (checkBox2.Checked)
                    eyelidL = "ok";
                else
                    eyelidL = "not ok";


                //conjunctiva
                if (checkBox4.Checked)
                    conjR = "ok";
                else
                    conjR = "not ok";

                if (checkBox3.Checked)
                    conjL = "ok";
                else
                    conjL = "not ok";

                //cornea
                if (checkBox6.Checked)
                    corR = "ok";
                else
                    corR = "not ok";

                if (checkBox5.Checked)
                    corL = "ok";
                else
                    corL = "not ok";

                //Iris
                if (checkBox8.Checked)
                    iriR = "ok";
                else
                    iriR = "not ok";

                if (checkBox7.Checked)
                    iriL = "ok";
                else
                    iriL = "not ok";

                //Lens
                if (checkBox10.Checked)
                    lenseR = "ok";
                else
                    lenseR = "not ok";

                if (checkBox9.Checked)
                    lenseL = "ok";
                else
                    lenseL = "not ok";

                //Optic disc
                if (checkBox16.Checked)
                    odR = "ok";
                else
                    odR = "not ok";

                if (checkBox15.Checked)
                    odL = "ok";
                else
                    odL = "not ok";

                //Macula
                if (checkBox14.Checked)
                    musR = "ok";
                else
                    musR = "not ok";

                if (checkBox13.Checked)
                    mucL = "ok";
                else
                    mucL = "not ok";


                //peripheral 
                if (checkBox12.Checked)
                    perR = "ok";
                else
                    perR = "not ok";

                if (checkBox11.Checked)
                    perL = "ok";
                else
                    perL = "not ok";


                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Enter MRD Number Before Proceeding To Print.");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 60, 10);
            //print page preview

            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 60, 10);

            e.Graphics.DrawString("\t\t\t     APPLICATION FORM", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, new Point(60, 120));
            e.Graphics.DrawString("MRD NUMBER :\t " + textBox1.Text + " \t\t NAME : " + textBox2.Text + "\t\t AGE : \t" + textBox3.Text + "\t\t SEX : \t" + textBox4.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawString("ADDRESS :\t " + textBox5.Text + " \t\t MOBILE : " + textBox6.Text + "\t\t DATE : \t" + dateTimePicker1.Value, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("Temp: "+textBox7.Text+"\t P.R. : "+textBox8.Text+"\t\tB.P. : \t"+textBox9.Text+"\t\t VN(unaided) : \t"+textBox13.Text+"\tBCVA (with glass) :  "+textBox14.Text , new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 250));
            e.Graphics.DrawString("1. Complains : \t" + textBox10.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 310));
            e.Graphics.DrawString("2. Past History : \t" + textBox11.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 370));
            e.Graphics.DrawString("3. Medical History : \t" + textBox12.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 440));
            e.Graphics.DrawString("4. Allergy History : ", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, new Point(60, 480));
            
            e.Graphics.DrawString("Slit Lamp Examination\t\tRight Eye\t\tLeft Eye", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 520));
            e.Graphics.DrawString("Eyelid \t\t\t\t"+eyelidR+"\t\t\t"+eyelidL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 540));
            e.Graphics.DrawString("Conjunctiva/Sclera\t\t" + conjR + "\t\t\t" + conjL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 560));
            e.Graphics.DrawString("Cornea \t\t\t\t" + corR + "\t\t\t" + corL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 580));
            e.Graphics.DrawString("Iris/Pupil \t\t\t" + iriR + "\t\t\t" + iriL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 600));
            e.Graphics.DrawString("Lens \t\t\t\t" + lenseR + "\t\t\t" + lenseL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 620));
            
            e.Graphics.DrawString("Fundus Examination\t\tRight Eye\t\tLeft Eye", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 660));
            e.Graphics.DrawString("Optic Disc\t\t\t" + odR + "\t\t\t" + odL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 680));
            e.Graphics.DrawString("Macula \t\t\t\t" + musR + "\t\t\t" + mucL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 700));
            e.Graphics.DrawString("Peripheral Retina \t\t\t" + perR + "\t\t\t" + perL, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 720));

            e.Graphics.DrawString("5. Diagnosis : \t" + textBox16.Text+"\n\n6. Treatment : "+textBox17.Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 760));
            e.Graphics.DrawString("7. Investigations\n1. RBS : "+textBox18.Text+"\n2.SYRINGING : "+textBox19.Text+"\n3. I.O.P. (mm Hg) : "+textBox20.Text, new Font("Segoe UI", 9, FontStyle.Regular), Brushes.Black, new Point(60, 830));
            e.Graphics.DrawString("CALCULATED IOL POWER : " + textBox15.Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 950));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\t______________________", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, new Point(60, 970));
            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t\t\tSurgeon's Signature", new Font("Segoe UI", 9, FontStyle.Italic), Brushes.Black, new Point(60, 1000));
            //
        }

        private void label62_Click(object sender, EventArgs e)
        {

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

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save to application panel
            if (textBox1.Text != "")
            {

                try
                {

                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into application (mrd_no, dig, trt, date) values (@mrd_no, @dig, @trt, @date)", con);
                    cmd.Parameters.AddWithValue("@mrd_no", textBox1.Text);
                    cmd.Parameters.AddWithValue("@dig", textBox16.Text);
                    cmd.Parameters.AddWithValue("@trt", textBox17.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);


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
