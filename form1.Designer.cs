namespace stm32f4_713
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bAlarm = new System.Windows.Forms.Button();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.bRound = new System.Windows.Forms.Button();
            this.bBlink = new System.Windows.Forms.Button();
            this.bBlueOn = new System.Windows.Forms.Button();
            this.bBlueOff = new System.Windows.Forms.Button();
            this.bAmberOff = new System.Windows.Forms.Button();
            this.bAmberOn = new System.Windows.Forms.Button();
            this.bGreenOff = new System.Windows.Forms.Button();
            this.bGreenOn = new System.Windows.Forms.Button();
            this.bRedOff = new System.Windows.Forms.Button();
            this.bRedOn = new System.Windows.Forms.Button();
            this.bAllOff = new System.Windows.Forms.Button();
            this.bAllOn = new System.Windows.Forms.Button();
            this.tbRX = new System.Windows.Forms.RichTextBox();
            this.bClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rShow = new System.Windows.Forms.RadioButton();
            this.rHide = new System.Windows.Forms.RadioButton();
            this.gSnVisible = new System.Windows.Forms.GroupBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.bTestBoard = new System.Windows.Forms.Button();
            this.gSnVisible.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAlarm
            // 
            this.bAlarm.BackColor = System.Drawing.Color.Gray;
            this.bAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAlarm.Location = new System.Drawing.Point(235, 30);
            this.bAlarm.Name = "bAlarm";
            this.bAlarm.Size = new System.Drawing.Size(107, 99);
            this.bAlarm.TabIndex = 2;
            this.bAlarm.Text = "Alarm";
            this.bAlarm.UseVisualStyleBackColor = false;
            this.bAlarm.Click += new System.EventHandler(this.bAlarm_Click);
            // 
            // mySerialPort
            // 
            this.mySerialPort.PortName = "COM7";
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mySerialPort_DataReceived);
            // 
            // bRound
            // 
            this.bRound.BackColor = System.Drawing.Color.Gray;
            this.bRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRound.Location = new System.Drawing.Point(122, 30);
            this.bRound.Name = "bRound";
            this.bRound.Size = new System.Drawing.Size(107, 99);
            this.bRound.TabIndex = 3;
            this.bRound.Text = "Pinwheel";
            this.bRound.UseVisualStyleBackColor = false;
            this.bRound.Click += new System.EventHandler(this.bRound_Click);
            // 
            // bBlink
            // 
            this.bBlink.BackColor = System.Drawing.Color.Gray;
            this.bBlink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBlink.Location = new System.Drawing.Point(9, 30);
            this.bBlink.Name = "bBlink";
            this.bBlink.Size = new System.Drawing.Size(107, 99);
            this.bBlink.TabIndex = 1;
            this.bBlink.Text = "Blink";
            this.bBlink.UseVisualStyleBackColor = false;
            this.bBlink.Click += new System.EventHandler(this.bBlink_Click);
            // 
            // bBlueOn
            // 
            this.bBlueOn.BackColor = System.Drawing.Color.Gray;
            this.bBlueOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBlueOn.Location = new System.Drawing.Point(348, 135);
            this.bBlueOn.Name = "bBlueOn";
            this.bBlueOn.Size = new System.Drawing.Size(107, 99);
            this.bBlueOn.TabIndex = 12;
            this.bBlueOn.Text = "ON";
            this.bBlueOn.UseVisualStyleBackColor = false;
            this.bBlueOn.Click += new System.EventHandler(this.bBlueOn_Click);
            // 
            // bBlueOff
            // 
            this.bBlueOff.BackColor = System.Drawing.Color.Blue;
            this.bBlueOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBlueOff.Location = new System.Drawing.Point(348, 240);
            this.bBlueOff.Name = "bBlueOff";
            this.bBlueOff.Size = new System.Drawing.Size(107, 99);
            this.bBlueOff.TabIndex = 13;
            this.bBlueOff.Text = "OFF";
            this.bBlueOff.UseVisualStyleBackColor = false;
            this.bBlueOff.Click += new System.EventHandler(this.bBlueOff_Click);
            // 
            // bAmberOff
            // 
            this.bAmberOff.BackColor = System.Drawing.Color.Orange;
            this.bAmberOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAmberOff.Location = new System.Drawing.Point(121, 240);
            this.bAmberOff.Name = "bAmberOff";
            this.bAmberOff.Size = new System.Drawing.Size(107, 99);
            this.bAmberOff.TabIndex = 9;
            this.bAmberOff.Text = "OFF";
            this.bAmberOff.UseVisualStyleBackColor = false;
            this.bAmberOff.Click += new System.EventHandler(this.bAmberOff_Click);
            // 
            // bAmberOn
            // 
            this.bAmberOn.BackColor = System.Drawing.Color.Gray;
            this.bAmberOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAmberOn.Location = new System.Drawing.Point(121, 135);
            this.bAmberOn.Name = "bAmberOn";
            this.bAmberOn.Size = new System.Drawing.Size(107, 99);
            this.bAmberOn.TabIndex = 8;
            this.bAmberOn.Text = "ON";
            this.bAmberOn.UseVisualStyleBackColor = false;
            this.bAmberOn.Click += new System.EventHandler(this.bAmberOn_Click);
            // 
            // bGreenOff
            // 
            this.bGreenOff.BackColor = System.Drawing.Color.Green;
            this.bGreenOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGreenOff.Location = new System.Drawing.Point(8, 240);
            this.bGreenOff.Name = "bGreenOff";
            this.bGreenOff.Size = new System.Drawing.Size(107, 99);
            this.bGreenOff.TabIndex = 7;
            this.bGreenOff.Text = "OFF";
            this.bGreenOff.UseVisualStyleBackColor = false;
            this.bGreenOff.Click += new System.EventHandler(this.bGreenOff_Click);
            // 
            // bGreenOn
            // 
            this.bGreenOn.BackColor = System.Drawing.Color.Gray;
            this.bGreenOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGreenOn.Location = new System.Drawing.Point(8, 135);
            this.bGreenOn.Name = "bGreenOn";
            this.bGreenOn.Size = new System.Drawing.Size(107, 99);
            this.bGreenOn.TabIndex = 6;
            this.bGreenOn.Text = "ON";
            this.bGreenOn.UseVisualStyleBackColor = false;
            this.bGreenOn.Click += new System.EventHandler(this.bGreenOn_Click);
            // 
            // bRedOff
            // 
            this.bRedOff.BackColor = System.Drawing.Color.Red;
            this.bRedOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRedOff.Location = new System.Drawing.Point(235, 240);
            this.bRedOff.Name = "bRedOff";
            this.bRedOff.Size = new System.Drawing.Size(107, 99);
            this.bRedOff.TabIndex = 11;
            this.bRedOff.Text = "OFF";
            this.bRedOff.UseVisualStyleBackColor = false;
            this.bRedOff.Click += new System.EventHandler(this.bRedOff_Click);
            // 
            // bRedOn
            // 
            this.bRedOn.BackColor = System.Drawing.Color.Gray;
            this.bRedOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRedOn.Location = new System.Drawing.Point(235, 135);
            this.bRedOn.Name = "bRedOn";
            this.bRedOn.Size = new System.Drawing.Size(107, 99);
            this.bRedOn.TabIndex = 10;
            this.bRedOn.Text = "ON";
            this.bRedOn.UseVisualStyleBackColor = false;
            this.bRedOn.Click += new System.EventHandler(this.bRedOn_Click);
            // 
            // bAllOff
            // 
            this.bAllOff.BackColor = System.Drawing.Color.Gray;
            this.bAllOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAllOff.Location = new System.Drawing.Point(462, 30);
            this.bAllOff.Name = "bAllOff";
            this.bAllOff.Size = new System.Drawing.Size(107, 99);
            this.bAllOff.TabIndex = 5;
            this.bAllOff.Text = "All Off";
            this.bAllOff.UseVisualStyleBackColor = false;
            this.bAllOff.Click += new System.EventHandler(this.bAllOff_Click);
            // 
            // bAllOn
            // 
            this.bAllOn.BackColor = System.Drawing.Color.Gray;
            this.bAllOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAllOn.Location = new System.Drawing.Point(349, 30);
            this.bAllOn.Name = "bAllOn";
            this.bAllOn.Size = new System.Drawing.Size(107, 99);
            this.bAllOn.TabIndex = 4;
            this.bAllOn.Text = "All On";
            this.bAllOn.UseVisualStyleBackColor = false;
            this.bAllOn.Click += new System.EventHandler(this.bAllOn_Click);
            // 
            // tbRX
            // 
            this.tbRX.Location = new System.Drawing.Point(462, 135);
            this.tbRX.Name = "tbRX";
            this.tbRX.Size = new System.Drawing.Size(209, 204);
            this.tbRX.TabIndex = 15;
            this.tbRX.Text = "";
            // 
            // bClear
            // 
            this.bClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClear.Location = new System.Drawing.Point(462, 345);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(87, 50);
            this.bClear.TabIndex = 17;
            this.bClear.Text = "Clear Screen";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "22201";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(154, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "22202";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(270, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "22203";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(380, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "22204";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(494, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "22205";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(44, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "22206";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(155, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "22208";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(268, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "22210";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(380, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "22212";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(46, 310);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "22207";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(157, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "22209";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(270, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "22211";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(380, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "22213";
            // 
            // rShow
            // 
            this.rShow.AutoSize = true;
            this.rShow.Checked = true;
            this.rShow.Location = new System.Drawing.Point(18, 13);
            this.rShow.Name = "rShow";
            this.rShow.Size = new System.Drawing.Size(52, 17);
            this.rShow.TabIndex = 32;
            this.rShow.TabStop = true;
            this.rShow.Text = "Show";
            this.rShow.UseVisualStyleBackColor = true;
            this.rShow.CheckedChanged += new System.EventHandler(this.rShow_CheckedChanged);
            // 
            // rHide
            // 
            this.rHide.AutoSize = true;
            this.rHide.Location = new System.Drawing.Point(92, 13);
            this.rHide.Name = "rHide";
            this.rHide.Size = new System.Drawing.Size(47, 17);
            this.rHide.TabIndex = 33;
            this.rHide.Text = "Hide";
            this.rHide.UseVisualStyleBackColor = true;
            this.rHide.CheckedChanged += new System.EventHandler(this.rHide_CheckedChanged);
            // 
            // gSnVisible
            // 
            this.gSnVisible.Controls.Add(this.rShow);
            this.gSnVisible.Controls.Add(this.rHide);
            this.gSnVisible.Location = new System.Drawing.Point(297, 345);
            this.gSnVisible.Name = "gSnVisible";
            this.gSnVisible.Size = new System.Drawing.Size(158, 36);
            this.gSnVisible.TabIndex = 34;
            this.gSnVisible.TabStop = false;
            this.gSnVisible.Text = "Serial Numbers";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // bTestBoard
            // 
            this.bTestBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTestBoard.Location = new System.Drawing.Point(583, 345);
            this.bTestBoard.Name = "bTestBoard";
            this.bTestBoard.Size = new System.Drawing.Size(87, 50);
            this.bTestBoard.TabIndex = 35;
            this.bTestBoard.Text = "Self Test";
            this.bTestBoard.UseVisualStyleBackColor = true;
            this.bTestBoard.Click += new System.EventHandler(this.bTestBoard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 407);
            this.Controls.Add(this.bTestBoard);
            this.Controls.Add(this.gSnVisible);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.tbRX);
            this.Controls.Add(this.bAllOff);
            this.Controls.Add(this.bAllOn);
            this.Controls.Add(this.bRedOff);
            this.Controls.Add(this.bRedOn);
            this.Controls.Add(this.bGreenOff);
            this.Controls.Add(this.bGreenOn);
            this.Controls.Add(this.bAmberOff);
            this.Controls.Add(this.bAmberOn);
            this.Controls.Add(this.bBlueOff);
            this.Controls.Add(this.bBlueOn);
            this.Controls.Add(this.bBlink);
            this.Controls.Add(this.bRound);
            this.Controls.Add(this.bAlarm);
            this.Name = "Form1";
            this.Text = "STM32F4DISCOVERY";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gSnVisible.ResumeLayout(false);
            this.gSnVisible.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAlarm;
        private System.IO.Ports.SerialPort mySerialPort;
        private System.Windows.Forms.Button bRound;
        private System.Windows.Forms.Button bBlink;
        private System.Windows.Forms.Button bBlueOn;
        private System.Windows.Forms.Button bBlueOff;
        private System.Windows.Forms.Button bAmberOff;
        private System.Windows.Forms.Button bAmberOn;
        private System.Windows.Forms.Button bGreenOff;
        private System.Windows.Forms.Button bGreenOn;
        private System.Windows.Forms.Button bRedOff;
        private System.Windows.Forms.Button bRedOn;
        private System.Windows.Forms.Button bAllOff;
        private System.Windows.Forms.Button bAllOn;
        private System.Windows.Forms.RichTextBox tbRX;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rShow;
        private System.Windows.Forms.RadioButton rHide;
        private System.Windows.Forms.GroupBox gSnVisible;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button bTestBoard;
    }
}

