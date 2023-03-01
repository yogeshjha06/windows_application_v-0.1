using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace eye_opd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //home application
            loadform(new home());

            //active bg
            pictureBox2.Visible = true;
            //inactive bg
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;

            //lable active
            label1.BackColor = Color.Lavender;
            //lable inactive
            label3.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadform(new search());

            //active bg
            pictureBox3.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;
            pictureBox10.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;


            //lable active
            label2.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loadform(new application());

            //active bg
            pictureBox4.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox10.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;


            //lable active
            label3.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            loadform(new ot());
            //active bg
            pictureBox5.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;


            //lable active
            label4.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            loadform(new discharge());

            //active bg
            pictureBox6.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;


            //lable active
            label5.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loadform(new consent());
            //active bg
            pictureBox7.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;


            //lable active
            label6.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            loadform(new declaration());
            //active bg
            pictureBox8.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox10.Visible = false;


            //lable active
            label8.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
            label9.BackColor = Color.RoyalBlue;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            loadform(new help());
            //active bg
            pictureBox10.Visible = true;
            //inactive bg
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;


            //lable active
            label9.BackColor = Color.Lavender;
            //lable inactive
            label1.BackColor = Color.RoyalBlue;
            label2.BackColor = Color.RoyalBlue;
            label3.BackColor = Color.RoyalBlue;
            label5.BackColor = Color.RoyalBlue;
            label4.BackColor = Color.RoyalBlue;
            label6.BackColor = Color.RoyalBlue;
            label8.BackColor = Color.RoyalBlue;

        }
    }
}