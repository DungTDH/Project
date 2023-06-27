
namespace HSV.Forms
{
    partial class AUTO
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
            this.btnRUN = new System.Windows.Forms.Button();
            this.btnEquipment = new RJCodeAdvance.RJControls.RJButton();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCurrentTacttime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShift2 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShift1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rjButton6 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton5 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.lblPreviousTactTime = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rjButton4 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton3 = new RJCodeAdvance.RJControls.RJButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnORIGIN = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRUN
            // 
            this.btnRUN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRUN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRUN.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRUN.Location = new System.Drawing.Point(22, 5);
            this.btnRUN.Name = "btnRUN";
            this.btnRUN.Size = new System.Drawing.Size(150, 134);
            this.btnRUN.TabIndex = 32;
            this.btnRUN.Text = "START";
            this.btnRUN.UseVisualStyleBackColor = false;
            this.btnRUN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRUN_MouseDown);
            this.btnRUN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRUN_MouseUp);
            // 
            // btnEquipment
            // 
            this.btnEquipment.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnEquipment.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnEquipment.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEquipment.BorderRadius = 15;
            this.btnEquipment.BorderSize = 1;
            this.btnEquipment.Enabled = false;
            this.btnEquipment.FlatAppearance.BorderSize = 0;
            this.btnEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipment.ForeColor = System.Drawing.Color.Black;
            this.btnEquipment.Location = new System.Drawing.Point(-136, 18);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(1045, 47);
            this.btnEquipment.TabIndex = 6;
            this.btnEquipment.Text = "Equipment Status";
            this.btnEquipment.TextColor = System.Drawing.Color.Black;
            this.btnEquipment.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 20);
            this.label12.TabIndex = 85;
            this.label12.Text = "Current Tacttime";
            // 
            // lblCurrentTacttime
            // 
            this.lblCurrentTacttime.AutoSize = true;
            this.lblCurrentTacttime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.lblCurrentTacttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTacttime.Location = new System.Drawing.Point(31, 63);
            this.lblCurrentTacttime.Name = "lblCurrentTacttime";
            this.lblCurrentTacttime.Size = new System.Drawing.Size(59, 31);
            this.lblCurrentTacttime.TabIndex = 85;
            this.lblCurrentTacttime.Text = "123";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(111, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 31);
            this.label14.TabIndex = 85;
            this.label14.Text = "(s)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.rjButton5);
            this.panel1.Controls.Add(this.rjButton2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 476);
            this.panel1.TabIndex = 98;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(573, 167);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(199, 307);
            this.panel13.TabIndex = 88;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.label4);
            this.panel15.Controls.Add(this.lblShift2);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 146);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(199, 161);
            this.panel15.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 31);
            this.label4.TabIndex = 85;
            this.label4.Text = "PCS";
            // 
            // lblShift2
            // 
            this.lblShift2.AutoSize = true;
            this.lblShift2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.lblShift2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift2.Location = new System.Drawing.Point(16, 73);
            this.lblShift2.Name = "lblShift2";
            this.lblShift2.Size = new System.Drawing.Size(59, 31);
            this.lblShift2.TabIndex = 85;
            this.lblShift2.Text = "123";
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.label3);
            this.panel14.Controls.Add(this.lblShift1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(199, 146);
            this.panel14.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 31);
            this.label3.TabIndex = 85;
            this.label3.Text = "PCS";
            // 
            // lblShift1
            // 
            this.lblShift1.AutoSize = true;
            this.lblShift1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.lblShift1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift1.Location = new System.Drawing.Point(16, 64);
            this.lblShift1.Name = "lblShift1";
            this.lblShift1.Size = new System.Drawing.Size(59, 31);
            this.lblShift1.TabIndex = 85;
            this.lblShift1.Text = "123";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rjButton6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(163, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(609, 100);
            this.panel5.TabIndex = 87;
            // 
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton6.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton6.BorderRadius = 15;
            this.rjButton6.BorderSize = 1;
            this.rjButton6.Enabled = false;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton6.ForeColor = System.Drawing.Color.Black;
            this.rjButton6.Location = new System.Drawing.Point(-44, 0);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(731, 100);
            this.rjButton6.TabIndex = 6;
            this.rjButton6.Text = "PRODUCTION  HOURLY";
            this.rjButton6.TextColor = System.Drawing.Color.Black;
            this.rjButton6.UseVisualStyleBackColor = false;
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton5.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton5.BorderRadius = 15;
            this.rjButton5.BorderSize = 1;
            this.rjButton5.Enabled = false;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton5.ForeColor = System.Drawing.Color.Black;
            this.rjButton5.Location = new System.Drawing.Point(163, 153);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(421, 160);
            this.rjButton5.TabIndex = 6;
            this.rjButton5.Text = "SHIFT 1";
            this.rjButton5.TextColor = System.Drawing.Color.Black;
            this.rjButton5.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 15;
            this.rjButton2.BorderSize = 1;
            this.rjButton2.Enabled = false;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.Black;
            this.rjButton2.Location = new System.Drawing.Point(163, 315);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(421, 160);
            this.rjButton2.TabIndex = 6;
            this.rjButton2.Text = "SHIFT 2";
            this.rjButton2.TextColor = System.Drawing.Color.Black;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 407);
            this.panel2.TabIndex = 86;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label28);
            this.panel12.Controls.Add(this.lblPreviousTactTime);
            this.panel12.Controls.Add(this.label26);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 245);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(161, 162);
            this.panel12.TabIndex = 88;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(-3, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(151, 20);
            this.label28.TabIndex = 85;
            this.label28.Text = "Previous Tacttime";
            // 
            // lblPreviousTactTime
            // 
            this.lblPreviousTactTime.AutoSize = true;
            this.lblPreviousTactTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.lblPreviousTactTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousTactTime.Location = new System.Drawing.Point(31, 73);
            this.lblPreviousTactTime.Name = "lblPreviousTactTime";
            this.lblPreviousTactTime.Size = new System.Drawing.Size(59, 31);
            this.lblPreviousTactTime.TabIndex = 85;
            this.lblPreviousTactTime.Text = "123";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(111, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 31);
            this.label26.TabIndex = 85;
            this.label26.Text = "(s)";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label12);
            this.panel11.Controls.Add(this.lblCurrentTacttime);
            this.panel11.Controls.Add(this.label14);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 100);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(161, 145);
            this.panel11.TabIndex = 87;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label25);
            this.panel10.Controls.Add(this.rjButton1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(161, 100);
            this.panel10.TabIndex = 86;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(38, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 25);
            this.label25.TabIndex = 95;
            this.label25.Text = "TIMER";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 15;
            this.rjButton1.BorderSize = 1;
            this.rjButton1.Enabled = false;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.Black;
            this.rjButton1.Location = new System.Drawing.Point(-48, -1);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(303, 101);
            this.rjButton1.TabIndex = 6;
            this.rjButton1.TextColor = System.Drawing.Color.Black;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 67);
            this.panel3.TabIndex = 85;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rjButton4);
            this.panel4.Controls.Add(this.rjButton3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 119);
            this.panel4.TabIndex = 99;
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton4.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton4.BorderRadius = 0;
            this.rjButton4.BorderSize = 0;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Location = new System.Drawing.Point(220, 11);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(207, 88);
            this.rjButton4.TabIndex = 0;
            this.rjButton4.Text = "DISCONNECT";
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            this.rjButton4.Click += new System.EventHandler(this.rjButton4_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton3.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 0;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(11, 11);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(203, 88);
            this.rjButton3.TabIndex = 0;
            this.rjButton3.Text = "CONNECT";
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(46, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(263, 134);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(70)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(148, 723);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 36);
            this.button4.TabIndex = 32;
            this.button4.Text = "HOME Z";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 119);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(774, 368);
            this.panel7.TabIndex = 101;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.btnORIGIN);
            this.panel9.Controls.Add(this.btnReset);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(391, 72);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(381, 294);
            this.panel9.TabIndex = 34;
            // 
            // btnORIGIN
            // 
            this.btnORIGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnORIGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnORIGIN.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnORIGIN.Location = new System.Drawing.Point(46, 145);
            this.btnORIGIN.Name = "btnORIGIN";
            this.btnORIGIN.Size = new System.Drawing.Size(263, 134);
            this.btnORIGIN.TabIndex = 32;
            this.btnORIGIN.Text = "ORIGIN";
            this.btnORIGIN.UseVisualStyleBackColor = false;
            this.btnORIGIN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
            this.btnORIGIN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button5_MouseUp);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnRUN);
            this.panel6.Controls.Add(this.btnAuto);
            this.panel6.Controls.Add(this.btnStop);
            this.panel6.Controls.Add(this.btnManual);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(432, 294);
            this.panel6.TabIndex = 33;
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuto.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuto.Location = new System.Drawing.Point(185, 5);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(151, 134);
            this.btnAuto.TabIndex = 32;
            this.btnAuto.Text = "AUTO";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            this.btnAuto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAuto_MouseDown_1);
            this.btnAuto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAuto_MouseUp_1);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(185, 145);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(151, 134);
            this.btnStop.TabIndex = 32;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManual.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManual.Location = new System.Drawing.Point(22, 145);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(150, 134);
            this.btnManual.TabIndex = 32;
            this.btnManual.Text = "MANUAL";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            this.btnManual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnManual_MouseDown_1);
            this.btnManual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnManual_MouseUp_1);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnEquipment);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(772, 72);
            this.panel8.TabIndex = 0;
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // AUTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(774, 925);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Name = "AUTO";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.AUTO_Load);
            this.panel1.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRUN;
        private RJCodeAdvance.RJControls.RJButton btnEquipment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCurrentTacttime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblPreviousTactTime;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label25;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private System.Windows.Forms.Panel panel3;
        private RJCodeAdvance.RJControls.RJButton rjButton4;
        private RJCodeAdvance.RJControls.RJButton rjButton3;
        private System.Windows.Forms.Button btnORIGIN;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel5;
        private RJCodeAdvance.RJControls.RJButton rjButton6;
        private RJCodeAdvance.RJControls.RJButton rjButton5;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShift2;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblShift1;
    }
}