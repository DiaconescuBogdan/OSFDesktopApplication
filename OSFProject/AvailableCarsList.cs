using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public string conString = @"Data Source=(localdb)\MSSQLLocalDB;initial catalog = OSFAcademy; integrated security = True";

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

            //dataGridView1.DataSource = GetAvailableCars();
            DateTime startDate = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime endDate = Convert.ToDateTime(dateTimePicker1.Text);
            string location = textLocation.Text;

            if ((startDate < endDate) || (startDate < DateTime.Now))
            {

                using (var myModel = new Entities.MyModel())
                {
                    if (myModel.Reservations.Where(c => c.Location == location).Any())
                    {
                        reservation = myModel.Reservations.Where(c => (c.EndDate >= startDate || c.StartDate <= endDate)
                        && c.Location == location).First();
                        dataGridView1.DataSource = myModel.Cars.Where(c => c.Location == location && c.CarID != reservation.CarID).ToList();
                    }
                    else if(myModel.Reservations.Where(c => c.Location != location).Any())
                    {
                        
                        dataGridView1.DataSource = myModel.Cars.Where(c => c.Location == location).ToList();
                    }
                    else
                    {
                        MessageBox.Show("No car available!");
                    }


                }
            }
            else
            {
                MessageBox.Show("Please insert valid dates!");
            }

        }

        private void AvailableCarsList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private DataTable GetAvailableCars()
        {
            DataTable dataTable = new DataTable();
            string location = textLocation.Text;
            DateTime startDate = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime endDate = Convert.ToDateTime(dateTimePicker1.Text);

            using (SqlConnection con = new SqlConnection(conString))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Cars.Plate, Cars.Manufacturer, Cars.Model, Cars.Location" +
                    " FROM Cars JOIN Reservations ON (Cars.CarID = Reservations.CarID AND Reservations.Location = '" + location + "' AND " +
                    "('" + startDate + "' > Reservations.EndDate OR '" + endDate + "' < Reservations.StartDate)OR(Cars.CarID != Reservations.CarID" +
                    "AND Cars.Location ='" + location + "')) ", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader == null)
                    {
                        MessageBox.Show("Please insert another date time");
                    }
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }
    }
}
