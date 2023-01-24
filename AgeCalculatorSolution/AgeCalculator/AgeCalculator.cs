using System.Text.Json;
using System.Xml.Linq;

namespace AgeCalculator
{
    public partial class AgeCalculator : Form
    {
        public int[] NoDayRegularMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int[] NoDayLeapMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int birthday = 0;
        public int currentday = 0;
        public int birthmonth = 0;
        public int currentmonth = 0;
        public int currentyear = 0;
        public int birthyear = 0;
        public int totaldaysPerMonth = 0;
        string fileName;
        int count = 0;
        int count2 = 0;
        List<JsonItems> ResultDateList = new List<JsonItems>();
        List<JsonItems> DateList = new List<JsonItems>();

        public AgeCalculator()
        {
            InitializeComponent();
        }

        public void DateInitialize()
        {
            ToDateCalender.Value = DateTime.Today;
            BirthDateCalender.Value = DateTime.Today;
        }
        public static bool LeapYear(int BirthYear)
        {
            if (BirthYear % 4 == 0)
            {
                if (BirthYear % 100 != 0)
                {
                    return true;
                }
                else
                {
                    if (BirthYear % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public void AddBirthDaysItem()
        {
            comboBoxBirthDay.Items.Clear();
            if (LeapYear(BirthDateCalender.Value.Year))
            {
                totaldaysPerMonth = NoDayLeapMonth[BirthDateCalender.Value.Month - 1];
            }
            else
            {
                totaldaysPerMonth = NoDayRegularMonth[BirthDateCalender.Value.Month - 1];
            }

            for (int i = 1; i <= totaldaysPerMonth; i++)
            {
                comboBoxBirthDay.Items.Add(i.ToString());
            }
            comboBoxBirthDay.SelectedIndex = BirthDateCalender.Value.Day - 1;
        }

        public void AddCurrentDaysItem()
        {
            comboBoxCurrentDay.Items.Clear();
            if (LeapYear(ToDateCalender.Value.Year))
            {
                totaldaysPerMonth = NoDayLeapMonth[ToDateCalender.Value.Month - 1];
            }
            else
            {
                totaldaysPerMonth = NoDayRegularMonth[ToDateCalender.Value.Month - 1];
            }

            for (int i = 1; i <= totaldaysPerMonth; i++)
            {
                comboBoxCurrentDay.Items.Add(i.ToString());
            }
            comboBoxCurrentDay.SelectedIndex = ToDateCalender.Value.Day - 1;
        }

        private void AgeCalculator_Load(object sender, EventArgs e)
        {
            lblmoreoutput.Text = "More Output";
            LblCheckboxOutput.Hide();
            Result.Hide();
            labelError.Hide();
            DateInitialize();
            comboBoxBirthMonth.SelectedIndex = BirthDateCalender.Value.Month - 1;
            textBoxBirthYear.Text = (BirthDateCalender.Value.Year).ToString();
            if (count == 0)
            {
                AddBirthDaysItem();
                comboBoxBirthDay.SelectedIndex = BirthDateCalender.Value.Day - 1;
                birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                birthmonth = comboBoxBirthMonth.SelectedIndex + 1;
                birthyear = int.Parse(textBoxBirthYear.Text);
                count++;
            }

            comboBoxCurrentMonth.SelectedIndex = ToDateCalender.Value.Month - 1;
            textBoxCurrentYear.Text = (ToDateCalender.Value.Year).ToString();
            comboBoxCurrentDay.SelectedIndex = ToDateCalender.Value.Day - 1;

            if (count2 == 0)
            {
                currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                currentyear = int.Parse(textBoxCurrentYear.Text);
                currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                count++;
            }
        }

        public string MonthDateError()
        {
            string error = "";
            int BirthYear = BirthDateCalender.Value.Year;
            int CurrentYear = ToDateCalender.Value.Year;
            int BirthMonth = BirthDateCalender.Value.Month;
            int CurrentMonth = ToDateCalender.Value.Month;
            int BirthDateDay = BirthDateCalender.Value.Day;
            int CurrentDay = ToDateCalender.Value.Day;
            if (BirthYear == CurrentYear)
            {
                if (BirthMonth > CurrentMonth)
                {
                    error = "To Date can’t be greater than your Birth Date!!!";

                    return error;
                }
                else if (BirthMonth == CurrentMonth)
                {
                    if (BirthDateDay > CurrentDay)
                    {
                        error = "To Date can’t be greater than your Birth Date!!!";

                        return error;
                    }
                }
            }
            return error;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DateTime todaydate = DateTime.Today;
            string ErrorMessage = MonthDateError();
            string today = todaydate.ToShortDateString();
            string Birthday = BirthDateCalender.Value.ToShortDateString();
            string Targetday = ToDateCalender.Value.ToShortDateString();
            int BirthYear = BirthDateCalender.Value.Year;
            int CurrentYear = ToDateCalender.Value.Year;
            int BirthMonth = BirthDateCalender.Value.Month;
            int CurrentMonth = ToDateCalender.Value.Month;
            int BirthDateDay = BirthDateCalender.Value.Day;
            int CurrentDay = ToDateCalender.Value.Day;
            if (DateList.Count != 0)
            {
                for (int i = 0; i < DateList.Count; i++)
                {
                    calculateAgeFromFile(DateList[i].birthDate, DateList[i].toDate);
                }
                string filepath = Path.GetDirectoryName(fileName);
                Stream createStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Json files (*.json)|*.json";
                saveFileDialog1.FilterIndex = 4;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((createStream = saveFileDialog1.OpenFile()) != null)
                    {
                        JsonSerializer.SerializeAsync(createStream, ResultDateList);
                        createStream.Close();
                    }
                }
            }
            else if (int.Parse(textBoxBirthYear.Text) <= 1753 || int.Parse(textBoxCurrentYear.Text) <= 1753)
            {
                Result.Hide();
                labelError.Hide();
                labelError.Text = ("You have to set year bigger then 1753");
                labelError.Show();
            }
            else if (int.Parse(textBoxBirthYear.Text) >= 9998 || int.Parse(textBoxCurrentYear.Text) >= 9998)
            {
                Result.Hide();
                labelError.Hide();
                labelError.Text = ("You have to set year smaller then 9998");
                labelError.Show();
            }
            else if (BirthDateCalender.Value.Year == ToDateCalender.Value.Year && BirthDateCalender.Value.Month == ToDateCalender.Value.Month && BirthDateCalender.Value.Day == ToDateCalender.Value.Day)
            {
                Result.Hide();
                labelError.Hide();
                labelError.Text = ("0 year, 0 month, 0 day");
                labelError.Show();
            }
            else if (BirthYear > CurrentYear)
            {
                Result.Hide();
                labelError.Hide();
                labelError.Text = ("Your birth year crosses the current year!!!");
                labelError.Show();
            }
            else if (ErrorMessage != "")
            {
                Result.Hide();
                labelError.Hide();
                labelError.Text = ErrorMessage;
                labelError.Show();
            }
            else
            {
                if (BirthDateDay > CurrentDay)
                {
                    if (LeapYear(BirthYear))
                    {
                        CurrentDay = CurrentDay + NoDayLeapMonth[CurrentMonth - 1];
                        CurrentMonth = CurrentMonth - 1;
                    }
                    else
                    {
                        CurrentDay = CurrentDay + NoDayRegularMonth[CurrentMonth - 1];
                        CurrentMonth = CurrentMonth - 1;
                    }
                }
                int  LeapYearCount = 0;
                for (int i = BirthYear; i <= CurrentYear; i++)
                {
                    if (LeapYear(i))
                    {
                        LeapYearCount++;
                    }                    
                }

                if (BirthMonth > CurrentMonth)
                {
                    CurrentYear = CurrentYear - 1;
                    CurrentMonth = CurrentMonth + 12;
                }
                int CalculatedDay = (CurrentDay - BirthDateDay);
                int CalculatedMonth = CurrentMonth - BirthMonth;
                int CalculatedYear = CurrentYear - BirthYear;
                int TotalDays = ((CalculatedYear * 365) + CalculatedMonth * 30) + CalculatedDay + LeapYearCount;
                int TotalMonths = ((CalculatedYear * 12) + CalculatedMonth);
                int TotalWeeks = TotalDays / 7;
                int WeekDays = TotalDays - TotalWeeks * 7;
                int TotalHour = TotalDays * 24;
                int TotalMinute = TotalHour * 60;
                double TotalSecond = Convert.ToDouble(TotalMinute * 60);
                for (int i = 0; i < 12; i++)
                {
                    if (CalculatedDay == NoDayLeapMonth[ToDateCalender.Value.Month] || CalculatedDay == NoDayRegularMonth[ToDateCalender.Value.Month])
                    {
                        CalculatedDay = 0;
                        CalculatedMonth += 1;
                        if (CalculatedMonth == 12)
                        {
                            CalculatedMonth = 0;
                            CalculatedYear += 1;
                        }
                    }
                }
                string moreOutputResult = "";
                for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
                {
                    if (checkedListBox.CheckedItems[i] == "Months")
                    {
                        moreOutputResult += "Or, " + TotalMonths + " Months and " + CalculatedDay + " Days.\n";
                    }
                    else if (checkedListBox.CheckedItems[i] == "Weeks")
                    {
                        moreOutputResult += "Or, " + TotalWeeks + " Weeks and " + WeekDays + " Days.\n";
                    }
                    else if (checkedListBox.CheckedItems[i] == "Days")
                    {
                        moreOutputResult += "Or, " + TotalDays + " Days.\n";
                    }
                    else if (checkedListBox.CheckedItems[i] == "Hours")
                    {
                        moreOutputResult += "Or, " + TotalHour + " Hours.\n";
                    }
                    else if (checkedListBox.CheckedItems[i] == "Minutes")
                    {
                        moreOutputResult += "Or, " + TotalMinute + " Minutes.\n";
                    }
                    else if (checkedListBox.CheckedItems[i] == "Seconds")
                    {
                        moreOutputResult += "Or, " + TotalSecond + " Seconds.\n";
                    }
                }
                Result.Hide();
                labelError.Hide();
                LblCheckboxOutput.Hide();
                Result.Text = "Your Age is " + CalculatedYear + " years, " + CalculatedMonth + " months and " + CalculatedDay + " days";
                Result.Show();
                LblCheckboxOutput.Text = moreOutputResult;
                if (moreOutputResult != "")
                {
                    LblCheckboxOutput.Show();
                }
            }
        }



        private void comboBoxBirthDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (birthday != 0 && birthmonth != 0 && birthyear != 0)
            {
                birthyear = int.Parse(textBoxBirthYear.Text);
                birthmonth = comboBoxBirthMonth.SelectedIndex + 1;
                birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                SelectedBirthDayUpgrade(birthyear);
                BirthDateCalender.Value = new DateTime(birthyear, birthmonth, birthday);
            }
        }

        private void comboBoxBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (birthday != 0 && birthmonth != 0 && birthyear != 0)
            {
                birthyear = int.Parse(textBoxBirthYear.Text);
                birthmonth = comboBoxBirthMonth.SelectedIndex + 1;
                birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                SelectedBirthDayUpgrade(birthyear);
                BirthDateCalender.Value = new DateTime(birthyear, birthmonth, birthday);
                AddBirthDaysItem();
            }
        }

        private void BirthDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxBirthYear.Text = (BirthDateCalender.Value.Year).ToString();
            comboBoxBirthMonth.SelectedIndex = BirthDateCalender.Value.Month - 1;
            comboBoxBirthDay.SelectedIndex = BirthDateCalender.Value.Day - 1;
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxCurrentYear.Text = (ToDateCalender.Value.Year).ToString();
            comboBoxCurrentMonth.SelectedIndex = ToDateCalender.Value.Month - 1;
            comboBoxCurrentDay.SelectedIndex = ToDateCalender.Value.Day - 1;
        }

