﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public class BaseForm
    {

    }
}*/
using System;
//using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public partial class BaseForm : Form
    {
        protected string connectionString = "server=localhost;uid=root;pwd=W#0324@aleed;database=loginids";
        protected string connectionString2 = "server=localhost;uid=root;pwd=W#0324@aleed;database=loginids";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        protected MySqlConnection GetConnection2()
        {
            return new MySqlConnection(connectionString2);
        }

        protected void ShowForm(Form form)
        {
            form.Show();
        }
    }
}

