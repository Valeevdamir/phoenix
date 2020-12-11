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
    public partial class Main_Form : Form
    {
        public Main_Form()
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
                data.Rows.Clear();

                data.Columns[0].HeaderText = "Маршрут";
                data.Columns[1].HeaderText = "Водитель";
                data.Columns[2].HeaderText = "Второй водитель";
                data.Columns[3].HeaderText = "Машина";
                data.Columns[4].HeaderText = "Ставка";
                data.Columns[5].HeaderText = "Чистая прибыль";
                data.Columns[6].HeaderText = "Дата отправки";
                data.Columns[7].HeaderText = "Дата прибытия";
                data.Columns[8].HeaderText = "Премия за маршрут";
                var users = db.data.ToList();

                foreach (var u in users)
                {
                    data.Rows.Add(u.track,u.driver,u.driver2,u.truck,u.payment,u.profit,u.departure_time,u.arrived_time, u.isaward);
                }
            }
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            
            data.Columns[0].HeaderText = "Имя";
            data.Columns[1].HeaderText = "Фамилия";
            data.Columns[2].HeaderText = "Отчество";
            data.Columns[3].HeaderText = "Опыт работы";
            data.Columns[4].HeaderText = "";
            data.Columns[5].HeaderText = "";
            data.Columns[6].HeaderText = "";
            data.Columns[7].HeaderText = "";
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.drivers.ToList();

                foreach (var u in users)
                {
                    data.Rows.Add(u.Name, u.Surname, u.Patronymic, u.Expirience);
                }
            }
        }
       

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            data.Columns[0].HeaderText = "Марка";
            data.Columns[1].HeaderText = "Расход топлива";
            data.Columns[2].HeaderText = "Грузоподъемность";
            data.Columns[3].HeaderText = "";
            data.Columns[4].HeaderText = "";
            data.Columns[5].HeaderText = "";
            data.Columns[6].HeaderText = "";
            data.Columns[7].HeaderText = "";
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.trucks.ToList();

                foreach (var u in users)
                {
                    data.Rows.Add(u.Name, u.FuelConsumption,u.Tonnage);
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Calculate_Form newForm = new Calculate_Form();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTrack_Form newForm = new AddTrack_Form();
            newForm.Show();
        }
    }
}
