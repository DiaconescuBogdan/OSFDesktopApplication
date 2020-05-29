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
    public partial class UpdateCustomer : Form
    {
        public Entities.MyCustomerModel customerModel = new Entities.MyCustomerModel();
        public Entities.Customer customer = new Entities.Customer();
        public string conString = @"Data Source=(localdb)\MSSQLLocalDB;initial catalog = OSFAcademy; integrated security = True";
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    string q = "UPDATE Customers SET Name=@a2,BirthDate=@a3,Location=@a4 WHERE CostumerID=@a1";
                    SqlCommand cmd = new SqlCommand(q, con);


                    cmd.Parameters.AddWithValue("@a1", textClientId.Text);
                    cmd.Parameters.AddWithValue("@a2", textClientName.Text);
                    cmd.Parameters.AddWithValue("@a3", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@a4", textLocation.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfuly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateModels_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(textClientId.Text);

            if (customerModel.Customers.Where(r => r.CostumerID == customerID).FirstOrDefault() != null)
            {
                customer.CostumerID = customerModel.Customers.Where(c => c.CostumerID == customerID).FirstOrDefault().CostumerID;
                customer.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
                customer.Location = textLocation.Text;
                customer.Name = textClientName.Text;

                using (var customerModel = new MyCustomerModel())
                {
                    customerModel.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    
                        customerModel.SaveChanges();
                        MessageBox.Show("Customer updated.");                 
                }

            }
            else
            {
                MessageBox.Show("Please insert valid customer ID");
            }
        }
    }
}
