using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using System.Net.Sockets;
using System.Threading;

namespace Locker
{
    public partial class UserDashboard : Form
    {
        Functions Con;
       
        string imagePath = "H:\\Mohammed course\\EE499\\project v6\\Resources\\icons8-lock-50 (1)Y.png";
     

        string imagePathLocked = "H:\\Mohammed course\\EE499\\project v6\\Resources\\icons8-lock-50.png";
       
        
        


        async void restore_def()
        {
            await Task.Delay(10000);
            for (int i = 0; i < 24; i++)
            {
                

                

                    string obj = "Locker" + (i + 1).ToString();
                    var buttons = this.Controls.Find(obj, true);
                    foreach (var button in buttons)
                    {
                        Image file = Image.FromFile(imagePathLocked);
                        button.BackgroundImage = file;

                    }
                

            }
        }


        public UserDashboard()
        {
            InitializeComponent();
            Con = new Functions();


            }

        private void locker1_Click(object sender, EventArgs e)
        {
            unlock(1 , this.locker1);
            
        }
        private void locker2_Click(object sender, EventArgs e)
        {
            unlock(2 , this.Locker2);
        }
        private void Locker3_Click(object sender, EventArgs e)
        {
            unlock(3 , this.Locker3);
        }
        private void Locker4_Click_1(object sender, EventArgs e)
        {
            unlock(4 , this.Locker4);
        }
        

        private void unlock(int locker , Button button)
        {
            string statusCode = "SELECT Status from Lockers where Id=" + locker.ToString();
            DataTable dt1 = new DataTable();
            dt1 = Con.GetData(statusCode);
            DataRow dr1 = dt1.Rows[0];

            string status = dr1["Status"].ToString();
            if (Functions.attemptsCounter[locker - 1] >= 3) MessageBox.Show("You have entered the wrong password 3 times, contact the admin to open the locker");
            else {
                if (status == "1")
                {
                    MessageBox.Show("Locker already Opened");
                }
                else
                {
                    string input = "";
                    ShowInputDialogBox(ref input, "Insert Locker Secret number !", "Confirm", 200, 200);

                    string check = "SELECT Secret FROM Lockers WHERE Id=" + locker.ToString();
                    DataTable dt = new DataTable();
                    dt = Con.GetData(check);
                    DataRow dr = dt.Rows[0];

                    string key = dr["Secret"].ToString();

                    if (key == input)
                    {
                        string update = "UPDATE Lockers SET Status=1 where Id=" + locker.ToString();

                        Con.SetData(update);
                        MessageBox.Show("Locker is Openned");

                        Image file = Image.FromFile(imagePath);

                        button.BackgroundImage = file;
                        // openlock( locker);
                        restore_def();




                    }
                    else
                    {
                        MessageBox.Show("Please Check the secret key that sended to your Email !");
                        ++Functions.attemptsCounter[locker - 1];
                        if (Functions.attemptsCounter[locker - 1] >= 3) MessageBox.Show("You have entered the wrong password 3 times, contact the admin to open the locker");

                    }
                }
            }
            
        }

        public static DialogResult ShowInputDialogBox(ref string input, string prompt, string title = "Title", int width = 300, int height = 200)
        {
            Functions.StartKey();
            //This function creates the custom input dialog box by individually creating the different window elements and adding them to the dialog box

            //Specify the size of the window using the parameters passed
            Size size = new Size(width, height);
            //Create a new form using a System.Windows Form
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            //Set the window title using the parameter passed
            inputBox.Text = title;

            //Create a new label to hold the prompt
            Label label = new Label();
            label.Text = prompt;
            label.Location = new Point(5, 20);
            label.Width = size.Width - 10;
            inputBox.Controls.Add(label);

            //Create a textbox to accept the user's input
            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, label.Location.Y + 40);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            //Create an OK Button 
            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, size.Height - 30);
            inputBox.Controls.Add(okButton);

            //Create a Cancel Button
            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, size.Height - 30);
            inputBox.Controls.Add(cancelButton);

            //Set the input box's buttons to the created OK and Cancel Buttons respectively so the window appropriately behaves with the button clicks
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            //Show the window dialog box 
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;

            //After input has been submitted, return the input value
            return result;
        }

        private void exit_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void Locker9_Click(object sender, EventArgs e)
        {
            unlock(9, this.Locker9);
        }

        private void Locker5_Click(object sender, EventArgs e)
        {
            unlock(5, this.Locker5);
        }

        private void Locker7_Click(object sender, EventArgs e)
        {
            unlock(7, this.Locker7);
        }

        private void Locker6_Click(object sender, EventArgs e)
        {
            unlock(6, this.Locker6);
        }

        private void Locker8_Click(object sender, EventArgs e)
        {
            unlock(8, this.Locker8);
        }

        private void Locker10_Click(object sender, EventArgs e)
        {
            unlock(10, this.Locker10);
        }

        private void Locker11_Click(object sender, EventArgs e)
        {
            unlock(11, this.Locker11);
        }

        private void Locker12_Click(object sender, EventArgs e)
        {
            unlock(12, this.Locker12);
        }

        private void Locker13_Click(object sender, EventArgs e)
        {
            unlock(13, this.Locker13);
        }

        private void Locker14_Click(object sender, EventArgs e)
        {
            unlock(14, this.Locker14);
        }

        private void Locker15_Click(object sender, EventArgs e)
        {
            unlock(15, this.Locker15);
        }

        private void Locker16_Click(object sender, EventArgs e)
        {
            unlock(16, this.Locker16);
        }

        private void Locker17_Click(object sender, EventArgs e)
        {
            unlock(17, this.Locker17);
        }

        private void Locker18_Click(object sender, EventArgs e)
        {
            unlock(18, this.Locker18);
        }

        private void Locker19_Click(object sender, EventArgs e)
        {
            unlock(19, this.Locker19);
        }

        private void Locker20_Click(object sender, EventArgs e)
        {
            unlock(20, this.Locker20);
        }

        private void Locker21_Click(object sender, EventArgs e)
        {
            unlock(21, this.Locker21);
        }

        private void Locker22_Click(object sender, EventArgs e)
        {
            unlock(22, this.Locker22);
        }

        private void Locker23_Click(object sender, EventArgs e)
        {
            unlock(23, this.Locker23);
        }

        private void Locker24_Click(object sender, EventArgs e)
        {
            unlock(24, this.Locker24);
        }




        private void openlock(int locker) {
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








    }
}
