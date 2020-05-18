namespace OSFProject
{
    partial class MenuScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegisterCR = new System.Windows.Forms.Button();
            this.btnUpdateCR = new System.Windows.Forms.Button();
            this.btnListRents = new System.Windows.Forms.Button();
            this.btnAvailableCars = new System.Windows.Forms.Button();
            this.btnRegisterCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnListCustomers = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegisterCR
            // 
            this.btnRegisterCR.Location = new System.Drawing.Point(56, 27);
            this.btnRegisterCR.Name = "btnRegisterCR";
            this.btnRegisterCR.Size = new System.Drawing.Size(176, 51);
            this.btnRegisterCR.TabIndex = 0;
            this.btnRegisterCR.Text = "Register New Cart Rent";
            this.btnRegisterCR.UseVisualStyleBackColor = true;
            this.btnRegisterCR.Click += new System.EventHandler(this.btnRegisterCR_Click);
            // 
            // btnUpdateCR
            // 
            this.btnUpdateCR.Location = new System.Drawing.Point(56, 84);
            this.btnUpdateCR.Name = "btnUpdateCR";
            this.btnUpdateCR.Size = new System.Drawing.Size(176, 42);
            this.btnUpdateCR.TabIndex = 1;
            this.btnUpdateCR.Text = "Update Car Rent";
            this.btnUpdateCR.UseVisualStyleBackColor = true;
            this.btnUpdateCR.Click += new System.EventHandler(this.btnUpdateCR_Click);
            // 
            // btnListRents
            // 
            this.btnListRents.Location = new System.Drawing.Point(56, 132);
            this.btnListRents.Name = "btnListRents";
            this.btnListRents.Size = new System.Drawing.Size(176, 49);
            this.btnListRents.TabIndex = 2;
            this.btnListRents.Text = "List Rents";
            this.btnListRents.UseVisualStyleBackColor = true;
            this.btnListRents.Click += new System.EventHandler(this.btnListRents_Click);
            // 
            // btnAvailableCars
            // 
            this.btnAvailableCars.Location = new System.Drawing.Point(56, 187);
            this.btnAvailableCars.Name = "btnAvailableCars";
            this.btnAvailableCars.Size = new System.Drawing.Size(176, 44);
            this.btnAvailableCars.TabIndex = 3;
            this.btnAvailableCars.Text = "List Available Cars";
            this.btnAvailableCars.UseVisualStyleBackColor = true;
            this.btnAvailableCars.Click += new System.EventHandler(this.btnAvailableCars_Click);
            // 
            // btnRegisterCustomer
            // 
            this.btnRegisterCustomer.Location = new System.Drawing.Point(56, 237);
            this.btnRegisterCustomer.Name = "btnRegisterCustomer";
            this.btnRegisterCustomer.Size = new System.Drawing.Size(176, 46);
            this.btnRegisterCustomer.TabIndex = 4;
            this.btnRegisterCustomer.Text = "Register New Customer";
            this.btnRegisterCustomer.UseVisualStyleBackColor = true;
            this.btnRegisterCustomer.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(56, 289);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(176, 46);
            this.btnUpdateCustomer.TabIndex = 5;
            this.btnUpdateCustomer.Text = "Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnListCustomers
            // 
            this.btnListCustomers.Location = new System.Drawing.Point(56, 341);
            this.btnListCustomers.Name = "btnListCustomers";
            this.btnListCustomers.Size = new System.Drawing.Size(176, 49);
            this.btnListCustomers.TabIndex = 6;
            this.btnListCustomers.Text = "List Customers";
            this.btnListCustomers.UseVisualStyleBackColor = true;
            this.btnListCustomers.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(56, 396);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(176, 42);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnListCustomers);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnRegisterCustomer);
            this.Controls.Add(this.btnAvailableCars);
            this.Controls.Add(this.btnListRents);
            this.Controls.Add(this.btnUpdateCR);
            this.Controls.Add(this.btnRegisterCR);
            this.Name = "MenuScreen";
            this.Text = "MenuScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterCR;
        private System.Windows.Forms.Button btnUpdateCR;
        private System.Windows.Forms.Button btnListRents;
        private System.Windows.Forms.Button btnAvailableCars;
        private System.Windows.Forms.Button btnRegisterCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnListCustomers;
        private System.Windows.Forms.Button btnQuit;
    }
}