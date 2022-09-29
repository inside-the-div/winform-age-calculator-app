using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace AgeCalculator
{
    public partial class AgeCalculator : Form
    {
        public AgeCalculator()
        {
            InitializeComponent();
        }
        public static bool LeapYear(int BirthYear)
        {
            if(BirthYear % 4 == 0)
            {
                if(BirthYear % 100 != 0)
                {
                    return true;
                }
                else
                {
                    if(BirthYear % 400 == 0)
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



        public int[] NoDayRegularMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int[] NoDayLeapMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int birthday = 0;
        public int currentday = 0;
        public int birthmonth = 0;
        public int currentmonth = 0;
        public int currentyear = 0;
        public int birthyear = 0;
        public int totaldaysPerMonth = 0;
        int count = 0;
        int count2 = 0;

        public void AddBirthDaysItem(ComboBox comboName)
        {

            comboName.Items.Clear();
            if (LeapYear(BirthDate.Value.Year))
            {
                totaldaysPerMonth = NoDayLeapMonth[BirthDate.Value.Month - 1];
            }
            else
            {
                totaldaysPerMonth = NoDayRegularMonth[BirthDate.Value.Month - 1];
            }

            for (int i = 1; i <= totaldaysPerMonth; i++)
            {
                comboName.Items.Add(i.ToString());
            }
            comboName.SelectedIndex = BirthDate.Value.Day-1;
        }


        public void AddCurrentDaysItem(ComboBox comboName)
        {
            int totaldays = 0;
            comboName.Items.Clear();
            if (LeapYear(ToDate.Value.Year))
            {
                totaldays = NoDayLeapMonth[ToDate.Value.Month - 1];
            }
            else
            {
                totaldays = NoDayRegularMonth[ToDate.Value.Month - 1];
            }

            for (int i = 1; i <= totaldays; i++)
            {
                comboName.Items.Add(i.ToString());
            }
            comboName.SelectedIndex = ToDate.Value.Day - 1;
        }


        private void AgeCalculator_Load(object sender, EventArgs e)
        {
            /*AddBirthDaysItem(comboBoxBirthDay);*/

            ToDate.Value = DateTime.Today;
            BirthDate.Value = DateTime.Today;
            comboBoxBirthMonth.SelectedIndex = BirthDate.Value.Month - 1;
            textBoxBirthYear.Text = (BirthDate.Value.Year).ToString();

            if (count == 0)
            {
                AddBirthDaysItem(comboBoxBirthDay);
                comboBoxBirthDay.SelectedIndex = BirthDate.Value.Day - 1;
                birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                birthmonth = comboBoxBirthMonth.SelectedIndex + 1;
                birthyear = int.Parse(textBoxBirthYear.Text);
                count++;
            }
            
            comboBoxCurrentMonth.SelectedIndex = ToDate.Value.Month - 1;
            textBoxCurrentYear.Text = (ToDate.Value.Year).ToString();
            comboBoxCurrentDay.SelectedIndex = ToDate.Value.Day - 1;

            if (count2 == 0)
            {                
                currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                currentyear = int.Parse(textBoxCurrentYear.Text);
                currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                count++;
            }

        }


        public void clear()
        {
            ToDate.Value = DateTime.Today;
            BirthDate.Value = DateTime.Today;
        }


        public string MonthDateError()
        {
            string error = "";
            int BirthYear = BirthDate.Value.Year;
            int CurrentYear = ToDate.Value.Year;
            int BirthMonth = BirthDate.Value.Month;
            int CurrentMonth = ToDate.Value.Month;
            int BirthDateDay = BirthDate.Value.Day;
            int CurrentDay = ToDate.Value.Day;
            if (BirthYear == CurrentYear)
            {
                if (BirthMonth > CurrentMonth)
                {
                    error = "Your birth month crosses the current month!!!";

                    return error;
                }
                else if (BirthMonth == CurrentMonth)
                {
                    if (BirthDateDay > CurrentDay)
                    {
                        error = "Your birth day crosses the current day!!!";

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
            string Birthday = BirthDate.Value.ToShortDateString();
            string Targetday = ToDate.Value.ToShortDateString();
            int BirthYear = BirthDate.Value.Year;
            int CurrentYear = ToDate.Value.Year;
            int BirthMonth = BirthDate.Value.Month;
            int CurrentMonth = ToDate.Value.Month;
            int BirthDateDay = BirthDate.Value.Day;
            int CurrentDay = ToDate.Value.Day;
            
            
            if (int.Parse(textBoxBirthYear.Text) <= 1753 || int.Parse(textBoxCurrentYear.Text) <= 1753)
            {
                MessageBox.Show("You have to set year bigger then 1753");
                clear();
                return;
            }
            else if (int.Parse(textBoxBirthYear.Text) >= 9998 || int.Parse(textBoxCurrentYear.Text) >= 9998)
            {
                MessageBox.Show("You have to set year smaller then 9998");
                clear();
                return;
            }
            else if (Birthday == today)
            {
                MessageBox.Show("You are born today, Happy Birthday To You");
                clear();
                return;
            }
            else if (BirthYear > CurrentYear)
            {
                MessageBox.Show("Your birth year crosses the current year!!!");
                clear();
                return;
            }
            else if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage);
                clear();
                return;
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

                if (BirthMonth > CurrentMonth)
                {
                    CurrentYear = CurrentYear - 1;
                    CurrentMonth = CurrentMonth + 12;
                }
                int CalculatedDay = (CurrentDay - BirthDateDay) + 1;
                int CalculatedMonth = CurrentMonth - BirthMonth;
                int CalculatedYear = CurrentYear - BirthYear;
                int TotalDays = (((CalculatedYear * 12) + CalculatedMonth) * 30) + CalculatedDay;
                int TotalMonths = ((CalculatedYear * 12) + CalculatedMonth);
                int TotalWeeks = TotalDays / 7;
                int WeekDays = TotalDays - TotalWeeks * 7;
                int TotalHour = TotalDays * 24;
                int TotalMinute = TotalHour * 60;
                int TotalSecond = TotalMinute * 60;
                Result.Text = "Your Age is " + CalculatedYear + " years, " + CalculatedMonth + " months and " + CalculatedDay + " days";

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
                BirthDate.Value = new DateTime(birthyear, birthmonth, birthday);
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
                BirthDate.Value = new DateTime(birthyear, birthmonth, birthday);
                AddBirthDaysItem(comboBoxBirthDay);        
            }

        }

        private void BirthDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxBirthYear.Text = (BirthDate.Value.Year).ToString();
            comboBoxBirthMonth.SelectedIndex = BirthDate.Value.Month - 1;
            comboBoxBirthDay.SelectedIndex = BirthDate.Value.Day - 1;            
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxCurrentYear.Text = (ToDate.Value.Year).ToString();
            comboBoxCurrentMonth.SelectedIndex = ToDate.Value.Month - 1;
            comboBoxCurrentDay.SelectedIndex = ToDate.Value.Day - 1;            
        }

        private void comboBoxCurrentDay_SelectedIndexChanged(object sender, EventArgs e)
        {           

            if (currentday != 0 && currentmonth != 0 && currentyear.ToString() != "0")
            {
                currentyear = int.Parse(textBoxCurrentYear.Text);
                currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;                
                currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                SelectedCurrentDayUpgrade(currentyear);

                ToDate.Value = new DateTime(currentyear, currentmonth, currentday);
            }
            else
            {
                return;
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
                ToDate.Value = new DateTime(currentyear, currentmonth, currentday);
                AddCurrentDaysItem(comboBoxCurrentDay);
            }
            else
            {
                return;
            }
        }

        private void textBoxBirthYear_TextChanged(object sender, EventArgs e)
        {            
            if (birthday != 0 && birthmonth != 0 && birthyear != 0 && textBoxBirthYear.Text != "")
            {
                if (int.Parse(textBoxBirthYear.Text) <= 1753 || int.Parse(textBoxBirthYear.Text) >= 9998 || textBoxBirthYear.Text == "")                    
                {
                    if ((textBoxBirthYear.Text).Length == 4)
                        MessageBox.Show("year must be biger then 1753 and smaller then 9998");
                    
                }
                else
                {
                    birthyear = int.Parse(textBoxBirthYear.Text);                    
                    birthmonth = comboBoxBirthMonth.SelectedIndex + 1;                    
                    birthday = int.Parse(comboBoxBirthDay.SelectedItem.ToString());
                    SelectedBirthDayUpgrade(birthyear);
                    BirthDate.Value = new DateTime(birthyear, birthmonth, birthday);                   
                    AddBirthDaysItem(comboBoxBirthDay);
                    
                }
            }
            
        }

        private void textBoxCurrentYear_TextChanged(object sender, EventArgs e)
        {            
            if (currentday != 0 && currentmonth != 0 && currentyear.ToString() != "0" && textBoxCurrentYear.Text != "")
            {
                if (int.Parse(textBoxCurrentYear.Text) <= 1753 || int.Parse(textBoxCurrentYear.Text) >= 9998 || textBoxCurrentYear.Text == "")
                {
                    if((textBoxCurrentYear.Text).Length == 4)
                    {
                        MessageBox.Show("year must be biger then 1753 and smaller then 9998");
                    }                   
                }
                else
                {
                    currentyear = int.Parse(textBoxCurrentYear.Text);
                    currentmonth = comboBoxCurrentMonth.SelectedIndex + 1;
                    currentday = int.Parse(comboBoxCurrentDay.SelectedItem.ToString());
                    SelectedCurrentDayUpgrade(currentyear);
                    ToDate.Value = new DateTime(currentyear, currentmonth, currentday);
                    AddCurrentDaysItem(comboBoxCurrentDay);
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
    }
}