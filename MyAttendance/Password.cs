using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //Additional
using System.Data.SqlClient; //Additional

namespace MyAttendance
{
    public partial class Password : Form
    {
        public Password()
        {
            //Splash page initialization
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void SplashStart() //Method to run the splash page
        {
            Application.Run(new SplashPage());
        }

        private void button1_Click(object sender, EventArgs e) //LOGIN button
        {
            //Establish a connection with the database and validate password
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\DATABASE\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From LOGIN where PASSWORD='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //If the password is correct, enter next form, else display error message
            if(dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 ss = new Form1();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password! Please try again.", "Error");
                textBox1.Clear();
            }          
        }

        private void button2_Click(object sender, EventArgs e) //EXIT button
        {
            Application.Exit();
        }

        private void label1_Click_1(object sender, EventArgs e) //Forgot password 
        {
            MessageBox.Show("Please contact your MyAttendance® administrator if\nyou have forgotten your password.", "Forgot Password");
        }

        private void Password_Load(object sender, EventArgs e)
        {

        }
    }
}
