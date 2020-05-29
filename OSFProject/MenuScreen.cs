using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSFProject
{
    public partial class MenuScreen : Form
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterNewCustomer rc = new RegisterNewCustomer();
            rc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerList cl = new CustomerList();
            cl.Show();
        }

        private void btnRegisterCR_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterNewCartRent cr = new RegisterNewCartRent();
            cr.Show();
        }

        private void btnUpdateCR_Click(object sender, EventArgs e)
        {
            Hide();
            UpdateCartRent cr = new UpdateCartRent();
            cr.Show();
        }

        private void btnListRents_Click(object sender, EventArgs e)
        {
            Hide();
            RentList rl = new RentList();
            rl.Show();
        }

        private void btnAvailableCars_Click(object sender, EventArgs e)
        {
            Hide();
            AvailableCarsList ac = new AvailableCarsList();
            ac.Show();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            Hide();
            UpdateCustomer uc = new UpdateCustomer();
            uc.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
        private void checkReservationStatus()
        {

        }
    }
}
