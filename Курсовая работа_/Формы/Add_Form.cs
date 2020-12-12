using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Курсовая_работа_
{
    public partial class Add_Form : Form
    {
        public Add_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Track track = new Track(textBox1.Text, Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), checkBox1.Checked);

                db.tracks.Add(track);

                db.SaveChanges();
                MessageBox.Show("Данные внесены");

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Truck truck = new Truck(textBox5.Text, Convert.ToInt32(textBox6.Text),
                    Convert.ToInt32(textBox7.Text));

                db.trucks.Add(truck);

                db.SaveChanges();
                MessageBox.Show("Данные внесены");

            }

        }
        private void button6_Click(object sender, EventArgs e)
        {

            using (ApplicationContext db = new ApplicationContext())
            {

                Driver driver = new Driver(textBox8.Text, textBox9.Text,
                   textBox10.Text, Convert.ToInt32(textBox11.Text));

                db.drivers.Add(driver);

                db.SaveChanges();
                MessageBox.Show("Данные внесены");

            }

        }
    }
}
