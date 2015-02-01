using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace stm32f4_713
{

    public partial class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent(); //sets up the program

             if (!mySerialPort.IsOpen) //Checks to see if the com port is open
             {
                 mySerialPort.Open();
                 tbRX.Text = "COM PORT is open.\r\n";

                 Thread.Sleep(100);
                 SelfTest();

             }
             else
             {
                 tbRX.Text = "The COM PORT is busy.\n\r"; // com port is not ready
                 tbRX.Text = "Self test failed.\n\r"; // Self test did not work.
             }
         }

        private void SelfTest()
        {
                mySerialPort.WriteLine("22214"); //writes out code to test board.
        }

        private string rxString;
        private void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rxString = mySerialPort.ReadExisting();
            this.Invoke(new EventHandler(displayText));
        }

        private void displayText(object o, EventArgs e)
        {
           
           tbRX.AppendText(rxString); // appends new text to exsiting text
            
        }

     
        private void bClear_Click(object sender, EventArgs e)
        {
              tbRX.Clear(); //clears the display
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mySerialPort.Close(); //Closes the com port
        }

  
        //Alarm button
        private void bAlarm_Click(object sender, EventArgs e)
        {

            if (mySerialPort.IsOpen)
            {  
    
                mySerialPort.WriteLine("22203");
                bAlarm.ForeColor = System.Drawing.Color.White;
                bAlarm.BackColor = System.Drawing.Color.Black;
                 
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOff.BackColor = System.Drawing.Color.Gray;
                bRound.ForeColor = System.Drawing.Color.Black;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bBlink.ForeColor = System.Drawing.Color.Black;
                bBlink.BackColor = System.Drawing.Color.Gray;

                bGreenOff.BackColor = System.Drawing.Color.Green;
                bGreenOn.BackColor = System.Drawing.Color.Gray;
                bAmberOff.BackColor = System.Drawing.Color.Orange;
                bAmberOn.BackColor = System.Drawing.Color.Gray;
                bRedOff.BackColor = System.Drawing.Color.Red;
                bRedOn.BackColor = System.Drawing.Color.Gray;
                bBlueOff.BackColor = System.Drawing.Color.Blue;
                bBlueOn.BackColor = System.Drawing.Color.Gray;

                bRound.Enabled = false; //Round
                bBlink.Enabled = false; //Blink
                bAllOff.Enabled = false; //All off
                bAllOn.Enabled = false; //All on
                bBlueOn.Enabled = false; // Blue LED
                bAmberOn.Enabled = false; // Amber LED
                bGreenOn.Enabled = false; // Green LED
                bRedOn.Enabled = false; // Red LED
    
                //Thread.Sleep(6475);
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bAlarm.BackColor = System.Drawing.Color.Gray;

                bRound.Enabled = true; //Round
                bBlink.Enabled = true; //Blink
                bAllOff.Enabled = true; //All off
                bAllOn.Enabled = true; //All on
                bBlueOn.Enabled = true; // Blue LED
                bAmberOn.Enabled = true; // Amber LED
                bGreenOn.Enabled = true; // Green LED
                bRedOn.Enabled = true; // Red LED
 
            }
        }

        
        //Round button
        private void bRound_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {

                mySerialPort.WriteLine("22202");   // Sends PDRND to stm32f4 to run blinky() 

                bRound.ForeColor = System.Drawing.Color.White;
                bRound.BackColor = System.Drawing.Color.Black;

                bAlarm.Enabled = false; //Alarm
                bBlink.Enabled = false; //Blink
                bAllOff.Enabled = false; //All off
                bAllOn.Enabled = false; //All on
                bBlueOn.Enabled = false; // Blue LED
                bAmberOn.Enabled = false; // Amber LED
                bGreenOn.Enabled = false; // Green LED
                bRedOn.Enabled = false; // Red LED

                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOff.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.ForeColor = System.Drawing.Color.Black;
                bBlink.BackColor = System.Drawing.Color.Gray;

                bGreenOff.BackColor = System.Drawing.Color.Green;
                bGreenOn.BackColor = System.Drawing.Color.Gray;
                bAmberOff.BackColor = System.Drawing.Color.Orange;
                bAmberOn.BackColor = System.Drawing.Color.Gray;
                bRedOff.BackColor = System.Drawing.Color.Red;
                bRedOn.BackColor = System.Drawing.Color.Gray;
                bBlueOff.BackColor = System.Drawing.Color.Blue;
                bBlueOn.BackColor = System.Drawing.Color.Gray;
                
                //Thread.Sleep(21500);
                bRound.ForeColor = System.Drawing.Color.Black;
                bRound.BackColor = System.Drawing.Color.Gray;

                bAlarm.Enabled = true; //Alarm
                bBlink.Enabled = true; //Blink
                bAllOff.Enabled = true; //All off
                bAllOn.Enabled = true; //All on
                bBlueOn.Enabled = true; // Blue LED
                bAmberOn.Enabled = true; // Amber LED
                bGreenOn.Enabled = true; // Green LED
                bRedOn.Enabled = true; // Red LED
            }
        }

        //Blink button
        private void bBlink_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {

                mySerialPort.WriteLine("22201");// Sends PDBLK to stm32f4 to run round()

                bBlink.ForeColor = System.Drawing.Color.White;
                bBlink.BackColor = System.Drawing.Color.Black;

                bRound.Enabled = false; //Round
                bAlarm.Enabled = false; //Alarm
                bAllOff.Enabled = false; //All off
                bAllOn.Enabled = false; //All on
                bBlueOn.Enabled = false; // Blue LED
                bAmberOn.Enabled = false; // Amber LED
                bGreenOn.Enabled = false; // Green LED
                bRedOn.Enabled = false; // Red LED

                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOff.BackColor = System.Drawing.Color.Gray;
                bRound.ForeColor = System.Drawing.Color.Black;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bAllOn.BackColor = System.Drawing.Color.Gray;

                bGreenOff.BackColor = System.Drawing.Color.Green;
                bGreenOn.BackColor = System.Drawing.Color.Gray;
                bAmberOff.BackColor = System.Drawing.Color.Orange;
                bAmberOn.BackColor = System.Drawing.Color.Gray;
                bRedOff.BackColor = System.Drawing.Color.Red;
                bRedOn.BackColor = System.Drawing.Color.Gray;
                bBlueOff.BackColor = System.Drawing.Color.Blue;
                bBlueOn.BackColor = System.Drawing.Color.Gray;

               // Thread.Sleep(11500);
                bBlink.ForeColor = System.Drawing.Color.Black;
                bBlink.BackColor = System.Drawing.Color.Gray;

                bRound.Enabled = true; //Round
                bAlarm.Enabled = true; //Alarm
                bAllOff.Enabled = true; //All off
                bAllOn.Enabled = true; //All on
                bBlueOn.Enabled = true; // Blue LED
                bAmberOn.Enabled = true; // Amber LED
                bGreenOn.Enabled = true; // Green LED
                bRedOn.Enabled = true; // Red LED

            }
        }

        //Blue on button
        private void bBlueOn_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            { 
                mySerialPort.WriteLine("22212"); // Sends PD15N to stm32f4 to turn on LED = Blue
                    
                bBlueOn.BackColor = System.Drawing.Color.Blue;
                bBlueOff.BackColor = System.Drawing.Color.Gray;
 
                bAllOff.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.BackColor = System.Drawing.Color.Gray;
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bRound.ForeColor = System.Drawing.Color.Black;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bBlink.ForeColor = System.Drawing.Color.Black;
               
            }
        }


        //Blue off button
        private void bBlueOff_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                 mySerialPort.WriteLine("22213");// Sends PD15F to stm32f4 to turn off LED = Blue
                bBlueOff.BackColor = System.Drawing.Color.Blue;
                bBlueOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
               
            }
        }

        //Amber on button
        private void bAmberOn_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                mySerialPort.WriteLine("22208"); // Sends PD13N to stm32f4 to turn on LED = Orange
                bAmberOn.BackColor = System.Drawing.Color.Orange;
                bAmberOff.BackColor = System.Drawing.Color.Gray;

                bAllOff.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.BackColor = System.Drawing.Color.Gray;
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bRound.ForeColor = System.Drawing.Color.Black;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bBlink.ForeColor = System.Drawing.Color.Black;
              
            }
        }

        //Amber off button
        private void bAmberOff_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                mySerialPort.WriteLine("22209"); // Sends PD13N to stm32f4 to turn on LED = Orange
                bAmberOff.BackColor = System.Drawing.Color.Orange;
                bAmberOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
            }
        }

        //Red on button
        private void bRedOn_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                mySerialPort.WriteLine("22210"); // Sends PD12N to stm32f4 to turn on LED = Red
                bRedOn.BackColor = System.Drawing.Color.Red;
                bRedOff.BackColor = System.Drawing.Color.Gray;

                 bAllOff.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.BackColor = System.Drawing.Color.Gray;
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bRound.ForeColor = System.Drawing.Color.Black;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bBlink.ForeColor = System.Drawing.Color.Black;
                
            }
        }

        //Red off button
        private void bRedOff_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {
                mySerialPort.WriteLine("22211");// Sends PD14F to stm32f4 to turn off LED = Red
                bRedOff.BackColor = System.Drawing.Color.Red;
                bRedOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
 
            }
        }

        //Green on button
        private void bGreenOn_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {   
                mySerialPort.WriteLine("22206");// Sends PD12F to stm32f4 to turn on LED = Green
                bGreenOn.BackColor = System.Drawing.Color.Green;
                bGreenOff.BackColor = System.Drawing.Color.Gray;

                bAllOff.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.BackColor = System.Drawing.Color.Gray;
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOn.ForeColor = System.Drawing.Color.Black;
                bRound.ForeColor = System.Drawing.Color.Black;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bBlink.ForeColor = System.Drawing.Color.Black;
                
            }
        }

        //Green off button
        private void bGreenOff_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {   
                mySerialPort.WriteLine("22207");// Sends PD12F to stm32f4 to turn off LED = Green
                bGreenOff.BackColor = System.Drawing.Color.Green;
                bGreenOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAllOn.ForeColor = System.Drawing.Color.Black;
               
            }
        }

        //All on button
        private void bAllOn_Click(object sender, EventArgs e)
        {
            if (mySerialPort.IsOpen)
            {

                mySerialPort.WriteLine("22204");// Sends PDONa to stm32f4 to turn on LED = All four

                bAllOn.ForeColor = System.Drawing.Color.White;
                bAllOn.BackColor = System.Drawing.Color.Black;

                bRound.Enabled = false; //Round
                bAlarm.Enabled = false; //Alarm
                bBlink.Enabled = false; //Blink
                bAllOff.Enabled = false; //All off

                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOff.BackColor = System.Drawing.Color.Gray;

                bRound.ForeColor = System.Drawing.Color.Black;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.ForeColor = System.Drawing.Color.Black;
                bBlink.BackColor = System.Drawing.Color.Gray;
                bGreenOff.BackColor = System.Drawing.Color.Gray;
                bGreenOn.BackColor = System.Drawing.Color.Green; 
                bAmberOff.BackColor = System.Drawing.Color.Gray;
                bAmberOn.BackColor = System.Drawing.Color.Orange; 
                bRedOff.BackColor = System.Drawing.Color.Gray;
                bRedOn.BackColor = System.Drawing.Color.Red; 
                bBlueOff.BackColor = System.Drawing.Color.Gray;
                bBlueOn.BackColor = System.Drawing.Color.Blue; 
               
                bRound.Enabled = true; //Round
                bAlarm.Enabled = true; //Alarm
                bBlink.Enabled = true; //Blink
                bAllOff.Enabled = true; //All off
            }
        }


         //All off button
        private void bAllOff_Click(object sender, EventArgs e)
        {

            if (mySerialPort.IsOpen)
            {
             
                bRound.Enabled = false; //Round
                bAlarm.Enabled = false; //Alarm
                bBlink.Enabled = false; //Blink

                mySerialPort.WriteLine("22205");// Sends PDOFA to stm32f4 to turn off LED = All four

                bAllOn.ForeColor = System.Drawing.Color.Black;
                bAllOn.BackColor = System.Drawing.Color.Gray;
                bAllOff.BackColor = System.Drawing.Color.Black;
                bAllOff.ForeColor = System.Drawing.Color.White;
                bRound.ForeColor = System.Drawing.Color.Black;
                bRound.BackColor = System.Drawing.Color.Gray;
                bAlarm.ForeColor = System.Drawing.Color.Black;
                bAlarm.BackColor = System.Drawing.Color.Gray;
                bBlink.ForeColor = System.Drawing.Color.Black;
                bBlink.BackColor = System.Drawing.Color.Gray;

                bGreenOff.BackColor = System.Drawing.Color.Green;
                bGreenOn.BackColor = System.Drawing.Color.Gray;
                bAmberOff.BackColor = System.Drawing.Color.Orange;
                bAmberOn.BackColor = System.Drawing.Color.Gray;
                bRedOff.BackColor = System.Drawing.Color.Red;
                bRedOn.BackColor = System.Drawing.Color.Gray;
                bBlueOff.BackColor = System.Drawing.Color.Blue;
                bBlueOn.BackColor = System.Drawing.Color.Gray;
               
                Thread.Sleep(100);
                bAllOff.ForeColor = System.Drawing.Color.Black;
                bAllOff.BackColor = System.Drawing.Color.Gray;

                bRound.Enabled = true; //Round
                bAlarm.Enabled = true; //Alarm
                bBlink.Enabled = true; //Blink
              }
        }
   
        private void rHide_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            
        }

        private void rShow_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mySerialPort.WriteLine("22205");// Sends PDOFA to stm32f4 to turn off LED = All four
        }

        private void bTestBoard_Click(object sender, EventArgs e)
        {
            mySerialPort.WriteLine("22214"); //writes out code to test board.
            tbRX.Clear(); //clears the display
        }
    }
}
