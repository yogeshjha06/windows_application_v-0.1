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

namespace eye_opd
{
    public partial class search : Form
    {
        string id;
        public search()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //adhar search and fetch data
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from user_data where uid=@uid", con);
            cmd.Parameters.AddWithValue("@uid", textBox10.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetValue(1).ToString();
                textBox2.Text = reader.GetValue(2).ToString();
                textBox3.Text = reader.GetValue(3).ToString();
                textBox4.Text = reader.GetValue(4).ToString();
                textBox5.Text = reader.GetValue(5).ToString();
                textBox6.Text = reader.GetValue(6).ToString();
                textBox7.Text = reader.GetValue(7).ToString();

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update table user_data
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();
            string query = "update user_data set name='" + textBox1.Text + "' , sex='" + textBox3.Text + "', address='" + textBox4.Text + "', mobile='" + textBox5.Text + "', mrd_no='" + textBox6.Text + "' where uid= " + textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("User Data Is Been Updated.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MRD_NO search and fetch data
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from user_data where mrd_no=@mrd_no", con);
            cmd.Parameters.AddWithValue("@mrd_no", textBox8.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetValue(1).ToString();
                textBox2.Text = reader.GetValue(2).ToString();
                textBox3.Text = reader.GetValue(3).ToString();
                textBox4.Text = reader.GetValue(4).ToString();
                textBox5.Text = reader.GetValue(5).ToString();
                textBox6.Text = reader.GetValue(6).ToString();
                textBox7.Text = reader.GetValue(7).ToString();

            }
            reader.Close();

            //data application data table

            SqlCommand cmd1 = new SqlCommand("select * from application where mrd_no=@mrd_no", con);
            cmd1.Parameters.AddWithValue("@mrd_no", textBox8.Text);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                textBox16.Text = reader1.GetValue(2).ToString();
                textBox13.Text = reader1.GetValue(3).ToString();
                textBox15.Text = reader1.GetValue(4).ToString();
            }
            reader1.Close();

            //data OT data table


            SqlCommand cmd3 = new SqlCommand("select * from ot where mrd_no=@mrd_no", con);
            cmd3.Parameters.AddWithValue("@mrd_no", textBox8.Text);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                textBox9.Text = reader3.GetValue(1).ToString();
                textBox12.Text = reader3.GetValue(2).ToString();
                textBox11.Text = reader3.GetValue(4).ToString();
                textBox17.Text = reader3.GetValue(3).ToString();
                textBox14.Text = reader3.GetValue(5).ToString();
            }
            reader3.Close();



            //data discharge data table


            SqlCommand cmd4 = new SqlCommand("select * from discharge where mrd_no=@mrd_no", con);
            cmd4.Parameters.AddWithValue("@mrd_no", textBox8.Text);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                textBox21.Text = reader4.GetValue(3).ToString();
                textBox22.Text = reader4.GetValue(2).ToString();
                textBox18.Text = reader4.GetValue(1).ToString();
            }
            reader4.Close();


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //update table application
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();
            string query = "update application set dig='" + textBox16.Text + "', trt='" + textBox13.Text + "', date='" + textBox15.Text + "' where mrd_no= '" + textBox6.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("User Application Data Is Been Updated.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //update table OT
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();
            string query = "update ot set time_in='" + textBox9.Text + "', time_out='" + textBox12.Text + "', date='" + textBox17.Text + "', dop='" + textBox11.Text + "', comp='" + textBox14.Text + "' where mrd_no= '" + textBox6.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("User OT Data Is Been Updated.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //update table Discharge
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-MICCQ4FT\\SQLEXPRESS;Initial Catalog=db_eye;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            con.Open();
            string query = "update discharge set date='" + textBox18.Text + "', iol='" + textBox22.Text + "', treat='" + textBox21.Text + "' where mrd_no= '" + textBox6.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("User Discharge Data Is Been Updated.");
        }
    }
}
