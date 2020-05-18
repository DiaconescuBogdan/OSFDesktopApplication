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
using OSFProject.Entities;

namespace OSFProject
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
           
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(var MyModelEntities = new MyCustomerModel())
            {
                dataGridView1.DataSource = MyModelEntities.Customers.ToList();
            }
     
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            MenuScreen menu = new MenuScreen();
            menu.Show();
        }
    }
}
