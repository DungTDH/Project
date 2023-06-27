
namespace HSV.Forms
{
    partial class ARLAM
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnCurrentAlarm = new System.Windows.Forms.Button();
            this.btnHistoryAlarm = new System.Windows.Forms.Button();
            this.btnAlarmFrequency = new System.Windows.Forms.Button();
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.clTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAlarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResetTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAlarmAll = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(783, 50);
            this.button1.TabIndex = 88;
            this.button1.Text = "MACHINE ALARM";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCurrentAlarm
            // 
            this.btnCurrentAlarm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCurrentAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentAlarm.ForeColor = System.Drawing.Color.White;
            this.btnCurrentAlarm.Location = new System.Drawing.Point(12, 816);
            this.btnCurrentAlarm.Name = "btnCurrentAlarm";
            this.btnCurrentAlarm.Size = new System.Drawing.Size(153, 50);
            this.btnCurrentAlarm.TabIndex = 88;
            this.btnCurrentAlarm.Text = "Current Alarm";
            this.btnCurrentAlarm.UseVisualStyleBackColor = false;
            this.btnCurrentAlarm.Click += new System.EventHandler(this.btnCurrentAlarm_Click);
            // 
            // btnHistoryAlarm
            // 
            this.btnHistoryAlarm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnHistoryAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryAlarm.ForeColor = System.Drawing.Color.White;
            this.btnHistoryAlarm.Location = new System.Drawing.Point(171, 816);
            this.btnHistoryAlarm.Name = "btnHistoryAlarm";
            this.btnHistoryAlarm.Size = new System.Drawing.Size(153, 50);
            this.btnHistoryAlarm.TabIndex = 88;
            this.btnHistoryAlarm.Text = "History Alarm";
            this.btnHistoryAlarm.UseVisualStyleBackColor = false;
            this.btnHistoryAlarm.Click += new System.EventHandler(this.btnHistoryAlarm_Click);
            // 
            // btnAlarmFrequency
            // 
            this.btnAlarmFrequency.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAlarmFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmFrequency.ForeColor = System.Drawing.Color.White;
            this.btnAlarmFrequency.Location = new System.Drawing.Point(330, 816);
            this.btnAlarmFrequency.Name = "btnAlarmFrequency";
            this.btnAlarmFrequency.Size = new System.Drawing.Size(153, 50);
            this.btnAlarmFrequency.TabIndex = 88;
            this.btnAlarmFrequency.Text = "Alarm Frequency";
            this.btnAlarmFrequency.UseVisualStyleBackColor = false;
            this.btnAlarmFrequency.Click += new System.EventHandler(this.btnAlarmFrequency_Click);
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.AllowUserToAddRows = false;
            this.dgvAlarm.AllowUserToDeleteRows = false;
            this.dgvAlarm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAlarm.ColumnHeadersHeight = 30;
            this.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clTime,
            this.clID,
            this.clAlarmName,
            this.clResetTime,
            this.clTotalTime,
            this.clCount});
            this.dgvAlarm.Location = new System.Drawing.Point(3, 54);
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.ReadOnly = true;
            this.dgvAlarm.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAlarm.RowHeadersWidth = 62;
            this.dgvAlarm.Size = new System.Drawing.Size(783, 756);
            this.dgvAlarm.TabIndex = 89;
            // 
            // clTime
            // 
            this.clTime.HeaderText = "Time";
            this.clTime.MinimumWidth = 8;
            this.clTime.Name = "clTime";
            this.clTime.ReadOnly = true;
            this.clTime.Width = 120;
            // 
            // clID
            // 
            this.clID.HeaderText = "ID";
            this.clID.MinimumWidth = 8;
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Width = 50;
            // 
            // clAlarmName
            // 
            this.clAlarmName.HeaderText = "Alarm Name";
            this.clAlarmName.MinimumWidth = 8;
            this.clAlarmName.Name = "clAlarmName";
            this.clAlarmName.ReadOnly = true;
            this.clAlarmName.Width = 290;
            // 
            // clResetTime
            // 
            this.clResetTime.HeaderText = "Reset";
            this.clResetTime.MinimumWidth = 8;
            this.clResetTime.Name = "clResetTime";
            this.clResetTime.ReadOnly = true;
            this.clResetTime.Width = 120;
            // 
            // clTotalTime
            // 
            this.clTotalTime.HeaderText = "Total Time";
            this.clTotalTime.MinimumWidth = 8;
            this.clTotalTime.Name = "clTotalTime";
            this.clTotalTime.ReadOnly = true;
            this.clTotalTime.Width = 80;
            // 
            // clCount
            // 
            this.clCount.HeaderText = "Count";
            this.clCount.MinimumWidth = 8;
            this.clCount.Name = "clCount";
            this.clCount.ReadOnly = true;
            this.clCount.Width = 50;
            // 
            // btnAlarmAll
            // 
            this.btnAlarmAll.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAlarmAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmAll.ForeColor = System.Drawing.Color.White;
            this.btnAlarmAll.Location = new System.Drawing.Point(489, 816);
            this.btnAlarmAll.Name = "btnAlarmAll";
            this.btnAlarmAll.Size = new System.Drawing.Size(153, 50);
            this.btnAlarmAll.TabIndex = 88;
            this.btnAlarmAll.Text = "Alarm All";
            this.btnAlarmAll.UseVisualStyleBackColor = false;
            this.btnAlarmAll.Click += new System.EventHandler(this.btnAlarmAll_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(663, 816);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 50);
            this.btnClear.TabIndex = 88;
            this.btnClear.Text = "Clear Alarm";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ARLAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(784, 931);
            this.Controls.Add(this.dgvAlarm);
            this.Controls.Add(this.btnAlarmFrequency);
            this.Controls.Add(this.btnHistoryAlarm);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAlarmAll);
            this.Controls.Add(this.btnCurrentAlarm);
            this.Controls.Add(this.button1);
            this.Name = "ARLAM";
            this.Text = "ARLAM";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCurrentAlarm;
        private System.Windows.Forms.Button btnHistoryAlarm;
        private System.Windows.Forms.Button btnAlarmFrequency;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.Button btnAlarmAll;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAlarmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResetTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTotalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCount;
        private System.Windows.Forms.Button btnClear;
    }
}