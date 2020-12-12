using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace Курсовая_работа_
{
    public partial class Report : Form
    {
        DateTime firsTime;
        DateTime lastTime;
        int track_value;
        int profit;

        public Report()
        {
  
            InitializeComponent();
            dataGridView1.Columns.Add("first", "Рейс");
            dataGridView1.Columns.Add("second", "Ставка");
            dataGridView1.Columns.Add("third", "Чистая прибыль с рейса");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            track_value = 0;
            profit = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.data.ToList();

                
                foreach (var u in users)
                {
                    if(u.arrived_time>firsTime && u.arrived_time<lastTime)
                    {
                        track_value++;
                        profit += u.profit;
                        dataGridView1.Rows.Add(u.track, u.payment, u.profit);
                    }
                    

                }
                dataGridView1.Rows.Add("", "", "");
                dataGridView1.Rows.Add("","Общая чистая прибыль",profit);
                dataGridView1.Rows.Add("", "Всего рейсов", track_value);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            firsTime = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            lastTime = dateTimePicker2.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
