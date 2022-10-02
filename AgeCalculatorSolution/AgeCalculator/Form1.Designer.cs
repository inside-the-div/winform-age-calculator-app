namespace AgeCalculator
{
    partial class AgeCalculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgeCalculator));
            this.label1 = new System.Windows.Forms.Label();
            this.BirthDateCalender = new System.Windows.Forms.DateTimePicker();
            this.ToDateCalender = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.comboBoxBirthDay = new System.Windows.Forms.ComboBox();
            this.comboBoxBirthMonth = new System.Windows.Forms.ComboBox();
            this.textBoxBirthYear = new System.Windows.Forms.TextBox();
            this.comboBoxCurrentDay = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrentMonth = new System.Windows.Forms.ComboBox();
            this.textBoxCurrentYear = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(92, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate Your Age";
            // 
            // BirthDateCalender
            // 
            this.BirthDateCalender.CustomFormat = "dd/mm/yyyy";
            this.BirthDateCalender.Location = new System.Drawing.Point(324, 81);
            this.BirthDateCalender.Name = "BirthDateCalender";
            this.BirthDateCalender.Size = new System.Drawing.Size(18, 23);
            this.BirthDateCalender.TabIndex = 3;
            this.BirthDateCalender.ValueChanged += new System.EventHandler(this.BirthDate_ValueChanged);
            // 
            // ToDateCalender
            // 
            this.ToDateCalender.Location = new System.Drawing.Point(324, 124);
            this.ToDateCalender.Name = "ToDateCalender";
            this.ToDateCalender.Size = new System.Drawing.Size(18, 23);
            this.ToDateCalender.TabIndex = 7;
            this.ToDateCalender.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date of Birth :\t";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(62, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "To Date  :\t";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCalculate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCalculate.Location = new System.Drawing.Point(252, 169);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(90, 26);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Result.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Result.Location = new System.Drawing.Point(16, 229);
            this.Result.Margin = new System.Windows.Forms.Padding(0);
            this.Result.Name = "Result";
            this.Result.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.Result.Size = new System.Drawing.Size(326, 41);
            this.Result.TabIndex = 3;
            this.Result.Text = "Your Age is 0 years, 0 months and 0 days";
            this.Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxBirthDay
            // 
            this.comboBoxBirthDay.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBirthDay.DropDownHeight = 85;
            this.comboBoxBirthDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBirthDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxBirthDay.FormattingEnabled = true;
            this.comboBoxBirthDay.IntegralHeight = false;
            this.comboBoxBirthDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBoxBirthDay.Location = new System.Drawing.Point(148, 81);
            this.comboBoxBirthDay.Name = "comboBoxBirthDay";
            this.comboBoxBirthDay.Size = new System.Drawing.Size(38, 23);
            this.comboBoxBirthDay.TabIndex = 0;
            this.comboBoxBirthDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxBirthDay_SelectedIndexChanged);
            // 
            // comboBoxBirthMonth
            // 
            this.comboBoxBirthMonth.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBirthMonth.DropDownHeight = 80;
            this.comboBoxBirthMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBirthMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxBirthMonth.FormattingEnabled = true;
            this.comboBoxBirthMonth.IntegralHeight = false;
            this.comboBoxBirthMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxBirthMonth.Location = new System.Drawing.Point(187, 81);
            this.comboBoxBirthMonth.Name = "comboBoxBirthMonth";
            this.comboBoxBirthMonth.Size = new System.Drawing.Size(80, 23);
            this.comboBoxBirthMonth.TabIndex = 1;
            this.comboBoxBirthMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxBirthMonth_SelectedIndexChanged);
            // 
            // textBoxBirthYear
            // 
            this.textBoxBirthYear.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBirthYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxBirthYear.Location = new System.Drawing.Point(273, 81);
            this.textBoxBirthYear.MaxLength = 4;
            this.textBoxBirthYear.Name = "textBoxBirthYear";
            this.textBoxBirthYear.Size = new System.Drawing.Size(45, 23);
            this.textBoxBirthYear.TabIndex = 2;
            this.textBoxBirthYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxBirthYear.TextChanged += new System.EventHandler(this.textBoxBirthYear_TextChanged);
            this.textBoxBirthYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBirthYear_KeyPress);
            // 
            // comboBoxCurrentDay
            // 
            this.comboBoxCurrentDay.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCurrentDay.DropDownHeight = 85;
            this.comboBoxCurrentDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCurrentDay.FormattingEnabled = true;
            this.comboBoxCurrentDay.IntegralHeight = false;
            this.comboBoxCurrentDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBoxCurrentDay.Location = new System.Drawing.Point(148, 124);
            this.comboBoxCurrentDay.MaxDropDownItems = 5;
            this.comboBoxCurrentDay.Name = "comboBoxCurrentDay";
            this.comboBoxCurrentDay.Size = new System.Drawing.Size(38, 23);
            this.comboBoxCurrentDay.TabIndex = 4;
            this.comboBoxCurrentDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentDay_SelectedIndexChanged);
            // 
            // comboBoxCurrentMonth
            // 
            this.comboBoxCurrentMonth.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCurrentMonth.DropDownHeight = 80;
            this.comboBoxCurrentMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCurrentMonth.FormattingEnabled = true;
            this.comboBoxCurrentMonth.IntegralHeight = false;
            this.comboBoxCurrentMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxCurrentMonth.Location = new System.Drawing.Point(187, 124);
            this.comboBoxCurrentMonth.Name = "comboBoxCurrentMonth";
            this.comboBoxCurrentMonth.Size = new System.Drawing.Size(80, 23);
            this.comboBoxCurrentMonth.TabIndex = 5;
            this.comboBoxCurrentMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentMonth_SelectedIndexChanged);
            // 
            // textBoxCurrentYear
            // 
            this.textBoxCurrentYear.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCurrentYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxCurrentYear.Location = new System.Drawing.Point(273, 124);
            this.textBoxCurrentYear.MaxLength = 4;
            this.textBoxCurrentYear.Name = "textBoxCurrentYear";
            this.textBoxCurrentYear.Size = new System.Drawing.Size(45, 23);
            this.textBoxCurrentYear.TabIndex = 6;
            this.textBoxCurrentYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCurrentYear.TextChanged += new System.EventHandler(this.textBoxCurrentYear_TextChanged);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.Firebrick;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelError.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelError.Location = new System.Drawing.Point(16, 229);
            this.labelError.Margin = new System.Windows.Forms.Padding(0);
            this.labelError.Name = "labelError";
            this.labelError.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.labelError.Size = new System.Drawing.Size(326, 41);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "Your Age is 0 years, 0 months and 0 days";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(187, 172);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // AgeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 284);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.textBoxCurrentYear);
            this.Controls.Add(this.textBoxBirthYear);
            this.Controls.Add(this.comboBoxCurrentMonth);
            this.Controls.Add(this.comboBoxBirthMonth);
            this.Controls.Add(this.comboBoxCurrentDay);
            this.Controls.Add(this.comboBoxBirthDay);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToDateCalender);
            this.Controls.Add(this.BirthDateCalender);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AgeCalculator";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Age Calculator";
            this.Load += new System.EventHandler(this.AgeCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DateTimePicker BirthDateCalender;
        private DateTimePicker ToDateCalender;
        private Label label2;
        private Label label3;
        private Button btnCalculate;
        private Label Result;
        private ComboBox comboBoxBirthDay;
        private ComboBox comboBoxBirthMonth;
        private TextBox textBoxBirthYear;
        private ComboBox comboBoxCurrentDay;
        private ComboBox comboBoxCurrentMonth;
        private TextBox textBoxCurrentYear;
        private Label labelError;
        private Button btnReset;
    }
}