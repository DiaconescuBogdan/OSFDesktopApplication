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
        
            string location = textCity.Text;
            string plate = textCartPlate.Text;
            int reservId = Convert.ToInt32(textReservationID.Text);

            if (myModel.Reservations.Where(r => r.ReservationID == reservId).FirstOrDefault() != null)
            {
                reservation.ReservationID = myModel.Reservations.Where(c => c.ReservationID == reservId).FirstOrDefault().ReservationID;


                if (myModel.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault() != null)
                {
                    car = myModel.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault();
                    reservation.CarID = car.CarID;
                    reservation.Location = car.Location;

                    int customerID = Convert.ToInt32(textClientID.Text);
                    if (customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault() != null)
                    {
                        customer = customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault();
                        reservation.CostumerID = customer.CostumerID;

                        reservation.StartDate = Convert.ToDateTime(dtStartDate.Text);
                        reservation.EndDate = Convert.ToDateTime(dtEndDate.Text);

                        if ((reservation.StartDate <= reservation.EndDate) && (reservation.StartDate >= DateTime.Now))
                        {
                            if ((myModel.Reservations.Where(c => (c.EndDate < reservation.StartDate || c.StartDate > reservation.EndDate)
                            && c.ReservationID != reservation.ReservationID).Any()) ||
                            (myModel.Reservations.Where(c => c.ReservationID == reservation.ReservationID).Any()))
                            {
                                using (var MyDbEntities = new MyModel())
                                {

                                    MyDbEntities.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                                    MyDbEntities.SaveChanges();
                                    MessageBox.Show("Reservation updated.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is another reservation in this period");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert valid dates");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please insert a valid Customer Id");

                    }
                }
                else
                {
                    MessageBox.Show("Invalid car plate or location!");

                }
            }
            else
            {
                MessageBox.Show("Please insert valid reservation ID");
            }
        }
    }
}






//string location = textCity.Text;
//string plate = textCartPlate.Text;
//int reservId = Convert.ToInt32(textReservationID.Text);
////reservation = myModel.Reservations.Where(c => c.ReservationID == reservId).FirstOrDefault();
//reservation.ReservationID = myModel.Reservations.Where(c => c.ReservationID == reservId).FirstOrDefault().ReservationID;
//reservation.ReservationStatus = null;
//if (myModel.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault() != null)
//{
//    car = myModel.Cars.Where(c => c.Plate == plate && c.Location == location).FirstOrDefault();
//    reservation.CarID = car.CarID;
//    //reservation.Plate = MyCar.Plate;
//    reservation.Location = car.Location;
//}
//else
//{
//    MessageBox.Show("Invalid car plate or location!");
//    //this.Hide();
//    //RegisterNewCar registerNewCar = new RegisterNewCar();
//    //registerNewCar.ShowDialog();
//    //this.Close();
//}
//int customerID = Convert.ToInt32(textClientID.Text);
//if (customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault() != null)
//{
//    customer = customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault();
//    reservation.CostumerID = customer.CostumerID;
//}
//else
//{
//    MessageBox.Show("Please insert a valid Customer Id");

//}
//reservation.StartDate = Convert.ToDateTime(dtStartDate.Text);
//reservation.EndDate = Convert.ToDateTime(dtEndDate.Text);
//using (var MyDbEntities = new MyModel())
//{
//    if ((reservation.StartDate <= reservation.EndDate) && (reservation.StartDate >= DateTime.Now))
//    {
//        if ((myModel.Reservations.Where(c => (c.EndDate < reservation.StartDate || c.StartDate > reservation.EndDate)
//        && c.ReservationID != reservation.ReservationID).Any()) ||
//        (myModel.Reservations.Where(c => c.ReservationID == reservation.ReservationID).Any()))
//        {
//            MyDbEntities.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
//            try
//            {
//                MyDbEntities.SaveChanges();
//                MessageBox.Show("Reservation updated.");
//            }
//            catch (Exception exception)
//            {
//                if (exception.Source != null)
//                    MessageBox.Show("IOException source: {0}", exception.Source);

//            }

//            //this.Hide();
//            //Menu menu = new Menu();
//            //menu.ShowDialog();
//            //this.Close();
//        }
//        else
//        {
//            MessageBox.Show("Please insert valid dates");
//            //this.Hide();
//            //UpdateCarRental updateCarRental = new UpdateCarRental();
//            //updateCarRental.ShowDialog();
//            //this.Close();
//        }
//    }

//}






