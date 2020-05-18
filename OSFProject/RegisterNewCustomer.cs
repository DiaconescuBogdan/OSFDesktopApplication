using OSFProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSFProject
{
    public partial class RegisterNewCustomer : Form
    {
        public Entities.Customer customer = new Entities.Customer();
        public string conString = @"Data Source=(localdb)\MSSQLLocalDB;initial catalog = OSFAcademy; integrated security = True";
        public RegisterNewCustomer()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }

        private void RegisterNewCustomer_Load(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    string q = "insert into Customers values (@ClientName,@BirthDate,@Location)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    
                    cmd.Parameters.AddWithValue("@ClientName", textClientName.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Location", textLocation.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added.");
                    Hide();
                    MenuScreen menu = new MenuScreen();
                    menu.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveModels_Click(object sender, EventArgs e)
        {
            customer.Name = textClientName.Text;
            customer.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
            customer.Location = textLocation.Text;

            using (var customerModel = new MyCustomerModel())
            {
                customerModel.Customers.Add(customer);
                customerModel.SaveChanges();
                MessageBox.Show("Customer added.");
            }

        }
    }
    
}
