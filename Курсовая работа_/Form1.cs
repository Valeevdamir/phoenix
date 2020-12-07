using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Курсовая_работа_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                //Track track = new Track("KazanMoscow", 800, 2, 35000, true);
                //Track track1 = new Track("KazanUral", 1500, 2, 50000, false);
                //Track track2 = new Track("KazanNovosib", 5000, 2, 100000, true);
                //Track track3 = new Track("KazanSpb", 1400, 2, 70000, true);


                //db.tracks.Add(track);
                //db.tracks.Add(track1);
                //db.tracks.Add(track2);
                //db.tracks.Add(track3);

                //db.SaveChanges();

                var users = db.tracks.ToList();

                foreach (var u in users)
                {
                    data.Rows.Add(u.Name, u.Distance, u.Day_value, u.Payment, u.Isaward);
                }
            }
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
    }
}
