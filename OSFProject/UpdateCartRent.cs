using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OSFProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSFProject
{
    public partial class UpdateCartRent : Form
    {
        public Entities.Reservation reservation = new Entities.Reservation();
        public Entities.Car car = new Entities.Car();
        public Entities.Customer customer = new Entities.Customer();

        public Entities.MyCustomerModel customerModel = new Entities.MyCustomerModel();
        public Entities.MyModel myModel = new Entities.MyModel();
        public UpdateCartRent()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }

        private void UpdateCartRent_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //using (var model = new MyModel())
            //{
                //reservation.ReservationID = Convert.ToInt32(textReservationID.Text);

                int reservationID = Convert.ToInt32(textReservationID.Text);
                if (myModel.Reservations.Where(r => r.ReservationID == reservationID).FirstOrDefault() != null)
                {

                //reservation.ReservationID = reservationID;
                    reservation = myModel.Reservations.Where(r => r.ReservationID == reservationID).FirstOrDefault();
                    string plate = textCartPlate.Text;
                    string location = textCity.Text;

                    if (myModel.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault() != null)
                    {
                    
                        car = myModel.Cars.AsNoTracking().Where(c => c.Plate == plate && c.Location == location).FirstOrDefault();
                        reservation.CarID = car.CarID;
                        reservation.Location = car.Location;
                    }
                    else
                    {   
                        MessageBox.Show("Invalid car plate or location!");
                        return;
                    }

                    int customerID = Convert.ToInt32(textClientID.Text);
                    if (customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault() != null)
                    {
                        customer = customerModel.Customers.AsNoTracking().Where(c => c.CostumerID == customerID).FirstOrDefault();
                        reservation.CostumerID = customer.CostumerID;
                    }
                    else
                    {
                        MessageBox.Show("Invalid customer id!");
                    return;
                    }
                    reservation.StartDate = Convert.ToDateTime(dtStartDate.Text);
                    reservation.EndDate = Convert.ToDateTime(dtEndDate.Text);

                using (var model = new MyModel())
                {
                    
                    myModel.Entry(reservation).State = System.Data.Entity.EntityState.Modified;

                    try
                    {
                        myModel.SaveChanges();
                        MessageBox.Show("Reservation updated.");
                    }
                    catch (Exception exception)
                    {
                        if (exception.Source != null)
                            MessageBox.Show(exception.StackTrace);

                    }
                }
                } else
                {
                    MessageBox.Show("Invalid reservation id!");
                }
            //}
        }
    }
}
