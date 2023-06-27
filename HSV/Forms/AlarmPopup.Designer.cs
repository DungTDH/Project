
namespace HSV.Forms
{
    partial class AlarmPopup
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
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.rjtAlarmID = new RJCodeAdvance.RJControls.RJTextBox();
            this.rjbConfirm = new RJCodeAdvance.RJControls.RJButton();
            this.rjtAlarmText = new RJCodeAdvance.RJControls.RJTextBox();
            this.SuspendLayout();
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Silver;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Silver;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rjButton1.Enabled = false;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(0, 0);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(558, 282);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.Red;
            this.rjButton2.BackgroundColor = System.Drawing.Color.Red;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 0;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rjButton2.Enabled = false;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(0, 0);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(558, 40);
            this.rjButton2.TabIndex = 1;
            this.rjButton2.Text = "ERROR";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // rjtAlarmID
            // 
            this.rjtAlarmID.BackColor = System.Drawing.SystemColors.Window;
            this.rjtAlarmID.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.rjtAlarmID.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjtAlarmID.BorderRadius = 0;
            this.rjtAlarmID.BorderSize = 2;
            this.rjtAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjtAlarmID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjtAlarmID.Location = new System.Drawing.Point(131, 81);
            this.rjtAlarmID.Margin = new System.Windows.Forms.Padding(4);
            this.rjtAlarmID.Multiline = false;
            this.rjtAlarmID.Name = "rjtAlarmID";
            this.rjtAlarmID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjtAlarmID.PasswordChar = false;
            this.rjtAlarmID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjtAlarmID.PlaceholderText = "";
            this.rjtAlarmID.Size = new System.Drawing.Size(261, 48);
            this.rjtAlarmID.TabIndex = 2;
            this.rjtAlarmID.Texts = "";
            this.rjtAlarmID.UnderlinedStyle = false;
            // 
            // rjbConfirm
            // 
            this.rjbConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rjbConfirm.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rjbConfirm.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjbConfirm.BorderRadius = 0;
            this.rjbConfirm.BorderSize = 0;
            this.rjbConfirm.FlatAppearance.BorderSize = 0;
            this.rjbConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjbConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjbConfirm.ForeColor = System.Drawing.Color.White;
            this.rjbConfirm.Location = new System.Drawing.Point(173, 199);
            this.rjbConfirm.Name = "rjbConfirm";
            this.rjbConfirm.Size = new System.Drawing.Size(186, 71);
            this.rjbConfirm.TabIndex = 3;
            this.rjbConfirm.Text = "CONFIRM";
            this.rjbConfirm.TextColor = System.Drawing.Color.White;
            this.rjbConfirm.UseVisualStyleBackColor = false;
            this.rjbConfirm.Click += new System.EventHandler(this.rjbConfirm_Click);
            // 
            // rjtAlarmText
            // 
            this.rjtAlarmText.BackColor = System.Drawing.SystemColors.Window;
            this.rjtAlarmText.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.rjtAlarmText.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjtAlarmText.BorderRadius = 0;
            this.rjtAlarmText.BorderSize = 2;
            this.rjtAlarmText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjtAlarmText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjtAlarmText.Location = new System.Drawing.Point(13, 128);
            this.rjtAlarmText.Margin = new System.Windows.Forms.Padding(4);
            this.rjtAlarmText.Multiline = false;
            this.rjtAlarmText.Name = "rjtAlarmText";
            this.rjtAlarmText.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjtAlarmText.PasswordChar = false;
            this.rjtAlarmText.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjtAlarmText.PlaceholderText = "";
            this.rjtAlarmText.Size = new System.Drawing.Size(532, 48);
            this.rjtAlarmText.TabIndex = 2;
            this.rjtAlarmText.Texts = "";
            this.rjtAlarmText.UnderlinedStyle = false;
            // 
            // AlarmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 282);
            this.Controls.Add(this.rjbConfirm);
            this.Controls.Add(this.rjtAlarmText);
            this.Controls.Add(this.rjtAlarmID);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.rjButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlarmPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlarmPopup";
            this.Load += new System.EventHandler(this.AlarmPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private RJCodeAdvance.RJControls.RJTextBox rjtAlarmID;
        private RJCodeAdvance.RJControls.RJButton rjbConfirm;
        private RJCodeAdvance.RJControls.RJTextBox rjtAlarmText;
    }
}