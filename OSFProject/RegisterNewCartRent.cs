
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSFProject
{
    public partial class RegisterNewCartRent : Form
    {
        public Entities.Reservation reservation = new Entities.Reservation();
        public Entities.Car car = new Entities.Car();
        public Entities.Customer customer = new Entities.Customer();
        public Entities.ReservationStatus reservationStatus = new Entities.ReservationStatus();
        //public Entities.Coupon coupon = new Entities.Coupon();

        public Entities.MyModel myModel = new Entities.MyModel();
        public Entities.MyCustomerModel customerModel = new Entities.MyCustomerModel();
        
        public RegisterNewCartRent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string location = textCity.Text;
            string plate = textCartPlate.Text;
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

                    
                        reservationStatus = myModel.ReservationStatuses.Where(r => r.ReservStatsID == 1).FirstOrDefault();
                        //coupon = myModel.Coupons.Where(c => c.CouponCode == "0I0J93K").FirstOrDefault();

                        reservation.ReservationStatus = reservationStatus;
                        //reservation.CouponCode = coupon.CouponCode;


                        myModel.Reservations.Add(reservation);
                        myModel.SaveChanges();
                        MessageBox.Show("Reservation added.");

                    }else
                    {
                        MessageBox.Show("Invalid dates");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid customer id!");
                }
            }
            else
            {
                MessageBox.Show("Invalid car plate or location!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }
    }
}
