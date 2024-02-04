using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locker
{
    public partial class Form1 : Form
    {
        Functions Con;
        public Form1()
        {
            InitializeComponent();
            Con = new Functions();
            for (int i = 0; i < 24; i++) {
                Functions.attemptsCounter[i] = 0;
            }
            

        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;

                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

//        SELECT*
//FROM INFORMATION_SCHEMA.COLUMNS


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(userName.Text == "" || password.Text == "")
            {
                MessageBox.Show("Missing Data !");

            }
            else
            {
                string Query = "Select * from Users";
                DataTable db = Con.GetData(Query);
                int found = 0;
                foreach (DataRow row in db.Rows)
                {
                    if (row["UserName"].ToString() == userName.Text && row["Password"].ToString() == password.Text)
                    {
                        if(row["Type"].ToString() == "1")
                        {
                            MessageBox.Show("Login as Admin");
                            found = 2;
                        }
                        else
                        {
                            found = 1;
                        }
                    }
                }
                string Result = "";
                if(found == 2)
                {
                    //Result = "Admin";
                    AdminDashboard dashboard = new AdminDashboard();
                    this.Hide();
                    userName.Text = "";
                    password.Text = "";
                    dashboard.ShowDialog();
                    this.Show();

                }
                else
                {
                    Result = "No user";
                    MessageBox.Show(Result);
                }
                
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userLoginButton_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard();
            this.Hide();
            dashboard.ShowDialog();
            this.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {


            HelpForm helpForm = new HelpForm();
            this.Hide();
            helpForm.ShowDialog();
            this.Show();

        }

   

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string input = "";
            if (e.CloseReason == CloseReason.UserClosing)
            {
                UserDashboard.ShowInputDialogBox(ref input, "Enter Pincode to logout !", "Confirm", 200, 200);
                if (input =="011222")
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("\nIncorrect Pincode", "Unuthorized Logout !");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void userName_Click(object sender, EventArgs e)
        {
            Functions.StartKey();
        }

        private void password_Click(object sender, EventArgs e)
        {
            Functions.StartKey();
        }
    }
}