        private void comboBoxCurrentDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentday != 0 && currentmonth != 0 && currentyear.ToString() != "0")
            {
                currentyear = int.Parse(textBoxCurrentYear.Text);
                currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                SelectedCurrentDayUpgrade(currentyear);
                ToDateCalender.Value = new DateTime(currentyear, currentmonth, currentday);
            }
        }

        private void comboBoxCurrentMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentday != 0 && currentmonth != 0 && currentyear.ToString() != "0")
            {
                currentyear = int.Parse(textBoxCurrentYear.Text);
                currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                SelectedCurrentDayUpgrade(currentyear);
                ToDateCalender.Value = new DateTime(currentyear, currentmonth, currentday);
                AddCurrentDaysItem();
            }
        }

        private void textBoxBirthYear_TextChanged(object sender, EventArgs e)
        {
            if (birthday != 0 && birthmonth != 0 && birthyear != 0 && textBoxBirthYear.Text != "")
            {
                if (int.Parse(textBoxBirthYear.Text) <= 1753 || int.Parse(textBoxBirthYear.Text) >= 9998 || textBoxBirthYear.Text == "")
                {
                    if ((textBoxBirthYear.Text).Length == 4)
                    {
                        Result.Hide();
                        labelError.Hide();
                        labelError.Text = ("year must be biger then 1753 and smaller then 9998");
                        labelError.Show();
                    }
                }
                else
                {
                    birthyear = int.Parse(textBoxBirthYear.Text);
                    birthmonth = comboBoxBirthMonth.SelectedIndex + 1;
                    birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                    SelectedBirthDayUpgrade(birthyear);
                    BirthDateCalender.Value = new DateTime(birthyear, birthmonth, birthday);
                    AddBirthDaysItem();
                }
            }
        }

        private void textBoxCurrentYear_TextChanged(object sender, EventArgs e)
        {
            if (currentday != 0 && currentmonth != 0 && currentyear.ToString() != "0" && textBoxCurrentYear.Text != "")
            {
                if (int.Parse(textBoxCurrentYear.Text) <= 1753 || int.Parse(textBoxCurrentYear.Text) >= 9998 || textBoxCurrentYear.Text == "")
                {
                    if ((textBoxCurrentYear.Text).Length == 4)
                    {
                        Result.Hide();
                        labelError.Hide();
                        labelError.Text = ("year must be biger then 1753 and smaller then 9998");
                        labelError.Show();
                    }
                }
                else
                {
                    currentyear = int.Parse(textBoxCurrentYear.Text);
                    currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                    currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                    SelectedCurrentDayUpgrade(currentyear);
                    ToDateCalender.Value = new DateTime(currentyear, currentmonth, currentday);
                    AddCurrentDaysItem();
                }
            }
        }

        private void textBoxBirthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        public void SelectedCurrentDayUpgrade(int year)
        {
            if (LeapYear(year))
            {
                if (currentday > NoDayLeapMonth[birthmonth - 1])
                {
                    currentday = NoDayLeapMonth[birthmonth - 1];
                }
            }
            else
            {
                if (currentday > NoDayRegularMonth[birthmonth - 1])
                {
                    currentday = NoDayRegularMonth[birthmonth - 1];
                }
            }
        }
        public void SelectedBirthDayUpgrade(int year)
        {
            if (LeapYear(year))
            {
                if (birthday > NoDayLeapMonth[birthmonth - 1])
                {
                    birthday = NoDayLeapMonth[birthmonth - 1];
                }
            }
            else
            {
                if (birthday > NoDayRegularMonth[birthmonth - 1])
                {
                    birthday = NoDayRegularMonth[birthmonth - 1];
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DateInitialize();
            Result.Hide();
            labelError.Hide();
            LblCheckboxOutput.Hide();
            Size = new Size(503, 298);
        }

        public void calculateAgeFromFile(string Filebirthdate, string Filetodate)
        {
            string[] FileBirthDate = Filebirthdate.Split('/');
            string[] FileToDate = Filetodate.Split('/');
            int FileBirthDay = int.Parse(FileBirthDate[0]);
            int FileBirthMOnth = int.Parse(FileBirthDate[1]);
            int FileBirthYear = int.Parse(FileBirthDate[2]);
            int FileToDay = int.Parse(FileToDate[0]);
            int FileToMOnth = int.Parse(FileToDate[1]);
            int FileToYear = int.Parse(FileToDate[2]);

            if (FileBirthDay > FileToDay)
            {
                if (LeapYear(FileBirthYear))
                {
                    FileToDay = FileToDay + NoDayLeapMonth[FileToMOnth - 1];
                    FileToMOnth = FileToMOnth - 1;
                }
                else
                {
                    FileToDay = FileToDay + NoDayRegularMonth[FileToMOnth - 1];
                    FileToMOnth = FileToMOnth - 1;
                }
            }

            if (FileBirthMOnth > FileToMOnth)
            {
                FileToYear = FileToYear - 1;
                FileToMOnth = FileToMOnth + 12;
            }
            int CalculatedDay = (FileToDay - FileBirthDay);
            int CalculatedMonth = FileToMOnth - FileBirthMOnth;
            int CalculatedYear = FileToYear - FileBirthYear;
            int TotalDays = (((CalculatedYear * 12) + CalculatedMonth) * 30) + CalculatedDay;
            int TotalMonths = ((CalculatedYear * 12) + CalculatedMonth);
            int TotalWeeks = TotalDays / 7;
            int WeekDays = TotalDays - TotalWeeks * 7;
            int TotalHour = TotalDays * 24;
            int TotalMinute = TotalHour * 60;
            double TotalSecond = Convert.ToDouble(TotalMinute * 60);
            for (int i = 0; i < 12; i++)
            {
                if (CalculatedDay == NoDayLeapMonth[FileToMOnth-1] || CalculatedDay == NoDayRegularMonth[FileToMOnth-1])
                {
                    CalculatedDay = 0;
                    CalculatedMonth += 1;
                    if (CalculatedMonth == 12)
                    {
                        CalculatedMonth = 0;
                        CalculatedYear += 1;
                    }
                }
            }
            string moreOutputResult = "";
            for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
            {
                if (checkedListBox.CheckedItems[i] == "Months")
                {
                    moreOutputResult += " And " + TotalMonths + " Months and " + CalculatedDay + " Days.";
                }
                else if (checkedListBox.CheckedItems[i] == "Weeks")
                {
                    moreOutputResult += " And " + TotalWeeks + " Weeks and " + WeekDays + " Days.";
                }
                else if (checkedListBox.CheckedItems[i] == "Days")
                {
                    moreOutputResult += " And " + TotalDays + " Days.";
                }
                else if (checkedListBox.CheckedItems[i] == "Hours")
                {
                    moreOutputResult += " And " + TotalHour + " Hours.";
                }
                else if (checkedListBox.CheckedItems[i] == "Minutes")
                {
                    moreOutputResult += " And " + TotalMinute + " Minutes.";
                }
                else if (checkedListBox.CheckedItems[i] == "Seconds")
                {
                    moreOutputResult += " And" + TotalSecond + " Seconds.";
                }
            }
            string result = Result.Text = "Age = " + CalculatedYear + " years, " + CalculatedMonth + " months and " + CalculatedDay + " days";
            if(moreOutputResult != "")
            {
                result = result + moreOutputResult;
            }
            string FinalResult = "birthDate = " + Filebirthdate + "\ntoDate = " + Filetodate +"\n"+ result;
           //ResultDateList.Add(FinalResult);
            ResultDateList.Add(new JsonItems()
            {
                birthDate = Filebirthdate,
                toDate = Filetodate,
                Age = result
            });
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            FD.Filter = "Json files (*.json)|*.json";
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                fileName = FD.FileName;
                string json = System.IO.File.ReadAllText(fileName);
                DateList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonItems>>(json);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}