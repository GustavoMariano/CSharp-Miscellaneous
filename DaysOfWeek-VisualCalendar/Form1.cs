using System;
using System.Windows.Forms;

namespace DaysOfWeek_VisualCalendar
{
    public partial class Form1 : Form
    {
        private readonly DateTime date;
        public Form1()
        {
            date = DateTime.Now;
            InitializeComponent();
            SetLabelsWithDaysOfWeek();
            DisplayTasks();
        }

        private void DisplayTasks()
        {
            for (int i = 0; i < 7; i++)
            {
                DateTime dateToSelecthInDB = date.AddDays(i);
                UserControlDays userCDays = new(dateToSelecthInDB);
                flowLayoutPanel1.Controls.Add(userCDays);
            }
        }

        private void SetLabelsWithDaysOfWeek()
        {
            label1.Text = date.AddDays(0).DayOfWeek.ToString();
            label2.Text = date.AddDays(1).DayOfWeek.ToString();
            label3.Text = date.AddDays(2).DayOfWeek.ToString();
            label4.Text = date.AddDays(3).DayOfWeek.ToString();
            label5.Text = date.AddDays(4).DayOfWeek.ToString();
            label6.Text = date.AddDays(5).DayOfWeek.ToString();
            label7.Text = date.AddDays(6).DayOfWeek.ToString();
        }
    }
}
