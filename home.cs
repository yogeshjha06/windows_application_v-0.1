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


namespace eye_opd
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into user_data values (@name, @age, @sex, @address, @mobile, @mrd_no, @uid)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@sex", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox5.Text);
                cmd.Parameters.AddWithValue("@mrd_no", textBox6.Text);
                cmd.Parameters.AddWithValue("@uid", textBox7.Text);


                cmd.ExecuteNonQuery();

                con.Close();
                //text box was cleared after data insered in table 
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                //confermation message

                MessageBox.Show("Data Inserted Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Data Request Denied! Please Enter Name, MRD Number and Adhar Card Number and try again.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
