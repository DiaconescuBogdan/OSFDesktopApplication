using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSFProject
{
    public partial class AvailableCarsList : Form
    {
        public Entities.Reservation reservation = new Entities.Reservation();
        public Entities.Car car = new Entities.Car();

        public Entities.MyModel myModel = new Entities.MyModel();
        public AvailableCarsList()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }

        private void Location_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime endDate = Convert.ToDateTime(dateTimePicker1.Text);
            string location = textLocation.Text;
            if((startDate < endDate) || (startDate < DateTime.Now))
            {

                using (var myModel = new Entities.MyModel())
                {
                    if (myModel.Reservations.Where(c => c.Location == location).Any())
                    {
                        reservation = myModel.Reservations.Where(c => (c.EndDate >= startDate || c.StartDate <= endDate)
                        && c.Location == location).First();
                        dataGridView1.DataSource = myModel.Cars.Where(c => c.Location == location && c.CarID != reservation.CarID).ToList();
                    }
                    else
                    {
                        dataGridView1.DataSource = myModel.Cars.Where(c => c.Location == location).ToList();
                    }


                }
            }
        }

        private void AvailableCarsList_Load(object sender, EventArgs e)
        {

        }
    }
}
