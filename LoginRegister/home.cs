using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegister
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.time.Text = dateTime.ToString();
        }

        private void home_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LoginRegister loginRegister = new LoginRegister();
            loginRegister.Show();
            this.Hide();
        }

        private void btnHomeLecturer_Click(object sender, EventArgs e)
        {
            LecturerManagement lecturerManagement = new LecturerManagement();
            lecturerManagement.Show();
            this.Hide();
        }
    }
}
