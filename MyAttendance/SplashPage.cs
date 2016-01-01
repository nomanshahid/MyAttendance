using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAttendance
{
    public partial class SplashPage : Form
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        private void SplashPage_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Progress bar loads according to the timer specified
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            } 
        }
    }
}
