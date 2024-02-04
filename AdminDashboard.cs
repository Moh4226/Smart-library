using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Locker
{
    
    public partial class AdminDashboard : Form
    {
        Functions Con;
        string MAIN_USER_EMAIL = "Slslroro26@gmail.com";
        string MAIN_USER_PASSWORD = "tuwsrsgjrqdvxrbw";
        string imagePathfree = "H:\\Mohammed course\\EE499\\project v6\\Resources\\redLock1.png";
        string imagePathLocked = "H:\\Mohammed course\\EE499\\project v6\\Resources\\icons8-lock-50.png";



        


        public AdminDashboard()
        {
            InitializeComponent();
            Con = new Functions();
            check_Credentials();
        }
        void check_Credentials()
        {
            string check = "SELECT Status from Lockers";
            DataTable dt = new DataTable();
            dt = Con.GetData(check);

            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.Rows[i];

                string status = dr["Status"].ToString();

                if (status == "0")
                {
                    string obj = "Locker" + (i + 1).ToString();
                    var buttons = this.Controls.Find(obj, true);
                    foreach (var button in buttons)
                    {
                        Image file = Image.FromFile(imagePathfree);
                        button.BackgroundImage = file;
                        button.BackColor = Color.White;
                        //   button.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
                else
                {
                    string obj = "Locker" + (i + 1).ToString();
                    var buttons = this.Controls.Find(obj, true);
                    foreach (var button in buttons)
                    {
                        Image file = Image.FromFile(imagePathLocked);
                        button.BackgroundImage = file;
                        button.BackColor = Color.White;

                        //   button.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
            }
            for(int i = 0; i < 24; i++)
            {
                if (Functions.attemptsCounter[i] >= 3)
                {
                    string obj = "Locker" + (i + 1).ToString();
                    var buttons = this.Controls.Find(obj, true);
                   foreach (var button in buttons)
                    {
                        button.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    string obj = "Locker" + (i + 1).ToString();
                    var buttons = this.Controls.Find(obj, true);
                    foreach (var button in buttons)
                    {
                        button.BackColor = Color.White;
                    }
                }
            }
        }

        private void Locker1_Click(object sender, EventArgs e)
        {
            sendNumber(1);
        }
        private void Locker2_Click(object sender, EventArgs e)
        {
            sendNumber(2);
        }
        private void Locker3_Click(object sender, EventArgs e)
        {
            sendNumber(3);
        }
        private void Locker4_Click(object sender, EventArgs e)
        {
            sendNumber(4);
        }
        private void Locker5_Click(object sender, EventArgs e)
        {
            sendNumber(5);
        }
        private void Locker6_Click(object sender, EventArgs e)
        {
            sendNumber(6);
        }
        private void Locker7_Click(object sender, EventArgs e)
        {
            sendNumber(7);
        }
        private void Locker8_Click(object sender, EventArgs e)
        {
            sendNumber(8);
        }
        private void Locker9_Click(object sender, EventArgs e)
        {
            sendNumber(9);
        }
        private void Locker10_Click(object sender, EventArgs e)
        {
            sendNumber(10);
        }
        private void Locker11_Click(object sender, EventArgs e)
        {
            sendNumber(11);
        }
        private void Locker12_Click(object sender, EventArgs e)
        {
            sendNumber(12);
        }
        private void Locker13_Click(object sender, EventArgs e)
        {
            sendNumber(13);
        }
        private void Locker14_Click(object sender, EventArgs e)
        {
            sendNumber(14);
        }
        private void Locker15_Click(object sender, EventArgs e)
        {
            sendNumber(15);
        }
        private void Locker16_Click(object sender, EventArgs e)
        {
            sendNumber(16);
        }
        private void Locker17_Click(object sender, EventArgs e)
        {
            sendNumber(17);
        }
        private void Locker18_Click(object sender, EventArgs e)
        {
            sendNumber(18);
        }
        private void Locker19_Click(object sender, EventArgs e)
        {
            sendNumber(19);
        }
        private void Locker20_Click(object sender, EventArgs e)
        {
            sendNumber(20);
        }
        private void Locker21_Click(object sender, EventArgs e)
        {
            sendNumber(21);
        }
        private void Locker22_Click(object sender, EventArgs e)
        {
            sendNumber(22);
        }
        private void Locker23_Click(object sender, EventArgs e)
        {
            sendNumber(23);
        }
        private void Locker24_Click(object sender, EventArgs e)
        {
            sendNumber(24);
        }
        async public void sendNumber(int locker)
        {
            if (emailText.Text == "")
            {
                MessageBox.Show("Please enter client email");
            }
            else
            {

            
                string check = "SELECT Status , Lock_Date from Lockers where Id=" + locker.ToString();
                DataTable dt = new DataTable();
                dt = Con.GetData(check);
                DataRow dr = dt.Rows[0];

                string status = dr["Status"].ToString();

                if (status == "0")
                {

                    MessageBox.Show("User did not open the locker!\nIt was locked at "+dr["Lock_Date"].ToString());
                }
                else
                {

                    System.Diagnostics.Debug.WriteLine(locker);
                    Random rand = new Random();
                    int number = rand.Next(1000, 9999);
                    System.Diagnostics.Debug.WriteLine(number);


                    // this.Hide();
                    // await Task.Factory.StartNew(() =>
                    // {
                    //     System.Threading.Thread.Sleep(30000);
                        
                    // });
                    // this.Show();
                    
                    string userEmail = emailText.Text;
                    string adminemail = "a1-25@hotmail.com";
                
                        string subject = "Locker " + locker.ToString();
                        string msg = "Hello Dear , You can Unlock the <b>locker " + locker.ToString() + "</b> with the key <b>" + number.ToString() + "</b>";
       
                        string fromEmail = MAIN_USER_EMAIL;
                        string frompass = MAIN_USER_PASSWORD;

                        MessageBox.Show("Sending Message ...");
                        string update = "UPDATE Lockers SET Secret=" + number.ToString() + ", Status=0 ,Lock_Date = '" + DateTime.Now.ToShortDateString() + "' WHERE Id=" + locker.ToString();
                        Con.SetData(update);

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromEmail);

                        message.Subject = subject;
                        Console.WriteLine(userEmail);
                        Console.WriteLine(adminemail);
                        message.To.Add(new MailAddress(userEmail));
                        message.To.Add(new MailAddress(adminemail));
                        message.Body = msg;
                        message.IsBodyHtml = true;

                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(fromEmail, frompass),
                            EnableSsl = true,
                        };

                        smtpClient.Send(message);
                    /////////
                    ///


                    update = "update Lockers set Locker = " + number.ToString() + " where Id = " + locker.ToString();
                        Con.SetData(update);

                        MessageBox.Show("Message sended");
                    check_Credentials();

                   // openlock(locker);



                }

            }

        }


        private void openlock(int locker)
        {
            SerialPort port = new SerialPort();
            port.PortName = "COM5";
            port.Parity = Parity.None;
            port.BaudRate = 115200;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            // port.Handshake = Handshake.RequestToSend;
            // port.ReceivedBytesThreshold = 8;
            if (port.IsOpen)

            {
                port.Close();
                port.Dispose();
            }


            switch (locker)
            {
                case 1:
                    byte[] bytesToSend1 = new byte[5] { 0x0D, 0xAA, 0x00, 0x01, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend1, 0, bytesToSend1.Length);
                    break;
                case 2:
                    byte[] bytesToSend2 = new byte[5] { 0x0D, 0xAA, 0x00, 0x02, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend2, 0, bytesToSend2.Length);
                    break;
                case 3:
                    byte[] bytesToSend3 = new byte[5] { 0x0D, 0xAA, 0x00, 0x03, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend3, 0, bytesToSend3.Length);
                    break;
                case 4:
                    byte[] bytesToSend4 = new byte[5] { 0x0D, 0xAA, 0x00, 0x04, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend4, 0, bytesToSend4.Length);
                    break;
                case 5:
                    byte[] bytesToSend5 = new byte[5] { 0x0D, 0xAA, 0x00, 0x05, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend5, 0, bytesToSend5.Length);
                    break;
                case 6:
                    byte[] bytesToSend6 = new byte[5] { 0x0D, 0xAA, 0x00, 0x06, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend6, 0, bytesToSend6.Length);
                    break;
                case 7:
                    byte[] bytesToSend7 = new byte[5] { 0x0D, 0xAA, 0x00, 0x07, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend7, 0, bytesToSend7.Length);
                    break;
                case 8:
                    byte[] bytesToSend8 = new byte[5] { 0x0D, 0xAA, 0x00, 0x08, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend8, 0, bytesToSend8.Length);
                    break;
                case 9:
                    byte[] bytesToSend9 = new byte[5] { 0x0D, 0xAA, 0x00, 0x09, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend9, 0, bytesToSend9.Length);
                    break;
                case 10:
                    byte[] bytesToSend10 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0A, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend10, 0, bytesToSend10.Length);
                    break;
                case 11:
                    byte[] bytesToSend11 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0B, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend11, 0, bytesToSend11.Length);
                    break;
                case 12:
                    byte[] bytesToSend12 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0C, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend12, 0, bytesToSend12.Length);
                    break;
                case 13:
                    byte[] bytesToSend13 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0D, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend13, 0, bytesToSend13.Length);
                    break;
                case 14:
                    byte[] bytesToSend14 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0E, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend14, 0, bytesToSend14.Length);
                    break;
                case 15:
                    byte[] bytesToSend15 = new byte[5] { 0x0D, 0xAA, 0x00, 0x0F, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend15, 0, bytesToSend15.Length);
                    break;
                case 16:
                    byte[] bytesToSend16 = new byte[5] { 0x0D, 0xAA, 0x00, 0x10, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend16, 0, bytesToSend16.Length);
                    break;
                case 17:
                    byte[] bytesToSend17 = new byte[5] { 0x0D, 0xAA, 0x00, 0x11, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend17, 0, bytesToSend17.Length);
                    break;
                case 18:
                    byte[] bytesToSend18 = new byte[5] { 0x0D, 0xAA, 0x00, 0x12, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend18, 0, bytesToSend18.Length);
                    break;
                case 19:
                    byte[] bytesToSend19 = new byte[5] { 0x0D, 0xAA, 0x00, 0x13, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend19, 0, bytesToSend19.Length);
                    break;
                case 20:
                    byte[] bytesToSend20 = new byte[5] { 0x0D, 0xAA, 0x00, 0x14, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend20, 0, bytesToSend20.Length);
                    break;
                case 21:
                    byte[] bytesToSend21 = new byte[5] { 0x0D, 0xAA, 0x00, 0x15, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend21, 0, bytesToSend21.Length);
                    break;
                case 22:
                    byte[] bytesToSend22 = new byte[5] { 0x0D, 0xAA, 0x00, 0x16, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend22, 0, bytesToSend22.Length);
                    break;
                case 23:
                    byte[] bytesToSend23 = new byte[5] { 0x0D, 0xAA, 0x00, 0x17, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend23, 0, bytesToSend23.Length);
                    break;
                case 24:
                    byte[] bytesToSend24 = new byte[5] { 0x0D, 0xAA, 0x00, 0x18, 0xF2 };
                    port.Open();
                    port.Write(bytesToSend24, 0, bytesToSend24.Length);
                    break;
                default:
                    throw new Exception();

            }



            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            port.Close();
            port.Dispose();




        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Console.WriteLine("In data receive");
            SerialPort port = (SerialPort)sender;

            int bytes = port.BytesToRead;
            byte[] buffer = new byte[bytes];

            if (port.BytesToRead > 1)
            {

                port.Read(buffer, 0, bytes);
            }

            foreach (byte item in buffer)
            {
                Console.WriteLine(item);
                Console.ReadKey();
            }

            //Console.ReadKey();
        }

        private void exit_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void buttonShowPin_Click(object sender, EventArgs e)
        {
            int locker = 0;
            try
            {
                locker = int.Parse(lockerName.Text);
                if (locker <= 0 || locker > 24)
                {
                    MessageBox.Show("Invalid Locker Number !");
                    return;
                }
                else
                {
                    string check = "Select Secret,Status from Lockers WHERE Id=" + locker.ToString();
                    DataTable dt = new DataTable();
                    dt = Con.GetData(check);
                    DataRow dr = dt.Rows[0];
                    string status = dr["Status"].ToString();

                    if (status == "1")
                    {
                        MessageBox.Show("Locker has no pin code !");
                    }
                    else
                    {
                        string code = dr["Secret"].ToString();
                        MessageBox.Show("Pin code for Locker (" + locker.ToString() + ") is " + code);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Locker Number !");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int locker = 0;
            try
            {
                locker = int.Parse(textBox1.Text);
                if (locker <= 0 || locker > 24)
                {
                    MessageBox.Show("Invalid Locker Number !");
                    return;
                }
                else if(Functions.attemptsCounter[locker-1]<3)
                {
                    MessageBox.Show("Locker isn't blocked!");

                }
                else if(Functions.attemptsCounter[locker - 1] >= 3)
                {
                    if (emailText.Text.Trim() != "")
                    {
                        Random rand = new Random();
                        int number = rand.Next(1000, 9999);
                        System.Diagnostics.Debug.WriteLine(number);


                        // this.Hide();
                        // await Task.Factory.StartNew(() =>
                        // {
                        //     System.Threading.Thread.Sleep(30000);

                        // });
                        // this.Show();

                        string userEmail = emailText.Text;
                        string adminemail = "a1-25@hotmail.com";

                        string subject = "Locker " + locker.ToString();
                        string msg = "Hello Dear , Your Recovery Key for <b>locker " + locker.ToString() + "</b> is <b>" + number.ToString() + "</b>";

                        string fromEmail = MAIN_USER_EMAIL;
                        string frompass = MAIN_USER_PASSWORD;

                        MessageBox.Show("Sending Message ...");
                        string update = "UPDATE Lockers SET Secret=" + number.ToString() + ", Status=0,Lock_Date = "+ DateTime.Now.ToShortDateString()+" WHERE Id=" + locker.ToString();
                        Con.SetData(update);


                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromEmail);

                        message.Subject = subject;
                        Console.WriteLine(userEmail);
                        Console.WriteLine(adminemail);
                        message.To.Add(new MailAddress(userEmail));
                        message.To.Add(new MailAddress(adminemail));
                        message.Body = msg;
                        message.IsBodyHtml = true;

                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(fromEmail, frompass),
                            EnableSsl = true,
                        };

                        smtpClient.Send(message);
                        /////////
                        ///


                        update = "update Lockers set Locker = " + number.ToString() + " where Id = " + locker.ToString();
                        Con.SetData(update);
                        Functions.attemptsCounter[locker - 1] = 0;
                        MessageBox.Show("Message sended");
                        check_Credentials();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Email send recovery pin !");

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Locker Number !");

            }
        }

        private void emailText_Click(object sender, EventArgs e)
        {
            Functions.StartKey();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Functions.StartKey();
        }

        private void lockerName_Click(object sender, EventArgs e)
        {
            Functions.StartKey();
        }
    }
}
