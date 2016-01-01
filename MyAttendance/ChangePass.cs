using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyAttendance
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //CANCEL button
        {
            this.Close();
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //OK button
        {
            //Establish conncetion with database to validate current password info
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\DATABASE\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From LOGIN where PASSWORD='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //If the current password is incorrect, display error, else change password
            if (dt.Rows[0][0].ToString() != "1")
            {
                MessageBox.Show("Incorrect password! Please enter your current password again.", "Error!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else if (textBox2.Text == textBox3.Text)
            {
                //Changes password info in database              
                con.Open();
                SqlCommand smd = new SqlCommand("UPDATE LOGIN SET PASSWORD ='" + textBox3.Text + "' WHERE (PASSWORD ='" + textBox1.Text + "')", con);
                smd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password changed successfully! Please use your new password at next sign-in.", "Change Password");
                this.Close();
            }     
            else
            {
                //If new passwords do not match, display error
                MessageBox.Show("Passwords do not match. Please try again.", "Error!");
                textBox2.Clear();
                textBox3.Clear();
            }
        }
    }
}
