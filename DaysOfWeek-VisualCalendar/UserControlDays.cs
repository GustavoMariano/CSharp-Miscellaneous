using System;
using System.Windows.Forms;

namespace DaysOfWeek_VisualCalendar
{
    public partial class UserControlDays : UserControl
    {
        public UserControlDays(DateTime date) //Date to select Tasks in DB
        {
            InitializeComponent();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn { 
                DataPropertyName = "Task", HeaderText = "Task" }
            );
            dataGridView1.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Rows.Add($"Test {date}");
        }
    }
}
