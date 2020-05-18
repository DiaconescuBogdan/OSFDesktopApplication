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
            //using (var customerModel = new MyCustomerModel())
            //{
            //    customerModel.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            //    int customerId = Convert.ToInt32(textClientId.Text);

            //    if (customerModel.Customers.Where(c => c.CostumerID == customerId).FirstOrDefault() != null)
            //    {
                    
            //        //customer.CostumerID = customerId;
            //        customer.Name = textClientName.Text;
            //        customer.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
            //        customer.Location = textLocation.Text;

            //        customerModel.SaveChanges();
            //        MessageBox.Show("Customer updated.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid CustomerID!");
            //    }
            //}
























            customer.CostumerID = Convert.ToInt32(textClientId.Text);
            customer.Name = textClientName.Text;
            customer.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
            customer.Location = textLocation.Text;

            using (var customerModel = new MyCustomerModel())
            {
                customerModel.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    customerModel.SaveChanges();
                    MessageBox.Show("Customer updated.");
                }
                catch (Exception exception)
                {
                    if (exception.Source != null)
                        MessageBox.Show("IOException source: {0}", exception.Source);

                }

            }

        }
    }
}
