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
    public partial class Calculate_Form : Form
    {
        Track track;
        Truck truck;
        Driver driver1;
        Driver driver2;
        double profit;
        DateTime outtime;
        DateTime dateTime1;
        public void zapisat()
        {
            DATA dATA;
            using (ApplicationContext db = new ApplicationContext())
            {
                if (driver2 == null)
                {
                    dATA = new DATA(track.Name, driver1.Name, "", truck.Name, (int)track.Payment, (int)profit, outtime, dateTime1, track.Isaward);
                }
                else
                {
                    dATA = new DATA(track.Name, driver1.Name, driver2.Name, truck.Name, (int)track.Payment, (int)profit, outtime, dateTime1, track.Isaward);
                }
                db.data.Add(dATA);

                db.SaveChanges();
                MessageBox.Show("Данные внесены");

            }
        }
        public double Calc(AbstractWorkDone abstractWork)
        {
            return track.Profit(truck,abstractWork);
        }
        public Calculate_Form()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.tracks.ToList();

                foreach (var u in users)
                {
                    comboBox1.Items.Add(u.Name);
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var drivers = db.drivers.ToList();
                foreach (var u in drivers)
                {
                    comboBox2.Items.Add(u.Name);
                    comboBox3.Items.Add(u.Name);
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var drivers = db.trucks.ToList();
                foreach (var u in drivers)
                {
                    
                    comboBox4.Items.Add(u.Name);
                }
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using ApplicationContext db = new ApplicationContext();
            var users = db.tracks.ToList();
            var u = users[comboBox1.SelectedIndex];
            track = new Track(u.Name, u.Distance, u.Day_value, u.Payment, u.Isaward);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using ApplicationContext db = new ApplicationContext();
            var users = db.drivers.ToList();
            var u = users[comboBox2.SelectedIndex];
            driver1 = new Driver(u.Name, u.Surname, u.Patronymic, u.Expirience);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using ApplicationContext db = new ApplicationContext();
            var users = db.drivers.ToList();
            var u = users[comboBox3.SelectedIndex];
            driver2 = new Driver(u.Name, u.Surname, u.Patronymic, u.Expirience);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime dateTime = DateTime.Now;
            
            if (driver2 != null)
            {
                TwoDriver twoDriver = new TwoDriver(driver1, driver2, track, dateTime);
                dateTime1 = twoDriver.date_arrive;
                profit = Calc(twoDriver);
                zapisat();
            }
            else
            {
                OneDriver oneDriver = new OneDriver(driver1, track, dateTime);
                dateTime1 = oneDriver.date_arrive;
                profit = Calc(oneDriver);
                zapisat();
            }
            

            MessageBox.Show($"Данные записаны{profit}");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            using ApplicationContext db = new ApplicationContext();
            var users = db.trucks.ToList();
            var u = users[comboBox4.SelectedIndex];
            truck = new Truck(u.Name, u.FuelConsumption, u.Tonnage);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                track.Isaward = checkBox1.Checked;
            }
            else
            {
                checkBox1.Checked = false;
                
                MessageBox.Show("Сначала введите маршрут");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            outtime = dateTimePicker1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int z;
            if ((Int32.TryParse(textBox1.Text, out z)))
            {

                using (ApplicationContext db = new ApplicationContext())
                {
                    comboBox4.Items.Clear();
                    var drivers = db.trucks.ToList();
                    foreach (var u in drivers)
                    {

                        comboBox4.Enabled = true;
                        if (textBox1.Text != "")
                            if (Convert.ToInt32(textBox1.Text) < u.Tonnage)
                                comboBox4.Items.Add(u.Name);
                    }
                }
            }
            else
            {
                textBox1.Clear();
                MessageBox.Show("Используйте только числа","FATAL ERROR");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
